using System;

using Mythic.Package.Spy;

namespace Mythic.Package.Editor
{
	public static class Globals
	{
		#region Logger
		private static Logger m_Logger;

		public static Logger Logger
		{
			get{ return m_Logger; }
		}
		#endregion

		#region Settings
		private static Settings m_Settings;

		public static Settings Settings
		{
			get{ return m_Settings; }
		}
		#endregion

		#region ResourceManager
		private static LanguageManager m_LanguageManager;

		public static LanguageManager LanguageManager
		{
			get{ return m_LanguageManager; }
		}
		#endregion

		#region MainForm
		private static MainForm m_MainForm;

		public static MainForm MainForm
		{
			get{ return m_MainForm; }
		}
		#endregion

		#region HashSpy
		private static HashSpy m_HashSpy;

		public static HashSpy HashSpy
		{
			get{ return m_HashSpy; }
		}

		#endregion

		#region Initialize
		public static void InitializeLogger()
		{
			m_Logger = new Logger( Logger.FileName );
		}

		public static void InitializeSettings()
		{
			m_Settings = new Settings();
		}

		public static void InitializeLanguage()
		{
			m_LanguageManager = new LanguageManager();
		}

		public static void InitializeMainForm()
		{
			m_MainForm = new MainForm();
		}

		public static void InitializeHashSpy()
		{
			m_HashSpy = new HashSpy();
		}
		#endregion
	}
}
