using System;
using System.IO;
using System.Collections.Generic;

namespace Mythic.Package
{
	/// <summary>
	/// Class describing block within .uop file.
	/// </summary>
	public class MythicPackageBlock
	{
		#region UpdateProgress
		/// <summary>
		/// Invoked when 1 file is opened, saved or unpacked.
		/// </summary>
		public static event UpdateProgress UpdateProgress;
		#endregion

		#region Size
		/// <summary>
		/// Size of the block header.
		/// </summary>
		public static int Size{ get{ return 12; } }
		#endregion

		#region Parent
		private MythicPackage m_Parent;

		/// <summary>
		/// Reference to <see cref="Mythic.Package.MythicPackage"/>, which contains this block.
		/// </summary>
		public MythicPackage Parent
		{
			get{ return m_Parent; }
			set{ m_Parent = value; }
		}
		#endregion

		#region Index
		private int m_Index;

		/// <summary>
		/// Index of this block in the <see cref="Mythic.Package.MythicPackage.Blocks"/> table.
		/// </summary>
		public int Index
		{
			get{ return m_Index; }
			set{ m_Index = value; }
		}
		#endregion

		#region Files
		private List<MythicPackageFile> m_Files = new List<MythicPackageFile>();

		/// <summary>
		/// List of containing <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		public List<MythicPackageFile> Files
		{
			get{ return m_Files; }
		}
		#endregion

		#region FileCount
		private int m_FileCount;

		/// <summary>
		/// Number of <see cref="Mythic.Package.MythicPackageFile"/> files in this block.
		/// </summary>
		public int FileCount
		{
			get{ return m_FileCount; }
			set { m_FileCount = value; }
		}
		#endregion

		#region NextBlock
		private long m_NextBlock;

		/// <summary>
		/// Address of the next block within .uop file.
		/// </summary>
		public long NextBlock
		{
			get{ return m_NextBlock; }
			set{ m_NextBlock = value; }
		}
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
		/// Indicates if this is a new block in <see cref="Mythic.Package.MythicPackage.Blocks"/> table.
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

		#region IsFull
		/// <summary>
		/// Indicates a full block.
		/// </summary>
		public bool IsFull{ get{ return m_FileCount >= m_Parent.Header.BlockSize; } }
		#endregion

		#region IsEmpty
		/// <summary>
		/// Indicates an empty block.
		/// </summary>
		public bool IsEmpty{ get{ return m_FileCount == 0; } }
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public MythicPackageBlock()
		{
			m_FileCount = 0;
			m_NextBlock = 0;
		}

		/// <summary>
		/// Initializes a new instance from <paramref name="reader"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="parent">Parent package.</param>
		/// <param name="filesToLoad">Amount of files to load (default = block size)</param>
		/// <param name="noHeader">Do we have to load the block header?</param>
		public MythicPackageBlock( BinaryReader reader, MythicPackage parent, int filesToLoad = 0, bool noHeader = false )
		{
			m_Parent = parent;

			m_FileCount = 0;
			m_NextBlock = 0;

			if ( !noHeader )
            {
				m_FileCount = reader.ReadInt32();
				m_NextBlock = reader.ReadInt64();
			}

			if ( filesToLoad == 0 )
				filesToLoad = parent.Header.BlockSize;

			MythicPackageFile file;
			int index = 0;

			do
			{
				file = new MythicPackageFile( reader, this );
				file.Index = index++;

				if ( file.DataBlockAddress != 0 )
					m_Files.Add( file );

				UpdateProgress( parent.Blocks.Count * parent.Header.BlockSize + index, parent.Header.FileCount );
			}
			while ( index < filesToLoad );
		}
		#endregion

		#region ToString
		/// <summary>
		/// Returns a <see cref="String"/> that represents this.
		/// </summary>
		/// <returns>Constructed String.</returns>
		public override string ToString()
		{
			return String.Format( "Block_{0}", m_Index );
		}
		#endregion

		#region Search
		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns>Index of the <see cref="Mythic.Package.MythicPackageFile"/> in <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.</returns>
		public int Search( string keyword )
		{
			return Search( 0, keyword );
		}

		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files.
		/// </summary>
		/// <param name="istart">Start file index.</param>
		/// <param name="keyword"></param>
		/// <returns>Index of the <see cref="Mythic.Package.MythicPackageFile"/> in <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.</returns>
		public int Search( int istart, string keyword )
		{
			if ( istart < 0 || istart > m_Files.Count - 1 )
				throw new ArgumentOutOfRangeException( "bstart" );

			if ( keyword == null )
				throw new ArgumentNullException( "keyword" );

			for ( int i = istart; i < m_Files.Count; i++ )
			{
				if ( m_Files[ i ].Search( keyword ) )
					return i;
			}

			return SearchResult.NotFoundResult;
		}

		/// <summary>
		/// Searches for <paramref name="keyword"/> in <see cref="Mythic.Package.MythicPackageFile"/> files. Checking
		/// only <paramref name="keyword"/> hash.
		/// </summary>
		/// <param name="hash">Hash of <paramref name="keyword"/></param>
		/// <param name="keyword"></param>
		/// <returns>Index of the <see cref="Mythic.Package.MythicPackageFile"/> in <see cref="Mythic.Package.MythicPackageBlock.Files"/> table.</returns>
		public int SearchHash( ulong hash, string keyword )
		{
			for ( int i = 0; i < m_Files.Count; i++ )
			{
				if ( m_Files[ i ].SearchHash( hash, keyword ) )
					return i;
			}

			return SearchResult.NotFoundResult;
		}
		#endregion

