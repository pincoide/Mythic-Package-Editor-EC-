using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

using Mythic.Package;

namespace Mythic.Package.Spy
{
	public abstract class BaseSpy : IDisposable
	{
		#region Properties
		private static readonly byte[] BreakCode = { 0xCC };
		private Dictionary<uint, byte[]> m_Dictionary;

		private Process m_Process;
		private IntPtr m_ProcessHandle;
		private NativeMethods.DEBUG_EVENT_EXCEPTION m_EventBuffer;
		private ManualResetEvent m_Stopped;
		
		private bool m_ToStop;

		private bool SafeToStop
		{
			get	{ lock ( this ) return m_ToStop; }
			set	{ lock ( this )	m_ToStop = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public BaseSpy()
		{
			m_ContextBuffer = new NativeMethods.CONTEXT();
			m_ContextBuffer.ContextFlags = NativeMethods.ContextFlags.CONTEXT_CONTROL | NativeMethods.ContextFlags.CONTEXT_INTEGER;
			m_EventBuffer = new NativeMethods.DEBUG_EVENT_EXCEPTION();

			m_ToStop = false;
			m_Stopped = new ManualResetEvent( true );

			m_Dictionary = new Dictionary<uint, byte[]>();
		}
		#endregion

		#region Init
		/// <summary>
		/// Initializes a spy from an executable file. 
		/// </summary>
		/// <param name="path">Path to executable file.</param>
		public void Init( string path )
		{
			string pathDir = Path.GetDirectoryName( path );

			NativeMethods.STARTUPINFO startupInfo = new NativeMethods.STARTUPINFO();
			NativeMethods.PROCESS_INFORMATION processInfo;

			if ( !NativeMethods.CreateProcess( path, null, IntPtr.Zero, IntPtr.Zero, false,
				NativeMethods.CreationFlag.DEBUG_PROCESS, IntPtr.Zero, pathDir, ref startupInfo, out processInfo ) )
				throw new Win32Exception();

			NativeMethods.CloseHandle( processInfo.hThread );

			m_Process = Process.GetProcessById( (int) processInfo.dwProcessId );
			m_ProcessHandle = processInfo.hProcess;

			InitBreakpoints();
		}

		/// <summary>
		/// Initializes a spy from existing process.
		/// </summary>
		/// <param name="process">Reference to existing process.</param>
		public void Init( Process process )
		{
			uint id = (uint)process.Id;

			m_Process = process;
			m_ProcessHandle = NativeMethods.OpenProcess( NativeMethods.DesiredAccessProcess.PROCESS_ALL_ACCESS, false, id );

			if ( m_ProcessHandle == IntPtr.Zero )
				throw new Win32Exception();

			if ( !NativeMethods.DebugActiveProcess( id ) )
				throw new Win32Exception();

			InitBreakpoints();
		}
		#endregion

		#region Breakpoints
		protected NativeMethods.CONTEXT m_ContextBuffer;

		/// <summary>
		/// Initializes breakpoints.
		/// </summary>
		protected virtual void InitBreakpoints()
		{

		}

		/// <summary>
		/// Adds a new breakpoint at specified address.
		/// </summary>
		/// <param name="address">Address of the breakpoint.</param>
		protected void AddBreakpoint( uint address )
		{
			m_Dictionary.Add( address, ReadProcessMemory( address, 1 ) );

			WriteProcessMemory( address, BreakCode );
		}

		/// <summary>
		/// Removes all breakpoints.
		/// </summary>
		protected void RemoveBreakpoints()
		{
			foreach ( KeyValuePair<uint, byte[]> kvp in m_Dictionary )
				WriteProcessMemory( kvp.Key, kvp.Value );

			m_Dictionary.Clear();
		}
		#endregion

		#region MainLoop
		/// <summary>
		/// Starts to spy.
		/// </summary>
		public void MainLoop()
		{
			m_Stopped.Reset();

			uint address;
			IntPtr hThread;

			try
			{
				while ( !SafeToStop && !m_Process.HasExited )
				{
					if ( NativeMethods.WaitForDebugEvent( ref m_EventBuffer, 1000 ) )
					{
						if ( m_EventBuffer.dwDebugEventCode == NativeMethods.DebugEventCode.EXCEPTION_DEBUG_EVENT )
						{
							address = (uint) m_EventBuffer.u.Exception.ExceptionRecord.ExceptionAddress.ToInt32();
							
							if ( m_Dictionary.ContainsKey( address ) )
							{
								hThread = NativeMethods.OpenThread( NativeMethods.DesiredAccessThread.THREAD_GET_CONTEXT | NativeMethods.DesiredAccessThread.THREAD_SET_CONTEXT, false, m_EventBuffer.dwThreadId );

								GetThreadContext( hThread, ref m_ContextBuffer );

								OnSpyAddress( address );
								
								WriteProcessMemory( address, m_Dictionary[ address ] );

								m_ContextBuffer.Eip--;
								m_ContextBuffer.EFlags |= 0x100; // Single step

								SetThreadContext( hThread, ref m_ContextBuffer );
								ContinueDebugEvent( m_EventBuffer.dwThreadId );

								if ( !NativeMethods.WaitForDebugEvent( ref m_EventBuffer, uint.MaxValue ) )
									throw new Win32Exception();
								
								WriteProcessMemory( address, BreakCode );
								GetThreadContext( hThread, ref m_ContextBuffer );
								m_ContextBuffer.EFlags &= ~0x100u; // End single step
								SetThreadContext( hThread, ref m_ContextBuffer );

								NativeMethods.CloseHandle( hThread );
                            }
						}

						ContinueDebugEvent( m_EventBuffer.dwThreadId );
					}
				}
			}
			finally
			{
				EndSpy();
			}
		}
		#endregion

		#region OnSpyAddress
		/// <summary>
		/// Invoked when execution is suspended at a breakpoint.
		/// </summary>
		/// <param name="address">Address of the breakpoint.</param>
		protected virtual void OnSpyAddress( uint address )
		{
		}
		#endregion

		#region ReadProcessMemory
		/// <summary>
		/// Reads data from an area of memory in a specified process.
		/// </summary>
		/// <param name="address">A pointer to the base address in the specified process from which to read.</param>
		/// <param name="length">The number of bytes to be read from the specified process.</param>
		/// <returns>Buffer that receives the contents from the address space of the specified process.</returns>
		protected byte[] ReadProcessMemory( uint address, uint length )
		{
			byte[] buffer = new byte[ length ];

			if ( address < Int32.MaxValue )
			{
				IntPtr ptrAddr = new IntPtr( address );

				uint read = 0;
				
				NativeMethods.ReadProcessMemory( m_ProcessHandle, ptrAddr, buffer, length, out read );

				if ( read != length )
					throw new Win32Exception( String.Format( "Read data length doesn't match requested: {0}/{1}!", read, length ) );
			}

			return buffer;
		}
		#endregion

		#region WriteProcessMemory
		/// <summary>
		/// Writes data to an area of memory in a specified process.
		/// </summary>
		/// <param name="address">A pointer to the base address in the specified process to which data is written.</param>
		/// <param name="data">Buffer that contains data to be written in the address space of the specified process.</param>
		protected void WriteProcessMemory( uint address, byte[] data )
		{
			uint length = (uint)data.Length;
			IntPtr ptrAddr = new IntPtr( address );

			uint written;
			NativeMethods.WriteProcessMemory( m_ProcessHandle, ptrAddr, data, length, out written );
			
			if ( written != length )
				throw new Win32Exception();

			NativeMethods.FlushInstructionCache( m_ProcessHandle, ptrAddr, length );
		}
		#endregion

		#region Private
		private void ContinueDebugEvent( uint threadId )
		{
			if ( !NativeMethods.ContinueDebugEvent( (uint)m_Process.Id, threadId, NativeMethods.ContinueStatus.DBG_CONTINUE ) )
				throw new Win32Exception();
		}

		private void GetThreadContext( IntPtr hThread, ref NativeMethods.CONTEXT context )
		{
			if ( !NativeMethods.GetThreadContext( hThread, ref context ) )
				throw new Win32Exception();
		}

		private void SetThreadContext( IntPtr hThread, ref NativeMethods.CONTEXT context )
		{
			if ( !NativeMethods.SetThreadContext( hThread, ref context ) )
				throw new Win32Exception();
		}

		public void EndSpy()
		{
			try
			{
				RemoveBreakpoints();
				NativeMethods.DebugActiveProcessStop( (uint)m_Process.Id );
				NativeMethods.CloseHandle( m_ProcessHandle );
			}
			catch { }

			m_Stopped.Set();
			SafeToStop = true;
		}
		#endregion

		#region IDisposable
		public void Dispose()
		{
			if ( !SafeToStop )
			{
				SafeToStop = true;

				m_Stopped.WaitOne();
				m_Stopped.Close();
			}
		}
		#endregion
	}
}