using System.Diagnostics;
using System.Collections.Generic;
using Mythic.Package.Spy;
using System.Linq;

namespace Mythic.Package.Editor
{
	/// <summary>
	/// Dictionary thread arguments
	/// </summary>
	public class DictionaryArgs
	{
		/// <summary>
		/// List of actions that can be done to the dictionary
		/// </summary>
		public enum Actions
		{
			LOAD = 0,
			SAVE = 1,
			MERGE = 2,
		}

		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Current thread action
		/// </summary>
		private Actions CurrentAction { get; set; }

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Dictionary file name
		/// </summary>
		public string Name { get; }

        /// <summary>
        /// Is this a loading thread?
        /// </summary>
        public bool Load => CurrentAction == Actions.LOAD;

        /// <summary>
        /// Is this a saving thread?
        /// </summary>
        public bool Save => CurrentAction == Actions.SAVE;

        /// <summary>
        /// Is this a merge thread?
        /// </summary>
        public bool Merge => CurrentAction == Actions.MERGE;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the thread arguments
        /// </summary>
        /// <param name="name">dictionary file name</param>
        /// <param name="action">action to perform on the dictionary</param>
        public DictionaryArgs( string name, Actions action )
		{
			Name = name;
			CurrentAction = action;
		}

		#endregion
	}

	/// <summary>
	/// UOP loading thread arguments
	/// </summary>
	public class LoadMythicPackageArgs
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Files names to load
		/// </summary>
		public string[] Names { get; }

