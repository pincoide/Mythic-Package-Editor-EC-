using System;
using System.Windows.Forms;
using System.Threading;

namespace Mythic.Package.Editor
{
	public static class Program
	{
		private static SplashScreen m_Splash;

		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );

			Initialize();
		}

		public static void Initialize()
		{
			Thread thread = new Thread( new ThreadStart( ShowSplash ) );
			thread.IsBackground = true;
			thread.SetApartmentState( ApartmentState.STA );
			thread.Start();

			while ( m_Splash == null )
				Thread.Sleep( 200 );

			if ( InitializeModules() )
			{
				if ( m_Splash != null )
					m_Splash.ThreadClose();

				if ( Globals.MainForm != null )
				{
					Application.Run( Globals.MainForm );
				}
			}
		}

		public static void ShowSplash()
		{
			m_Splash = new SplashScreen();
			Application.Run( m_Splash );
		}

		public static bool InitializeModules()
		{
			// logger
			m_Splash.ThreadSetText( "Initializing logger..." );

			try
			{
				Globals.InitializeLogger();
			}
			catch ( Exception ex )
			{
				MessageBox.Show( ex.Message, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}

			// settings
			m_Splash.ThreadSetText( String.Format( "Loading {0}...", Settings.FileName ) );

			try
			{
				Globals.InitializeSettings();
			}
			catch ( Exception ex )
			{
				m_Splash.HandleException( String.Format( "Error loading {0}", Settings.FileName ) );
				Globals.Logger.LogException( ex );
				return false;
			}

			// language
			m_Splash.ThreadSetText( String.Format( "Loading {0}...", Globals.Settings.Language ) );

			try
			{
				Globals.InitializeLanguage();
			}
			catch ( Exception ex )
			{
				m_Splash.HandleException( String.Format( "Error loading {0}", Globals.Settings.Language ) );
				Globals.Logger.LogException( ex );
				return false;
			}

			// hash spy
			m_Splash.ThreadSetText( "Initializing hash spy" );

			try
			{
				Globals.InitializeHashSpy();
			}
			catch ( Exception ex )
			{
				m_Splash.HandleException( "Error initializing hash spy." );
				Globals.Logger.LogException( ex );
				return false;
			}

			// main form
			m_Splash.ThreadSetText( "Initializing main form..." );

			try
			{
				Globals.InitializeMainForm();
			}
			catch ( Exception ex )
			{
				m_Splash.HandleException( "Error initializing main form." );
				Globals.Logger.LogException( ex );
				return false;
			}

			// hash dictionary
			m_Splash.ThreadSetText( "Loading dictionary..." );

			try
			{
				HashDictionary.LoadDictionary( HashDictionary.FileName );
			}
			catch ( Exception ex )
			{
				Globals.Logger.LogException( ex );
			}

			// delay
			m_Splash.ThreadSetText( "Done" );
			return true;
		}

		public static void EndInitialize()
		{
		}
	}
}
