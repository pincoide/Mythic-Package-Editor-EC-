using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace Mythic.Package.Editor
{
    /// <summary>
    /// Add/replace file form
    /// </summary>
    public partial class AddFile : Form
    {
        // --------------------------------------------------------------
        #region PUBLIC VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// List of the selected files
        /// </summary>
        public string[] Files => lstFiles.Items.Cast<string>().ToArray();

        /// <summary>
        /// Relative path of the file(s) to add/replace
        /// </summary>
        public string InnerDirectory { get => cmbRelativePath.Text; set => cmbRelativePath.Text = value; }

        /// <summary>
        /// Type of compression to use for the file(s)
        /// </summary>
        public CompressionFlag Compression
        {
            get => (CompressionFlag)cmbCompression.SelectedIndex;
            set => cmbCompression.SelectedIndex = cmbCompression.Items.IndexOf( value.ToString() );
        }

        /// <summary>
        /// Set if the file browse should allow multiple files selection
        /// </summary>
        public bool MultiFileSelect { get => OpenFileDialog.Multiselect; set => OpenFileDialog.Multiselect = value; }

        /// <summary>
        /// Set the window title
        /// </summary>
        public string Title { get => Text; set { Text = value; btnOK.Text = value; } }

        /// <summary>
        /// Package to add/replace the files to
        /// </summary>
        public MythicPackage PackageToAddTo { get; set; }

        /// <summary>
        /// File to replace
        /// </summary>
        public MythicPackageFile FileToReplace { get; set; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        public AddFile()
        {
            // initialize the components
            InitializeComponent();

            // set the form icon
            Icon = Icon.FromHandle( Properties.Resources.Add.GetHicon() );

            // set the window title
            Text = Globals.LanguageManager.GetString( "AddFile_Title" );

            // set the caption labels text
            lblFiles.Text = Globals.LanguageManager.GetString( "AddFile_File" );
            lblRelativePath.Text = Globals.LanguageManager.GetString( "AddFile_InnerDirectory" );
            lblCompression.Text = Globals.LanguageManager.GetString( "AddFile_Compression" );

            // set the checkbox text
            chkShowAll.Text = Globals.LanguageManager.GetString( "AddFile_ShowAll" );

            // set the checkbox tooltip
            ttp.SetToolTip( chkShowAll, Globals.LanguageManager.GetString( "AddFile_ShowAll_ttp" ) );

            // set the button text
            btnCancel.Text = Globals.LanguageManager.GetString( "AddFile_Button_Cancel" );
            btnOK.Text = Globals.LanguageManager.GetString( "AddFile_Button_Add" );

            // set the open file dialog title
            OpenFileDialog.Title = Globals.LanguageManager.GetString( "AddFile_Dialog_Title" );

            // add all the known relative paths to the list
            cmbRelativePath.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

            // if we have something in the relative paths list, we select the first one
            if ( cmbRelativePath.Items.Count > 0 )
                cmbRelativePath.SelectedIndex = 0;

            // fill the compression type list
            cmbCompression.Items.AddRange( Enum.GetNames( typeof( CompressionFlag ) ) );

            // set it to zlib as default
            cmbCompression.SelectedIndex = 1;

            // initialize the tooltip error title
            ttpError.ToolTipTitle = Globals.LanguageManager.GetString( "AddFile_ToolTip_Title" );
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Set the file in the list (only for replace)
        /// </summary>
        /// <param name="fileName">file to show on the list</param>
        public void SetCurrentReplacement( string fileName )
        {
            // clear the list
            lstFiles.Items.Clear();

            // add the item to the list
            lstFiles.Items.Add( fileName );
        }

        /// <summary>
        /// Clear the files list
        /// </summary>
        public void ClearList()
        {
            // clear the list
            lstFiles.Items.Clear();
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL EVENTS
        // --------------------------------------------------------------

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
        /// Dialog show event
        /// </summary>
        private void AddFile_Shown( object sender, EventArgs e )
        {
            // can we select multiple files?
            if ( MultiFileSelect )
            {
                // make the window higher
                Height = 310;

                // make the text files list higher
                lstFiles.Height = 150;
            }
            else // single file
            {
                // make the window shorter
                Height = 180;

                // make the text files list so that it will show only 1 file
                lstFiles.Height = 17;
            }

            // enable the checkbox
            chkShowAll.Enabled = true;

            // uncheck the checkbox
            chkShowAll.Checked = false;

            // by default we fill the relative paths combo with the paths used in this package
            GetPackageFolders();
        }

        /// <summary>
        /// add files button clicked
        /// </summary>
        private void btnOK_Click( object sender, EventArgs e )
        {
            try
            {
                // check the files are correct, if they are we can confirm it all
                if ( CheckFiles() )
                {
                    // set the dialog result to OK
                    DialogResult = DialogResult.OK;

                    // close the form
                    Close();
                }

            }
            catch ( Exception ex )
            {
                // there was an unknown problem with the files, show an error
                ShowErrorTooltip( ex.Message );
            }
        }

        /// <summary>
        /// Cancel button clicked
        /// </summary>
        private void btnCancel_Click( object sender, EventArgs e )
        {
            // clear the selected files list
            ClearList();
        }

        /// <summary>
        /// Search files button clicked
        /// </summary>
        private void btnBrowseFile_Click( object sender, EventArgs e )
        {
            // do we have some files selected?
            if ( OpenFileDialog.ShowDialog( this ) == DialogResult.OK )
            {
                // clear the files list
                lstFiles.Items.Clear();

                // add the selected files to the list
                lstFiles.Items.AddRange( OpenFileDialog.FileNames );

                // if we have some files in the list, we select the first one
                if ( lstFiles.Items.Count > 0 )
                    lstFiles.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Delete selected file from the list
        /// </summary>
        private void btnDeleteFile_Click( object sender, EventArgs e )
        {
            // if we have an item selected in the list (and we can have multiple files), we remove it
            if ( lstFiles.SelectedIndex >= 0 && MultiFileSelect )
                lstFiles.Items.Remove( lstFiles.SelectedItem );

            // if we can't have multiple files, we just clear the list (if there is something in the list)
            else if ( lstFiles.Items.Count > 0 && !MultiFileSelect )
                lstFiles.Items.Clear();
        }

        /// <summary>
        /// Draw the files list elements
        /// </summary>
        private void lstFiles_DrawItem( object sender, DrawItemEventArgs e )
        {
            // get the listbox object
            ListBox listBox = (ListBox)sender;

            // make sure there is an item to draw
            if ( e.Index < 0 )
                return;

            // default back color
            Color backColor = listBox.BackColor;

            // default forecolor
            Color textColor;

            // determine if the item is selected
            bool selected = ( e.State & DrawItemState.Selected ) == DrawItemState.Selected;

            // get the current item text
            string txt = listBox.GetItemText(listBox.Items[e.Index]);

            // is the item selected (and we can have multiple files?)
            if ( selected && MultiFileSelect )
            {
                // change colors for the selection
                backColor = Color.RoyalBlue;
            }

            // set the color for a file that doesn't exist
            if ( !File.Exists( txt ) )
                textColor = selected && MultiFileSelect ? Color.Salmon : Color.Red;

            else // set the color for a file that exist
                textColor = selected && MultiFileSelect ? Color.LightGreen : Color.DarkGreen;

            // check if the file already exist inside the package
            List<MythicPackageFile> existing = ( from b in PackageToAddTo.Blocks
                                                 from f in b.Files
                                                 where !string.IsNullOrEmpty( f.FileName ) && Path.GetFileName( txt ) == Path.GetFileName( f.FileName ) && f.FilePath == InnerDirectory.Replace( '\\', '/' ) && !f.Equals( FileToReplace )
                                                 select f ).ToList();

            // if the file already exist in the package, we mark it in orange
            if ( existing.Count > 0 )
                textColor = selected && MultiFileSelect ? Color.Orange : Color.DarkOrange;

            // check if the file has already been added
            List<MythicPackageFile> added = ( from b in PackageToAddTo.Blocks
                                              from f in b.Files
                                              where !string.IsNullOrEmpty( f.SourceFileName ) && Path.GetFileName( txt ) == Path.GetFileName( f.SourceFileName ) && f.FilePath == InnerDirectory.Replace( '\\', '/' ) && !f.Equals( FileToReplace )
                                              select f ).ToList();

            // if the file has already been added to the package, we mark it in magenta
            if ( added.Count > 0 )
                textColor = selected && MultiFileSelect ? Color.Magenta : Color.DarkMagenta;

            // create a brush and draw the selection rectangle
            using ( SolidBrush brush = new SolidBrush( backColor ) )
                e.Graphics.FillRectangle( brush, e.Bounds );

            // draw the text (only the file name, not the whole pat)
            TextRenderer.DrawText( e.Graphics, Path.GetFileName( txt ), listBox.Font, e.Bounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left );
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        ///  verify the files path is correct and that all the files still exist
        /// </summary>
        /// <returns>are the selected files still valid?</returns>
        private bool CheckFiles()
        {
            // search for invalid files
            List<string> invalid = Files.Where( f => f == null || !File.Exists( f ) ).ToList();

            // check if the file already exist insiede the package
            List<MythicPackageFile> existing = ( from ff in Files
                                                 from b in PackageToAddTo.Blocks
                                                 from f in b.Files
                                                 where !string.IsNullOrEmpty( f.FileName ) && Path.GetFileName( ff ) == Path.GetFileName( f.FileName ) && f.FilePath == InnerDirectory.Replace( '\\', '/' ) && !f.Equals( FileToReplace )
                                                 select f ).ToList();

            // check if the file has already been added
            List<MythicPackageFile> added = ( from ff in Files
                                              from b in PackageToAddTo.Blocks
                                              from f in b.Files
                                              where !string.IsNullOrEmpty( f.SourceFileName ) && Path.GetFileName( ff ) == Path.GetFileName( f.SourceFileName ) && f.FilePath == InnerDirectory.Replace( '\\', '/' ) && !f.Equals( FileToReplace )
                                              select f ).ToList();

            // redraw the list
            lstFiles.Refresh();

            // one or more files are invalid?
            if ( invalid.Count > 0 )
                ShowErrorTooltip( Globals.LanguageManager.GetString( "AddFile_ToolTip_Text" ) );

            else if ( existing.Count > 0 )
                ShowErrorTooltip( Globals.LanguageManager.GetString( "AddFile_ToolTip_Already_Exist" ) );

            else if ( added.Count > 0 )
                ShowErrorTooltip( Globals.LanguageManager.GetString( "AddFile_ToolTip_Already_Added" ) );

            // if we have something inside the list, there is at least 1 invalid file.
            return invalid.Count <= 0 && existing.Count <= 0 && added.Count <= 0;
        }

        /// <summary>
        /// show an error over the files combobox
        /// </summary>
        /// <param name="message">message to show</param>
        private void ShowErrorTooltip( string message )
        {
            // show the tooltip message over the files combobox
            ttpError.Show( message, this, lstFiles.Location.X + 10, lstFiles.Location.Y - 40, 3000 );
        }

        /// <summary>
		/// Update the relative path combo with the folders used in this package
		/// </summary>
		private void GetPackageFolders()
        {
            // clear the relative path combo
            cmbRelativePath.Items.Clear();

            // get all the unique paths of this package
            string[] paths = PackageToAddTo.GetAllPaths();

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