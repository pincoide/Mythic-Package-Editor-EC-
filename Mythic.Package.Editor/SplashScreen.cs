using System;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

using DelayTimer = System.Timers.Timer;

using Mythic.Package.Editor.Properties;

namespace Mythic.Package.Editor
{
	delegate void SetSplashTextCallback( string text );
	delegate void CloseSplashCallback();

	public partial class SplashScreen : Form
	{
		private SetSplashTextCallback m_TextCallback;
		private CloseSplashCallback m_CloseCallback;

		public SplashScreen()
		{
			InitializeComponent();
			FadeIn();

			m_TextCallback += new SetSplashTextCallback( TextCallback_Invoke );
			m_CloseCallback += new CloseSplashCallback( CloseCallback_Invoke );
		}

		#region FadeIn
		private DelayTimer m_Timer;

		private void FadeIn()
		{
			m_Timer = new DelayTimer( 10 );
			m_Timer.Elapsed += new ElapsedEventHandler( FadeStep );
			m_Timer.SynchronizingObject = this;
			m_Timer.Start();
		}

		private void FadeStep( object sender, ElapsedEventArgs e )
		{
			Opacity += 0.05;

			if ( Opacity >= 0.95 )
			{
				if ( m_Timer != null )
					m_Timer.Stop();

				m_Timer = null;
			}
		}
		#endregion

		private void Details_Click( object sender, EventArgs e )
		{
			try
			{
				Process.Start( Logger.FileName );
			}
			catch ( Exception ex )
			{
				Globals.Logger.LogException( ex );
				MessageBox.Show( String.Format( "Error running {0}", Logger.FileName ), "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private void TextCallback_Invoke( string text )
		{
			ProgressText.Text = text;
		}

		private void CloseCallback_Invoke()
		{
			Close();
		}

		public void HandleException( string message )
		{
			ProgressText.ForeColor = Color.Red;
			ProgressText.Text = message;

			DetailsText.Location = new Point( ProgressText.Location.X + ProgressText.Size.Width + DetailsText.Margin.Left, DetailsText.Location.Y );
			DetailsText.Visible = true;
		}

		public void ThreadSetText( string text )
		{
			Invoke( m_TextCallback, text );
		}

		public void ThreadClose()
		{
			DelayTimer timer = new DelayTimer( 50 );
			timer.Elapsed += new ElapsedEventHandler( ThreadClose );
			timer.AutoReset = false;
			timer.Start();
		}

		public void ThreadClose( object sender, ElapsedEventArgs e )
		{
			Invoke( m_CloseCallback );
		}

		#region Static
		private static SplashScreen m_Splash;
		private static Thread m_SplashThread;

		public static void ShowSplash()
		{
			m_SplashThread = new Thread( new ThreadStart( ShowSplash ) );
			m_SplashThread.IsBackground = true;
			m_SplashThread.SetApartmentState( ApartmentState.STA );
			m_SplashThread.Start();
		}

		private static void ThreadShowSplash()
		{
			m_Splash = new SplashScreen();
			Application.Run( m_Splash );
		}

		public static void CloseSplash()
		{
			m_Splash.Close();
		}
		#endregion
	}
}
