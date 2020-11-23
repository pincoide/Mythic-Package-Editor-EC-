using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Mythic.Package
{
    /// <summary>
    /// Class describing a file within .uop.
    /// </summary>
    public class MythicPackageFile
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Used to determine a file MIME-Type
        /// </summary>
        [DllImport( @"urlmon.dll", CharSet = CharSet.Auto )]
        private static extern uint FindMimeFromData( uint pBC, [MarshalAs( UnmanagedType.LPStr )] string pwzUrl, [MarshalAs( UnmanagedType.LPArray )] byte[] pBuffer, uint cbSize, [MarshalAs( UnmanagedType.LPStr )] string pwzMimeProposed, uint dwMimeFlags, out uint ppwzMimeOut, uint dwReserverd );

        #endregion

        /// <summary>
        /// Previous data block address
        /// </summary>
        private long m_OldDataBlockAddress;

        /// <summary>
        /// Byte buffer of the file data
        /// </summary>
        private byte[] m_SourceBuffer;

        private bool m_Modified;
        private bool m_Added;

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Dictionary to convert the mime to file extension
        /// </summary>
        public static readonly Dictionary<string, string> MimeToExtension = new Dictionary<string, string>()
        {
            { "application/octet-stream", "bin" },
            { "text/xml", "xml" },
            { "application/zip", "zip" },
            { "image/vnd-ms.dds", "dds" },
            { "image/x-targa", "tga" },
            { "audio/wav", "wav" },
            { "audio/mpeg", "mp3" },
            { "application/vnd.ms-excel", "xls" },
            { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx" },
            { "audio/midi", "mid" },
            { "text/html", "html" },
            { "application/pdf", "pdf" },
            { "font/font-sfnt", "ttf" },
            { "font/vnd.ms-opentype", "otf" },
            { "application/CDFV2", "cdf" },
            { "image/x-tga", "tga" },
            { "image/vnd.ms-dds", "dds" },
            { "image/pjpeg", "jpg" },
            { "text/plain", "txt" },
        };

        /// <summary>
        /// Byte sequence to recognize extra file types
        /// </summary>
        public static readonly Dictionary<byte[], string> MimeFileTypes = new Dictionary<byte[], string>()
        {
            { new byte[] { 0, 1, 0, 0, 0 }, "font/font-sfnt" }, // TTF
			{ new byte[] { 79, 84, 84, 79, 0 }, "font/vnd.ms-opentype" }, // OTF
			{ new byte[] { 255, 251, 48 }, "audio/mpeg" }, // MP3
			{ new byte[] { 73, 68, 51 }, "audio/mpeg" }, // MP3
			{ new byte[] { 255, 243, 200 }, "audio/mpeg" }, // MP3
			{ new byte[] { 255, 243, 192 }, "audio/mpeg" }, // MP3
			{ new byte[] { 255, 243, 128 }, "audio/mpeg" }, // MP3
			{ new byte[] { 255, 243, 130 }, "audio/mpeg" }, // MP3
			{ new byte[] { 0, 0, 10, 0, 0, 0  }, "image/x-tga" }, // tga
			{ new byte[] { 0, 0, 2, 0, 0, 0  }, "image/x-tga" }, // tga
			{ new byte[] { 208, 207, 17, 224, 161, 177, 26, 225  }, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }, // xlsx
		};

        /// <summary>
        /// Size of the file header.
        /// </summary>
        public static int Size => 34;

        #endregion

        /// <summary>
        /// Reference to <see cref="MythicPackageBlock"/>, which contains this file.
        /// </summary>
        public MythicPackageBlock Parent { get; set; }

        /// <summary>
        /// Index of this file in the <see cref="MythicPackageBlock.Files"/> table.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Global index of this file inside the UOP.
        /// </summary>
        public int GlobalIndex { get; set; }

        /// <summary>
        /// Address of actual data.
        /// </summary>
        public long DataBlockAddress { get; private set; }

        /// <summary>
        /// Length of the data header.
        /// </summary>
        public int DataBlockLength { get; private set; }

        /// <summary>
        /// Adler32 hash of the data header in little endian sequence.
        /// </summary>
        public uint DataBlockHash { get; private set; }

        /// <summary>
        /// Compression type.
        /// </summary>
        public CompressionFlag Compression { get; private set; }

        /// <summary>
        /// Size of the compressed file. Equals to <see cref="DecompressedSize"/> when
        /// <see cref="Compression"/> is set to <see cref="CompressionFlag.None"/>.
        /// </summary>
        public uint CompressedSize { get; private set; }

        /// <summary>
        /// Size of the decompressed file.
        /// </summary>
        public uint DecompressedSize { get; private set; }

        /// <summary>
        /// Hash of the <see cref="FileName"/>.
        /// </summary>
        public ulong FileHash { get; private set; }

        /// <summary>
        /// Name and relative path of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File name from the hdd (used for replace)
        /// </summary>
        public string SourceFileName { get; set; }

        /// <summary>
        /// Relative path of the file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Indicates if this file has been changed (added, removed or changed a file).
        /// </summary>
        public bool Modified
        {
            get => m_Modified;
            set
            {
                // if we have a parent, we flag that as modified too (only if the value is true)
                if ( Parent != null && value )
                    Parent.Modified = value;

                m_Modified = value;
            }
        }

        /// <summary>
        /// Indicates if this is a new file.
        /// </summary>
        public bool Added
        {
            get => m_Added;
            set
            {
                // if we have a parent, we flag that as modified too (only if the value is true)
                if ( Parent != null && value )
                    Parent.Modified = true;

                m_Added = value;
            }
        }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTORS
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance from existing Mythic package file.
        /// </summary>
        /// <param name="reader">Binary file (.uop source).</param>
        /// <param name="parent">Parent entity.</param>
        public MythicPackageFile( BinaryReader reader, MythicPackageBlock parent = null )
        {
            // get the data location address
            DataBlockAddress = m_OldDataBlockAddress = reader.ReadInt64();

            // get the data block length (unknown how to determine)
            DataBlockLength = reader.ReadInt32();

            // get the compressed file size
            CompressedSize = reader.ReadUInt32();

            // get the decompressed file size
            DecompressedSize = reader.ReadUInt32();

            // get the file hash
            FileHash = reader.ReadUInt64();

            // if we have a valid hash, we try to get the file name from the dictionary
            if ( FileHash != 0 )
                FileName = HashDictionary.Get( FileHash, true );

            // verify the file name is complete and actually matches the hash
            VerifyFileName();

            // store the file path (only if we have a valid file name)
            if ( !string.IsNullOrEmpty( FileName ) )
                FilePath = FileName.Replace( Path.GetFileName( FileName ), "" );

            // get the file data hash
            DataBlockHash = reader.ReadUInt32();

            // get the compression flag
            short flag = reader.ReadInt16();

            // set the compression based on the flag we just read
            switch ( flag )
            {
                // no compression?
                case 0x0: Compression = CompressionFlag.None; break;

                // Zlib?
                case 0x1: Compression = CompressionFlag.Zlib; break;

                // any other case throws an exception (usually happens when the pointer addresses are incorrect)
                default: throw new InvalidCompressionException( flag );
            }

            // do we have a parent block for this file and also the file data address?
            if ( parent != null && DataBlockAddress != 0 )
            {
                // set the parent
                Parent = parent;

                // set the file index
                Index = parent.Files.Count;

                // calculate the global index of the file
                GlobalIndex = GetGlobalFileIndex();

                // add the file to the block files list
                parent.Files.Add( this );
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="fileName">Absolute path to the file on HD.</param>
        /// <param name="innerFolder">Relative folder within the UOP file (destination).</param>
        /// <param name="flag">Compression type.</param>
        /// <param name="parent">Parent block</param>
        /// <param name="isNewFile">Is this a new file added to the block (if not then the file is been loaded from an uop file)</param>
        public MythicPackageFile( string fileName, string innerFolder, CompressionFlag flag = CompressionFlag.Zlib, MythicPackageBlock parent = null, bool isNewFile = true )
        {
            // if we have an invalid file name, we throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, generate an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // create the full file name and change the \ to / in the file path
            FileName = Path.Combine( innerFolder, Path.GetFileName( fileName ) ).ToLower().Replace( '\\', '/' );

            // remove \ or / if the file name starts with it
            if ( FileName.StartsWith( "\\" ) || FileName.StartsWith( "/" ) )
                FileName = FileName.Substring( 1 );

            // store the file relative path (inside the archive)
            FilePath = innerFolder.Replace( '\\', '/' );

            // calculate the file hash
            FileHash = HashDictionary.HashFileName( FileName );

            // store the new file location in the hdd
            SourceFileName = fileName;

            // set the compression flag
            Compression = flag;

            // initialize the data length and hash to 0 (they'll be calculated later)
            DataBlockLength = 0;
            DataBlockHash = 0;

            // do we have a parent block?
            if ( parent != null )
            {
                // set the parent
                Parent = parent;

                // set the file index
                Index = parent.Files.Count;

                // calculate the global index of the file
                GlobalIndex = GetGlobalFileIndex();

                // add the file to the block files list
                parent.Files.Add( this );
            }

            // set the flag indicating that is a new file
            Added = isNewFile;
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region STATIC
        // --------------------------------------------------------------

        /// <summary>
        /// Determine the file MIME-TYPE
        /// </summary>
        /// <param name="data">File data bytes</param>
        /// <returns>File MIME-TYPE</returns>
        public static string GetMimeType( byte[] data )
        {
            // default mime type (bin)
            string DefaultMimeType = "application/octet-stream";

            try
            {
                // minimum bytes required to check the file type
                uint MimeSampleSize = 256;

                // parse the file data to determine the mime type
                FindMimeFromData( 0, null, data, MimeSampleSize, null, 0, out uint mimeType, 0 );

                // get the mime pointer
                IntPtr mimePointer = new IntPtr(mimeType);

                // get the mime type string
                string mime = Marshal.PtrToStringUni(mimePointer);

                // release the mime pointer
                Marshal.FreeCoTaskMem( mimePointer );

                // did we fail to get a mime?
                if ( string.IsNullOrEmpty( mime ) || mime == DefaultMimeType )
                {
                    // check the known byte sequence
                    foreach ( KeyValuePair<byte[], string> k in MimeFileTypes )
                    {
                        // is this byte sequence the one in the file?
                        if ( data.Take( k.Key.Length ).SequenceEqual( k.Key ) )
                        {
                            // get the mime type
                            mime = k.Value;

                            break;
                        }
                    }
                }

                // did we fail again to get a mime?
                if ( string.IsNullOrEmpty( mime ) || mime == DefaultMimeType )
                {
                    // check if the file is a binary or text file
                    mime = !IsBinary( data ) ? "text/plain" : DefaultMimeType;
                }

                return mime ?? DefaultMimeType;
            }
            catch
            {
                return DefaultMimeType;
            }
        }

        /// <summary>
        /// Get the MD5 hash for the specified bytes array
        /// </summary>
        /// <param name="data">data bytes</param>
        /// <returns>MD5 hash of this data array</returns>
        public static string GetMD5Hash( byte[] data )
        {
            // create the MD5 hash handler
            using ( MD5 hash = MD5.Create() )
            {
                return BitConverter.ToString( hash.ComputeHash( data ) ).Replace( "-", string.Empty );
            }
        }

        /// <summary>
        /// Get the MD5 hash for an external file
        /// </summary>
        /// <param name="fileName">File to examine</param>
        /// <returns>MD5 hash of the specified file</returns>
        public static string GetMD5Hash( string fileName )
        {
            // if the file doesn't exist, generate an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // create the MD5 hash handler
            using ( MD5 hash = MD5.Create() )
            using ( FileStream f = File.OpenRead( fileName ) )
            {
                return BitConverter.ToString( hash.ComputeHash( f ) ).Replace( "-", string.Empty );
            }
        }

        #endregion

        // --------------------------------------------------------------
        #region OVERRIDES
        // --------------------------------------------------------------

        /// <summary>
        /// Returns a <see cref="string"/> that represents this.
        /// </summary>
        /// <returns>Constructed String.</returns>
        public override string ToString()
        {
            // initialize the string to return
            string value;

            // if we have a file name, we use that.
            if ( FileName != null )
                value = Path.GetFileName( FileName );

            else // if we don't have a file name, we use Block_X_Index_Y as file name
                value = string.Format( "Index_{0}", Index );

            // if this is a new file, we add a "+" in front of it
            if ( m_Added )
                value = string.Format( "+{0}", value );

            // if this file has been modified, we add a "*" in front of it
            else if ( m_Modified )
                value = string.Format( "*{0}", value );

            return value;
        }

        #endregion

        // --------------------------------------------------------------
        #region SEARCH
        // --------------------------------------------------------------

        /// <summary>
        /// Checks if <see cref="FileName"/> or <see cref="FileHash"/>
        /// contains <paramref name="keyword"/>.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>If <paramref name="keyword"/> is found.</returns>
        public bool Search( string keyword )
        {
            // no keyword to search? throw an exception
            if ( string.IsNullOrEmpty( keyword ) )
                throw new ArgumentNullException( "keyword" );

            // if we have a file name, and it contains the keyword, then we found a match!
            if ( !string.IsNullOrEmpty( FileName ) && FileName.Contains( keyword ) )
                return true;

            // is the file hash the same as the keyword hash? (perfect match)
            if ( FileHash == HashDictionary.HashFileName( keyword ) )
            {
                // set the file name in the dictionary
                HashDictionary.Set( FileHash, keyword );

                // refresh the file name
                RefreshFileName();

                return true;
            }

            // get the file hash
            string hash = FileHash.ToString( "X16" );

            // does the keyword resemble the hash?
            return hash.Contains( keyword );
        }

        /// <summary>
        /// Checks if hash of <paramref name="keyword"/> is equal to <see cref="FileHash"/>.
        /// </summary>
        /// <param name="hash">Hash of the <paramref name="keyword"/></param>
        /// <param name="keyword">Word or a phrase.</param>
        /// <returns>If <paramref name="keyword"/> equals to <see cref="FileHash"/>.</returns>
        public bool SearchHash( ulong hash, char[] keyword )
        {
            // we just use transform the char array to string and use the other overload
            return SearchHash( hash, new string( keyword ) );
        }

        /// <summary>
        /// Checks if hash of <paramref name="keyword"/> is equal to <see cref="FileHash"/>.
        /// </summary>
        /// <param name="hash">Hash of the <paramref name="keyword"/></param>
        /// <param name="keyword">Word or a phrase.</param>
        /// <returns>If <paramref name="keyword"/> equals to <see cref="FileHash"/>.</returns>
        public bool SearchHash( ulong hash, string keyword )
        {
            // is the file name missing and the hash is correct?
            if ( ( string.IsNullOrEmpty( FileName ) || FileName != keyword ) && FileHash == HashDictionary.HashFileName( keyword ) )
            {
                // set the file name in the dictionary
                HashDictionary.Set( hash, keyword );

                // refresh the file name
                RefreshFileName();

                return true;
            }

            return false;
        }

        #endregion

        // --------------------------------------------------------------
        #region ADD/REMOVE FILE
        // --------------------------------------------------------------

        /// <summary>
        /// Replaces this file with another.
        /// </summary>
        /// <param name="fileName">Path to the file on HD.</param>
        /// <param name="packageFolder">Relative folder within the UOP file.</param>
        /// <param name="flag">Compression type.</param>
        public void Replace( string fileName, string packageFolder, CompressionFlag flag = CompressionFlag.Zlib )
        {
            // no file name? throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, generate an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // get the current file MD5
            string md5 = GetMD5Hash();

            // get the new file MD5
            string md5FIle = GetMD5Hash( fileName );

            // if the MD5 is the same for both files, we can skip this file because they are exactly the same
            if ( md5 == md5FIle )
                return;

            // set the full file name
            FileName = Path.Combine( packageFolder, Path.GetFileName( fileName ) ).ToLower();

            // set the file hash
            FileHash = HashDictionary.HashFileName( FileName );

            // set the file path on the hdd
            SourceFileName = fileName;

            // store the compression flag
            Compression = flag;

            // initialize the data length and hash to 0 (they'll be calculated later)
            DataBlockLength = 0;
            DataBlockHash = 0;

            // store the file path
            FilePath = packageFolder.Replace( '\\', '/' );

            // flag the file as modified
            Modified = true;
        }

        /// <summary>
        /// Removes this file from <see cref="MythicPackageBlock.Files"/> list.
        /// </summary>
        public void Remove()
        {
            // remove this file from the parent block
            Parent.RemoveFile( Index );
        }

        #endregion

        // --------------------------------------------------------------
        #region SAVE
        // --------------------------------------------------------------

        /// <summary>
        /// Saves file header to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">Binary file (.uop destination).</param>
        public void Save( BinaryWriter writer )
        {
            // write the address of the file's data
            writer.Write( DataBlockAddress );

            // since we don't know how to determine the data block header, we just use 0.
            writer.Write( 0 );

            // write the file compressed size
            writer.Write( CompressedSize );

            // write the file decompressed size
            writer.Write( DecompressedSize );

            // write the file hash
            writer.Write( FileHash );

            // write the file data hash
            writer.Write( DataBlockHash );

            // write the compression type flag
            writer.Write( (short)Compression );
        }

        /// <summary>
        /// Saves file data to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">Binary file (.uop destination).</param>
        /// <param name="reader">Binary file (.uop source).</param>
        public void SaveData( BinaryWriter writer, BinaryReader reader = null )
        {
            // do we have the original data buffer?
            if ( m_SourceBuffer != null )
            {
                // write the file data
                writer.Write( m_SourceBuffer, 0, (int)CompressedSize );

                // store the hash and file name (if available, otherwise only the hash will get stored) into the dictionary
                HashDictionary.Set( FileHash, FileName );
            }
            else // save the file from hdd
            {
                // move to the file data location
                reader.BaseStream.Seek( m_OldDataBlockAddress + DataBlockLength, SeekOrigin.Begin );

                // read the hdd file data
                m_SourceBuffer = reader.ReadBytes( (int)CompressedSize );

                // write the file data (inside the uop)
                writer.Write( m_SourceBuffer, 0, (int)CompressedSize );
            }

            // update the previous file data address
            m_OldDataBlockAddress = DataBlockAddress;

            // clear the data buffer
            m_SourceBuffer = null;

            // clear the modified flags
            m_Modified = false;
            m_Added = false;
        }

        /// <summary>
        /// Updates <see cref="DataBlockAddress"/> within .uop file,
        /// <see cref="CompressedSize"/> and <see cref="DecompressedSize"/>.
        /// </summary>
        /// <param name="pointer">Address of <see cref="DataBlockAddress"/>.</param>
        public void UpdateOffsets( ref ulong pointer )
        {
            // current file data address
            DataBlockAddress = (long)pointer;

            // is this a new/modified file?
            if ( m_Added || m_Modified )
            {
                // is the new file still available?
                if ( !File.Exists( SourceFileName ) )
                    throw new FileNotFoundException();

                // load the new file data
                byte[] sourceBuffer = File.ReadAllBytes(SourceFileName);

                // get the new file size
                CompressedSize = (uint)sourceBuffer.Length;
                DecompressedSize = (uint)sourceBuffer.Length;

                // if the file is less than 4 bytes, we can't compress it.
                if ( sourceBuffer.Length < 4 )
                    Compression = CompressionFlag.None;

                // check what compression type we need to use
                switch ( Compression )
                {
                    case CompressionFlag.Zlib:
                        {
                            // initialize the compressed data array
                            m_SourceBuffer = new byte[CompressedSize];

                            // initialize the compressed data size
                            int csize = (int) CompressedSize;

                            // compress the file
                            ZLibError error = Zlib.Zip( m_SourceBuffer, ref csize, sourceBuffer, ZLibQuality.Best );

                            // update the compressed data size
                            CompressedSize = (uint)csize;

                            // did we get an error?
                            if ( error != ZLibError.Okay )
                                throw new CompressionException( error );

                            break;
                        }
                    case CompressionFlag.None:
                        {
                            // if there is no compression, we save the file as it is...
                            m_SourceBuffer = sourceBuffer;

                            break;
                        }

                    default:
                        break;
                }

                // update the data block hash
                DataBlockHash = HashDictionary.HashDataBlock( m_SourceBuffer );
            }

            // increase the address for the next size to be placed AFTER this one.
            pointer += CompressedSize;
        }

        #endregion

        // --------------------------------------------------------------
        #region UNPACK
        // --------------------------------------------------------------

        /// <summary>
        /// Unpack the file
        /// </summary>
        /// <returns>Binary data from this file.</returns>
        public byte[] Unpack()
        {
            // unpack this file to a byte array
            return Unpack( Parent.Parent.FileInfo.FullName );
        }

        /// <summary>
        /// Unpacks this file<paramref name="myp"/>.
        /// </summary>
        /// <param name="myp">Path to mythic package.</param>
        /// <returns>Binary data from this file.</returns>
        public byte[] Unpack( string myp )
        {
            // open the uop and unpack the file to a byte array
            using ( FileStream stream = File.OpenRead( myp ) )
            using ( BinaryReader source = new BinaryReader( stream ) )
                return Unpack( source );
        }

        /// <summary>
        /// Unpacks this file to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain the UOP file folder structure?</param>
        public void Unpack( string folder, bool fullPath )
        {
            // do we have the uop file info?
            if ( Parent != null && Parent.Parent != null && !string.IsNullOrEmpty( Parent.Parent.FileInfo.Name ) )
            {
                // open the uop and unpack the file
                using ( FileStream stream = File.OpenRead( Parent.Parent.FileInfo.FullName ) )
                using ( BinaryReader source = new BinaryReader( stream ) )
                    Unpack( source, folder, fullPath );
            }
        }

        /// <summary>
        /// Unpacks this file<paramref name="source"/>.
        /// </summary>
        /// <param name="source">Binary file (.uop source).</param>
        /// <returns>Binary data from this file.</returns>
        public byte[] Unpack( BinaryReader source )
        {
            // move to the file data position in the uop stream reader
            source.BaseStream.Seek( DataBlockAddress + DataBlockLength, SeekOrigin.Begin );

            // initialize the byte array in which we'll put the data in
            byte[] sourceData = new byte[CompressedSize];

            // read the file data
            source.Read( sourceData, 0, (int)CompressedSize );

            // check the compression type this file is using
            switch ( Compression )
            {
                // is it using Zlib?
                case CompressionFlag.Zlib:
                    {
                        // create a byte array for the decompressed data
                        byte[] destData = new byte[DecompressedSize];

                        // decompress the file
                        ZLibError error = Zlib.Unzip( destData, sourceData );

                        // did the decompression was succecssful? if not we throw an exception
                        return error != ZLibError.Okay ? throw new CompressionException( error ) : destData;
                    }
                // no compression? we just use the data we read then...
                case CompressionFlag.None:
                    return sourceData;

                // any other case is invalid, so we can just return null
                default: return null;
            }
        }

        /// <summary>
        /// Unpacks this file to <paramref name="folder"/> from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">Binary file (.uop source).</param>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain the UOP file folder structure?</param>
        public void Unpack( BinaryReader source, string folder, bool fullPath )
        {
            // get the file data
            byte[] data = Unpack( source );

            // get the file name
            string fileName = FileName;

            // do we have an invalid file name?
            if ( string.IsNullOrEmpty( fileName ) )
            {
                // get the file mime
                string mime = GetMimeType( data );

                // get the file extension to use
                string extension = MimeToExtension[mime];

                // if we didn't find the extension, we save it as bin
                if ( string.IsNullOrEmpty( extension ) )
                    extension = "bin";

                // create the file name
                fileName = string.Format( "{0}_B{1}_F{2}.{3}", Parent.Parent.FileInfo.Name, Parent.Index, Index, extension );
            }

            // create the full file path
            fileName = Path.Combine( folder, fullPath ? fileName : Path.GetFileName( fileName ) );

            // get the file directory
            string directory = Path.GetDirectoryName( fileName );

            // make sure the directory exist and create it if necessary
            if ( !Directory.Exists( directory ) )
                Directory.CreateDirectory( directory );

            // write the file
            using ( FileStream stream = File.Create( fileName ) )
            using ( BinaryWriter writer = new BinaryWriter( stream ) )
                if ( data != null )
                    writer.Write( data, 0, (int)DecompressedSize );
        }

        #endregion

        /// <summary>
        /// Verify if a file name is valid and compatible with the hash.
        /// </summary>
        /// <returns></returns>
        public bool VerifyFileName()
        {
            // check the file name if it's valid
            if ( string.IsNullOrEmpty( FileName ) || string.IsNullOrEmpty( Path.GetExtension( FileName ) ) )
            {
                // remove the broken file name
                FileName = null;

                // remove the file path
                FilePath = null;

                // remove the broken name from the dictionary
                HashDictionary.Unset( FileHash );

                return false;
            }

            // is the file name correct with the hash?
            return FileHash == HashDictionary.HashFileName( FileName );
        }

        /// <summary>
        /// Reloads file names from the dictionary.
        /// </summary>
        public void RefreshFileName()
        {
            // get the file name from the dictionary
            FileName = HashDictionary.Get( FileHash, false );

            // store the file path
            if ( !string.IsNullOrEmpty( FileName ) )
                FilePath = FileName.Replace( Path.GetFileName( FileName ), "" );

            // verify the file name
            VerifyFileName();
        }

        /// <summary>
        /// Determine the file MIME-TYPE
        /// </summary>
        /// <returns>File MIME-TYPE</returns>
        public string GetMimeType()
        {
            // initialize the bytes array of the file
            byte[] data;

            // if this is a new/modified file, we get the mime of the hdd file instead
            if ( Added || Modified )
                data = File.ReadAllBytes( SourceFileName );

            else // get the file bytes
                data = Unpack();

            return GetMimeType( data );
        }

        /// <summary>
        /// Get the MD5 hash for the current file
        /// </summary>
        /// <returns>MD5 hash of this file</returns>
        public string GetMD5Hash()
        {
            return GetMD5Hash( Unpack() );
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Calculate the file index, starting from the first file of the package (the normal file index starts and ends with each block)
        /// </summary>
        /// <returns>Index of the file inside the UOP</returns>
        private int GetGlobalFileIndex()
        {
            // initialize the file index
            int currentFileIndex = 0;

            // count the files of the previous blocks
            for ( int i = 0; i < Parent.Index; i++ )
                currentFileIndex += Parent.Parent.Blocks[i].FileCount;

            return currentFileIndex + Index;
        }

        /// <summary>
        /// Determine if a file is binary
        /// </summary>
        /// <param name="data">file content</param>
        /// <param name="requiredConsecutiveNul"></param>
        /// <returns></returns>
        private static bool IsBinary( byte[] data, int requiredConsecutiveNul = 1 )
        {
            // number of characters to check to make sure
            const int charsToCheck = 8000;

            // character that cannot be typed in ascii
            const char nulChar = '\0';

            // counter for the amount of null characters
            int nulCount = 0;

            // start reading the data
            using ( MemoryStream streamReader = new MemoryStream( data ) )
            {
                // start looping through the characters of the "text"
                for ( int i = 0; i < charsToCheck; i++ )
                {
                    // if we haven't found anything and there is nothing left to read, we can get out
                    if ( !streamReader.CanRead )
                        return false;

                    // check if it's a null character
                    if ( (char)streamReader.ReadByte() == nulChar )
                    {
                        // increase the null counter
                        nulCount++;

                        // too manu null characters? is a bynary file
                        if ( nulCount >= requiredConsecutiveNul )
                            return true;
                    }
                    else // reset the null counter
                        nulCount = 0;
                }
            }

            // if we got here is not a binary file
            return false;
        }

        #endregion
    }
}
