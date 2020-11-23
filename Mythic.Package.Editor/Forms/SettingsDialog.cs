using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
    public partial class SettingsDialog : Form
    {
        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        public SettingsDialog()
        {
            // initialize the components
            InitializeComponent();

            // set the form icon
            Icon = Icon.FromHandle( Properties.Resources.Wrench.GetHicon() );

            // set the form title
            Text = Globals.LanguageManager.GetString( "SettingsDialog_Title" );

            // set the labels caption text
            lblLanguage.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Language" );
            lblCurrentLangauge.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_CurrentLanguage" );
            lblUnpacking.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Unpacking" );
            lblOutputPath.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_OutputPath" );
            chkInnerFolder.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_InnerFolder" );
            lblInnerFolders.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_InnerFolders" );

            // set the error tooltip title
            ttpError.ToolTipTitle = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_ErrorTitle" );

            // fill the language combo
            cmbLanguage.Items.AddRange( Globals.Settings.LanguageOptions.ToArray() );

            // select the currently active language
            cmbLanguage.SelectedItem = Globals.Settings.Language;

            // set the output path to the one saved in the settings
            txtOutputPath.Text = Globals.Settings.OutputPath;

            // set the "relative folder path" checkbox value
            chkInnerFolder.Checked = Globals.Settings.WithInnerPath;

            // list all the saved relative paths
            lstInnerFolders.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

            // set the folder browse description
            FolderBrowser.Description = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Description" );

            // set the buttons text
            btnReset.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Reset" );
            btnCancel.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Cancel" );
            btnSave.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Save" );
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// Path changed event
        /// </summary>
        private void txtOutputPath_TextChanged( object sender, EventArgs e )
        {
            // verify the path while typing
            Verify();
        }

        /// <summary>
        /// Button reset click
        /// </summary>
        private void btnReset_Click( object sender, EventArgs e )
        {
            // set language to english
            cmbLanguage.SelectedItem = "Eng.xml";

            // set the output path to the default directory
            txtOutputPath.Text = Path.Combine( Application.StartupPath, "Output" ); ;

            // restore the check to the use of relative paths
            chkInnerFolder.Checked = true;
        }

        /// <summary>
        /// Button save click
        /// </summary>
        private void ButtonSave_Click( object sender, EventArgs e )
        {
            // make sure the output path is correct before we save
            if ( !Verify() )
                return;

            // save the output path
            Globals.Settings.OutputPath = txtOutputPath.Text;

            // save the selected language
            Globals.Settings.Language = cmbLanguage.SelectedItem.ToString();

            // save the relative path usage setting
            Globals.Settings.WithInnerPath = chkInnerFolder.Checked;

            // update the relative paths list
            Globals.Settings.AddInnerDirectory( lstInnerFolders.Items.Cast<string>().ToList() );

            // save the settings
            Globals.Settings.Save();

            // set the dialog result as OK
            DialogResult = DialogResult.OK;

            // clse the dialog
            Close();
        }

        /// <summary>
        /// Add path button clicked
        /// </summary>
        private void btnAdd_Click( object sender, EventArgs e )
        {
            // add an empty folder to the list
            lstInnerFolders.Items.Add( string.Empty );

            // select the new item
            lstInnerFolders.SelectedIndex = lstInnerFolders.Items.Count - 1;

            // show the edit textbox on the relative path
            ShowTextBox();
        }

        /// <summary>
        /// Delete path button clicked
        /// </summary>
        private void btnRemove_Click( object sender, EventArgs e )
        {
            // Delete the selected path from the list
            DeletePath();
        }

        /// <summary>
        /// Change output path button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputPath_Click( object sender, EventArgs e )
        {
            // show the open folder dialog. If we have a result, we set it to the output textbox
            if ( FolderBrowser.ShowDialog( this ) == DialogResult.OK )
                txtOutputPath.Text = FolderBrowser.SelectedPath;
        }

        /// <summary>
        /// Edit folders list key down event
        /// </summary>
        private void txtDynamic_KeyDown( object sender, KeyEventArgs e )
        {
            // enter or escape pressed?
            if ( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape )
            {
                // hide the text box
                HideTextBox();

                // prevent the "beep"
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Edit folders lost focus event
        /// </summary>
        private void txtDynamic_LostFocus( object sender, EventArgs e )
        {
            // hide the text box on focus lost
            HideTextBox();
        }

        /// <summary>
        /// Folders list double click event
        /// </summary>
        private void lstInnerFolders_DoubleClick( object sender, EventArgs e )
        {
            // show the edit textbox on a relative path double click
            ShowTextBox();
        }

        /// <summary>
        /// Folders list key down event
        /// </summary>
        private void lstInnerFolders_KeyDown( object sender, KeyEventArgs e )
        {
            // f2 or enter pressed? we show the edit box
            if ( e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter )
                ShowTextBox();

            // delete pressed? delete the selected path
            else if ( e.KeyCode == Keys.Delete )
                DeletePath();

            // prevent the "beep"
            e.Handled = e.SuppressKeyPress = true;
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Verify all the data is correct
        /// </summary>
        /// <returns>is the cdata correct?</returns>
        private bool Verify()
        {
            // set the path color to black (default)
            txtOutputPath.ForeColor = Color.Black;

            // does the path exist?
            if ( !Directory.Exists( txtOutputPath.Text ) )
            {
                // show the error the path doesn't exist
                ttpError.Show( Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_ErrorText" ), txtOutputPath, 0, -70 );

                // set the path color to red
                txtOutputPath.ForeColor = Color.Red;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Show the textbox to edit a relative path in the list
        /// </summary>
        private void ShowTextBox()
        {
            // get the current selected item index
            int selected = lstInnerFolders.SelectedIndex;

            // do we have a selected item?
            if ( selected >= 0 )
            {
                // disable the list box during edit
                lstInnerFolders.Enabled = false;

                // get the selected item size
                Rectangle rec = lstInnerFolders.GetItemRectangle( selected );

                // get the selected item position
                Point loc = lstInnerFolders.Location;

                // move the edit box to the item position
                txtDynamic.Location = new Point( loc.X + rec.X + 3, loc.Y + rec.Y + 7 );

                // resize the edit box to the item we're trying to edit size
                txtDynamic.Size = new Size( rec.Width, rec.Height );

                // set the edit box text to the same text as the item
                txtDynamic.Text = (string)lstInnerFolders.Items[selected];

                // show the edit box
                txtDynamic.Show();

                // set the focus on the edit box
                txtDynamic.Focus();

                // select the text
                txtDynamic.SelectAll();
            }
        }

        /// <summary>
        /// Hide the edit box for the relative paths in the list
        /// </summary>
        private void HideTextBox()
        {
            // disable the list box during edit
            lstInnerFolders.Enabled = true;

            // get the current selected item index
            int selected = lstInnerFolders.SelectedIndex;

            // do we have a selected item? then we rename it
            if ( selected >= 0 )
                lstInnerFolders.Items[selected] = txtDynamic.Text;

            // hide the edit box
            txtDynamic.Hide();
        }

        /// <summary>
        /// Delete the selected relative path from the list
        /// </summary>
        private void DeletePath()
        {
            // get the selected item index
            int selected = lstInnerFolders.SelectedIndex;

            // do we have an item selected?
            if ( selected >= 0 )
            {
                // remove the selected item
                lstInnerFolders.Items.RemoveAt( selected );

                // was the selected item the last in the list? then we selecte the "new" last
                if ( selected >= lstInnerFolders.Items.Count )
                    lstInnerFolders.SelectedIndex = selected - 1;

                else // select the next item in the list
                    lstInnerFolders.SelectedIndex = selected;
            }
        }

        #endregion
    }
}
