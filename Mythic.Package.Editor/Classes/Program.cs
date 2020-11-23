using System;
using System.Windows.Forms;
using System.Threading;

namespace Mythic.Package.Editor
{
    public static class Program
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Active splash screen
        /// </summary>
        private static SplashScreen m_Splash;

        #endregion

        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the app
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // enable the OS visual styles
            Application.EnableVisualStyles();

            // enable text rendering
            Application.SetCompatibleTextRenderingDefault( false );

            // initialize the app
            Initialize();
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the app
        /// </summary>
        private static void Initialize()
        {
            // create the splash screen thread (in background)
            Thread thread = new Thread( new ThreadStart( ShowSplash ) )
            {
                IsBackground = true
            };

            // set the thread as single thread
            thread.SetApartmentState( ApartmentState.STA );

            // start the thread
            thread.Start();

            // wait for the splash screen to be created
            while ( m_Splash == null )
                Thread.Sleep( 200 );

            // initialize the app modules
            if ( InitializeModules() )
            {
                // is the splash screen gone? close that thread
                if ( m_Splash != null )
                    m_Splash.ThreadClose();

                // if the main form is not visible yet, we show it
                if ( Globals.MainForm != null )
                    Application.Run( Globals.MainForm );
            }
        }

        /// <summary>
        /// Show the splash screen
        /// </summary>
        private static void ShowSplash()
        {
            // create the splash screen window
            m_Splash = new SplashScreen();

            // show the splash screen
            Application.Run( m_Splash );
        }

        /// <summary>
        /// Initialize all the app modules
        /// </summary>
        /// <returns>true on success, false if something goes wrong</returns>
        private static bool InitializeModules()
        {
            // set the splash screen text
            m_Splash.ThreadSetText( "Initializing logger..." );

            // initialize the logger
            try { Globals.InitializeLogger(); }

            catch ( Exception ex )
            {
                // if something goes wrong show a message box with the error
                MessageBox.Show( ex.Message, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error );

                return false;
            }

            // set the splash screen text
            m_Splash.ThreadSetText( string.Format( "Loading {0}...", Settings.FileName ) );

            // initialize the settings
            try { Globals.InitializeSettings(); }

            catch ( Exception ex )
            {
                // if something goes wrong, log the exception
                m_Splash.HandleException( string.Format( "Error loading {0}", Settings.FileName ) );
                Globals.Logger.Log( ex );

                return false;
            }

            // set the splash screen text
            m_Splash.ThreadSetText( string.Format( "Loading {0}...", Globals.Settings.Language ) );

            // initialize the language
            try { Globals.InitializeLanguage(); }

            catch ( Exception ex )
            {
                // if something goes wrong, log the exception
                m_Splash.HandleException( string.Format( "Error loading {0}", Globals.Settings.Language ) );
                Globals.Logger.Log( ex );

                return false;
            }

            // set the splash screen text
            m_Splash.ThreadSetText( "Initializing hash spy" );

            // initialize the spy
            try { Globals.InitializeHashSpy(); }

            catch ( Exception ex )
            {
                // if something goes wrong, log the exception
                m_Splash.HandleException( "Error initializing hash spy." );
                Globals.Logger.Log( ex );

                return false;
            }

            // set the splash screen text
            m_Splash.ThreadSetText( "Initializing main form..." );

            // initialize the main form
            try { Globals.InitializeMainForm(); }

            catch ( Exception ex )
            {
                // if something goes wrong, log the exception
                m_Splash.HandleException( "Error initializing main form." );
                Globals.Logger.Log( ex );

                return false;
            }

            // set the splash screen text
            m_Splash.ThreadSetText( "Loading dictionary..." );

            // initialize the dictionary
            try { HashDictionary.LoadDictionary( HashDictionary.FileName ); }

            catch ( Exception ex )
            {
                // if something goes wrong, log the exception
                Globals.Logger.Log( ex );
            }

            // set the splash screen text for the process completed
            m_Splash.ThreadSetText( "Done" );

            return true;
        }

        #endregion
    }
}
