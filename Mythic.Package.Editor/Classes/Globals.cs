using Mythic.Package.Spy;

namespace Mythic.Package.Editor
{
	/// <summary>
	/// Global objects for main operations
	/// </summary>
	public static class Globals
	{
		// --------------------------------------------------------------
		#region PUBLIC VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Main debug logger object
		/// </summary>
		public static Logger Logger { get; private set; }

		/// <summary>
		/// Main settings
		/// </summary>
		public static Settings Settings { get; private set; }

		/// <summary>
		/// Main language strings
		/// </summary>
		public static LanguageManager LanguageManager { get; private set; }

		/// <summary>
		/// Main app form
		/// </summary>
		public static MainForm MainForm { get; private set; }

		/// <summary>
		/// Main spy object
		/// </summary>
		public static HashSpy HashSpy { get; private set; }

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the debug logger
		/// </summary>
		public static void InitializeLogger()
		{
			Logger = new Logger();
		}

		/// <summary>
		/// Initialize the user settings
		/// </summary>
		public static void InitializeSettings()
		{
			Settings = new Settings();
		}

		/// <summary>
		/// Initialize the language
		/// </summary>
		public static void InitializeLanguage()
		{
			LanguageManager = new LanguageManager();
		}

		/// <summary>
		/// Initialize the main app form
		/// </summary>
		public static void InitializeMainForm()
		{
			MainForm = new MainForm();
		}

		/// <summary>
		/// Initialize the spy object
		/// </summary>
		public static void InitializeHashSpy()
		{
			HashSpy = new HashSpy();
		}

		#endregion
	}
}
