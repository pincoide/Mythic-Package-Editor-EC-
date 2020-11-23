using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mythic.Package
{
    /// <summary>
    /// Class describing block within .uop file.
    /// </summary>
    public class MythicPackageBlock
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

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
        /// Invoked when 1 file is opened, saved or unpacked.
        /// </summary>
        public static event UpdateProgress UpdateProgress;

        /// <summary>
        /// Size of the block header.
        /// </summary>
        public static int Size => 12;

        #endregion

        /// <summary>
        /// Reference to <see cref="MythicPackage"/>, which contains this block.
        /// </summary>
        public MythicPackage Parent { get; set; }

        /// <summary>
        /// Index of this block in the <see cref="MythicPackage.Blocks"/> table.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// List of containing <see cref="MythicPackageFile"/> files.
        /// </summary>
        public List<MythicPackageFile> Files { get; } = new List<MythicPackageFile>();

        /// <summary>
        /// Number of <see cref="MythicPackageFile"/> files in this block.
        /// </summary>
        public int FileCount { get; set; }

        /// <summary>
        /// Address of the next block within .uop file.
        /// </summary>
        public long NextBlock { get; set; }

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
        /// Indicates if this is a new block in <see cref="MythicPackage.Blocks"/> table.
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

        /// <summary>
        /// Indicates a full block.
        /// </summary>
        public bool IsFull => Files.Count >= Parent.Header.BlockSize;

        /// <summary>
        /// Indicates an empty block.
        /// </summary>
        public bool IsEmpty => Files.Count == 0;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MythicPackageBlock()
        {
            FileCount = 0;
            NextBlock = 0;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MythicPackageBlock( MythicPackage parent )
        {
            // set the block parent
            Parent = parent;

            // initialize with 0 files
            FileCount = 0;

            // initialize with no next blocks
            NextBlock = 0;

            // flag that is a new block
            m_Added = true;

            // set the block index
            Index = parent.Blocks.Count;

            // add the block to the uop blocks list
            parent.Blocks.Add( this );
        }

        /// <summary>
        /// Initializes a new instance from <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">Binary file (.uop source).</param>
        /// <param name="parent">Parent package.</param>
        public MythicPackageBlock( BinaryReader reader, MythicPackage parent )
        {
            // set the uop file as parent
            Parent = parent;

            // get the saved files count for the block
            FileCount = reader.ReadInt32();

            // get the address of the next block (0 if there is no next)
            NextBlock = reader.ReadInt64();

            // set the block index
            Index = parent.Blocks.Count;

            // add the block to the uop blocks list
            parent.Blocks.Add( this );

            // index to keep track how many files we tried to load
            // NOTE: the actual number of files is sometimes less than the filecount, so we need to track the index separately
            int index = 0;

            do
            {
                // load the next file
                new MythicPackageFile( reader, this );

                // increase the files index
                index++;
            }
            // keep loading until we got all files
            while ( index < FileCount );

            // fix the file count (some uop files have a file count higher than the real number of files)
            if ( Files.Count != FileCount )
                FileCount = Files.Count;
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region OVERRIDES
        // --------------------------------------------------------------

        /// <summary>
        /// Returns a <see cref="string"/> that represents this.
        /// </summary>
        /// <returns>Constructed String.</returns>
        public override string ToString()
        {
            // intialize the text to return
            string value = string.Format( "Block_{0}", Index );

            // if the file has been modified (this is an existing block), we add * after the name
            if ( Modified && !Added )
                value = string.Format( "{0}*", value );

            // if the file has been modified (this is a new block), we add + after the name
            if ( Modified && Added )
                value = string.Format( "{0}+", value );

            return value;
        }
        #endregion

        // --------------------------------------------------------------
        #region SEARCH
        // --------------------------------------------------------------

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Index of the <see cref="MythicPackageFile"/> in <see cref="Files"/> table.</returns>
        public int Search( string keyword )
        {
            return Search( 0, keyword );
        }

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files.
        /// </summary>
        /// <param name="istart">Start file index.</param>
        /// <param name="keyword"></param>
        /// <returns>Index of the <see cref="MythicPackageFile"/> in <see cref="Files"/> table.</returns>
        public int Search( int istart, string keyword )
        {
            // starting file out of range? throw an exception
            if ( istart < 0 || istart > Files.Count - 1 )
                throw new ArgumentOutOfRangeException( "bstart" );

            // no keyword to search? throw an exception
            if ( string.IsNullOrEmpty( keyword ) )
                throw new ArgumentNullException( "keyword" );

            // search the files for the keyword
            foreach ( MythicPackageFile f in Files )
                if ( f.Index > istart && f.Search( keyword ) )
                    return f.Index;

            // if we got here, we found nothing
            return SearchResult.NotFoundResult;
        }

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files. Checking
        /// only <paramref name="keyword"/> hash.
        /// </summary>
        /// <param name="hash">Hash of <paramref name="keyword"/></param>
        /// <param name="keyword"></param>
        /// <returns>Index of the <see cref="MythicPackageFile"/> in <see cref="Files"/> table.</returns>
        public int SearchHash( ulong hash, string keyword )
        {
            // no keyword to search? throw an exception
            if ( string.IsNullOrEmpty( keyword ) )
                throw new ArgumentNullException( "keyword" );

            // search the files for the keyword
            foreach ( MythicPackageFile f in Files )
                if ( f.SearchHash( hash, keyword ) )
                    return f.Index;

            // if we got here, we found nothing
            return SearchResult.NotFoundResult;
        }

        #endregion

        // --------------------------------------------------------------
        #region ADD/REMOVE FILES
        // --------------------------------------------------------------

        /// <summary>
        /// Adds a file, located in <paramref name="fileName"/>, to <see cref="Files"/> table.
        /// </summary>
        /// <param name="fileName">Path to a file on HD.</param>
        /// <param name="innerFolder">Relative folder within the UOP file (destination).</param>
        /// <param name="flag">Compression type.</param>
        public void AddFile( string fileName, string innerFolder, CompressionFlag flag )
        {
            // no file name? throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, generate an exception
            if ( !File.Exists( fileName ) )
                if ( !File.Exists( fileName ) )
                    throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // is the block full? throw an exception
            if ( IsFull )
                throw new BlockFullException();

            // add the new file
            new MythicPackageFile( fileName, innerFolder, flag, this, true );

            // fix the file count
            FileCount = Files.Count;

            // update the total files count
            Parent.Header.FileCount += 1;
        }

        /// <summary>
        /// Removes a file from <see cref="Files"/>.
        /// </summary>
        /// <param name="index">Index of the file to remove.</param>
        public void RemoveFile( int index )
        {
            // indexout of range? throw an exception
            if ( index < 0 || index > Files.Count - 1 )
                throw new ArgumentOutOfRangeException( "index" );

            // remove the file
            Files.RemoveAt( index );

            // update the total files count
            Parent.Header.FileCount -= 1;

            // is the block empty? then we can remove it
            if ( IsEmpty )
                Parent.RemoveBlock( Index );

            else // the block still has files in it
            {
                // decrease the index of all the files that came after the one we removed
                for ( int i = index; i < Files.Count; i++ )
                {
                    Files[i].Index -= 1;
                    Files[i].GlobalIndex -= 1;
                }

                // update the files count
                FileCount = Files.Count;
            }

            // flag the block as modified
            Modified = true;
        }

        /// <summary>
        /// Removes this block from <see cref="MythicPackage"/>.
        /// </summary>
        public void Remove()
        {
            // delete this block
            Parent.RemoveBlock( Index );
        }

        #endregion

        // --------------------------------------------------------------
        #region SAVE
        // --------------------------------------------------------------

        /// <summary>
        /// Saves block to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">Binary file (.uop destination).</param>
        /// <param name="reader">Binary file (.uop source).</param>
        public void Save( BinaryWriter writer, BinaryReader reader = null )
        {
            // write the files count
            writer.Write( Files.Count );

            // write the address of the next block (0 if there is no next block)
            writer.Write( NextBlock );

            // save all files headers
            foreach ( MythicPackageFile f in Files )
                f.Save( writer );

            // scan all files to save the file data
            foreach ( MythicPackageFile f in Files )
            {
                // save the file data
                f.SaveData( writer, reader );

                // update the progress bar (if one is available)
                UpdateProgress?.Invoke( f.GlobalIndex, Parent.Header.FileCount );
            }

            // reset the modified flags
            m_Modified = false;
            m_Added = false;
        }

        /// <summary>
        /// Updates <see cref="MythicPackageFile.DataBlockAddress"/> of all files within this block.
        /// </summary>
        /// <param name="pointer">Address of this block.</param>
        public void UpdateOffsets( ref ulong pointer )
        {
            // calculate the size of the files header
            pointer += (ulong)( Size + ( Files.Count * MythicPackageFile.Size ) );

            // scan all files
            foreach ( MythicPackageFile f in Files )
            {
                // update the data address for the current file
                f.UpdateOffsets( ref pointer );

                // update the progress bar (if one is available)
                UpdateProgress?.Invoke( f.GlobalIndex, Parent.Header.FileCount );
            }

            // are there more blocks after this one?
            if ( Index < Parent.Blocks.Count - 1 )

                // set the address of the next block
                NextBlock = (long)pointer;

            else // no more blocks, we can set the address to 0
                NextBlock = 0;
        }

        #endregion

        // --------------------------------------------------------------
        #region UNPACK
        // --------------------------------------------------------------

        /// <summary>
        /// Unpacks all files in this block to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it has to retain the relative folder structure?</param>
        public void Unpack( string folder, bool fullPath )
        {
            // start reading the uop data
            using ( FileStream stream = File.OpenRead( Parent.FileInfo.FullName ) )
            using ( BinaryReader source = new BinaryReader( stream ) )
            {
                // scan all files in the block
                foreach ( MythicPackageFile f in Files )
                {
                    // unpack the file
                    f.Unpack( source, folder, fullPath );

                    // update the progress bar (if one is available)
                    UpdateProgress?.Invoke( f.GlobalIndex, Parent.Header.FileCount );
                }
            }
        }

        /// <summary>
        /// Unpacks file at <paramref name="index"/> in this block to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain the relative folder structure?</param>
        /// <param name="index">Index of the file in <see cref="Files"/>.</param>
        public void Unpack( string folder, bool fullPath, int index )
        {
            // indexout of range? throw an exception
            if ( index < 0 || index > Files.Count - 1 )
                throw new ArgumentOutOfRangeException( "index" );

            // unpack the file
            Files[index].Unpack( folder, fullPath );

            // update the progress bar (if one is available)
            UpdateProgress?.Invoke( Files[index].GlobalIndex, Parent.Header.FileCount );
        }

        /// <summary>
        /// Unpacks all files in this block to <paramref name="folder"/> from <paramref name="source"/>.
        /// </summary>
        /// <param name="source">Binary file (.uop source).</param>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain relative folder structure?</param>
        public void Unpack( BinaryReader source, string folder, bool fullPath )
        {
            // scan all files to unpack them all
            foreach ( MythicPackageFile f in Files )
            {
                // unpack the file
                f.Unpack( source, folder, fullPath );

                // update the progress bar (if one is available)
                UpdateProgress?.Invoke( f.GlobalIndex, Parent.Header.FileCount );
            }
        }

        #endregion

        /// <summary>
        /// Reloads file names from the dictionary.
        /// </summary>
        public void RefreshFileNames()
        {
            // refresh all files names
            foreach ( MythicPackageFile f in Files )
                f.RefreshFileName();
        }

        /// <summary>
        /// Get a list of all the files with an unknown name inside this block.
        /// </summary>
        /// <returns>List of all the files inside this block with unknown names.</returns>
        public List<MythicPackageFile> GetAllUnnamedFiles()
        {
            // get all the files with an unknown name
            return Files.Where( f => string.IsNullOrEmpty( f.FileName ) || !f.VerifyFileName() ).ToList();
        }

        #endregion
    }
}
