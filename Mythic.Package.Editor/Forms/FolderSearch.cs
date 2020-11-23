using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Mythic.Package.Editor
{
    public partial class FolderSearch : Form
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// Selected forlder
        /// </summary>
        public string RootDirectory => txtFolder.Text;

        /// <summary>
        /// Inner directory to parse
        /// </summary>
        public string InnerDirectory => cmbRelativePath.Text;

        /// <summary>
        /// Package to search
        /// </summary>
        public List<MythicPackage> PackagesToSearch { get; set; } = new List<MythicPackage>();

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        public FolderSearch()
        {
            // initialize the components
            InitializeComponent();

            // set the form icon
            Icon = Icon.FromHandle( Properties.Resources.Folder.GetHicon() );

            // set the caption labels text
            lblFolder.Text = Globals.LanguageManager.GetString( "FolderSearch_Folder" );
            lblRelativePath.Text = Globals.LanguageManager.GetString( "FolderSearch_InnerDirectory" );

            // set the checkbox text
            chkShowAll.Text = Globals.LanguageManager.GetString( "FolderSearch_ShowAll" );

            // set the checkbox tooltip
            ttp.SetToolTip( chkShowAll, Globals.LanguageManager.GetString( "FolderSearch_ShowAll_ttp" ) );

            // set the button text
            btnCancel.Text = Globals.LanguageManager.GetString( "FolderSearch_Button_Cancel" );
            btnParse.Text = Globals.LanguageManager.GetString( "FolderSearch_Button_Parse" );

            // add all the known relative paths to the list
            cmbRelativePath.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

            // if we have something in the relative paths list, we select the first one
            if ( cmbRelativePath.Items.Count > 0 )
                cmbRelativePath.SelectedIndex = 0;

            // initialize the tooltip error title
            InvalidPath.ToolTipTitle = Globals.LanguageManager.GetString( "FolderSearch_ToolTip_Title" );

            // set the root folder for the search
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            // set the open folder description
            OpenFolderDialog.Description = Globals.LanguageManager.GetString( "FolderSearch_Browse_Description" );
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// form shows up event
        /// </summary>
        private void FolderSearch_Shown( object sender, EventArgs e )
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
        /// Parse folder button clicked
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
            InvalidPath.Show( message, this, txtFolder.Location.X + 10, txtFolder.Location.Y - 40, 3000 );
        }

        /// <summary>
        /// Update the relative path combo with the folders used in this package
        /// </summary>
        private void GetPackageFolders()
        {
            // clear the relative path combo
            cmbRelativePath.Items.Clear();

            // intialize the paths array
            string[] paths = new string[0];

            // search the paths in all packages
            foreach ( MythicPackage p in PackagesToSearch )
            {
                // get all the unique paths of this package
                string[] path = p.GetAllPaths();

                // add the new paths
                paths = paths.Concat( path ).ToArray();
            }

            // remove all duplicates
            paths = paths.Distinct().ToArray();

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
