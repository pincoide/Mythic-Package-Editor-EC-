using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Mythic.Package.Editor
{
	public partial class SelectProcess : Form
	{
		// --------------------------------------------------------------
		#region PRIVATE VARIABLES
		// --------------------------------------------------------------

		/// <summary>
		/// Class used to create the process item variable
		/// </summary>
		private class ProcessItem
		{
			/// <summary>
			/// Process associated to this object
			/// </summary>
			public Process Process { get; }

			/// <summary>
			/// Initialize a new process item
			/// </summary>
			/// <param name="process">Process to link to this object</param>
			public ProcessItem( Process process )
			{
				Process = process;
			}

			/// <summary>
			/// Get the process name
			/// </summary>
			/// <returns>Process name</returns>
			public override string ToString()
			{
				// do we have a process? then we get the window title (if available, otherwise we show only the process name)
				if ( Process != null )
					return !string.IsNullOrEmpty( Process.MainWindowTitle.Trim() ) ? Process.MainWindowTitle + " ( " + Process.ProcessName + " )" : Process.ProcessName;

				// this should never happen!
				return null;
			}
		}

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Process selected from the list
        /// </summary>
        public Process SelectedProcess => ( (ProcessItem)lstProcess.SelectedItem )?.Process;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        public SelectProcess()
		{
			// initialize the components
			InitializeComponent();

			// set the form icon
			Icon = Icon.FromHandle( Properties.Resources.Search.GetHicon() );

			// set the buttons text
			btnOK.Text = Globals.LanguageManager.GetString( "SelectProcessDialog_Button_OK" );
			btnCancel.Text = Globals.LanguageManager.GetString( "SelectProcessDialog_Button_Cancel" );
			btnRefresh.Text = Globals.LanguageManager.GetString( "SelectProcessDialog_Button_Refresh" );
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL EVENTS
		// --------------------------------------------------------------

		/// <summary>
		/// Form shown event
		/// </summary>
		private void SelectProcess_Shown( object sender, EventArgs e )
		{
			// initialize the process list
			InitializeProcesses();
		}

		/// <summary>
		/// Refresh button clicked
		/// </summary>
		private void ButtonRefresh_Click( object sender, EventArgs e )
		{
			// initialize the process list
			InitializeProcesses();
		}

		/// <summary>
		/// Process double clicked
		/// </summary>
		private void lstProcess_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			// set the dialog result as OK
			DialogResult = DialogResult.OK;

			// close the dialog
			Close();
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// (Re-)Create the process list
		/// </summary>
		private void InitializeProcesses()
		{
			// clear the process list
			lstProcess.Items.Clear();

			// get the list of all active process
			ProcessItem[] list = Process.GetProcesses().Where( p => (long)p.MainWindowHandle != 0 ).Select( p => new ProcessItem( p ) ).ToArray();

			// add the process to the list
			lstProcess.Items.AddRange( list );
		}

        #endregion
    }
}
