using System;
using System.Runtime.InteropServices;

namespace Mythic.Package
{
    /// <summary>
    /// Zlib compression quality.
    /// </summary>
    public enum ZLibQuality
    {
        /// <summary></summary>
        None        = 0,

        /// <summary></summary>
        Speed       = 1,

        /// <summary></summary>
        Best        = 9,

        /// <summary></summary>
        Default     = -1,
    }

    /// <summary>
    /// Zlib error.
    /// </summary>
    public enum ZLibError
    {
        /// <summary></summary>
        Okay            = 0,

        /// <summary></summary>
        StreamEnd       = 1,

        /// <summary></summary>
        NeedDictionary  = 2,

        /// <summary></summary>
        FileError       = -1,

        /// <summary></summary>
        StreamError     = -2,

        /// <summary></summary>
        DataError       = -3,

        /// <summary></summary>
        MemoryError     = -4,

        /// <summary></summary>
        BufferError     = -5,

        /// <summary></summary>
        VersionError    = -6,
    }

    /// <summary>
    /// Compression library.
    /// </summary>
    public class Zlib
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// 32bit version of the dll
        /// </summary>
        [DllImport( "Zlib32", EntryPoint = "zlibVersion" )]
        private static extern string ZlibVersion();

        /// <summary>
        /// 64bit version of the dll
        /// </summary>
        [DllImport( "Zlib64", EntryPoint = "zlibVersion" )]
        private static extern string ZlibVersion64();

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Version of the library (64 or 32 bit).
        /// </summary>
        public static string Version => Environment.Is64BitProcess ? ZlibVersion64() : ZlibVersion();


        // --------------------------------------------------------------
        #region 32 BIT
        // --------------------------------------------------------------

        /// <summary>
        /// Decompress data (64bit version)
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib32", EntryPoint = "uncompress" )]
        private static extern ZLibError Uncompress( byte[] dest, ref int destLen, byte[] source, int sourceLen );

        /// <summary>
        /// Compress data (32bit version)
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib32", EntryPoint = "compress" )]
        private static extern ZLibError Compress( byte[] dest, ref int destLen, byte[] source, int sourceLen );

        /// <summary>
        /// Compress data (32bit version) - with quality specification
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <param name="quality">Compression quality</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib32", EntryPoint = "compress2" )]
        private static extern ZLibError Compress( byte[] dest, ref int destLen, byte[] source, int sourceLen, ZLibQuality quality );

        #endregion

        // --------------------------------------------------------------
        #region 64 BIT
        // --------------------------------------------------------------

        /// <summary>
        /// Decompress data (64bit version)
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib64", EntryPoint = "uncompress" )]
        private static extern ZLibError Uncompress64( byte[] dest, ref int destLen, byte[] source, int sourceLen );

        /// <summary>
        /// Compress data (64bit version)
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib64", EntryPoint = "compress" )]
        private static extern ZLibError Compress64( byte[] dest, ref int destLen, byte[] source, int sourceLen );

        /// <summary>
        /// Compress data (64bit version) - with quality specification
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="destLen">destination bytes array size</param>
        /// <param name="source">original bytes array</param>
        /// <param name="sourceLen">original bytes array size</param>
        /// <param name="quality">Compression quality</param>
        /// <returns>Has the operation been successfull?</returns>
        [DllImport( "Zlib64", EntryPoint = "compress2" )]
        private static extern ZLibError Compress64( byte[] dest, ref int destLen, byte[] source, int sourceLen, ZLibQuality quality );

        #endregion

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Decompresses array of bytes.
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="source">original bytes array</param>
        /// <returns>Has the operation been successfull?</returns>
        public static ZLibError Unzip( byte[] dest, byte[] source )
        {
            // get the size of the destination array
            int destLength = dest.Length;

            // execute the decompress
            return Unzip( dest, ref destLength, source, source.Length );
        }

        /// <summary>
        /// Decompresses array of bytes.
        /// </summary>
        /// <param name="dest">Destination byte array.</param>
        /// <param name="destLength">Destination length (Sets it).</param>
        /// <param name="source">Source byte array.</param>
        /// <param name="sourceLength">Source length.</param>
        /// <returns>Error</returns>
        public static ZLibError Unzip( byte[] dest, ref int destLength, byte[] source, int sourceLength )
        {
            // use the 32/64bit dll to decompress
            return Environment.Is64BitProcess
                ? Uncompress64( dest, ref destLength, source, sourceLength )
                : Uncompress( dest, ref destLength, source, sourceLength );
        }

        /// <summary>
        /// Decompresses array of bytes.
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// <param name="source">original bytes array</param>
        /// <param name="quality"><see cref="ZLibQuality"/> of compression.</param>
        /// <returns>Has the operation been successfull?</returns>
        public static ZLibError Zip( byte[] dest, byte[] source, ZLibQuality quality = ZLibQuality.Default )
        {
            // get the size of the destination array
            int destLength = dest.Length;

            // execute the decompress
            return Zip( dest, ref destLength, source, source.Length, quality );
        }

        /// <summary>
        /// Decompresses array of bytes.
        /// </summary>
        /// <param name="dest">destination bytes array</param>
        /// /// <param name="destLength">Destination length (Sets it).</param>
        /// <param name="source">original bytes array</param>
        /// <param name="quality"><see cref="ZLibQuality"/> of compression.</param>
        /// <returns>Has the operation been successfull?</returns>
        public static ZLibError Zip( byte[] dest, ref int destLength, byte[] source, ZLibQuality quality = ZLibQuality.Default )
        {
            // execute the decompress
            return Zip( dest, ref destLength, source, source.Length, quality );
        }

        /// <summary>
        /// Compresses array of bytes.
        /// </summary>
        /// <param name="dest">Destination byte array.</param>
        /// <param name="destLength">Destination length (Sets it).</param>
        /// <param name="source">Source byte array.</param>
        /// <param name="sourceLength">Source length.</param>
        /// <param name="quality"><see cref="ZLibQuality"/> of compression.</param>
        /// <returns><see cref="ZLibError.Okay"/> if okay.</returns>
        public static ZLibError Zip( byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality = ZLibQuality.Default )
        {
            // is the compress request at default quality?
            if ( quality == ZLibQuality.Default )
            {
                // use the 32/64bit dll to compress
                return Environment.Is64BitProcess
                    ? Compress64( dest, ref destLength, source, sourceLength )
                    : Compress( dest, ref destLength, source, sourceLength );
            }
            else // quality specified?
            {
                // use the 32/64bit dll to compress
                return Environment.Is64BitProcess
                    ? Compress64( dest, ref destLength, source, sourceLength, quality )
                    : Compress( dest, ref destLength, source, sourceLength, quality );
            }
        }

        #endregion
    }
}