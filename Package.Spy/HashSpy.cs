using System.Text;

namespace Mythic.Package.Spy
{
    /// <summary>
    /// Hash found function to be used to store the found file name
    /// </summary>
    /// <param name="hash">file hash</param>
    /// <param name="value">file name</param>
    public delegate void HashFound( ulong hash, string value );

    public class HashSpy : BaseSpy
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC
        // --------------------------------------------------------------

        /// <summary>
        /// byte to ascii encoder
        /// </summary>
        private static readonly ASCIIEncoding m_Encoding = new ASCIIEncoding();

        /// <summary>
        /// signature call used to find the files names
        /// </summary>
        private static readonly byte[] m_Signature = new byte[] { 0x59, 0x89, 0x44, 0x24, 0x10, 0x89, 0x54, 0x24, 0x14, 0xEB };

        #endregion

        /// <summary>
        /// starting address for the range to scan
        /// </summary>
        private const uint StartAddress = 0x500000; //0x665000;

        /// <summary>
        /// end address for the range to scan
        /// </summary>
        private const uint EndAddress = 0xAE5000; //0x8E5000;

        /// <summary>
        /// memory range to scan
        /// </summary>
        private const uint ScanRange = EndAddress - StartAddress;

        /// <summary>
        /// data buffer
        /// </summary>
        private byte[] m_Buffer;

        /// <summary>
        /// current address
        /// </summary>
        private uint m_Address;

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        // hash found main event
        public event HashFound HashFound;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Class used to spy hashes on memory areas of the client
        /// </summary>
        public HashSpy() : base()
        {
            // initialize the data buffer
            m_Buffer = new byte[ScanRange];
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region OVERRIDES
        // --------------------------------------------------------------

        /// <summary>
        /// initialize a breakpoint
        /// </summary>
        private protected override void InitBreakpoints()
        {
            // get the first breakpoint address
            m_Address = FindBreakPoint();

            // if we found no break points, we throw an exception
            if ( m_Address == 0 )
                throw new AddressNotFoundException();

            // add the breakpoint at the current address
            AddBreakpoint( m_Address );
        }

        /// <summary>
        /// Spy address event
        /// </summary>
        /// <param name="address"></param>
        private protected override void OnSpyAddress( uint address )
        {
            // read 256 bytes of the current context area
            byte[] data = ReadProcessMemory( m_ContextBuffer.Ecx, 256 );

            // initialize the data length
            int length = 0;

            // find the data
            for ( int i = 0; i < data.Length && length == 0; i++ )
                if ( data[i] == 0 )
                    length = i;

            // build the string of the file name
            string name = m_Encoding.GetString( data, 0, length );

            // get the file hash
            ulong hash = ( (ulong) m_ContextBuffer.Edx << 32 ) | m_ContextBuffer.Eax;

            // if we found the hash we store it into the dictionary
            HashFound?.Invoke( hash, name );
        }

        #endregion

        /// <summary>
        /// find the first break point in the memory area we are scanning
        /// </summary>
        /// <returns></returns>
        private uint FindBreakPoint()
        {
            // read the chunk of memory
            m_Buffer = ReadProcessMemory( StartAddress, ScanRange );

            // scan the data buffer
            for ( int i = 0; i < m_Buffer.Length - m_Signature.Length; i++ )
            {
                // initialize the index
                int j;

                // search for the signature byte
                for ( j = 0; j < m_Signature.Length; j++ )
                {
                    // is this the signature?
                    if ( m_Buffer[i + j] != m_Signature[j] )
                        break;
                }

                // move to the next chunk of memory data if we haven't found it
                if ( j == m_Signature.Length )
                    return (uint)( StartAddress + i + 1 );
            }

            return 0;
        }

        #endregion
    }
}