		#region RefreshFileNames
		/// <summary>
		/// Reloads file names from the dictionary.
		/// </summary>
		public void RefreshFileNames()
		{
			for ( int i = 0; i < m_Files.Count; i++ )
				m_Files[ i ].RefreshFileName();
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

			if ( IsFull )
				throw new BlockFullException();

			MythicPackageFile index = new MythicPackageFile( fileName, innerFolder, flag );
			index.Parent = this;
			index.Index = m_Files.Count;
			index.Added = true;

			m_FileCount += 1;
			m_Files.Add( index );

			m_Parent.Header.FileCount += 1;
		}
		#endregion

		#region Remove
		/// <summary>
		/// Removes this block from <see cref="Mythic.Package.MythicPackage"/>.
		/// </summary>
		public void Remove()
		{
			m_Parent.RemoveBlock( m_Index );
		}

		/// <summary>
		/// Removes a file from <see cref="Mythic.Package.MythicPackageBlock.Files"/>.
		/// </summary>
		/// <param name="index">Index of the file to remove.</param>
		public void RemoveFile( int index )
		{
			m_Files.RemoveAt( index );

			for ( int i = index; i < m_Files.Count; i++ )
				m_Files[ i ].Index -= 1;

			m_FileCount -= 1;
			m_Parent.Header.FileCount -= 1;

			if ( IsEmpty )
				m_Parent.RemoveBlock( m_Index );
		}
		#endregion

		#region Save
		/// <summary>
		/// Saves block to <paramref name="writer"/>.
		/// </summary>
		/// <param name="reader">Binary file (.uop source).</param>
		/// <param name="writer">Binary file (.uop destination).</param>
		public void Save( BinaryReader reader, BinaryWriter writer )
		{
			writer.Write( m_FileCount );
			writer.Write( m_NextBlock );

			for ( int i = 0; i < m_Files.Count; i++ )
			{
				m_Files[ i ].Save( writer );
			}

			byte[] empty = new byte[ MythicPackageFile.Size * ( m_FileCount ) ];
			Array.Clear( empty, 0, empty.Length );
			writer.Write( empty );

			for ( int i = 0; i < m_Files.Count; i++ )
			{
				m_Files[ i ].SaveData( reader, writer );

				if ( UpdateProgress != null )
					UpdateProgress( m_Parent.Header.FileCount + m_Index * m_Parent.Header.BlockSize + i, m_Parent.Header.FileCount * 2 );
			}

			m_Modified = false;
			m_Added = false;
		}
		#endregion

		#region UpdateOffsets
		/// <summary>
		/// Updates <see cref="Mythic.Package.MythicPackageFile.DataBlockAddress"/> of all files within this block.
		/// </summary>
		/// <param name="pointer">Address of this block.</param>
		public void UpdateOffsets( ref long pointer )
		{
			pointer += MythicPackageBlock.Size + m_Parent.Header.BlockSize * MythicPackageFile.Size;

			for ( int i = 0; i < m_Files.Count; i++ )
			{
				m_Files[ i ].UpdateOffsets( ref pointer );

				if ( UpdateProgress != null )
					UpdateProgress( m_Index * m_Parent.Header.BlockSize + i, m_Parent.Header.FileCount * 2 );
			}

			if ( m_Index < m_Parent.Blocks.Count - 1 )
				m_NextBlock = pointer;
			else
				m_NextBlock = 0;
		}
		#endregion

		#region Unpack
		/// <summary>
		/// Unpacks all files in this block to <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( string folder, bool fullPath )
		{
			using ( FileStream stream = File.OpenRead( m_Parent.FileInfo.FullName ) )
			{
				using ( BinaryReader source = new BinaryReader( stream ) )
				{
					for ( int i = 0; i < m_Files.Count; i++ )
					{
						m_Files[ i ].Unpack( source, folder, fullPath );

						if ( UpdateProgress != null )
							UpdateProgress( m_Index * m_Parent.Header.BlockSize + i, m_Parent.Header.FileCount );
					}
				}
			}
		}

		/// <summary>
		/// Unpacks file at <paramref name="index"/> in this block to <paramref name="folder"/>.
		/// </summary>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		/// <param name="index">Index of the file in <see cref="Mythic.Package.MythicPackageBlock.Files"/>.</param>
		public void Unpack( string folder, bool fullPath, int index )
		{
			if ( index < 0 || index > m_Files.Count - 1 )
				throw new ArgumentOutOfRangeException( "index" );

			m_Files[ index ].Unpack( folder, fullPath );

			if ( UpdateProgress != null )
				UpdateProgress( m_Index * m_Parent.Header.BlockSize + index, m_Parent.Header.FileCount );
		}

		/// <summary>
		/// Unpacks all files in this block to <paramref name="folder"/> from <paramref name="source"/>.
		/// </summary>
		/// <param name="source">Binary file (.uop source).</param>
		/// <param name="folder">Destination folder.</param>
		/// <param name="fullPath">Does it retain KR folder structure.</param>
		public void Unpack( BinaryReader source, string folder, bool fullPath )
		{
			for ( int i = 0; i < m_Files.Count; i++ )
			{
				m_Files[ i ].Unpack( source, folder, fullPath );

				if ( UpdateProgress != null )
					UpdateProgress( m_Index * m_Parent.Header.BlockSize + i, m_Parent.Header.FileCount );
			}
		}
		#endregion
	}
}
