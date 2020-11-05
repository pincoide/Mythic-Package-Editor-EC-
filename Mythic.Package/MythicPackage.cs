using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mythic.Package
{
	/// <summary>
	/// Updates progress bar.
	/// </summary>
	public delegate void UpdateProgress( int current, int max );

	/// <summary>
	/// Type of compression.
	/// </summary>
	public enum CompressionFlag : short
	{
		/// <summary>
		/// None.
		/// </summary>
		None	= 0x0,

		/// <summary>
		/// Zlib.
		/// </summary>
		Zlib	= 0x1
	}

	/// <summary>
	/// Search result.
	/// </summary>
	public class SearchResult
	{
		#region NotFound
		/// <summary>
		/// Seatch result indicating nothing was found.
		/// </summary>
		public static readonly SearchResult NotFound = new SearchResult( -1, -1 );

		/// <summary>
		/// Seatch result indicating nothing was found in the <see cref="Mythic.Package.MythicPackageBlock"/>.
		/// </summary>
		public static readonly int NotFoundResult = -1;
		#endregion

		#region Block
		private int m_Block;

		/// <summary>
		/// Index of the block in <see cref="Mythic.Package.MythicPackage.Blocks"/>.
		/// </summary>
		///
		public int Block{ get{ return m_Block; } }
		#endregion

		#region File
		private int m_File;

		/// <summary>
		/// Index if the file in <see cref="Mythic.Package.MythicPackageBlock.Files"/>.
		/// </summary>
		public int File{ get{ return m_File; } }
		#endregion

		#region Found
		/// <summary>
		/// Indicates search was successful.
		/// </summary>
		public bool Found{ get{ return m_Block >= 0 && m_File >= 0; } }
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="block">Index if block in <see cref="Mythic.Package.MythicPackage.Blocks"/>.</param>
		/// <param name="file">Index of file in <see cref="Mythic.Package.MythicPackageBlock.Files"/>.</param>
		public SearchResult( int block, int file )
		{
			m_Block = block;
			m_File = file;
		}
		#endregion
	}

	/// <summary>
	/// Descriptor used when loading a file from package.
	/// </summary>
	public class FileDescriptor
	{
		#region FileName
		private string m_FileName;

		/// <summary>
		/// Name of the mythic package (absolute).
		/// </summary>
		public string FileName
		{
			get { return m_FileName; }
			set { m_FileName = value; }
		}
		#endregion

		#region MythicPackageFile
		private MythicPackageFile m_File;

		/// <summary>
		/// Information about file in mythic package.
		/// </summary>
		public MythicPackageFile File
		{
			get { return m_File; }
			set { m_File = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constucts new file descriptor.
		/// </summary>
		/// <param name="fileName">Path to the mythic package.</param>
		/// <param name="file">Information about file in mythic package.</param>
		public FileDescriptor( string fileName, MythicPackageFile file )
		{
			m_FileName = fileName;
			m_File = file;
		}
		#endregion
	}

	/// <summary>
	/// Class describing .uop file.
	/// </summary>
	public class MythicPackage
	{
		#region FileInfo
		private FileInfo m_FileInfo;

		/// <summary>
		/// Reference to <see cref="FileInfo"/>.
		/// </summary>
		public FileInfo FileInfo
		{
			get { return m_FileInfo; }
			set { m_FileInfo = value; }
		}
		#endregion

		#region Header
		private MythicPackageHeader m_Header;

		/// <summary>
		/// Reference to <see cref="Mythic.Package.MythicPackageHeader"/>.
		/// </summary>
		public MythicPackageHeader Header
		{
			get { return m_Header; }
		}
		#endregion

		#region Blocks
		private List<MythicPackageBlock> m_Blocks = new List<MythicPackageBlock>();

		/// <summary>
		/// List of <see cref="Mythic.Package.MythicPackageBlock"/> in this file.
		/// </summary>
		public List<MythicPackageBlock> Blocks
		{
			get { return m_Blocks; }
		}
		#endregion

		#region Modified
		private bool m_Modified;

		/// <summary>
		/// Indicates if this package has been changed (added, removed or changed a file).
		/// </summary>
		public bool Modified
		{
			get { return m_Modified; }
			set { m_Modified = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of Mythic Package File.
		/// </summary>
		public MythicPackage() : this( MythicPackageHeader.SupportedVersion )
		{
		}

		/// <summary>
		/// Initializes a new instance of Mythic Package File.
		/// <param name="version">Version of the file.</param>
		/// </summary>
		public MythicPackage( int version )
		{
			m_Header = new MythicPackageHeader( version );
		}

		/// <summary>
		/// Initializes a new Instance from <paramref name="fileName"/>.
		/// </summary>
		/// <param name="fileName">Path to .uop file.</param>
		public MythicPackage( string fileName )
		{
			using ( FileStream stream = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
			{
				using ( BinaryReader reader = new BinaryReader( stream ) )
				{
					int index = 0;

					m_FileInfo = new FileInfo( fileName );
					m_Header = new MythicPackageHeader( reader );

					stream.Seek( (long) m_Header.StartAddress, SeekOrigin.Begin );

					MythicPackageBlock block;

					do
					{
						block = new MythicPackageBlock( reader, this );
						block.Index = index++;
						block.Parent = this;

						m_Blocks.Add( block );

					}
					while ( stream.Seek( block.NextBlock, SeekOrigin.Begin ) != 0 );
				}
			}
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

			if ( m_FileInfo != null )
				value = m_FileInfo.Name;
			else
				value = base.ToString();

			if ( m_Modified )
				value = String.Format( "{0}*" );

			return value;
		}
		#endregion

		#region Search
		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns><see cref="Mythic.Package.SearchResult"/></returns>
		public SearchResult Search( string keyword )
		{
			return Search( 0, 0, keyword );
		}

		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		/// <param name="bstart">Start block index.</param>
		/// <param name="keyword"></param>
		/// <returns><see cref="Mythic.Package.SearchResult"/></returns>
		public SearchResult Search( int bstart, string keyword )
		{
			return Search( bstart, 0, keyword );
		}

		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		/// <param name="bstart">Start block index.</param>
		/// <param name="istart">Start file index.</param>
		/// <param name="keyword"></param>
		/// <returns><see cref="Mythic.Package.SearchResult"/></returns>
		public SearchResult Search( int bstart, int istart, string keyword )
		{
			if ( bstart < 0 || bstart > m_Blocks.Count - 1 )
				throw new ArgumentOutOfRangeException( "bstart" );

			if ( keyword == null )
				throw new ArgumentNullException( "keyword" );

			int idx = m_Blocks[ bstart ].Search( istart, keyword );

			if ( idx > -1 )
				return new SearchResult( bstart, idx );

			for ( int i = bstart + 1; i < m_Blocks.Count; i++ )
			{
				idx = m_Blocks[ i ].Search( keyword );

				if ( idx > - 1 )
					return new SearchResult( i, idx );
			}

			return SearchResult.NotFound;
		}

		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files. Checking
		/// only <paramref name="keyword"/> hash.
		/// </summary>
		/// <param name="hash">Hash of <paramref name="keyword"/></param>
		/// <param name="keyword"></param>
		/// <returns>Index of the <see cref="Mythic.Package.MythicPackageFile"/> in <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.</returns>
		public SearchResult SearchHash( ulong hash, string keyword )
		{
			int idx = -1;

			for ( int i = 0; i < m_Blocks.Count; i++ )
			{
				idx = m_Blocks[ i ].SearchHash( hash, keyword );

				if ( idx > - 1 )
					return new SearchResult( i, idx );
			}

			return SearchResult.NotFound;
		}

		/// <summary>
		/// Search the exact file name inside the UOP file
		/// </summary>
		/// <param name="fileName">EXACT file name to search</param>
		/// <returns>Index of the <see cref="Mythic.Package.MythicPackageFile"/> in <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.</returns>
		public SearchResult SearchExactFileName( string fileName )
		{
			foreach ( MythicPackageBlock block in m_Blocks )
				foreach ( MythicPackageFile file in block.Files )
					if ( file.FileHash == HashDictionary.HashFileName( fileName ) )
						return new SearchResult( block.Index, file.Index );

			return SearchResult.NotFound;
		}
		#endregion

		#region RefreshFileNames
		/// <summary>
		/// Reloads file names from the dictionary.
		/// </summary>
		public void RefreshFileNames()
		{
			for ( int i = 0; i < m_Blocks.Count; i++ )
				m_Blocks[ i ].RefreshFileNames();
		}
		#endregion

		#region AddFile
		/// <summary>
		/// Adds a file, located in <paramref name="fileName"/>, to <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.
		/// </summary>
		/// <param name="fileName">Path to a file on HD.</param>
		/// <param name="innerFolder">Relative folder within KR (destination).</param>
		/// <param name="flag">Compression type.</param>
		public void AddFile( string fileName, string innerFolder, CompressionFlag flag )
		{
			if ( String.IsNullOrEmpty( fileName ) )
				throw new ArgumentException( "fileName" );

			MythicPackageBlock block;

			if ( m_Blocks.Count > 0 )
				block = m_Blocks[ m_Blocks.Count - 1 ];
			else
				block = NewBlock();

			if ( block.IsFull )
				block = NewBlock();

			block.AddFile( fileName, innerFolder, flag );
		}

		/// <summary>
		/// Adds a multiple files, located in <paramref name="fileName"/>, to <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.
		/// </summary>
		/// <param name="fileNames">Array of file paths on HD.</param>
		/// <param name="innerFolder">Relative folder within KR (destination).</param>
		/// <param name="flag">Compression type.</param>
		public void AddFiles( string[] fileNames, string innerFolder, CompressionFlag flag )
		{
			foreach ( string file in fileNames )
				AddFile( file, innerFolder, flag );
		}

		/// <summary>
		/// Adds all files within a certain folder to .uop package.
		/// </summary>
		/// <param name="folder">Folder, which contains files.</param>
		/// <param name="flag">Compression type.</param>
		public void AddFolder( string folder, CompressionFlag flag )
		{
			if ( !Directory.Exists( folder ) )
				throw new ArgumentException( String.Format( "'{0}' is not a folder!", folder ) );

			Stack<string> stack = new Stack<string>();
			stack.Push( folder );

			while ( stack.Count > 0 )
			{
				string f = stack.Pop();
				string inner = f.Remove( 0, folder.Length );

				foreach ( string file in Directory.GetFiles( f ) )
					AddFile( file, inner, flag );

				foreach ( string newFolder in Directory.GetDirectories( f ) )
					stack.Push( newFolder );
			}
		}

		private MythicPackageBlock NewBlock()
		{
			MythicPackageBlock block = new MythicPackageBlock();
			block.Parent = this;
			block.Index = m_Blocks.Count;
			block.Added = true;
			m_Blocks.Add( block );

			return block;
		}
		#endregion

		#region RemoveFile
		/// <summary>
		/// Removes a file from <see cref="Mythic.Package.MythicPackageBlock.Files"/>.
		/// </summary>
		/// <param name="block">Index of the block.</param>
		/// <param name="index">Index of the file to remove.</param>
		public void RemoveFile( int block, int index )
		{
			m_Blocks[ block ].RemoveFile( index );
		}

		/// <summary>
		/// Removes a block from <see cref="Mythic.Package.MythicPackage.Blocks"/>.
		/// </summary>
		/// <param name="index">Index of the block to remove.</param>
		public void RemoveBlock( int index )
		{
			MythicPackageBlock block = m_Blocks[ index ];

			m_Modified = true;
			m_Header.FileCount -= block.FileCount;
			m_Blocks.RemoveAt( index );

			for ( int i = index; i < m_Blocks.Count; i++ )
				m_Blocks[ i ].Index -= 1;
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves block to <paramref name="writer"/>.
		/// </summary>
		/// <param name="fileName">Name of the file (Destination).</param>
		public void Save( string fileName )
		{
			UpdateOffsets();

			string tempFile = fileName;
			bool exists = File.Exists( fileName );

			if ( exists )
				tempFile = fileName + ".temp";

			if ( m_FileInfo != null )
			{
				using ( FileStream source = new FileStream( m_FileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
				using ( FileStream destination = new FileStream( tempFile, FileMode.Create, FileAccess.Write ) )
				{
					using ( BinaryReader reader = new BinaryReader( source ) )
					using ( BinaryWriter writer = new BinaryWriter( destination ) )
					{
						m_Header.Save( writer );

						for ( int i = 0; i < m_Blocks.Count; i++ )
						{
							m_Blocks[ i ].Save( reader, writer );
						}
					}
				}
			}
			else
			{
				using ( FileStream destination = new FileStream( tempFile, FileMode.Create, FileAccess.Write ) )
				{
					using ( BinaryWriter writer = new BinaryWriter( destination ) )
					{
						m_Header.Save( writer );

						for ( int i = 0; i < m_Blocks.Count; i++ )
						{
							m_Blocks[ i ].Save( null, writer );
						}
					}
				}
			}

            if ( exists )
                File.Replace( tempFile, fileName, String.Format( "{0}.backup", m_FileInfo.FullName ), true );

            m_FileInfo = new FileInfo( fileName );
			m_Modified = false;
		}

		/// <summary>
		/// Updates <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/> within .uop file,
		/// <see cref="Mythic.Package.MythicPackageFile.CompressedSize"/> and <see cref="Mythic.Package.MythicPackageFile.DecompressedSize"/>.
		/// </summary>
		public void UpdateOffsets()
		{
			ulong pointer = (ulong) m_Header.StartAddress;

			for ( int i = 0; i < m_Blocks.Count; i++ )
			{
				m_Blocks[ i ].UpdateOffsets( ref pointer );
			}
		}
		#endregion

		#region Load File Descriptors
		/// <summary>
		/// Initializes <paramref name="cache"/> with all files (details) inside pacakge found at <paramref name="myp"/>.
		/// </summary>
		/// <param name="myp">Path to the mythic package.</param>
		/// <param name="cache">Dictionary to fill (used to quickly access to file address within .uop file).</param>
		public static void LoadFileDescriptors( string myp, Dictionary<ulong, FileDescriptor> cache )
		{
			if ( cache == null )
				throw new ArgumentNullException( "cache" );

			using ( FileStream stream = new FileStream( myp, FileMode.Open ) )
			{
				using ( BinaryReader reader = new BinaryReader( stream ) )
				{
					byte[] id = reader.ReadBytes( 4 );

					if ( id[ 0 ] != 'M' || id[ 1 ] != 'Y' || id[ 2 ] != 'P' || id[ 3 ] != 0 )
						throw new FormatException( "This is not a Mythic Package file!" );

					stream.Seek( 8, SeekOrigin.Current );
					long start = reader.ReadInt64();
					stream.Seek( start, SeekOrigin.Begin );

					MythicPackageFile file;
					int count;
					long next;

					do
					{
						count = reader.ReadInt32();
						next = reader.ReadInt64();

						for ( int i = 0; i < count; i++ )
						{
							file = new MythicPackageFile( reader, null );
							cache.Add( file.FileHash, new FileDescriptor( myp, file ) );
						}

						if ( next != 0 )
							stream.Seek( next, SeekOrigin.Begin );
					}
					while ( next != 0 );
				}
			}
		}
		#endregion

		#region Unpack
		/// <summary>
		/// Unpacks all files in this package to <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( string folder, bool fullPath )
		{
			using ( FileStream stream = File.OpenRead( m_FileInfo.FullName ) )
			{
				using ( BinaryReader source = new BinaryReader( stream ) )
				{
					for ( int i = 0; i < m_Blocks.Count; i++ )
						m_Blocks[ i ].Unpack( source, folder, fullPath );
				}
			}
		}

		/// <summary>
		/// Unpacks all files in the <paramref name="block"/> in this package to <paramref name="folder"/> from <paramref name="source"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		/// <param name="block">Index of the block in <see cref="Mythic.Package.MythicPackage.Blocks"/>.</param>
		public void Unpack( string folder, bool fullPath, int block )
		{
			if ( block < 0 || block > m_Blocks.Count - 1 )
				throw new ArgumentOutOfRangeException( "block" );

			m_Blocks[ block ].Unpack( folder, fullPath );
		}

		/// <summary>
		/// Unpacks a file in <paramref name="block"/> in this package to <paramref name="folder"/> from <paramref name="source"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		/// <param name="index">Index of the file in <see cref="Mythic.Package.MythicPackageBlock.Files"/>.</param>
		/// <param name="block">Index of the block in <see cref="Mythic.Package.MythicPackage.Blocks"/>.</param>
		public void Unpack( string folder, bool fullPath, int block, int index )
		{
			if ( block < 0 || block > m_Blocks.Count - 1 )
				throw new ArgumentOutOfRangeException( "block" );

			m_Blocks[ block ].Unpack( folder, fullPath, index );
		}
		#endregion
	}
}
