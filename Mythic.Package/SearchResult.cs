namespace Mythic.Package
{
    /// <summary>
    /// Search result.
    /// </summary>
    public class SearchResult
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Seatch result indicating nothing was found.
        /// </summary>
        public static readonly SearchResult NotFound = new SearchResult( -1, -1 );

        /// <summary>
        /// Seatch result indicating nothing was found in the <see cref="MythicPackageBlock"/>.
        /// </summary>
        public static readonly int NotFoundResult = -1;

        /// <summary>
        /// Index of the block in <see cref="MythicPackage.Blocks"/>.
        /// </summary>
        ///
        public int Block { get; }

        /// <summary>
        /// Indicate if it's a new file or we already knew the name..
        /// </summary>
        ///
        public bool NewFile { get; }

        /// <summary>
        /// Index if the file in <see cref="MythicPackageBlock.Files"/>.
        /// </summary>
        public int File { get; }

        /// <summary>
        /// Indicates search was successful.
        /// </summary>
        public bool Found => Block >= 0 && File >= 0;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTORS
        // --------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="block">Index if block in <see cref="MythicPackage.Blocks"/>.</param>
        /// <param name="file">Index of file in <see cref="MythicPackageBlock.Files"/>.</param>
        public SearchResult( int block, int file )
        {
            Block = block;
            File = file;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="block">Index if block in <see cref="MythicPackage.Blocks"/>.</param>
        /// <param name="file">Index of file in <see cref="MythicPackageBlock.Files"/>.</param>
        /// <param name="newFile">Indicate if this is a new file we've just discovered (true) or we already new the name (false)</param>
        public SearchResult( int block, int file, bool newFile )
        {
            Block = block;
            File = file;
            NewFile = newFile;
        }

        #endregion
    }
}
