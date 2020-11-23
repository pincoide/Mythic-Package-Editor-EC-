using System;
using System.Runtime.InteropServices;

namespace Mythic.Package.Spy
{
    public sealed class NativeMethods
    {
        /// <summary>
        /// Process information structure
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }

        /// <summary>
        /// process startup info
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct STARTUPINFO
        {
            public uint cb;
            [MarshalAs( UnmanagedType.LPTStr )]
            public string lpReserved;
            [MarshalAs( UnmanagedType.LPTStr )]
            public string lpDesktop;
            [MarshalAs( UnmanagedType.LPTStr )]
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public ushort wShowWindow;
            public ushort cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        /// <summary>
        /// Process creation flags
        /// </summary>
        [Flags]
        public enum CreationFlag : uint
        {
            DEBUG_PROCESS                       = 0x00000001,
            DEBUG_ONLY_THIS_PROCESS             = 0x00000002,

            CREATE_SUSPENDED                    = 0x00000004,

            DETACHED_PROCESS                    = 0x00000008,

            CREATE_NEW_CONSOLE                  = 0x00000010,

            NORMAL_PRIORITY_CLASS               = 0x00000020,
            IDLE_PRIORITY_CLASS                 = 0x00000040,
            HIGH_PRIORITY_CLASS                 = 0x00000080,
            REALTIME_PRIORITY_CLASS             = 0x00000100,

            CREATE_NEW_PROCESS_GROUP            = 0x00000200,
            CREATE_UNICODE_ENVIRONMENT          = 0x00000400,

            CREATE_SEPARATE_WOW_VDM             = 0x00000800,
            CREATE_SHARED_WOW_VDM               = 0x00001000,
            CREATE_FORCEDOS                     = 0x00002000,

            BELOW_NORMAL_PRIORITY_CLASS         = 0x00004000,
            ABOVE_NORMAL_PRIORITY_CLASS         = 0x00008000,
            STACK_SIZE_PARAM_IS_A_RESERVATION   = 0x00010000,

            CREATE_BREAKAWAY_FROM_JOB           = 0x01000000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL    = 0x02000000,

            CREATE_DEFAULT_ERROR_MODE           = 0x04000000,
            CREATE_NO_WINDOW                    = 0x08000000,

            PROFILE_USER                        = 0x10000000,
            PROFILE_KERNEL                      = 0x20000000,
            PROFILE_SERVER                      = 0x40000000,

            CREATE_IGNORE_SYSTEM_DEFAULT        = 0x80000000
        }

        /// <summary>
        /// Function used to create a new process
        /// </summary>
        /// <param name="lpApplicationName">name of the application</param>
        /// <param name="lpCommandLine">command line to execute</param>
        /// <param name="lpProcessAttributes">process attributes to use</param>
        /// <param name="lpThreadAttributes">thread attributes to use</param>
        /// <param name="bInheritHandles">does it inherits the handle?</param>
        /// <param name="dwCreationFlags">creation flags</param>
        /// <param name="lpEnvironment">environment pointer</param>
        /// <param name="lpCurrentDirectory">current directory</param>
        /// <param name="lpStartupInfo">startup info</param>
        /// <param name="lpProcessInformation">process info</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool CreateProcess
            (
            [MarshalAs( UnmanagedType.LPStr )] string lpApplicationName,
            [MarshalAs( UnmanagedType.LPStr )] string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            CreationFlag dwCreationFlags,
            IntPtr lpEnvironment,
            [MarshalAs( UnmanagedType.LPStr )] string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation
            );

        /// <summary>
        /// set active process to monitor
        /// </summary>
        /// <param name="dwProcessId">process ID</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool DebugActiveProcess( uint dwProcessId );

        /// <summary>
        /// detach from a process
        /// </summary>
        /// <param name="dwProcessId">process ID</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool DebugActiveProcessStop( uint dwProcessId );

        /// <summary>
        /// Process access flags
        /// </summary>
        [Flags]
        public enum DesiredAccessProcess : uint
        {
            PROCESS_TERMINATE           = 0x0001,
            PROCESS_CREATE_THREAD       = 0x0002,
            PROCESS_VM_OPERATION        = 0x0008,
            PROCESS_VM_READ             = 0x0010,
            PROCESS_VM_WRITE            = 0x0020,
            PROCESS_DUP_HANDLE          = 0x0040,
            PROCESS_CREATE_PROCESS      = 0x0080,
            PROCESS_SET_QUOTA           = 0x0100,
            PROCESS_SET_INFORMATION     = 0x0200,
            PROCESS_QUERY_INFORMATION   = 0x0400,
            SYNCHRONIZE                 = 0x00100000,
            PROCESS_ALL_ACCESS          = SYNCHRONIZE | 0xF0FFF
        }

        /// <summary>
        /// Access a process data
        /// </summary>
        /// <param name="dwDesiredAccess">process access flags</param>
        /// <param name="bInheritHandle">does the process inherits the handle?</param>
        /// <param name="dwProcessId">process ID</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern IntPtr OpenProcess( DesiredAccessProcess dwDesiredAccess, bool bInheritHandle, uint dwProcessId );

        /// <summary>
        /// Thread access flags
        /// </summary>
        [Flags]
        public enum DesiredAccessThread : uint
        {
            SYNCHRONIZE                 = 0x00100000,
            THREAD_TERMINATE            = 0x0001,
            THREAD_SUSPEND_RESUME       = 0x0002,
            THREAD_GET_CONTEXT          = 0x0008,
            THREAD_SET_CONTEXT          = 0x0010,
            THREAD_SET_INFORMATION      = 0x0020,
            THREAD_QUERY_INFORMATION    = 0x0040,
            THREAD_SET_THREAD_TOKEN     = 0x0080,
            THREAD_IMPERSONATE          = 0x0100,
            THREAD_DIRECT_IMPERSONATION = 0x0200,
            THREAD_ALL_ACCESS           = SYNCHRONIZE | 0xF03FF
        }

        /// <summary>
        /// Access a thread
        /// </summary>
        /// <param name="dwDesiredAccess">thread access flags</param>
        /// <param name="bInheritHandle">does the thread inherits the handle?</param>
        /// <param name="dwThreadId">thread ID</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern IntPtr OpenThread( DesiredAccessThread dwDesiredAccess, bool bInheritHandle, uint dwThreadId );

        /// <summary>
        /// Close the thread we were reading
        /// </summary>
        /// <param name="hObject">thread pointer</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool CloseHandle( IntPtr hObject );

        /// <summary>
        /// data reading flags
        /// </summary>
        public enum DebugEventCode : uint
        {
            EXCEPTION_DEBUG_EVENT           = 1,
            CREATE_THREAD_DEBUG_EVENT       = 2,
            CREATE_PROCESS_DEBUG_EVENT      = 3,
            EXIT_THREAD_DEBUG_EVENT         = 4,
            EXIT_PROCESS_DEBUG_EVENT        = 5,
            LOAD_DLL_DEBUG_EVENT            = 6,
            UNLOAD_DLL_DEBUG_EVENT          = 7,
            OUTPUT_DEBUG_STRING_EVENT       = 8,
            RIP_EVENT                       = 9
        }

        /// <summary>
        /// maximum number of parameters
        /// </summary>
        public const int EXCEPTION_MAXIMUM_PARAMETERS = 15;

        /// <summary>
        /// Data record struture
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct EXCEPTION_RECORD
        {
            public uint ExceptionCode;
            public uint ExceptionFlags;
            public IntPtr ExceptionRecord;
            public IntPtr ExceptionAddress;
            public uint NumberParameters;
            [MarshalAs( UnmanagedType.ByValArray, SizeConst = EXCEPTION_MAXIMUM_PARAMETERS)]
            public uint[] ExceptionInformation;
        }

        /// <summary>
        /// Data info structure
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct EXCEPTION_DEBUG_INFO
        {
            public EXCEPTION_RECORD ExceptionRecord;
            public uint dwFirstChance;
        }

        /// <summary>
        /// Data event structure
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct DEBUG_EVENT_EXCEPTION
        {
            public DebugEventCode dwDebugEventCode;
            public uint dwProcessId;
            public uint dwThreadId;

            [StructLayout( LayoutKind.Explicit )]
            public struct UnionException
            {
                [FieldOffset( 0 )]
                public EXCEPTION_DEBUG_INFO Exception;
            }
            public UnionException u;
        }

        /// <summary>
        /// wait for event
        /// </summary>
        /// <param name="lpDebugEvent">event we're waiting for</param>
        /// <param name="dwMilliseconds">how long do we have to wait? (in milliseconds)</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool WaitForDebugEvent( ref DEBUG_EVENT_EXCEPTION lpDebugEvent, uint dwMilliseconds );

        /// <summary>
        /// scan resume flags
        /// </summary>
        [Flags]
        public enum ContinueStatus : uint
        {
            DBG_CONTINUE                = 0x00010002,
            DBG_EXCEPTION_NOT_HANDLED   = 0x80010001
        }

        /// <summary>
        /// resume the scanning
        /// </summary>
        /// <param name="dwProcessId">process ID</param>
        /// <param name="dwThreadId">thread ID</param>
        /// <param name="dwContinueStatus">resume scan flags</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool ContinueDebugEvent( uint dwProcessId, uint dwThreadId, ContinueStatus dwContinueStatus );

        /// <summary>
        /// Read memory chunk
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool ReadProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesRead );

