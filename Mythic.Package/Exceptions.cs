using System;

namespace Mythic.Package
{
    /// <summary>
    /// The exception that is thrown when adding a file to a full <see cref="MythicPackageBlock"/>.
    /// </summary>
    public class BlockFullException : SystemException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public BlockFullException() : base( "Block is full!" )
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when loading a <see cref="MythicPackageFile"/>, which is compressed
    /// using unknown compression.
    /// </summary>
    public class InvalidCompressionException : SystemException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public InvalidCompressionException( short flag ) : base( string.Format( "Invalid compression flag: {0}!", flag ) )
        {
        }
    }
    /// <summary>
    /// The exception that is thrown when compressing/decompressing a <see cref="MythicPackageFile"/>.
    /// </summary>
    public class CompressionException : SystemException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public CompressionException( ZLibError error ) : base( string.Format( "Error compressing/decompressing: {0}", error ) )
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when Unpacking a <see cref="MythicPackageFile"/> and size of the data read from .uop
    /// doesn't match <see cref="MythicPackageFile.CompressedSize"/>.
    /// </summary>
    public class StreamSourceException : SystemException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public StreamSourceException() : base( "Error reading data from stream!" )
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when loading a <see cref="MythicPackageBlock"/> and <see cref="HashDictionary.HashDataBlock"/>
    /// fails to match <see cref="MythicPackageFile.DataBlockHash"/>.
    /// </summary>
    public class AdlerFailedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AdlerFailedException( string index ) : base( string.Format( "Error running Adler32 on {0} data block!", index ) )
        {
        }
    }
}
