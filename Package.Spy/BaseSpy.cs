using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Mythic.Package.Spy
{
    /// <summary>
    /// Class for spying the client file access and discover hashed file names.
    /// </summary>
    public abstract class BaseSpy : IDisposable
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC
        // --------------------------------------------------------------

        /// <summary>
        /// code used to detect breakpoints
        /// </summary>
        private static readonly byte[] BreakCode = { 0xCC };

        #endregion

        /// <summary>
        /// dictionary used for mapping the memory address of the breakpoints
        /// </summary>
        private readonly Dictionary<uint, byte[]> m_Dictionary;

        /// <summary>
        /// the process we're monitoring
        /// </summary>
        private Process m_Process;

        /// <summary>
        /// pointer for the process we're monitoring
        /// </summary>
        private IntPtr m_ProcessHandle;

        /// <summary>
        /// recorded events buffer
        /// </summary>
        private NativeMethods.DEBUG_EVENT_EXCEPTION m_EventBuffer;

        /// <summary>
        /// event context buffer
        /// </summary>
        private protected NativeMethods.CONTEXT m_ContextBuffer;

        /// <summary>
        /// stop recording event handler
        /// </summary>
        private readonly ManualResetEvent m_Stopped;

        private bool m_ToStop;

        /// <summary>
        /// stop recording flag (triggered when the user manually detach the process)
        /// </summary>
        private bool SafeToStop
        {
            get { lock ( this ) return m_ToStop; }
            set { lock ( this ) m_ToStop = value; }
        }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public BaseSpy()
        {
            // initialize the context buffer
            m_ContextBuffer = new NativeMethods.CONTEXT
            {
                ContextFlags = NativeMethods.ContextFlags.CONTEXT_CONTROL | NativeMethods.ContextFlags.CONTEXT_INTEGER
            };

            // initialize the event buffer
            m_EventBuffer = new NativeMethods.DEBUG_EVENT_EXCEPTION();

            // reset the stop flags
            m_ToStop = false;
            m_Stopped = new ManualResetEvent( true );

            // initialize the data dictionary
            m_Dictionary = new Dictionary<uint, byte[]>();
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a spy from an executable file.
        /// </summary>
        /// <param name="fileName">Path to executable file.</param>
        public void Init( string fileName )
        {
            // reset the safe to stop flag
            SafeToStop = false;

            // make sure the dictionary is empty before we start
            m_Dictionary.Clear();

            // if the file doesn't exist, throw an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // get the executable path
            string pathDir = Path.GetDirectoryName( fileName );

            // create a temporary startup info events tracker
            NativeMethods.STARTUPINFO startupInfo = new NativeMethods.STARTUPINFO();

            // try to create the process, if it fails, throws an exception
            if ( !NativeMethods.CreateProcess( fileName, null, IntPtr.Zero, IntPtr.Zero, false, NativeMethods.CreationFlag.DEBUG_PROCESS, IntPtr.Zero, pathDir, ref startupInfo, out NativeMethods.PROCESS_INFORMATION processInfo ) )
                throw new Win32Exception();

            // get the thread process data
            NativeMethods.CloseHandle( processInfo.hThread );

            // get the process
            m_Process = Process.GetProcessById( (int)processInfo.dwProcessId );

            // get the process handle
            m_ProcessHandle = processInfo.hProcess;

            // initialize the breakpoints
            InitBreakpoints();
        }

        /// <summary>
        /// Attach the spy to an existing process.
        /// </summary>
        /// <param name="process">Reference to existing process.</param>
        public void Init( Process process )
        {
            // no process? throw an exception
            if ( process == null )
                throw new ArgumentNullException( "process" );

            // reset the safe to stop flag
            SafeToStop = false;

            // get the process ID
            uint id = (uint)process.Id;

            // store the procress
            m_Process = process;

            // get the process pointer
            m_ProcessHandle = NativeMethods.OpenProcess( NativeMethods.DesiredAccessProcess.PROCESS_ALL_ACCESS, false, id );

            // is the pointer 0? throw an exception
            if ( m_ProcessHandle == IntPtr.Zero )
                throw new Win32Exception();

            // is the process inactive? throw an exception
            if ( !NativeMethods.DebugActiveProcess( id ) )
                throw new Win32Exception();

            // initialize the breakpoints
            InitBreakpoints();
        }

        /// <summary>
        /// Main spying loop
        /// </summary>
        public void MainLoop()
        {
            // reset the stop event
            m_Stopped.Reset();

            try
            {
                // loop until the spying has been stopped by the user or the process ended
                while ( !SafeToStop && !m_Process.HasExited )
                {
                    // wait for something to happen
                    if ( NativeMethods.WaitForDebugEvent( ref m_EventBuffer, 1000 ) )
                    {
                        // did we find somthing of interest?
                        if ( m_EventBuffer.dwDebugEventCode == NativeMethods.DebugEventCode.EXCEPTION_DEBUG_EVENT )
                        {
                            // get the memory address of the event
                            uint address = (uint)m_EventBuffer.u.Exception.ExceptionRecord.ExceptionAddress.ToInt32();

                            // is the event inside the dictionary?
                            if ( m_Dictionary.ContainsKey( address ) )
                            {
                                // get the thread pointer
                                IntPtr hThread = NativeMethods.OpenThread( NativeMethods.DesiredAccessThread.THREAD_GET_CONTEXT | NativeMethods.DesiredAccessThread.THREAD_SET_CONTEXT, false, m_EventBuffer.dwThreadId );

                                // get the thread context
                                GetThreadContext( hThread, ref m_ContextBuffer );

                                // spy on the event
                                OnSpyAddress( address );

                                // store the event in the dictionary
                                WriteProcessMemory( address, m_Dictionary[address] );

                                // do a single step
                                m_ContextBuffer.Eip--;
                                m_ContextBuffer.EFlags |= 0x100; // Single step

                                // update the thread context
                                SetThreadContext( hThread, ref m_ContextBuffer );

                                // progress to the next event
                                ContinueDebugEvent( m_EventBuffer.dwThreadId );

                                // can't get any more events? throw an exception
                                if ( !NativeMethods.WaitForDebugEvent( ref m_EventBuffer, uint.MaxValue ) )
                                    throw new Win32Exception();

                                // write a break in the process
                                WriteProcessMemory( address, BreakCode );

                                // update the thread context
                                GetThreadContext( hThread, ref m_ContextBuffer );

                                // return to the previous position
                                m_ContextBuffer.EFlags &= ~0x100u; // End single step

                                // update the thread context
                                SetThreadContext( hThread, ref m_ContextBuffer );

                                // close this event
                                NativeMethods.CloseHandle( hThread );
                            }
                        }
                        // wait for the next event
                        ContinueDebugEvent( m_EventBuffer.dwThreadId );
                    }
                }
            }
            finally
            {
                // terminate the spying session
                EndSpy();
            }
        }

        /// <summary>
        /// Terminate the spying session
        /// </summary>
        public void EndSpy()
        {
            try
            {
                // remove all breaking points
                RemoveBreakpoints();

                // detach from the process
                NativeMethods.DebugActiveProcessStop( (uint)m_Process.Id );

                // close the current event
                NativeMethods.CloseHandle( m_ProcessHandle );
            }
            catch { }

            // trigger the stop process for the main loop
            m_Stopped.Set();
            SafeToStop = true;
        }

        /// <summary>
        /// Dispose the spying object
        /// </summary>
        public void Dispose()
        {
            // is the spying still in progress?
            if ( !SafeToStop )
            {
                // stop the spying process
                SafeToStop = true;

                // detach from the process
                m_Stopped.WaitOne();
                m_Stopped.Close();
            }
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes breakpoints.
        /// </summary>
        private protected virtual void InitBreakpoints()
        {
        }

        /// <summary>
        /// Adds a new breakpoint at specified address.
        /// </summary>
        /// <param name="address">Address of the breakpoint.</param>
        private protected void AddBreakpoint( uint address )
        {
            // add the breakpoint to the dictioanry
            m_Dictionary.Add( address, ReadProcessMemory( address, 1 ) );

            // write the break code in the process
            WriteProcessMemory( address, BreakCode );
        }

        /// <summary>
        /// Removes all breakpoints.
        /// </summary>
        private protected void RemoveBreakpoints()
        {
            // remove all saved breakpoints
            foreach ( KeyValuePair<uint, byte[]> kvp in m_Dictionary )
                WriteProcessMemory( kvp.Key, kvp.Value );

            // clear the dictionary
            m_Dictionary.Clear();
        }

        /// <summary>
        /// Invoked when execution is suspended at a breakpoint.
        /// </summary>
        /// <param name="address">Address of the breakpoint.</param>
        private protected virtual void OnSpyAddress( uint address )
        {
        }

        /// <summary>
        /// Reads data from an area of memory in a specified process.
        /// </summary>
        /// <param name="address">A pointer to the base address in the specified process from which to read.</param>
        /// <param name="length">The number of bytes to be read from the specified process.</param>
        /// <returns>Buffer that receives the contents from the address space of the specified process.</returns>
        private protected byte[] ReadProcessMemory( uint address, uint length )
        {
            // initialize the byte buffer to store the data
            byte[] buffer = new byte[length];

            // is this a valid address?
            if ( address < int.MaxValue )
            {
                // create a pointer to the given address
                IntPtr ptrAddr = new IntPtr( address );

                // read the data at the given address
                NativeMethods.ReadProcessMemory( m_ProcessHandle, ptrAddr, buffer, length, out uint read );

                // did we read more (or less) data than we were supposed to? throw an exception
                if ( read != length )
                    throw new Win32Exception( string.Format( "Read data length doesn't match requested: {0}/{1}!", read, length ) );
            }

            return buffer;
        }

        /// <summary>
        /// Writes data to an area of memory in a specified process.
        /// </summary>
        /// <param name="address">A pointer to the base address in the specified process to which data is written.</param>
        /// <param name="data">Buffer that contains data to be written in the address space of the specified process.</param>
        private protected void WriteProcessMemory( uint address, byte[] data )
        {
            // get the data length
            uint length = (uint)data.Length;

            // create a pointer to the given address
            IntPtr ptrAddr = new IntPtr( address );

            // write the data into the given memory address
            NativeMethods.WriteProcessMemory( m_ProcessHandle, ptrAddr, data, length, out uint written );

            // get the status of the operation
            Win32Exception w = new Win32Exception();

            // if the result is anything but "operation successfull" (0), we throw an exception
            if ( w.NativeErrorCode != 0 && written != length )
                throw w;

            // flush the data
            NativeMethods.FlushInstructionCache( m_ProcessHandle, ptrAddr, length );
        }

        /// <summary>
        /// Progress in the scanning of the process events
        /// </summary>
        /// <param name="threadId">Current process thread</param>
        private void ContinueDebugEvent( uint threadId )
        {
            // keep scanning the process events. If it's impossible we throw an exception
            if ( !NativeMethods.ContinueDebugEvent( (uint)m_Process.Id, threadId, NativeMethods.ContinueStatus.DBG_CONTINUE ) )
                throw new Win32Exception();
        }

        /// <summary>
        /// Retrieve the thread context event
        /// </summary>
        /// <param name="threadId">Current process thread</param>
        /// <param name="context">Thread context to return</param>
        private void GetThreadContext( IntPtr hThread, ref NativeMethods.CONTEXT context )
        {
            // get the thread context. If it fails, we throw an exception
            if ( !NativeMethods.GetThreadContext( hThread, ref context ) )
                throw new Win32Exception();
        }

        /// <summary>
        /// Set the thread context event
        /// </summary>
        /// <param name="threadId">Current process thread</param>
        /// <param name="context">Context to set</param>
        private void SetThreadContext( IntPtr hThread, ref NativeMethods.CONTEXT context )
        {
            // set the context event. If it fails throw an exception
            if ( !NativeMethods.SetThreadContext( hThread, ref context ) )
                throw new Win32Exception();
        }

        #endregion
    }
}