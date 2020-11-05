using System;
using System.IO;
using System.Text;

namespace Mythic.Package
{
	/// <summary>
	/// Class describing a file within .uop.
	/// </summary>
	public class MythicPackageFile
	{
		#region Size
		/// <summary>
		/// Size of the file header.
		/// </summary>
		public static int Size{ get{ return 34; } }
		#endregion

		#region Parent
		private MythicPackageBlock m_Parent;

		/// <summary>
		/// Reference to <see cref="Mythic.Package.MythicPackageBlock"/>, which contains this file.
		/// </summary>
		public MythicPackageBlock Parent
		{
			get{ return m_Parent; }
			set{ m_Parent = value; }
		}
		#endregion

		#region Index
		private int m_Index;

		/// <summary>
		/// Index of this file in the <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.
		/// </summary>
		public int Index
		{
			get{ return m_Index; }
			set{ m_Index = value; }
		}
		#endregion

		#region DataBlockAddress
		private long m_DataBlockAddress;
		private long m_OldDataBlockAddress;

		/// <summary>
		/// Address of actual data.
		/// </summary>
		public long DataBlockAddress
		{
			get{ return m_DataBlockAddress; }
		}
		#endregion

		#region DataBlockLength
		private int m_DataBlockLength;

		/// <summary>
		/// Length of the data header.
		/// </summary>
		public int DataBlockLength
		{
			get{ return m_DataBlockLength; }
		}
		#endregion

		#region CompressedSize
		private uint m_CompressedSize;

		/// <summary>
		/// Size of the compressed file. Equals to <see cref="Mythic.Package.MythicPackageFile.DecompressedSize"/> when
		/// <see cref="Mythic.Package.MythicPackageFile.Compression"/> is set to <see cref="Mythic.Package.CompressionFlag.None"/>.
		/// </summary>
		public uint CompressedSize
		{
			get{ return m_CompressedSize; }
		}
		#endregion

		#region DecompressedSize
		private uint m_DecompressedSize;

		/// <summary>
		/// Size of the decompressed file.
		/// </summary>
		public uint DecompressedSize
		{
			get{ return m_DecompressedSize; }
		}
		#endregion

		#region FileHash
		private ulong m_FileHash;

		/// <summary>
		/// Hash of the <see cref="Mythic.Package.MythicPackageFile.FileName"/>.
		/// </summary>
		public ulong FileHash
		{
			get{ return m_FileHash; }
		}
		#endregion

		#region DataBlockHash
		private uint m_DataBlockHash;

		/// <summary>
		/// Adler32 hash of the data header in little endian sequence.
		/// </summary>
		public uint DataBlockHash
		{
			get{ return m_DataBlockHash; }
		}
		#endregion

		#region Compression
		private CompressionFlag m_Compression;

		/// <summary>
		/// Compression type.
		/// </summary>
		public CompressionFlag Compression
		{
			get{ return m_Compression; }
		}
		#endregion

		#region FileName
		private string m_FileName;

		/// <summary>
		/// Name and relative path of the file.
		/// </summary>
		public string FileName
		{
			get{ return m_FileName; }
			set{ m_FileName = value; }
		}
		#endregion

		#region SourceFileName
		private string m_SourceFileName;
		#endregion

		#region SourceBuffer
		private byte[] m_SourceBuffer;
		#endregion

		#region Modified
		private bool m_Modified;

		/// <summary>
		/// Indicates if this file has been changed (added, removed or changed a file).
		/// </summary>
		public bool Modified
		{
			get{ return m_Modified; }
			set
			{
				if ( value )
					m_Parent.Modified = value;

				m_Modified = value;
			}
		}
		#endregion

		#region Added
		private bool m_Added;

