using System;
using System.Timers;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using DelayTimer = System.Timers.Timer;

namespace Mythic.Package.Editor
{
    internal delegate void SetSplashTextCallback( string text );
    internal delegate void CloseSplashCallback();

	public partial class SplashScreen : Form
	{
		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// text updates callback event
		/// </summary>
		private readonly SetSplashTextCallback m_TextCallback;

		/// <summary>
		/// close splash screen callback event
		/// </summary>
		private readonly CloseSplashCallback m_CloseCallback;

		/// <summary>
		/// main delay used for the fadein
		/// </summary>
		private DelayTimer m_Timer;

		#endregion

		// --------------------------------------------------------------
		#region CONSTRUCTOR
		// --------------------------------------------------------------

		/// <summary>
		/// Initialize the form
		/// </summary>
		public SplashScreen()
		{
			// initialize the components
			InitializeComponent();

			// fade in the splash screen
			FadeIn();

			// add the text update callback event
			m_TextCallback += new SetSplashTextCallback( TextCallback_Invoke );

			// add the close splash callback event
			m_CloseCallback += new CloseSplashCallback( CloseCallback_Invoke );
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL EVENTS
		// --------------------------------------------------------------

		/// <summary>
		/// Error Details clicked
		/// </summary>
		private void Details_Click( object sender, EventArgs e )
		{
			// show the log file
			try { Process.Start( Globals.Logger.FileName ); }

			catch ( Exception ex )
			{
				// if something goes wrong log the exception
				Globals.Logger.Log( ex );

				// show a message box with the error
				MessageBox.Show( string.Format( "Error running {0}", Globals.Logger.FileName ), "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Handle exception
		/// </summary>
		/// <param name="message">error message to show</param>
		public void HandleException( string message )
		{
			// se the progress label color to red
			lblProgress.ForeColor = Color.Red;

			// set the progress label with the error message
			lblProgress.Text = message;

			// move the details label near the progress label
			lblDetails.Location = new Point( lblProgress.Location.X + lblProgress.Size.Width + lblDetails.Margin.Left, lblDetails.Location.Y );

			// show the details lable
			lblDetails.Visible = true;
		}

		/// <summary>
		/// Set the progress text through another thread
		/// </summary>
		/// <param name="text">text to set</param>
		public void ThreadSetText( string text )
		{
			// set the progress text
			Invoke( m_TextCallback, text );
		}

		/// <summary>
		/// End the splash screen thread
		/// </summary>
		public void ThreadClose()
		{
			// set a timer to trigger the splash screen close
			DelayTimer timer = new DelayTimer( 50 );

			// set the timer event
			timer.Elapsed += new ElapsedEventHandler( ThreadClose );

			// disable the timer auto-reset
			timer.AutoReset = false;

			// start the timer
			timer.Start();
		}

		/// <summary>
		/// Close the splash screen event
		/// </summary>
		public void ThreadClose( object sender, ElapsedEventArgs e )
		{
			// execute the close splash screen event
			Invoke( m_CloseCallback );
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Fadein effect
		/// </summary>
		private void FadeIn()
		{
			// create a new timer for the next step
			m_Timer = new DelayTimer( 10 );

			// add the event for the timer tick event
			m_Timer.Elapsed += new ElapsedEventHandler( FadeStep );

			// attach the timer to the form
			m_Timer.SynchronizingObject = this;

			// start the timer
			m_Timer.Start();
		}

		/// <summary>
		/// Increase the form opacity
		/// </summary>
		private void FadeStep( object sender, ElapsedEventArgs e )
		{
			// increase the opacity for the form
			Opacity += 0.05;

			// is the form completely opaque?
			if ( Opacity >= 0.95 )
			{
				// if we still have a timer, we stop it
				if ( m_Timer != null )
					m_Timer.Stop();

				// remove the timer
				m_Timer.Dispose();
				m_Timer = null;
			}
		}

		/// <summary>
		/// Update the label
		/// </summary>
		/// <param name="text">text to set on the label</param>
		private void TextCallback_Invoke( string text )
		{
			// update the progress label
			lblProgress.Text = text;
		}


		/// <summary>
		/// Close splash screen
		/// </summary>
		private void CloseCallback_Invoke()
		{
			// close the dialog
			Close();
		}

		#endregion
	}
}
