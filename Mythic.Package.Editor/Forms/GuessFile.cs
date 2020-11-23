using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Mythic.Package.Editor
{
    public partial class GuessFile : Form
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// File that we are analyzing
        /// </summary>
        private readonly MythicPackageFile m_File;

        /// <summary>
        /// brute froce search entries in use
        /// </summary>
        private List<BruteForceEntry> entries;

        /// <summary>
        /// original string used to start the search
        /// </summary>
        private string originalPattern;

        private volatile bool m_NameFound;

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Flag indicating that we found the name
        /// </summary>
        public bool NameFound { get => m_NameFound; set => m_NameFound = value; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        /// <param name="file"></param>
        public GuessFile( MythicPackageFile file )
        {
            // initialize the components
            InitializeComponent();

            // set the form icon
            Icon = Icon.FromHandle( Properties.Resources.SearchExpression.GetHicon() );

            // set the file we're using
            m_File = file;

            // set the window title
            Text = Globals.LanguageManager.GetString( "GuessFileDialog_Title" );

            // set the checkbox text
            chkShowAll.Text = Globals.LanguageManager.GetString( "GuessFileDialog_ShowAll" );

            // set the checkbox tooltip
            ttp.SetToolTip( chkShowAll, Globals.LanguageManager.GetString( "GuessFileDialog_ShowAll_ttp" ) );

            // set the "type to find the name" status
            lblStatus.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Type" );

            // set the file hash text
            lblFileHash.Text = string.Format( Globals.LanguageManager.GetString( "GuessFileDialog_FileHash" ), m_File.FileHash.ToString( "X16" ) );

            // set the buttons text
            btnBrute.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Brute" );
            btnCancel.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Cancel" );

            // initialize the tooltip error title
            ttpError.ToolTipTitle = Globals.LanguageManager.GetString( "GuessFileDialog_ErrorTitle" );

            // remove the typed hash text
            lblTypeHash.Text = "";
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// form shows up event
        /// </summary>
        private void GuessFile_Shown( object sender, EventArgs e )
        {
            // enable the checkbox
            chkShowAll.Enabled = true;

            // uncheck the checkbox
            chkShowAll.Checked = false;

            // by default we fill the relative paths combo with the paths used in this package
            GetPackageFolders();
        }

        /// <summary>
        /// Folder checkbox value changed
        /// </summary>
        private void chkShowAll_CheckedChanged( object sender, EventArgs e )
        {
            // if enabled, all folders will be shown in the relative path combo
            if ( chkShowAll.Checked )
                GetAllKnownFolders();

            else // if disabled, only the folders used in this file's package will be shown in the relative path combo
                GetPackageFolders();
        }

        /// <summary>
        /// Begin/stop brute search
        /// </summary>
        private void btnBrute_Click( object sender, EventArgs e )
        {
            // is the search in progress?
            if ( Worker.IsBusy )
            {
                // re-enable the form
                EnableForm();

                // send the cancel request
                Worker.CancelAsync();
            }
            else // start search
            {
                // verify the pattern
                BruteForce.CreateEntryResults verify = BruteForce.VerifyBruteForcePattern( txtFileName.Text, out entries );

                // do we have valid patterns?
                if ( verify == BruteForce.CreateEntryResults.succecss )
                {
                    // store the current pattern
                    originalPattern = txtFileName.Text;

                    // disable the form
                    DisableForm();

                    // start the search
                    Worker.RunWorkerAsync();
                }
                else // show the pattern error
                    ShowErrorTooltip( Globals.LanguageManager.GetString( "BruteForce_Exception_" + verify.ToString() ) );
            }
        }

        /// <summary>
        /// Filename changed event
        /// </summary>
        private void txtFileName_TextChanged( object sender, EventArgs e )
        {
            // get the relative path
            string relativePath = cmbRelativePath.SelectedItem.ToString();

            // make sure the path is not included in the text
            txtFileName.Text = txtFileName.Text.Replace( relativePath, "" );

            // is the textbox empty?
            if ( string.IsNullOrEmpty( txtFileName.Text ) )
            {
                // clear the typed hash text
                lblTypeHash.Text = "";

                return;
            }

            // get the file name from the textbox
            string fileName = relativePath + txtFileName.Text;

            // set the color red
            txtFileName.ForeColor = Color.Black;

            // brute force button disabled unless there is a pattern to search
            btnBrute.Enabled = Worker.IsBusy;

            // do we have a brute force pattern?
            if ( fileName.Contains( "{" ) || fileName.Contains( "}" ) )
            {
                // remove the typed hash for the brute force pattern
                lblTypeHash.Text = "";

                // verify the pattern
                BruteForce.CreateEntryResults verify = BruteForce.VerifyBruteForcePattern( fileName, out _ );

                // do we have at least 1 valid pattern?
                if ( verify != BruteForce.CreateEntryResults.succecss )
                {
                    // set the color red
                    txtFileName.ForeColor = Color.Red;

                    // show the pattern error
                    ShowErrorTooltip( Globals.LanguageManager.GetString( "BruteForce_Exception_" + verify.ToString() ) );

                    return;
                }

                // enable brute force button if the pattern is correct
                btnBrute.Enabled = true;
            }
            else // normal search
            {
                // make sure the file name is viable
                if ( Path.GetFileName( fileName ).IndexOfAny( Path.GetInvalidFileNameChars() ) >= 0 )
                {
                    // set the color red
                    txtFileName.ForeColor = Color.Red;

                    return;
                }

                // calculate the hash of the typed text
                ulong textHash = HashDictionary.HashFileName( fileName );

                // does the typed hash matches the file hash?
                if ( m_File.FileHash == textHash )
                {
                    // flag that we found the name
                    NameFound = true;

                    // stop the current search if we found a match
                    Worker.CancelAsync();

                    // update the dictionary
                    HashDictionary.Set( m_File.FileHash, fileName );

                    // update the form
                    m_File.RefreshFileName();

                    // close the guess window if the search is not running
                    Close();
                }
                // show the new hash and text color ONLY if we're not doing the brute force search
                else if ( !Worker.IsBusy )
                {
                    // set the typed hash text
                    lblTypeHash.Text = string.Format( Globals.LanguageManager.GetString( "GuessFileDialog_TypedHash" ), textHash.ToString( "X16" ) );

                    // set the color red
                    txtFileName.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Execute a background search
        /// </summary>
        private void Worker_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e )
        {
            // continue until all entries are completed (or the process has been stopped by the user)
            while ( !BruteForce.AllEntriesCompleted( ref entries ) && !Worker.CancellationPending && !NameFound )
            {
                // create the text for the file of the brute force. When the result is correct, the form will close.
                SetTextBox( BruteForce.GetNextBruteString( ref entries ) );
            }

            // if the process has been cancelled, we restore the text in the textbox
            if ( Worker.CancellationPending && !NameFound )
                SetTextBox( originalPattern );
        }

        /// <summary>
        /// Search complete
        /// </summary>
        private void Worker_RunWorkerCompleted( object sender, System.ComponentModel.RunWorkerCompletedEventArgs e )
        {
            // re-enable the form
            EnableForm();
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// show an error over the files combobox
        /// </summary>
        /// <param name="message">message to show</param>
        private void ShowErrorTooltip( string message )
        {
            // show the tooltip message over the files combobox
            ttpError.Show( message, this, txtFileName.Location.X + 10, txtFileName.Location.Y - 80, 5000 );
        }

        /// <summary>
        /// Disable all forms controls
        /// </summary>
        private void DisableForm()
        {
            // set the search status window
            lblStatus.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Search" );

            // scan all the components of the form
            foreach ( Control obj in Controls )
            {
                // disable all but the bruteforce button
                if ( obj != btnBrute && obj != this )
                    obj.Enabled = false;
            }

            // change the button text to stop search
            btnBrute.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Stop" );
        }

        /// <summary>
        /// Enable all forms controls
        /// </summary>
        private void EnableForm()
        {
            // set the "type to find the name" status
            lblStatus.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Type" );

            // scan all the components of the form
            foreach ( Control obj in Controls )
            {
                // enable all but the bruteforce button
                if ( obj != btnBrute && obj != this )
                    obj.Enabled = true;
            }

            // change the button text to the starting value
            btnBrute.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Brute" );

            // restore the original search pattern
            if ( !string.IsNullOrEmpty( originalPattern ) )
                txtFileName.Text = originalPattern;
        }

        /// <summary>
        /// Set the text to a textbox from another thread
        /// </summary>
        /// <param name="value">text to set into the textbox</param>
        private void SetTextBox( string value )
        {
            // is the call from another thread?
            if ( InvokeRequired )
            {
                // make the call from the correct thread
                Invoke( new Action<string>( SetTextBox ), new object[] { value } );

                return;
            }

            // set the text
            txtFileName.Text = value;
        }

        /// <summary>
        /// Update the relative path combo with the folders used in this package
        /// </summary>
        private void GetPackageFolders()
        {
            // clear the relative path combo
            cmbRelativePath.Items.Clear();

            // get all the unique paths of this package
            string[] paths = m_File.Parent.Parent.GetAllPaths();

            // did we find any path?
            if ( paths.Length <= 0 )
            {
                // get all known paths
                GetAllKnownFolders();

                // disable the checkbox
                chkShowAll.Enabled = false;

                return;
            }

            // add all the known relative paths to the list
            cmbRelativePath.Items.AddRange( paths );

            // if we have something in the relative paths list, we select the first one
            if ( cmbRelativePath.Items.Count > 0 )
                cmbRelativePath.SelectedIndex = 0;
        }

        /// <summary>
        /// Get all known folders from settings
        /// </summary>
        private void GetAllKnownFolders()
        {
            // clear the relative path combo
            cmbRelativePath.Items.Clear();

            // add all the known relative paths to the list
            cmbRelativePath.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

            // if we have something in the relative paths list, we select the first one
            if ( cmbRelativePath.Items.Count > 0 )
                cmbRelativePath.SelectedIndex = 0;
        }

        #endregion
    }
}