        /// <summary>
        /// Write in a chunk of memory
        /// </summary>
        /// <param name="hProcess">process pointer</param>
        /// <param name="lpBaseAddress">starting address</param>
        /// <param name="lpBuffer">byte array to write</param>
        /// <param name="nSize">data size</param>
        /// <param name="lpNumberOfBytesWritten">(output) number of bytes written</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool WriteProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten );

        /// <summary>
        /// Flush instructions queue
        /// </summary>
        /// <param name="hProcess">process pointer</param>
        /// <param name="lpBaseAddress">starting address</param>
        /// <param name="dwSize">memory area size</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool FlushInstructionCache( IntPtr hProcess, IntPtr lpBaseAddress, uint dwSize );

        /// <summary>
        /// Process context flags
        /// </summary>
        [Flags]
        public enum ContextFlags : uint
        {
            CONTEXT_i386 = 0x00010000,
            CONTEXT_i486 = 0x00010000,

            CONTEXT_CONTROL = CONTEXT_i386 | 0x00000001,
            CONTEXT_INTEGER = CONTEXT_i386 | 0x00000002,
            CONTEXT_SEGMENTS = CONTEXT_i386 | 0x00000004,
            CONTEXT_FLOATING_POINT = CONTEXT_i386 | 0x00000008,
            CONTEXT_DEBUG_REGISTERS = CONTEXT_i386 | 0x00000010,
            CONTEXT_EXTENDED_REGISTERS = CONTEXT_i386 | 0x00000020,

            CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS
        }

        /// <summary>
        /// Data saving structure
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct FLOATING_SAVE_AREA
        {
            public uint ControlWord;
            public uint StatusWord;
            public uint TagWord;
            public uint ErrorOffset;
            public uint ErrorSelector;
            public uint DataOffset;
            public uint DataSelector;
            [MarshalAs( UnmanagedType.ByValArray, SizeConst = 80 )]
            public byte[] RegisterArea;
            public uint Cr0NpxState;
        }

        /// <summary>
        /// Context storing structure
        /// </summary>
        [StructLayout( LayoutKind.Sequential )]
        public struct CONTEXT
        {
            public ContextFlags ContextFlags;

            public uint Dr0;
            public uint Dr1;
            public uint Dr2;
            public uint Dr3;
            public uint Dr6;
            public uint Dr7;

            public FLOATING_SAVE_AREA FloatSave;

            public uint SegGs;
            public uint SegFs;
            public uint SegEs;
            public uint SegDs;

            public uint Edi;
            public uint Esi;
            public uint Ebx;
            public uint Edx;
            public uint Ecx;
            public uint Eax;

            public uint Ebp;
            public uint Eip;
            public uint SegCs;
            public uint EFlags;
            public uint Esp;
            public uint SegSs;

            [MarshalAs( UnmanagedType.ByValArray, SizeConst = 512 )]
            public byte[] ExtendedRegisters;
        }

        /// <summary>
        /// Retrieve thread context
        /// </summary>
        /// <param name="hThread">thread pointer</param>
        /// <param name="lpContext">retrieved context values</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool GetThreadContext( IntPtr hThread, ref CONTEXT lpContext );

        /// <summary>
        /// Set thread context
        /// </summary>
        /// <param name="hThread">thread pointer</param>
        /// <param name="lpContext">context to set</param>
        /// <returns></returns>
        [DllImport( "Kernel32" )]
        public static extern bool SetThreadContext( IntPtr hThread, ref CONTEXT lpContext );
    }
}