		/// <summary>
		/// Indicates if this is a new file.
		/// </summary>
		public bool Added
		{
			get{ return m_Added; }
			set
			{
				if ( m_Added != value )
				{
					m_Parent.Modified = true;
					m_Added = value;
				}
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance from existing Mythic package file.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="parent">Parent entity.</param>
		public MythicPackageFile( BinaryReader reader, MythicPackageBlock parent )
		{
			m_Parent = parent;

			m_DataBlockAddress = m_OldDataBlockAddress = reader.ReadInt64();
			m_DataBlockLength = reader.ReadInt32();
			m_CompressedSize = reader.ReadUInt32();
			m_DecompressedSize = reader.ReadUInt32();
			m_FileHash = reader.ReadUInt64();

			if ( m_FileHash != 0 )
				m_FileName = HashDictionary.Get( m_FileHash, true );

			m_DataBlockHash = reader.ReadUInt32();

			short flag = reader.ReadInt16();

			switch ( flag )
			{
				case 0x0: m_Compression = CompressionFlag.None; break;
				case 0x1: m_Compression = CompressionFlag.Zlib; break;
				default: throw new InvalidCompressionException( flag );
			}
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="fileName">Absolute path to the file on HD.</param>
		/// <param name="innerFolder">Relative folder within KR (destination).</param>
		/// <param name="flag">Compression type.</param>
		public MythicPackageFile( string fileName, string innerFolder, CompressionFlag flag )
		{
			if ( String.IsNullOrEmpty( fileName ) )
				throw new ArgumentException( "fileName" );

			m_FileName = Path.Combine( innerFolder, Path.GetFileName( fileName ) ).ToLower();

			if ( m_FileName.StartsWith( "\\" ) || m_FileName.StartsWith( "/" ) )
				m_FileName = m_FileName.Substring( 1 );

			m_FileName = m_FileName.Replace( '\\', '/' );
			m_FileHash = HashDictionary.HashFileName( m_FileName );
			m_SourceFileName = fileName;
			m_Compression = flag;
			m_DataBlockLength = 0;
			m_DataBlockHash = 0;
		}
		#endregion

		#region ToString
		/// <summary>
		/// Returns a <see cref="String"/> that represents this.
		/// </summary>
		/// <returns>Constructed String.</returns>
		public override string ToString()
		{
			string value = String.Empty;

			if ( m_FileName != null )
				value = Path.GetFileName( m_FileName );
			else
				value = String.Format( "Index_{0}", m_Index );

			if ( m_Added )
				value = String.Format( "+{0}", value );
			else if ( m_Modified )
				value = String.Format( "*{0}", value );

			return value;
		}
		#endregion

		#region Search
		/// <summary>
		/// Checks if <see cref="Mythic.Package.MythicPackageFile.FileName"/> or <see cref="Mythic.Package.MythicPackageFile.FileHash"/>
		/// contains <paramref name="keyword"/>.
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns>If <paramref name="keyword"/> is found.</returns>
		public bool Search( string keyword )
		{
			if ( m_FileName != null && m_FileName.Contains( keyword ) )
				return true;

			string hash = m_FileHash.ToString( "X16" );

			if ( hash.Contains( keyword ) )
				return true;

			return false;
		}

		/// <summary>
		/// Checks if hash of <paramref name="keyword"/> is equal to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.
		/// </summary>
		/// <param name="hash">Hash of the <paramref name="keyword"/></param>
		/// <param name="keyword">Word or a phrase.</param>
		/// <returns>If <paramref name="keyword"/> equals to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.</returns>
		public bool SearchHash( ulong hash, string keyword )
		{
			if ( m_FileName == null && m_FileHash == hash )
			{
				HashDictionary.Set( hash, keyword );
				m_FileName = keyword;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if hash of <paramref name="keyword"/> is equal to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.
		/// </summary>
		/// <param name="hash">Hash of the <paramref name="keyword"/></param>
		/// <param name="keyword">Word or a phrase.</param>
		/// <returns>If <paramref name="keyword"/> equals to <see cref="Mythic.Package.MythicPackageFile.FileHash"/>.</returns>
		public bool SearchHash( ulong hash, char[] keyword )
		{
			if ( m_FileName == null && m_FileHash == hash )
			{
				String name = new String( keyword );
				HashDictionary.Set( hash, name );
				m_FileName = name;
				return true;
			}

			return false;
		}
		#endregion

		#region RefreshFileNames
		/// <summary>
		/// Reloads file names from the dictionary.
		/// </summary>
		public void RefreshFileName()
		{
			m_FileName = HashDictionary.Get( m_FileHash, false );
		}
		#endregion

		#region Replace
		/// <summary>
		/// Replaces this file with another.
		/// </summary>
		/// <param name="fileName">Path to the file on HD.</param>
		/// <param name="packageFolder">Relative folder within KR.</param>
		/// <param name="flag">Compression type.</param>
		public void Replace( string fileName, string packageFolder, CompressionFlag flag )
		{
			m_FileName = Path.Combine( packageFolder, Path.GetFileName( fileName ) ).ToLower();
			m_FileHash = HashDictionary.HashFileName( m_FileName );
			m_SourceFileName = fileName;
			m_Compression = flag;
			m_DataBlockLength = 0;
			m_DataBlockHash = 0;

			Modified = true;
		}
		#endregion

		#region Remove
		/// <summary>
		/// Removes this file from <see cref="Mythic.Package.MythicPackageBlock.Files"/> list.
		/// </summary>
		public void Remove()
		{
			m_Parent.RemoveFile( m_Index );
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves file header to <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void Save( BinaryReader reader, BinaryWriter writer )
		{
			writer.Write( m_DataBlockAddress );
			writer.Write( 0 );
			writer.Write( m_CompressedSize );
			writer.Write( m_DecompressedSize );
			writer.Write( m_FileHash );
			writer.Write( m_DataBlockHash );
			writer.Write( (short) m_Compression );
		}

		/// <summary>
		/// Saves file data to <paramref name="writer"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void SaveData( BinaryReader reader, BinaryWriter writer )
		{
			if ( m_SourceBuffer != null )
			{
				writer.Write( m_SourceBuffer, 0, (int) m_CompressedSize );
				HashDictionary.Set( m_FileHash, m_FileName );
			}
			else
			{
				reader.BaseStream.Seek( (long) m_OldDataBlockAddress + m_DataBlockLength, SeekOrigin.Begin );
				m_SourceBuffer = reader.ReadBytes( (int) m_CompressedSize );
				writer.Write( m_SourceBuffer, 0, (int) m_CompressedSize );
			}

			m_OldDataBlockAddress = m_DataBlockAddress;
			m_SourceBuffer = null;
			m_Modified = false;
			m_Added = false;
		}
		#endregion

		#region UpdateOffsets
		/// <summary>
		/// Updates <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/> within .uop file,
		/// <see cref="Mythic.Package.MythicPackageFile.CompressedSize"/> and <see cref="Mythic.Package.MythicPackageFile.DecompressedSize"/>.
		/// </summary>
		/// <param name="pointer">Address of <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/>.</param>
		public void UpdateOffsets( ref ulong pointer )
		{
			// current file data address
			m_DataBlockAddress = (long) pointer;

			// is this a new/modified file?
			if ( m_Added || m_Modified )
			{
				// is the new file still available?
				if ( !File.Exists( m_SourceFileName ) )
					throw new FileNotFoundException();

				// load the new file data
				byte[] sourceBuffer = File.ReadAllBytes(m_SourceFileName);

				// get the new file size
				m_CompressedSize = (uint) sourceBuffer.Length;
				m_DecompressedSize = (uint) sourceBuffer.Length;

				// if the file is less than 4 bytes, we can't compress it.
				if ( sourceBuffer.Length < 4 )
					m_Compression = CompressionFlag.None;

                // check what compression type we need to use
                switch ( m_Compression )
                {
                    case CompressionFlag.Zlib:
                        {
							// initialize the compressed data array
                            m_SourceBuffer = new byte[m_CompressedSize];

							// initialize the compressed data size
                            int csize = (int) m_CompressedSize;

							// compress the file
                            ZLibError error = Zlib.Compress( m_SourceBuffer, ref csize, sourceBuffer, (int) m_DecompressedSize, ZLibQuality.Best );

							// update the compressed data size
                            m_CompressedSize = (uint) csize;

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
                }

				// update the data block hash
                m_DataBlockHash = HashDictionary.HashDataBlock( m_SourceBuffer );

				// make sure the lenght is 0
				m_DataBlockLength = 0;
			}
			//else
			//	m_SourceBuffer = null;

			// increase the address for the next size to be placed AFTER this one.
			pointer += m_CompressedSize;
		}
		#endregion

		#region Unpack
		/// <summary>
		/// Unpacks this file to <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( string folder, bool fullPath )
		{
			if ( m_Parent != null && m_Parent.Parent != null && m_Parent.Parent.FileInfo.Name != string.Empty )
			{
				using ( FileStream stream = File.OpenRead( m_Parent.Parent.FileInfo.FullName ) )
				{
					using ( BinaryReader source = new BinaryReader( stream ) )
						Unpack( source, folder, fullPath );
				}
			}
		}

		/// <summary>
		/// Unpacks this file to <paramref name="folder"/> from <paramref name="source"/>.
		/// </summary>
		/// <param name="source">Binary file (.uop source).</param>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( BinaryReader source, string folder, bool fullPath )
		{
			string fileName = m_FileName;

			if ( String.IsNullOrEmpty( fileName ) )
				fileName = String.Format( "{0}_{1}_{2}.bin", m_Parent.Parent.FileInfo.Name, m_Parent.Index, m_Index );

			fileName = Path.Combine( folder, fullPath ? fileName : Path.GetFileName( fileName ) );

			string directory = Path.GetDirectoryName( fileName );

			if ( !Directory.Exists( directory ) )
				Directory.CreateDirectory( directory );

			using ( FileStream stream = File.Create( fileName ) )
			{
				using ( BinaryWriter writer = new BinaryWriter( stream ) )
				{
					byte[] data = Unpack( source );

					if ( data != null )
						writer.Write( data, 0, (int) m_DecompressedSize );
				}
			}
		}

		/// <summary>
		/// Unpacks this file<paramref name="myp"/>.
		/// </summary>
		/// <param name="myp">Path to mythic package.</param>
		/// <returns>Binary data from this file.</returns>
		public byte[] Unpack( string myp )
		{
			using ( FileStream stream = File.OpenRead( myp ) )
			{
				using ( BinaryReader source = new BinaryReader( stream ) )
					return Unpack( source );
			}
		}

		/// <summary>
		/// Unpacks this file<paramref name="source"/>.
		/// </summary>
		/// <param name="source">Binary file (.uop source).</param>
		/// <returns>Binary data from this file.</returns>
		public byte[] Unpack( BinaryReader source )
		{
			source.BaseStream.Seek( (long) m_DataBlockAddress + m_DataBlockLength, SeekOrigin.Begin );

			byte[] sourceData = new byte[ m_CompressedSize ];

			if ( source.Read( sourceData, 0, (int) m_CompressedSize ) != m_CompressedSize )
				throw new StreamSourceException();

			switch ( m_Compression )
			{
				case CompressionFlag.Zlib:
					{
						byte[] destData = new byte[ m_DecompressedSize ];
						int destLength = (int) m_DecompressedSize;
						ZLibError error = Zlib.Decompress( destData, ref destLength, sourceData, (int) m_CompressedSize );

						if ( error != ZLibError.Okay )
							throw new CompressionException( error );

						return destData;
					}
				case CompressionFlag.None:
					{
						return sourceData;
					}
			}

			return null;
		}
		#endregion
	}
}