		/// <summary>
		/// Loaded uop files
		/// </summary>
		public MythicPackage[] Result { get; set; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="names">Files to load</param>
		public LoadMythicPackageArgs( string[] names )
		{
			Names = names;
			Result = null;
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Load the packages
		/// </summary>
		public void LoadPackages()
        {
			// initialize the packages list array
			MythicPackage[] packs = new MythicPackage[ Names.Length ];

			// scan the packages array
			for ( int i = 0; i < Names.Length; i++ )
			{
				// load the uop
				packs[i] = new MythicPackage( Names[i] );

				// get all the paths that are NOT inside the settings
				List<string> newPaths = ( from block in packs[i].Blocks
										  from f in block.Files
										  where !string.IsNullOrEmpty( f.FilePath ) && !Globals.Settings.InnerDirectoryOptions.Contains( f.FilePath )
										  select f.FilePath ).ToList();

				// add all the new paths to the settings
				foreach ( string path in newPaths )
				{
					// add the folder to the list
					Globals.Settings.AddInnerDirectory( path );

					// write the path added to the log
					Globals.Logger.Log( "Added new path to the settings: " + path );

					// save the settings
					Globals.Settings.Save();
				}
			}

			// set the loaded packages as result
			Result = packs;
		}

		#endregion
	}

	/// <summary>
	/// UOP saving thread arguments
	/// </summary>
	public class SaveMythicPackageArgs
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// UOP file to save
		/// </summary>
		public MythicPackage Package { get; }

		/// <summary>
		/// Destination file name for the UOP file
		/// </summary>
		public string FileName { get; }

		/// <summary>
		/// Close the file when done
		/// </summary>
		public bool CloseFile { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="package">UOP file to save</param>
		/// <param name="fileName">destination file name to use</param>
		public SaveMythicPackageArgs( MythicPackage package, string fileName, bool closeFile = false )
		{
			Package = package;
			FileName = fileName;
			CloseFile = closeFile;
		}

		#endregion
	}

	/// <summary>
	/// UOP unpacking thread arguments
	/// </summary>
	public class UnpackMythicPackageArgs
	{
		/// <summary>
		/// List of the unpacking options
		/// </summary>
		public enum Options
		{
			/// <summary>
			/// Whole UO file
			/// </summary>
			PACKAGE = 0,

			/// <summary>
			/// Whole block
			/// </summary>
			BLOCK = 1,

			/// <summary>
			/// Single file
			/// </summary>
			FILE = 2,
		}

		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Current unpack action
		/// </summary>
		private readonly Options CurrentAction;

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Are we unpacking the whole UOP file?
        /// </summary>
        public bool IsPackage => CurrentAction == Options.PACKAGE;

        /// <summary>
        /// Are we unpacking a whole block?
        /// </summary>
        public bool IsBlock => CurrentAction == Options.BLOCK;

        /// <summary>
        /// Are we unpacking a single file?
        /// </summary>
        public bool IsFile => CurrentAction == Options.FILE;

        /// <summary>
        /// Current UOP file we are operating on
        /// </summary>
        public MythicPackage Package { get; }

		/// <summary>
		/// Current block we are operating on
		/// </summary>
		public MythicPackageBlock Block { get; }

		/// <summary>
		/// Current file(s) we are operating on
		/// </summary>
		public MythicPackageFile[] Files { get; }

		/// <summary>
		/// Current output folder for the operation
		/// </summary>
		public string Folder { get; }

		/// <summary>
		/// Does the operation has to use the relative path of the file (specified inside the package)?
		/// </summary>
		public bool FullPath { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments for the UOP unpacking
		/// </summary>
		/// <param name="package">UOP to unpack</param>
		/// <param name="folder">destination folder</param>
		/// <param name="fullPath">shall we use the relative files paths of the UOP?</param>
		public UnpackMythicPackageArgs( MythicPackage package, string folder, bool fullPath )
		{
			CurrentAction = Options.PACKAGE;
			Package = package;
			Folder = folder;
			FullPath = fullPath;
		}

		/// <summary>
		/// Initialize the thread arguments for the block unpacking
		/// </summary>
		/// <param name="block">block to unpack</param>
		/// <param name="folder">destination folder</param>
		/// <param name="fullPath">shall we use the relative files paths of the UOP?</param>
		public UnpackMythicPackageArgs( MythicPackageBlock block, string folder, bool fullPath )
		{
			CurrentAction = Options.BLOCK;
			Block = block;
			Folder = folder;
			FullPath = fullPath;
		}

		/// <summary>
		/// Initialize the thread arguments for the files unpacking
		/// </summary>
		/// <param name="files">file(s) to unpack</param>
		/// <param name="folder">destination folder</param>
		/// <param name="fullPath">shall we use the relative files paths of the UOP?</param>
		public UnpackMythicPackageArgs( MythicPackageFile[] files, string folder, bool fullPath )
		{
			CurrentAction = Options.FILE;
			Files = files;
			Folder = folder;
			FullPath = fullPath;
		}

		#endregion
	}

	/// <summary>
	/// Spy process thread arguments
	/// </summary>
	public class SpyProcessArgs
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Spy object to use
		/// </summary>
		public HashSpy HashSpy { get; }

		/// <summary>
		/// Process to spy
		/// </summary>
		public Process Process { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="hashSpy">Spy object to use</param>
		/// <param name="process">Process to spy</param>
		public SpyProcessArgs( HashSpy hashSpy, Process process )
		{
			HashSpy = hashSpy;
			Process = process;
		}

		#endregion
	}

	/// <summary>
	/// Spy start process thread arguments
	/// </summary>
	public class SpyPathArgs
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Spy object to use
		/// </summary>
		public HashSpy HashSpy { get; }

		/// <summary>
		/// Path of the executable to start
		/// </summary>
		public string Path { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="hashSpy">Spy object to use</param>
		/// <param name="path">Path of the executable to start</param>
		public SpyPathArgs( HashSpy hashSpy, string path )
		{
			HashSpy = hashSpy;
			Path = path;
		}

		#endregion
	}

	/// <summary>
	/// Search folder thread arguments
	/// </summary>
	public class SearchFolderArgs
	{

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Package to which the files belong
		/// </summary>
		public MythicPackage Package { get; }

		/// <summary>
		/// List of the unnamed files to parse
		/// </summary>
		public List<MythicPackageFile> UnnamedFiles { get; }

		/// <summary>
		/// List of files to use as search pattern
		/// </summary>
		public List<string> FilesToParse { get; }

		/// <summary>
		/// Root folder of the files in the hdd
		/// </summary>
		public string RootFolder { get; }

		/// <summary>
		/// Relative folder where the files should be inside the package
		/// </summary>
		public string InnerPath { get; }

		/// <summary>
		/// Total amount of files discovered
		/// </summary>
		public int TotalFound { get; set; }
		/// <summary>
		/// Original amount of unnamed files
		/// </summary>
		public int OriginalCount { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="unnamedFiles">List of the unnamed files inside the package</param>
		/// <param name="filesToParse">List of file names to use as pattern</param>
		/// <param name="rootFolder">Root folder of the files in the hdd</param>
		/// <param name="innerPath">Relative folder where the files should be inside the package</param>
		public SearchFolderArgs( MythicPackage package, List<MythicPackageFile> unnamedFiles, List<string> filesToParse, string rootFolder, string innerPath )
		{
			Package = package;
			UnnamedFiles = unnamedFiles;
			FilesToParse = filesToParse;
			RootFolder = rootFolder;
			InnerPath = innerPath;
			OriginalCount = unnamedFiles.Count;
		}

		#endregion
	}


	/// <summary>
	/// Brute force file name search thread arguments
	/// </summary>
	public class BruteForceArgs
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// List of the brute force patterns
		/// </summary>
		public List<BruteForceEntry> Entries { get; }

		/// <summary>
		/// List of the unnamed files to parse
		/// </summary>
		public List<MythicPackageFile> UnnamedFiles { get; }

		/// <summary>
		/// Total amount of files discovered
		/// </summary>
		public int TotalFound { get; set; }

		/// <summary>
		/// Original amount of unnamed files
		/// </summary>
		public int OriginalCount { get; }

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="entries">Brute force search patterns</param>
		public BruteForceArgs( List<BruteForceEntry> entries, List<MythicPackageFile> unnamedFiles )
		{
			Entries = entries;
			UnnamedFiles = unnamedFiles;
			OriginalCount = unnamedFiles.Count;
		}

		#endregion
	}



	public class SearchExpressionArgs
	{

		// -------- OLD HASH SEARCH TO BE UPDATED/REMOVED --------

		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		#endregion

		public object Source { get; }
        public List<SearchExpressionEntry> Entries { get; }
        public int Length { get; }
        public char[] After { get; }

        public int Found { get; set; }

		/// <summary>
		/// Initialize the thread arguments
		/// </summary>
		/// <param name="source"></param>
		/// <param name="entries"></param>
		/// <param name="after"></param>
		/// <param name="length"></param>
		public SearchExpressionArgs( object source, List<SearchExpressionEntry> entries, char[] after, int length )
		{
			Source = source;
			Entries = entries;
			After = after;
			Length = length;
		}
	}

	public class SearchExpressionEntry
	{
		// -------- OLD HASH SEARCH TO BE UPDATED --------

		public char[] Before { get; }
        public char[] From { get; }
        public char[] To { get; }
        public int Start { get; }
        public int End { get; }

        public SearchExpressionEntry( char[] before, char[] from, char[] to, int start, int end )
		{
			Before = before;
			From = from;
			To = to;
			Start = start;
			End = end;
		}
	}
}
