using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        None    = 0x0,

        /// <summary>
        /// Zlib.
        /// </summary>
        Zlib    = 0x1
    }

    /// <summary>
    /// Class describing .uop file.
    /// </summary>
    public class MythicPackage
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Reference to <see cref="FileInfo"/>.
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// Reference to <see cref="MythicPackageHeader"/>.
        /// </summary>
        public MythicPackageHeader Header { get; }

        /// <summary>
        /// List of <see cref="MythicPackageBlock"/> in this file.
        /// </summary>
        public List<MythicPackageBlock> Blocks { get; } = new List<MythicPackageBlock>();

        /// <summary>
        /// Indicates if this package has been changed (added, removed or changed a file).
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// Flag indicating that this is a new file
        /// </summary>
        public bool Added { get; set; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTORS
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of Mythic Package File.
        /// </summary>
        public MythicPackage() : this( MythicPackageHeader.SupportedVersion )
        {
            // set the modified and new flag
            Added = true;
            Modified = true;
        }

        /// <summary>
        /// Initializes a new instance of Mythic Package File.
        /// <param name="version">Version of the file.</param>
        /// </summary>
        public MythicPackage( int version )
        {
            // create the header
            Header = new MythicPackageHeader( version );

            // set the modified and new flag
            Added = true;
            Modified = true;
        }

        /// <summary>
        /// Initializes a new Instance from <paramref name="fileName"/>.
        /// </summary>
        /// <param name="fileName">Path to .uop file.</param>
        public MythicPackage( string fileName )
        {
            // if the file doesn't exist, throw an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // open the uop file
            using ( FileStream stream = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
            using ( BinaryReader reader = new BinaryReader( stream ) )
            {
                // get the file info for the UOP file
                FileInfo = new FileInfo( fileName );

                // get the file header
                Header = new MythicPackageHeader( reader );

                // move to the starting point to start reading the blocks
                stream.Seek( (long)Header.StartAddress, SeekOrigin.Begin );

                // initialize the block variable
                MythicPackageBlock block;

                do // load the block
                    block = new MythicPackageBlock( reader, this );

                // keep loading until we have a next block address
                while ( stream.Seek( block.NextBlock, SeekOrigin.Begin ) != 0 );
            }
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
            // initialize the text to return
            string value;

            // do we have the file informations?
            if ( FileInfo != null )

                // get the file name
                value = FileInfo.Name;

            else // since we don't have the file name, we just use a default name...
                value = "unsaved package.uop";

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
        #region UNPACK
        // --------------------------------------------------------------

        /// <summary>
        /// Unpacks all files in this package to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain relative folder structure?</param>
        public void Unpack( string folder, bool fullPath )
        {
            using ( FileStream stream = File.OpenRead( FileInfo.FullName ) )
            using ( BinaryReader source = new BinaryReader( stream ) )
            {
                // unpack all files of all blocks
                foreach ( MythicPackageBlock b in Blocks )
                    b.Unpack( source, folder, fullPath );
            }
        }

        /// <summary>
        /// Unpacks all files in the <paramref name="block"/> in this package to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain relative folder structure?</param>
        /// <param name="block">Index of the block in <see cref="Blocks"/>.</param>
        public void Unpack( string folder, bool fullPath, int block )
        {
            // if the block is out of range, we throw an exception
            if ( block < 0 || block > Blocks.Count - 1 )
                throw new ArgumentOutOfRangeException( "block" );

            // unpack the all the files in the block
            Blocks[block].Unpack( folder, fullPath );
        }

        /// <summary>
        /// Unpacks a file in <paramref name="block"/> in this package to <paramref name="folder"/>.
        /// </summary>
        /// <param name="folder">Destination folder.</param>
        /// <param name="fullPath">Does it retain relative folder structure?</param>
        /// <param name="index">Index of the file in <see cref="MythicPackageBlock.Files"/>.</param>
        /// <param name="block">Index of the block in <see cref="Blocks"/>.</param>
        public void Unpack( string folder, bool fullPath, int block, int index )
        {
            // if the block is out of range, we throw an exception
            if ( block < 0 || block > Blocks.Count - 1 )
                throw new ArgumentOutOfRangeException( "block" );

            // unpack the file
            Blocks[block].Unpack( folder, fullPath, index );
        }

        #endregion

        // --------------------------------------------------------------
        #region SEARCH
        // --------------------------------------------------------------

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns><see cref="SearchResult"/></returns>
        public SearchResult Search( string keyword )
        {
            return Search( 0, 0, keyword );
        }

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files.
        /// </summary>
        /// <param name="bstart">Start block index.</param>
        /// <param name="keyword"></param>
        /// <returns><see cref="SearchResult"/></returns>
        public SearchResult Search( int bstart, string keyword )
        {
            return Search( bstart, 0, keyword );
        }

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files.
        /// </summary>
        /// <param name="bstart">Start block index.</param>
        /// <param name="istart">Start file index.</param>
        /// <param name="keyword"></param>
        /// <returns><see cref="SearchResult"/></returns>
        public SearchResult Search( int bstart, int istart, string keyword )
        {
            // starting block out of range? throw an exception
            if ( bstart < 0 || bstart > Blocks.Count - 1 )
                throw new ArgumentOutOfRangeException( "bstart" );

            // no keyword to search? throw an exception
            if ( string.IsNullOrEmpty( keyword ) )
                throw new ArgumentNullException( "keyword" );

            // search the block files from istart for kyeword
            int idx = Blocks[bstart].Search( istart, keyword );

            // if we found something we can return the result
            if ( idx > -1 )
                return new SearchResult( bstart, idx );

            // scan all blocks
            foreach ( MythicPackageBlock b in Blocks )
            {
                idx = b.Search( keyword );

                // if we found something we can return the result
                if ( idx > -1 )
                    return new SearchResult( b.Index, idx );
            }

            // if we got here, we found nothing
            return SearchResult.NotFound;
        }

        /// <summary>
        /// Searches for <paramref name="keyword"/> in <see cref="MythicPackageFile"/> files. Checking
        /// only <paramref name="keyword"/> hash.
        /// </summary>
        /// <param name="hash">Hash of <paramref name="keyword"/></param>
        /// <param name="keyword"></param>
        /// <returns>Index of the <see cref="MythicPackageFile"/> in <see cref="MythicPackageBlock.Files"/> table.</returns>
        public SearchResult SearchHash( ulong hash, string keyword )
        {
            // no keyword to search? throw an exception
            if ( string.IsNullOrEmpty( keyword ) )
                throw new ArgumentNullException( "keyword" );

            // scan all blocks
            foreach ( MythicPackageBlock b in Blocks )
            {
                // search for the hash in the current block
                int idx = b.SearchHash( hash, keyword );

                // if we found something we can return the result
                if ( idx > -1 )
                    return new SearchResult( b.Index, idx );
            }

            // if we got here, we found nothing
            return SearchResult.NotFound;
        }

        /// <summary>
        /// Search the exact file name inside the UOP file
        /// </summary>
        /// <param name="fileName">EXACT file name to search</param>
        /// <returns>Index of the <see cref="MythicPackageFile"/> in <see cref="MythicPackageBlock.Files"/> table.</returns>
        public SearchResult SearchExactFileName( string fileName )
        {
            // search for the exact file name
            MythicPackageFile found = ( from b in Blocks
                                        from f in b.Files
                                        where !string.IsNullOrEmpty( f.FileName ) && ( f.Search( fileName ) || f.Search( Path.GetFileName( fileName ) ) )
                                        select f ).FirstOrDefault();

            // did we find the file?
            if ( found != null )
                return new SearchResult( found.Parent.Index, found.Index, HashDictionary.AddedFilenames.Contains( found.FileHash ) );

            // if we got here, we found nothing
            return SearchResult.NotFound;
        }

        #endregion

        // --------------------------------------------------------------
        #region ADD/REMOVE FILES
        // --------------------------------------------------------------

        /// <summary>
        /// Adds a file, located in <paramref name="fileName"/>, to <see cref="MythicPackageBlock.Files"/> table.
        /// </summary>
        /// <param name="fileName">Path to a file on HD.</param>
        /// <param name="innerFolder">Relative folder within the UOP file (destination).</param>
        /// <param name="flag">Compression type.</param>
        public void AddFile( string fileName, string innerFolder, CompressionFlag flag = CompressionFlag.Zlib )
        {
            // empty file name? throw an exception
            if ( string.IsNullOrEmpty( fileName ) )
                throw new ArgumentException( "fileName" );

            // if the file doesn't exist, throw an exception
            if ( !File.Exists( fileName ) )
                throw new Exception( string.Format( "Cannot find {0}!", Path.GetFileName( fileName ) ) );

            // initialize the block variable to use
            MythicPackageBlock block;

            // do we have at least one block in the file?
            if ( Blocks.Count > 0 )

                // use the last block
                block = Blocks[Blocks.Count - 1];

            else // create a new block
                block = NewBlock();

            // is the block full? create a new block then
            if ( block.IsFull )
                block = NewBlock();

            // add the file to the block
            block.AddFile( fileName, innerFolder, flag );
        }

        /// <summary>
        /// Adds a multiple files, located in <paramref name="fileNames"/>, to <see cref="MythicPackageBlock.Files"/> table.
        /// </summary>
        /// <param name="fileNames">Array of file paths on HD.</param>
        /// <param name="innerFolder">Relative folder within the UOP file (destination).</param>
        /// <param name="flag">Compression type.</param>
        public void AddFiles( string[] fileNames, string innerFolder, CompressionFlag flag = CompressionFlag.Zlib )
        {
            // parse all the files in the array
            foreach ( string file in fileNames )

                // add the file inside the first block that can accomodate it
                AddFile( file, innerFolder, flag );
        }

        /// <summary>
        /// Adds all files within a certain folder to .uop package.
        /// </summary>
        /// <param name="folder">Folder, which contains files.</param>
        /// <param name="flag">Compression type.</param>
        public void AddFolder( string folder, CompressionFlag flag = CompressionFlag.Zlib )
        {
            // if the folder doesn't exist, we throw an exception
            if ( !Directory.Exists( folder ) )
                throw new ArgumentException( string.Format( "'{0}' is not a folder!", folder ) );

            // create a stack of strings
            Stack<string> stack = new Stack<string>();

            // add the main folder to the stack
            stack.Push( folder );

            // keep looping until we parsed all folders
            while ( stack.Count > 0 )
            {
                // get the current folder
                string f = stack.Pop();

                // remove the root path (to create the relative path to use inside the uop)
                string inner = f.Remove( 0, folder.Length );

                try // we use a try because if in the folder there is something weird (like a link), we would get an exception
                {
                    // add all the files in this folder
                    foreach ( string file in Directory.GetFiles( f ) )
                        AddFile( file, inner, flag );

                    // add all the sub-folders of this folder inside the stack
                    foreach ( string newFolder in Directory.GetDirectories( f ) )
                        stack.Push( newFolder );
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Replace the existing files inside the current package with the one with the same names provided on the files list.
        /// </summary>
        /// <param name="filesList">List of the files to replace</param>
        /// <param name="rootDir">Root directory of the file structure. Used to create the relative path for the files to add. Only necessary if <paramref name="addMissing"/> is true.</param>
        /// <param name="addMissing">Do we need to add the files that are not present in the current package?</param>
        /// <param name="flag">Compression type.</param>
        public void ReplaceFiles( List<string> filesList, string rootDir = "", bool addMissing = false, CompressionFlag flag = CompressionFlag.Zlib )
        {
            // create a queue for the files
            Queue<string> q = new Queue<string>(filesList);

            // keep looping until the queue is empty
            while ( q.Count > 0 )
            {
                // get the file from the list and make sure is lower case
                string currFile = q.Dequeue().ToLower();

                // search for a file with the current file name
                MythicPackageFile found = ( from b in Blocks
                                            from f in b.Files
                                            where !string.IsNullOrEmpty( f.FileName ) && Path.GetFileName( f.FileName ) == Path.GetFileName( currFile )
                                            select f ).FirstOrDefault();

                // if we found a file, we execute the replace
                if ( found != null )
                    found.Replace( currFile, found.FilePath, flag );

                // if the file doesn't exit, we add it to the archive (if addMissing is true)
                else if ( addMissing )
                    AddFile( currFile, GetRelativePath( rootDir, currFile ) );
            }
        }

        /// <summary>
        /// Removes a file from <see cref="MythicPackageBlock.Files"/>.
        /// </summary>
        /// <param name="block">Index of the block.</param>
        /// <param name="index">Index of the file to remove.</param>
        public void RemoveFile( int block, int index )
        {
            // block index of range? throw an exception
            if ( block < 0 || block > Blocks.Count - 1 )
                throw new ArgumentOutOfRangeException( "block" );

            // file index out of range? throw an exception
            if ( index < 0 || index > Blocks[block].Files.Count - 1 )
                throw new ArgumentOutOfRangeException( "index" );

            // remove the file
            Blocks[block].RemoveFile( index );
        }

        /// <summary>
        /// Removes a block from <see cref="Blocks"/>.
        /// </summary>
        /// <param name="index">Index of the block to remove.</param>
        public void RemoveBlock( int index )
        {
            // block out of range? throw an exception
            if ( index < 0 || index > Blocks.Count - 1 )
                throw new ArgumentOutOfRangeException( "index" );

            // get the block at the specified index
            MythicPackageBlock block = Blocks[index];

            // flag the uop file as modified
            Modified = true;

            // get the amount of files removed
            int removedFiles = block.FileCount;

            // remove the files count of this block from the total files count
            Header.FileCount -= removedFiles;

            // remove the block
            Blocks.RemoveAt( index );

            // decrease the index of all the blocks that came after the one we removed
            for ( int i = index; i < Blocks.Count; i++ )
            {
                // update the block index
                Blocks[i].Index -= 1;

                // decrease the global index of all the files in the block
                foreach ( MythicPackageFile f in Blocks[i].Files )
                    f.GlobalIndex -= removedFiles;
            }
        }

        #endregion

        /// <summary>
        /// Reloads file names from the dictionary.
        /// </summary>
        public void RefreshFileNames()
        {
            // refresh the file name of all the files in all the blocks
            foreach ( MythicPackageBlock b in Blocks )
                b.RefreshFileNames();
        }

        /// <summary>
        /// Initializes <paramref name="cache"/> with all files (details) inside pacakge found at <paramref name="myp"/>.
        /// </summary>
        /// <param name="myp">Path to the mythic package.</param>
        /// <param name="cache">Dictionary to fill (used to quickly access to file address within .uop file).</param>
        public static void LoadFileDescriptors( string myp, Dictionary<ulong, FileDescriptor> cache )
        {
            // no dictionary specified? throw an exception
            if ( cache == null )
                throw new ArgumentNullException( "cache" );

            // open the UOP file
            using ( FileStream stream = new FileStream( myp, FileMode.Open ) )
            using ( BinaryReader reader = new BinaryReader( stream ) )
            {
                // read the file header
                byte[] id = reader.ReadBytes( 4 );

                // is this a uop file header?
                if ( id[0] != 'M' || id[1] != 'Y' || id[2] != 'P' || id[3] != 0 )
                    throw new FormatException( "This is not a Mythic Package file!" );

                // read the last part of the header
                stream.Seek( 8, SeekOrigin.Current );

                // get the first block address
                long start = reader.ReadInt64();

                // move to the address position
                stream.Seek( start, SeekOrigin.Begin );

                // next block address
                long next;

                do
                {
                    // get the files count
                    int count = reader.ReadInt32();

                    // get the next block address
                    next = reader.ReadInt64();

                    // read all files inside the block
                    for ( int i = 0; i < count; i++ )
                    {
                        // get the file data
                        MythicPackageFile file = new MythicPackageFile( reader );

                        // store the file descriptor
                        cache.Add( file.FileHash, new FileDescriptor( myp, file ) );
                    }
                } // keep loading until we have a next block address
                while ( stream.Seek( next, SeekOrigin.Begin ) != 0 );
            }
        }

        // --------------------------------------------------------------
        #region SAVE
        // --------------------------------------------------------------

        /// <summary>
        /// Saves the uop file
        /// </summary>
        /// <param name="fileName">Name of the uop file (Destination).</param>
        public void Save( string fileName )
        {
            // make sure the file name is viable
            if ( Path.GetFileName( fileName ).IndexOfAny( Path.GetInvalidFileNameChars() ) >= 0 )
                throw new Exception( string.Format( "Invalid file name {0}!", Path.GetFileName( fileName ) ) );

            // update the location address inside the file of all blocks and files
            UpdateOffsets();

            // store the file name as a temporary file name to use
            string tempFile = fileName;

            // does the file specified already exist?
            bool exists = File.Exists( fileName );

            // if the file already exist, we create a temporary one with .temp extension (removed later)
            if ( exists )
                tempFile = fileName + ".temp";

            // if we have the fileinfo, then this is a file we open before (not created from scratch)
            if ( FileInfo != null )
            {
                // start writing the file
                using ( FileStream source = new FileStream( FileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
                using ( FileStream destination = new FileStream( tempFile, FileMode.Create, FileAccess.Write ) )
                {
                    // open the reader (for the original file), and writer (for the file we are saving)
                    using ( BinaryReader reader = new BinaryReader( source ) )
                    using ( BinaryWriter writer = new BinaryWriter( destination ) )
                    {
                        // save the uop header
                        Header.Save( writer );

                        // save all blocks and files
                        foreach ( MythicPackageBlock b in Blocks )
                            b.Save( writer, reader );
                    }
                }
            }
            else // new file created from scratch
            {
                // create a new file
                using ( FileStream destination = new FileStream( tempFile, FileMode.Create, FileAccess.Write ) )
                using ( BinaryWriter writer = new BinaryWriter( destination ) )
                {
                    // save the header
                    Header.Save( writer );

                    // save all blocks and files
                    foreach ( MythicPackageBlock b in Blocks )
                        b.Save( writer );
                }
            }

            // if we are replacing an existing file, we also create a backup of the original one
            if ( exists )
                File.Replace( tempFile, fileName, string.Format( "{0}.backup", FileInfo.FullName ), true );

            // update the file info
            FileInfo = new FileInfo( fileName );

            // remove the modified flag
            Modified = false;

            // remove the "is new" flag
            Added = false;
        }

        /// <summary>
        /// Updates <see cref="MythicPackageFile.DataBlockAddress"/> within .uop file,
        /// <see cref="MythicPackageFile.CompressedSize"/> and <see cref="MythicPackageFile.DecompressedSize"/>.
        /// </summary>
        public void UpdateOffsets()
        {
            // get the first block address
            ulong pointer = Header.StartAddress;

            // update the address of each block and file in the uop file
            foreach ( MythicPackageBlock b in Blocks )
                b.UpdateOffsets( ref pointer );
        }

        #endregion

        /// <summary>
        /// Get all the unique relative paths used by this package files (only the known ones).
        /// </summary>
        /// <returns>array of all the unique path used by this package files</returns>
        public string[] GetAllPaths()
        {
            // get a list of all the unique paths inside thie package
            return ( from b in Blocks
                     from f in b.Files
                     where !string.IsNullOrEmpty( f.FileName )
                     select f.FilePath ).Distinct().ToArray();
        }

        /// <summary>
        /// Get a list of all the files inside thie package with an unknown name.
        /// </summary>
        /// <returns>All the files inside this package with unknown names.</returns>
        public List<MythicPackageFile> GetAllUnnamedFiles()
        {
            // make a list of all the files without a name
            return ( from b in Blocks
                     from f in b.GetAllUnnamedFiles()
                     select f ).ToList();
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Create an empty block
        /// </summary>
        /// <returns>The new block</returns>
        private MythicPackageBlock NewBlock()
        {
            // create an empty block
            MythicPackageBlock block = new MythicPackageBlock(this);

            return block;
        }

        /// <summary>
        /// Get the relative path of a file
        /// </summary>
        /// <param name="filename">filename to get the path from</param>
        /// <param name="root">root folder to remove from the path</param>
        /// <returns>relative path of the file from a root of &lt;folder&gt;.uop</returns>
        private string GetRelativePath( string root, string filename )
        {
            // remove the file name from the path
            string relativePath = filename.Replace( Path.GetFileName( filename ), "" ).ToLower();

            // remove the root folder
            relativePath = relativePath.Replace( root.ToLower() + @"\", "" );

            // invert the \ from the path
            relativePath = relativePath.Replace( @"\", "/" );

            return relativePath;
        }

        #endregion
    }
}
