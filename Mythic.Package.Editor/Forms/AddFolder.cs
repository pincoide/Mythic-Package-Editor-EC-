 using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Mythic.Package.Editor
{
	public partial class AddFolder : Form
	{
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Selected forlder
        /// </summary>
        public string Folder => txtFolder.Text;

        /// <summary>
        /// Compression type
        /// </summary>
        public CompressionFlag Compression => (CompressionFlag)cmbCompression.SelectedIndex;

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        public AddFolder()
		{
			// initialize the components
			InitializeComponent();

			// set the form icon
			Icon = Icon.FromHandle( Properties.Resources.AddFolder.GetHicon() );

			// set the window title
			Text = Globals.LanguageManager.GetString( "AddFolder_Title" );

			// set the caption labels text
			lblFolder.Text = Globals.LanguageManager.GetString( "FolderSearch_Folder" );
			lblCompression.Text = Globals.LanguageManager.GetString( "AddFolder_Compression" );

			// set the buttons text
			btnCancel.Text = Globals.LanguageManager.GetString( "AddFolder_Button_Cancel" );
			btnOK.Text = Globals.LanguageManager.GetString( "AddFolder_Button_Add" );

			// fill the compression type list
			cmbCompression.Items.AddRange( Enum.GetNames( typeof( CompressionFlag ) ) );

			// set it to zlib as default
			cmbCompression.SelectedIndex = 1;

			// initialize the tooltip error title
			ttpError.ToolTipTitle = Globals.LanguageManager.GetString( "AddFolder_ToolTip_Title" );

			// set the root folder for the search
			OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			// set the open folder description
			OpenFolderDialog.Description = Globals.LanguageManager.GetString( "AddFolder_Browse_Description" );
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL EVENTS
		// --------------------------------------------------------------

		/// <summary>
		/// Add folder button clicked
		/// </summary>
		private void btnOK_Click( object sender, EventArgs e )
		{
			try
			{
				// does the folder still exist?
				if ( CheckDirectory() )
                {
					// set the dialog result to OK
					DialogResult = DialogResult.OK;

					// close the form
					Close();
				}
				else // the folder doesn't exist, show an error
					ShowErrorTooltip( Globals.LanguageManager.GetString( "AddFolder_ToolTip_Text" ) );
			}
			catch ( Exception ex )
			{
				// there was an unknown problem with the folder, show an error
				ShowErrorTooltip( ex.Message );
			}
		}

		/// <summary>
		/// Cancel button clicked
		/// </summary>
		private void btnCancel_Click( object sender, EventArgs e )
		{
			// clear the selected folder
			ClearFolder();
		}

		/// <summary>
		/// Browse folder button clicked
		/// </summary>
		private void btnBrowseFolder_Click( object sender, EventArgs e )
		{
			// do we have a folder selected?
			if ( OpenFolderDialog.ShowDialog( this ) == DialogResult.OK )

				// set the folder path into the textbox
				txtFolder.Text = OpenFolderDialog.SelectedPath;
		}

		/// <summary>
		/// Folder text changed
		/// </summary>
		private void txtFolder_TextChanged( object sender, EventArgs e )
		{
			// if the folder exist, we set the text color green
			if ( Directory.Exists( txtFolder.Text ) )
				txtFolder.ForeColor = Color.DarkGreen;

			else // if the folder doesn't exist we set the text color red
				txtFolder.ForeColor = Color.Red;
		}

		#endregion

		// --------------------------------------------------------------
		#region PUBLIC FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Clear the files list
		/// </summary>
		public void ClearFolder()
		{
			// clear the folder text
			txtFolder.Text = string.Empty;
		}

		#endregion

		// --------------------------------------------------------------
		#region LOCAL FUNCTIONS
		// --------------------------------------------------------------

		/// <summary>
		/// Verify the selected folder path
		/// </summary>
		/// <returns>is the selected folder still valid?</returns>
		private bool CheckDirectory()
		{
			// trigger the text changed to update the text color
			txtFolder_TextChanged( txtFolder, new EventArgs() );

			return Directory.Exists( txtFolder.Text );
		}

		/// <summary>
		/// show an error over the files combobox
		/// </summary>
		/// <param name="message">message to show</param>
		private void ShowErrorTooltip( string message )
		{
			// show the tooltip message over the files combobox
			ttpError.Show( message, this, txtFolder.Location.X + 10, txtFolder.Location.Y - 40, 3000 );
		}

        #endregion
    }
}
