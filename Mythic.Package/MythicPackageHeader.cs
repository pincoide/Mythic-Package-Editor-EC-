using System;
using System.IO;

namespace Mythic.Package
{
    /// <summary>
    /// Class describing .uop file header.
    /// </summary>
    public class MythicPackageHeader
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Supported version.
        /// </summary>
        public static int SupportedVersion => 5;

        /// <summary>
        /// Default misc value.
        /// </summary>
        public static uint DefaultMisc => 0xFD23EC43;

        /// <summary>
        /// Default start address.
        /// </summary>
        public static ulong DefaultStartAddress => 0x200;

        /// <summary>
        /// Default <see cref="BlockSize"/>.
        /// </summary>
        public static int DefaultBlockSize => 1000;

        #endregion

        /// <summary>
        /// Version of .uop format.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Probably format release date and time
        /// </summary>
        public uint Misc { get; set; }

        /// <summary>
        /// Start of the first <see cref="MythicPackageBlock"/>.
        /// </summary>
        public ulong StartAddress { get; set; }

        /// <summary>
        /// Maximum amount of files that one <see cref="MythicPackageBlock"/> can hold.
        /// </summary>
        public int BlockSize { get; set; }

        /// <summary>
        /// Number if files in this .uop file.
        /// </summary>
        public int FileCount { get; set; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public MythicPackageHeader( int version )
        {
            // set the version
            Version = version;

            // use the default unknown value
            Misc = DefaultMisc;

            // use the default start address
            StartAddress = DefaultStartAddress;

            // use the default block size
            BlockSize = DefaultBlockSize;

            // initialize the files cound at 0
            FileCount = 0;
        }

        /// <summary>
        /// Creates a new instance from <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">Binary file (.uop source).</param>
        public MythicPackageHeader( BinaryReader reader )
        {
            // get the initial 4 bytes
            byte[] id = reader.ReadBytes( 4 );

            // UOP packages always starts with MYP0, if the file doesn't have it, we throw an exception.
            if ( id[0] != 'M' || id[1] != 'Y' || id[2] != 'P' || id[3] != 0 )
                throw new FormatException( "This is not a Mythic Package file!" );

            // get the file version
            Version = reader.ReadInt32();

            // is this version supported? if not, we throw an exception
            if ( Version > SupportedVersion )
                throw new FormatException( "Unsupported version!" );

            // get the unknown value
            Misc = reader.ReadUInt32();

            // get the first block address location
            StartAddress = reader.ReadUInt64();

            // get the default block size
            BlockSize = reader.ReadInt32();

            // get the files count
            FileCount = reader.ReadInt32();
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Saves .uop header to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">Binary file (.uop destination).</param>
        public void Save( BinaryWriter writer )
        {
            // write MYP0 in the first 4 bytes
            writer.Write( (byte)'M' );
            writer.Write( (byte)'Y' );
            writer.Write( (byte)'P' );
            writer.Write( (byte)0 );

            // write the version
            writer.Write( Version );

            // write the unknown value
            writer.Write( Misc );

            // write the first block start address
            writer.Write( StartAddress );

            // write the default block size
            writer.Write( BlockSize );

            // write the files count
            writer.Write( FileCount );

            // write 0 in each bytes from the current position to the start address of the first block
            while ( (ulong)writer.BaseStream.Position < StartAddress )
                writer.Write( (byte)0x0 );
        }

        #endregion
    }
}