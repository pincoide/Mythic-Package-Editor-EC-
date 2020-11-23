namespace Mythic.Package
{
    /// <summary>
    /// Descriptor used when loading a file from package.
    /// </summary>
    public class FileDescriptor
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Name of the mythic package (absolute).
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Information about file in mythic package.
        /// </summary>
        public MythicPackageFile File { get; set; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Constucts new file descriptor.
        /// </summary>
        /// <param name="fileName">Path to the mythic package.</param>
        /// <param name="file">Information about file in mythic package.</param>
        public FileDescriptor( string fileName, MythicPackageFile file )
        {
            FileName = fileName;
            File = file;
        }

        #endregion
    }
}
