using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using DelayTimer = System.Timers.Timer;
using Mythic.Package.Spy;
using System.Linq;
using System.Data;
using System.Media;
using StbImageSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CSharpImageLibrary;
using System.Windows;
using System.Windows.Media.Imaging;
using Clipboard = System.Windows.Clipboard;

namespace Mythic.Package.Editor
{
    /// <summary>
    /// Main app window
    /// </summary>
    public partial class MainForm : Form
    {
        // --------------------------------------------------------------
        #region PRIVATE VARIABLES
        // --------------------------------------------------------------

        /// <summary>
        /// counter for new hashes
        /// </summary>
        private int m_NewHashes;

        /// <summary>
        /// counter for new file names
        /// </summary>
        private int m_NewFileNames;

        private string m_OldKeyword;

        /// <summary>
        /// last keyword used in the text search
        /// </summary>
        private string OldKeyword
        {
            get => m_OldKeyword;
            set
            {
                // reset the results if the keyword is different
                if ( m_OldKeyword != value )
                {
                    m_searchIdx = -1;
                    results.Clear();
                }

                // store the new keyword
                m_OldKeyword = value;
            }
        }

        /// <summary>
        /// supported text files extension
        /// </summary>
        private readonly List<string> textExtensions = new List<string> { ".csv", ".xml", ".lua" };

        /// <summary>
        /// supported image files extension
        /// </summary>
        private readonly List<string> imageExtensions = new List<string> { ".dds", ".tga", ".jpg", ".png" };

        /// <summary>
        /// storage for the preview tab page (so we can show/hide it)
        /// </summary>
        private TabPage m_previewPage;

        /// <summary>
        /// current files matching the text search result
        /// </summary>
        private List<MythicPackageFile> results = new List<MythicPackageFile>();

        /// <summary>
        /// current index inside the search results
        /// </summary>
        private int m_searchIdx = -1;

        /// <summary>
        /// Flag indicating that a search (folder or brute force) is in progress
        /// </summary>
        private bool SearchInProgess { get; set; }

        /// <summary>
        /// Flag indicating that we are updating the files list (it could take some time if there are a lot of blocks)
        /// </summary>
        private bool RefreshInProgess { get; set; }

        #endregion

        // --------------------------------------------------------------
        #region CONSTRUCTOR
        // --------------------------------------------------------------

        /// <summary>
        /// Initialize the form
        /// </summary>
        public MainForm()
        {
            // initialize the components
            InitializeComponent();

            // initialize the window elements with text and data
            Initialize();
        }

        #endregion

        // --------------------------------------------------------------
        #region LOCAL EVENTS
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region FORM EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// Form shown event
        /// </summary>
        private void MainForm_Shown( object sender, EventArgs e )
        {
            // create a timer
            DelayTimer timer = new DelayTimer( 100 );

            // add the disable topmost event to the timer tick
            timer.Elapsed += new ElapsedEventHandler( DisableTopMost );

            // attach the timer to the form
            timer.SynchronizingObject = this;

            // disable the autorestart
            timer.AutoReset = false;

            // start the timer
            timer.Start();
        }

        /// <summary>
        /// Is the form about to close?
        /// </summary>
        private void Main_FormClosing( object sender, FormClosingEventArgs e )
        {
            // determine if we can exit, if we can't, we cancel the closing
            e.Cancel = !TryExit();
        }

        /// <summary>
        /// Form size changed event
        /// </summary>
        private void MainForm_SizeChanged( object sender, EventArgs e )
        {
            // make sure the listbox and treeview height remains the same
            ListBox.Height = TreeView.Height;
        }

        /// <summary>
        /// Application exit event
        /// </summary>
        private void OnApplicationExit( object sender, EventArgs e )
        {
            // start a cmd process to delete the zlib files
            Process psi = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C timeout 3 & del /Q \"{ Path.Combine( Application.StartupPath, "Zlib32.dll" ) }\" & del /Q \"{ Path.Combine( Application.StartupPath, "Zlib64.dll" ) }\"",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            // start the process
            psi.Start();
        }

        #endregion

        // --------------------------------------------------------------
        #region TREEVIEW EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// Select a tree node event
        /// </summary>
        private void TreeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            // is the selected node an UOP file? get the package info
            if ( e.Node.Tag is MythicPackage package )
                ChangePackage( package );

            // is the selected node a block? get the block info
            else if ( e.Node.Tag is MythicPackageBlock block )
                ChangeBlock( block );

            else // nothing selected? clear all tabs
                ClearAllTabs();
        }

        /// <summary>
        /// Treeview button pressed
        /// </summary>
        private void TreeView_KeyDown( object sender, KeyEventArgs e )
        {
            // escape
            if ( e.KeyCode == Keys.Escape )
            {
                // remove the node selection
                TreeView.SelectedNode = null;

                // prevent the system "beep"
                e.SuppressKeyPress = e.Handled = true;
            }
            // DEL key trigger the delete button
            else if ( e.KeyCode == Keys.Delete )
                btnRemove.PerformClick();
        }

        /// <summary>
        /// Tree node custom drawing event
        /// </summary>
        private void TreeView_DrawNode( object sender, DrawTreeNodeEventArgs e )
        {
            // make sure we have a node to draw
            if ( e.Node == null ) return;

            // get the treeview object
            TreeView tree = e.Node.TreeView;

            // default back color
            Color backColor = tree.BackColor;

            // default forecolor
            Color textColor = tree.ForeColor;

            // get the selected status of the node
            bool selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;

            // get the current node text
            string txt = e.Node.Text;

            // is the node selected?
            if ( selected )
            {
                // change colors for the selection
                backColor = Color.RoyalBlue;
                textColor = Color.Yellow;
            }

            // set the color for a modified file
            if ( txt.EndsWith( "*" ) )
                textColor = selected ? Color.Salmon : Color.Red;

            // set the color for a new file
            if ( txt.EndsWith( "+" ) )
                textColor = selected ? Color.LightGreen : Color.DarkGreen;

            // create a brush and draw the selection rectangle
            using ( SolidBrush brush = new SolidBrush( backColor ) )
                e.Graphics.FillRectangle( brush, e.Bounds );

            // draw the text
            TextRenderer.DrawText( e.Graphics, txt, tree.Font, e.Bounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left );
        }

        #endregion

        // --------------------------------------------------------------
        #region LISTVIEW EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// Listbox key down event
        /// </summary>

        private void ListBox_KeyDown( object sender, KeyEventArgs e )
        {
            // delete key pressed? press the remove button
            if ( e.KeyCode == Keys.Delete )
                btnRemove.PerformClick();

            // F3 pressed? we search for the next file matching the search
            else if ( e.KeyCode == Keys.F3 && !e.Shift )
                TextSearch( txtSearchBox.Text, txtSearchBox.Text == OldKeyword );

            // SHIFT + F3 pressed? we search for the previous file matching the search
            else if ( e.KeyCode == Keys.F3 && e.Shift )
                TextSearch( txtSearchBox.Text, txtSearchBox.Text == OldKeyword, true );

            // escape pressed?
            else if ( e.KeyCode == Keys.Escape )
            {
                // remove the current selection
                ListBox.SelectedIndex = -1;

                // focus the tree view
                TreeView.Focus();

                // prevent the system "beep"
                e.SuppressKeyPress = e.Handled = true;
            }
        }

        /// <summary>
        /// A file on the list has been selected
        /// </summary>
        private void ListBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            // get the selected file data
            MythicPackageFile file = (MythicPackageFile)ListBox.SelectedItem;

            // do we have a valid file?
            if ( file != null )
            {
                // toggle the button to unset the file name (available only if we have a file name)
                btnFileUnset.Visible = string.IsNullOrEmpty( file.FileName );

                // load the file data
                ChangeFile( file );
            }
            else // clear the file data
                ClearFile();
        }

        /// <summary>
        /// Listbox custom draw items event
        /// </summary>
        private void ListBox_DrawItem( object sender, DrawItemEventArgs e )
        {
            // get the listbox object
            ListBox listBox = (ListBox)sender;

            // make sure there is an item to draw
            if ( e.Index < 0 )
                return;

            // default back color
            Color backColor = listBox.BackColor;

            // default forecolor
            Color textColor = listBox.ForeColor;

            // determine if the item is selected
            bool selected = ( e.State & DrawItemState.Selected ) == DrawItemState.Selected;

            // get the current item text
            string txt = listBox.GetItemText(listBox.Items[e.Index]);

            // is the item selected?
            if ( selected )
            {
                // change colors for the selection
                backColor = Color.RoyalBlue;
                textColor = Color.Yellow;
            }

            // set the color for a modified file
            if ( txt.StartsWith( "*" ) )
                textColor = selected ? Color.Salmon : Color.Red;

            // set the color for a new file
            if ( txt.StartsWith( "+" ) )
                textColor = selected ? Color.LightGreen : Color.DarkGreen;

            // create a brush and draw the selection rectangle
            using ( SolidBrush brush = new SolidBrush( backColor ) )
                e.Graphics.FillRectangle( brush, e.Bounds );

            // draw the text
            TextRenderer.DrawText( e.Graphics, txt, listBox.Font, e.Bounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left );
        }

        #endregion

        // --------------------------------------------------------------
        #region MAIN MENU
        // --------------------------------------------------------------

        /// <summary>
        /// Create new UOP event
        /// </summary>
        private void MainMenuFileNew_Click( object sender, EventArgs e )
        {
            // create a new UOP
            MythicPackage package = new MythicPackage();

            // create the node for the UOP
            int node = TreeView.Nodes.Add( new TreeNode( package.ToString() ) { Tag = package, } );

            // select the node
            TreeView.SelectedNode = TreeView.Nodes[node];
        }

        /// <summary>
        /// Open UOP event
        /// </summary>
        private void MainMenuFileOpen_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // show the open file window
            if ( ShowOpenPackage() == DialogResult.OK )
            {
                // get the list of UOP files that are NOT already opened
                List<string> files = OpenFileDialog.FileNames.Where( fileName => !AlreadyOpen( fileName ) ).ToList();

                // update the list of new hashes and file names
                m_NewHashes = HashDictionary.NewHashes;
                m_NewFileNames = HashDictionary.NewFileNames;

                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_LoadingPackages" ), false );

                // start the background thread to open the files
                Worker.RunWorkerAsync( new LoadMythicPackageArgs( files.ToArray() ) );
            }
        }

        /// <summary>
        /// Save UOP event
        /// </summary>
        private void MainMenuFileSave_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // get the selected package
            MythicPackage package = GetSelectedPackage( out _ );

            // do we have a selected package?
            if ( package != null )
            {
                // save the package
                SavePackage( package );
            }
            else // warn the user that there is nothing selected
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
        }

        /// <summary>
        /// Close a package file
        /// </summary>
        private void MainMenuFileClose_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // get the selected package
            MythicPackage package = GetSelectedPackage( out TreeNode packageNode );

            // do we have a selected package?
            if ( package != null )
            {
                // has the package been modified?
                if ( package.Modified )
                {
                    // ask the user if he wants to save the changes
                    DialogResult res = ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_SavePackage" ) );

                    // get out in case of "cancel"
                    if ( res == DialogResult.Cancel )
                        return;

                    // save the package in case of "yes", then close the file
                    if ( res == DialogResult.Yes )
                    {
                        // save the package
                        SavePackage( package, true );

                        // we can go out since the save will close the file when the saving is done
                        return;
                    }
                }

                // close the package
                CloseFile( packageNode );
            }
            else // warn the user that there is nothing selected
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
        }

        /// <summary>
        /// Close button click
        /// </summary>
        private void MainMenuFileExit_Click( object sender, EventArgs e )
        {
            // if we can get out, we close the application
            if ( TryExit() )
                Application.Exit();
        }

        /// <summary>
        /// Edit settings click
        /// </summary>
        private void MainMenuEditSettings_Click( object sender, EventArgs e )
        {
            // show the settings dialog
            Settings.ShowDialog( this );
        }

        /// <summary>
        /// Save dictionary button click
        /// </summary>
        private void MainMenuDictionaryLoad_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // has the ditionary been modified?
            if ( HashDictionary.Modified )
            {
                // ask the user if he wants to save the changes
                if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_SaveDictionary" ) ) == DialogResult.Yes )
                {
                    // update the status with the new operation
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" ), false );

                    // start the background thread to save the dictionary
                    Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.Actions.SAVE ) );
                }
            }
            // show the open dictionary dialog
            else if ( ShowOpenDictionary() == DialogResult.OK )
            {
                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_LoadingDictionary" ), false );

                // start the background thread to load the dictionary
                Worker.RunWorkerAsync( new DictionaryArgs( OpenFileDialog.FileName, DictionaryArgs.Actions.LOAD ) );
            }
        }

        /// <summary>
        /// Save dictionary button click
        /// </summary>
        private void MainMenuDictionarySave_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // has the dictionary been modified?
            if ( HashDictionary.Modified )
            {
                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" ), false );

                // start the background thread to save the dictionary
                Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.Actions.SAVE ) );
            }
            else // warning the user that there is nothing to save
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_DictionaryNotChanged" ) );
        }

        /// <summary>
        /// Merge dictionary button click
        /// </summary>
        private void MainMenuDictionaryMerge_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // show the open dictionary dialog
            if ( ShowOpenDictionary() == DialogResult.OK )
            {
                // store the amount of new hashes and file names
                m_NewHashes = HashDictionary.NewHashes;
                m_NewFileNames = HashDictionary.NewFileNames;

                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_MergingDictionary" ), false );

                // start the background thread to merge the dictionary
                Worker.RunWorkerAsync( new DictionaryArgs( OpenFileDialog.FileName, DictionaryArgs.Actions.MERGE ) );
            }
        }

        /// <summary>
        /// Start process to spy button click
        /// </summary>
        private void MainMenuSpyStart_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // show the open executable file dialog
            if ( ShowOpenExecutable() == DialogResult.OK )
            {
                // store the amount of new hashes and file names
                m_NewHashes = HashDictionary.NewHashes;
                m_NewFileNames = HashDictionary.NewFileNames;

                // disable start and attach and enable detach to process
                MainMenuDictionarySpyStart.Enabled = false;
                MainMenuDictionarySpyAttach.Enabled = false;
                MainMenuDictionarySpyDetach.Enabled = true;

                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SpyingOn", OpenFileDialog.FileName ), false );

                // start the background thread to spy a process activity
                Worker.RunWorkerAsync( new SpyPathArgs( Globals.HashSpy, OpenFileDialog.FileName ) );
            }
        }

        /// <summary>
        /// Attach to a process to spy button click
        /// </summary>
        private void MainMenuSpyAttach_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // show the select process dialog
            if ( SelectProcess.ShowDialog( this ) == DialogResult.OK )
            {
                // get the selected process
                Process process = SelectProcess.SelectedProcess;

                // do we have a selected process?
                if ( process != null )
                {
                    // store the amount of new hashes and file names
                    m_NewHashes = HashDictionary.NewHashes;
                    m_NewFileNames = HashDictionary.NewFileNames;

                    // disable start and attach and enable detach to process
                    MainMenuDictionarySpyStart.Enabled = false;
                    MainMenuDictionarySpyAttach.Enabled = false;
                    MainMenuDictionarySpyDetach.Enabled = true;

                    // update the status with the new operation
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SpyingOn", process.ProcessName ), false );

                    // start the background thread to spy a process activity
                    Worker.RunWorkerAsync( new SpyProcessArgs( Globals.HashSpy, process ) );
                }
                else // invalid process
                    ShowError( Globals.LanguageManager.GetString( "MainForm_Information_InvalidProcess" ) );
            }
        }

        /// <summary>
        /// Detach from process button click
        /// </summary>
        private void MainMenuSpyDetach_Click( object sender, EventArgs e )
        {
            // enable star and attach and disable detach
            MainMenuDictionarySpyStart.Enabled = true;
            MainMenuDictionarySpyAttach.Enabled = true;
            MainMenuDictionarySpyDetach.Enabled = false;

            // do we still have the spy object? terminate the spy activity
            if ( Globals.HashSpy != null )
                Globals.HashSpy.EndSpy();

            // did we find new file names? show how many in the status
            if ( HashDictionary.NewFileNames > m_NewFileNames )
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewFileNames", ( HashDictionary.NewFileNames - m_NewFileNames ).ToString() ), false );

            // scan the treeview nodes
            foreach ( TreeNode node in TreeView.Nodes )
            {
                // update each package file names
                if ( node.Tag is MythicPackage package )
                    package.RefreshFileNames();
            }
        }

        /// <summary>
        /// Help button click
        /// </summary>
        private void MainMenuHelpContent_Click( object sender, EventArgs e )
        {
            // show the app guide
            Process.Start( "Help.chm" );
        }

        /// <summary>
        /// About button click
        /// </summary>
        private void MainMenuHelpAbout_Click( object sender, EventArgs e )
        {
            // show the about dialog
            About.ShowDialog( this );
        }

        #endregion

        // --------------------------------------------------------------
        #region TOOLBAR
        // --------------------------------------------------------------

        /// <summary>
        /// Add file button click
        /// </summary>
        private void ButtonAdd_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // get the selected package
            MythicPackage package = GetSelectedPackage( out _ );

            // do we have a package selected?
            if ( package == null )
            {
                // warn the user that needs to select a uop file
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );

                return;
            }

            // show the add files dialog
            if ( ShowAddFiles( package ) == DialogResult.OK )
            {
                // add the files to the package
                package.AddFiles( AddFile.Files, AddFile.InnerDirectory, AddFile.Compression );

                // refresh the block
                RefreshBlocks();
            }
        }

        /// <summary>
        /// Add folder button click
        /// </summary>
        private void ButtonAddFolder_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // get the selected package
            MythicPackage package = GetSelectedPackage( out _ );

            // do we have a package selected?
            if ( package == null )
            {
                // warn the user that needs to select a uop file
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );

                return;
            }

            // show the add folder dialog
            if ( AddFolder.ShowDialog( this ) == DialogResult.OK )
            {
                // add the selected folder
                package.AddFolder( AddFolder.Folder, AddFolder.Compression );

                // clear the selected folder
                AddFolder.ClearFolder();

                // refresh the block
                RefreshBlocks();
            }
        }

        /// <summary>
        /// Remove file button click
        /// </summary>
        private void ButtonRemove_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // currently selected block
            MythicPackageBlock selectedBlock = GetSelectedBlock();

            // list of the currently selected files
            List<MythicPackageFile> selectedFiles = GetSelectedFiles();

            if ( selectedBlock == null && ( selectedFiles == null || selectedFiles.Count <= 0 ) )
            {
                // warn the user that needs to select a block or a file
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectBlockFile" ) );

                return;
            }

            // do we have file(s) selected?
            if ( selectedFiles == null || selectedFiles.Count <= 0 )
            {
                // ask the user to confirm the removal
                if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_Remove", selectedBlock.ToString() ) ) == DialogResult.Yes )
                {
                    // get the next node
                    TreeNode next = SelectNextNode( TreeView.SelectedNode );

                    // remove the block
                    selectedBlock.Remove();

                    // refresh the block
                    RefreshBlocks();

                    // select the "next" node
                    TreeView.SelectedNode = next;
                }
            }
            else // remove file(s)
            {
                // ask the user if he wants to remove the file (1)
                if ( selectedFiles.Count == 1 && ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_Remove", selectedFiles[0].ToString() ) ) != DialogResult.Yes )
                    return;

                // ask the user if he wants to remove the files (multiple)
                if ( selectedFiles.Count > 1 && ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_RemoveMultiple", selectedFiles.Count.ToString() ) ) != DialogResult.Yes )
                    return;

                // remove all files in the list
                foreach ( MythicPackageFile f in selectedFiles )
                    f.Remove();

                // deselect all files
                ListBox.SelectedIndex = -1;

                // refresh the block
                RefreshBlocks();
            }
        }

        /// <summary>
        /// Unpack a file/block/entire uop button click
        /// </summary>
        private void ButtonUnpack_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out _ );

            // currently selected block
            MythicPackageBlock selectedBlock = GetSelectedBlock();

            // list of the currently selected files
            List<MythicPackageFile> files = GetSelectedFiles();

            // do we have something selected?
            if ( selectedUOP == null && selectedBlock == null && ( files == null || files.Count <= 0 ) )
            {
                // warn the user that there is nothing to unpack
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectPackageBlockFile" ) );

                return;
            }

            // get the output path
            string path = Globals.Settings.OutputPath;

            // if there is no path set on the stored settings, we set a default one.
            if ( !Directory.Exists( path ) )
            {
                // default path
                path = Path.Combine( Application.StartupPath, "Output" );

                // store the default path
                Globals.Settings.OutputPath = path;

                // save the settings
                Globals.Settings.Save();
            }

            // if the default path has never been used, we create the folder
            if ( !Directory.Exists( path ) )
                Directory.CreateDirectory( path );

            // use the files inner path?
            bool innerPath = Globals.Settings.WithInnerPath;

            // initialize the unpack result variable
            UnpackMythicPackageArgs args = null;

            // do we have to extract multiple files?
            if ( files != null && files.Count > 0 )
            {
                // do we have any file to unpack? if we do, we start unpacking
                args = new UnpackMythicPackageArgs( files.ToArray(), path, innerPath );
            }
            // do we have a block/uop file selected?
            else if ( selectedBlock != null )
            {
                // unpack the block
                args = new UnpackMythicPackageArgs( selectedBlock, path, innerPath );
            }
            else if ( selectedUOP != null )
            {
                // unpack the whole uop file
                args = new UnpackMythicPackageArgs( selectedUOP, path, innerPath );
            }

            // do we have something to unpack?
            if ( args != null )
            {
                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_UnpackingIn", path ), false );

                // start the background thread to spy a process activity
                Worker.RunWorkerAsync( args );
            }
        }

        /// <summary>
        /// Replace the selected file
        /// </summary>
        private void ButtonReplace_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // list of the currently selected files
            List<MythicPackageFile> files = GetSelectedFiles();

            // is there a file selected?
            if ( files == null || files.Count <= 0 )
            {
                // warn the user that he needs to select a file first
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectFile" ) );

                return;
            }

            // are there multiple files selected?
            if ( files.Count > 1 )
            {
                // warn the user that he needs to select only ONE file
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectFileMultiple" ) );

                return;
            }

            // select the first file in the list
            MythicPackageFile file = files[0];

            // show the add file dialog and make sure we the file to add
            if ( ShowReplaceFile( file ) == DialogResult.OK && AddFile.Files.Length > 0 )
            {
                // do the file replacement
                file.Replace( AddFile.Files[0], AddFile.InnerDirectory, AddFile.Compression );

                // refresh the block
                RefreshBlocks();
            }
        }

        /// <summary>
        /// Replace multiple files with the one inside the selected folder and sub-folders
        /// </summary>
        private void ButtonReplaceFolder_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out _ );

            // no package selected?
            if ( selectedUOP == null )
            {
                // warn the user that there is nothing selected
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );

                return;
            }

            // set the root folder for the search
            SelectFolder.RootFolder = Environment.SpecialFolder.MyComputer;

            // set the open folder description
            SelectFolder.Description = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_ReplaceFolder_Dialog" );

            // did we have a folder selected?
            if ( SelectFolder.ShowDialog( this ) == DialogResult.OK )
            {
                // get the list of all the files in the folder and sub-folders
                List<string> files = DirSearch( SelectFolder.SelectedPath );

                // replace the existing files and ask if he want to add the missing files
                selectedUOP.ReplaceFiles( files, SelectFolder.SelectedPath, MessageBox.Show( this, Globals.LanguageManager.GetString( "MainForm_Confirm_Add_Missing" ), Globals.LanguageManager.GetString( "MainForm_Confirm_Add_Missing_Title" ), MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes );

                // refresh the tree
                RefreshBlocks();
            }
        }

        /// <summary>
        /// Folder search button click
        /// </summary>
        private void btnFolderSearch_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // clear the packages list of the folder search
            FolderSearch.PackagesToSearch.Clear();

            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out _ );

            // no package selected?
            if ( selectedUOP == null )
            {
                // warn the user that there is nothing selected
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );

                return;
            }

            // create a list of all the unnamed files
            List<MythicPackageFile> filesToCheck = selectedUOP.GetAllUnnamedFiles();

            // no files without a name? nothing to do then...
            if ( filesToCheck.Count <= 0 )
            {
                // update the status
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_No_Files_Unnamed" ), false );

                return;
            }

            /// clear the package to search list
            FolderSearch.PackagesToSearch.Clear();

            // add the selected package
            FolderSearch.PackagesToSearch.Add( selectedUOP );

            // show the folder search dialog
            if ( FolderSearch.ShowDialog( this ) == DialogResult.OK )
            {
                // get the inner folder for the search (except the final \)
                string innerFolder = FolderSearch.InnerDirectory.Substring(0, FolderSearch.InnerDirectory.Length - 1 );

                // get the root directory to use
                string rootFolder = FolderSearch.RootDirectory;

                // clear the selected folder
                FolderSearch.ClearFolder();

                // get the list of all files in the folder (and sub-folders)
                List<string> files = DirSearch( rootFolder );

                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Folder_Search_Start" ), false );

                // start the background thread to do the folder search
                Worker.RunWorkerAsync( new SearchFolderArgs( selectedUOP, filesToCheck, files, rootFolder, innerFolder ) );
            }
        }

        /// <summary>
        /// Brute force search click
        /// </summary>
        private void btnBruteSearch_Click( object sender, EventArgs e )
        {
            // another operation is in progress?
            if ( CheckWorker() )
                return;

            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out _ );

            // no package selected?
            if ( selectedUOP == null )
            {
                // warn the user that there is nothing selected
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );

                return;
            }

            // create a list of all the unnamed files
            List<MythicPackageFile> filesToCheck = selectedUOP.GetAllUnnamedFiles();

            // no files without a name? nothing to do then...
            if ( filesToCheck.Count <= 0 )
            {
                // update the status
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_No_Files_Unnamed" ), false );

                return;
            }

            // verify the pattern
            BruteForce.CreateEntryResults verify = BruteForce.VerifyBruteForcePattern( txtSearchBox.Text, out List<BruteForceEntry> entries );

            // do we have valid patterns?
            if ( verify != BruteForce.CreateEntryResults.succecss )
            {
                // show the error over the search box
                ErrorTooltip.Show( Globals.LanguageManager.GetString( "BruteForce_Exception_" + verify.ToString() ), txtSearchBox, 0, -85 );

                return;
            }

            // update the status with the new operation
            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Brute_Search_Start" ), false );

            // start the background thread to do the brute force search
            Worker.RunWorkerAsync( new BruteForceArgs( entries, filesToCheck ) );
        }


        /// <summary>
        /// stop the search process
        /// </summary>
        private void BtnStopSearch_Click( object sender, EventArgs e )
        {
            // if the worker is busy and we have a search in progress, we stop the worker
            if ( Worker.IsBusy && SearchInProgess )
                Worker.CancelAsync();
        }

        /// <summary>
        /// Show log click
        /// </summary>
        private void btnShowLog_ButtonClick( object sender, EventArgs e )
        {
            // show the log file
            Process.Start( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Globals.Logger.FileName ) );
        }

        #endregion

        // --------------------------------------------------------------
        #region SEARCH EVENTS
        // --------------------------------------------------------------

        /// <summary>
        /// Search text button click
        /// </summary>
        private void Search_Click( object sender, EventArgs e )
        {
            // do we have something to search?
            if ( !string.IsNullOrEmpty( txtSearchBox.Text ) )
            {
                // search for the text
                TextSearch( txtSearchBox.Text, txtSearchBox.Text == OldKeyword );
            }
            else // nothing to search
            {
                // focus the textbox
                txtSearchBox.Focus();

                // play the system beep sound
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// Search box key press
        /// </summary>
        private void SearchBox_KeyPress( object sender, KeyPressEventArgs e )
        {
            // has enter been pressed?
            if ( (Keys)e.KeyChar == Keys.Enter )
            {
                // search the text
                TextSearch( txtSearchBox.Text, txtSearchBox.Text == OldKeyword );

                // disable the windows beep
                e.Handled = true;
            }
            else if ( (Keys)e.KeyChar == Keys.Escape )
            {
                // escape clear the current search
                btnClearSearch.PerformClick();

                // disable the windows beep
                e.Handled = true;
            }
        }

        /// <summary>
        /// Clear search button click
        /// </summary>
        private void btnClearSearch_Click( object sender, EventArgs e )
        {
            // clear the searchbox
            txtSearchBox.Text = string.Empty;

            // clear the old search criteria
            OldKeyword = null;
        }

        #endregion

        // --------------------------------------------------------------
        #region THREAD WORKER
        // --------------------------------------------------------------

        /// <summary>
        /// Created a new thread to work
        /// </summary>
        private void Worker_DoWork( object sender, DoWorkEventArgs e )
        {
            // is this a dictionary event thread?
            switch ( e.Argument )
            {
                // is this a load dictionary event?
                case DictionaryArgs dic:
                    {
                        if ( dic.Load )
                            HashDictionary.LoadDictionary( dic.Name );

                        // is this a save dictionary event?
                        else if ( dic.Save )
                            HashDictionary.SaveDictionary( dic.Name );

                        // is this a merge dictionary event?
                        else if ( dic.Merge )
                            HashDictionary.MergeDictionary( dic.Name );

                        break;
                    }

                // is this the load package event?
                case LoadMythicPackageArgs loadPacks:
                    {
                        // execute the loading process
                        loadPacks.LoadPackages();

                        break;
                    }

                // is this the save package event?
                case SaveMythicPackageArgs savePack:
                    {
                        // save the package
                        savePack.Package.Save( savePack.FileName );

                        break;
                    }

                // is this the unpack event?
                case UnpackMythicPackageArgs unpack:
                    {
                        // unpack the whole package?
                        if ( unpack.IsPackage )
                            unpack.Package.Unpack( unpack.Folder, unpack.FullPath );

                        // unpack a block?
                        else if ( unpack.IsBlock )
                            unpack.Block.Unpack( unpack.Folder, unpack.FullPath );

                        // unpack a file(s)?
                        else if ( unpack.IsFile )
                            foreach ( MythicPackageFile file in unpack.Files )
                                file.Unpack( unpack.Folder, unpack.FullPath );

                        break;
                    }

                // is this a spy process event?
                case SpyProcessArgs spyAttach:
                    {
                        // attach to the process
                        spyAttach.HashSpy.Init( spyAttach.Process );

                        // start spying
                        spyAttach.HashSpy.MainLoop();

                        break;
                    }

                // is this a spy start process event?
                case SpyPathArgs spyStart:
                    {
                        // start the process to spy
                        spyStart.HashSpy.Init( spyStart.Path );

                        // start spying
                        spyStart.HashSpy.MainLoop();

                        break;
                    }

                // is this the folder search event?
                case SearchFolderArgs fs:
                    {
                        // flag that a search is in progress
                        SearchInProgess = true;

                        // execute the folder search loop
                        FolderSearchLoop( fs );

                        break;
                    }

                // is this the brute force search event?
                case BruteForceArgs bf:
                    {
                        // flag that a search is in progress
                        SearchInProgess = true;

                        // execute the brute force search
                        BruteSearchLoop( bf );

                        break;
                    }

                default:
                    break;
            }

            // store the arguments as result
            e.Result = e.Argument;
        }

        /// <summary>
        /// Thread operation ended
        /// </summary>
        private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            // do we have an error?
            if ( e.Error != null )
            {
                // was this a spy operation?
                if ( e.Result is SpyProcessArgs || e.Result is SpyPathArgs )
                {
                    // disable the detach and enable the start/attach process
                    MainMenuDictionarySpyStart.Enabled = true;
                    MainMenuDictionarySpyAttach.Enabled = true;
                    MainMenuDictionarySpyDetach.Enabled = false;
                }

                // log the error
                Globals.Logger.Log( e.Error );

                // warn the user that there has been a problem
                ShowError( string.Format( Globals.LanguageManager.GetString( "MainForm_Information_WorkerError" ), Globals.Logger.FileName ) );
            }
            // is this a dictionary operation?
            else switch ( e.Result )
                {
                    // is this a load dictionary event?
                    case DictionaryArgs dic:
                        {
                            // load dictionary finished
                            if ( dic.Load )
                                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_DictionaryLoadingFinished" ), false );

                            // save dictionary finished
                            else if ( dic.Save )
                                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_DictionarySavingFinished" ), false );

                            // merge dictionary finished
                            else if ( dic.Merge )
                                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_MergingSummary", ( HashDictionary.NewHashes - m_NewHashes ).ToString(), ( HashDictionary.NewFileNames - m_NewFileNames ).ToString() ) );

                            break;
                        }

                    // is this the load package event?
                    case LoadMythicPackageArgs loadPacks:
                        {
                            // fill the tree with the loaded packages
                            LoadPackagesToTree( loadPacks.Result );

                            break;
                        }

                    // is this the save package event?
                    case SaveMythicPackageArgs savePack:
                        {
                            // do we have to close the file?
                            if ( savePack.CloseFile )
                                CloseFile( savePack.Package );

                            else // refresh the tree
                                RefreshBlocks();

                            // warn the user the operation is complete
                            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SavingFinished" ), false );

                            break;
                        }

                    // is this the unpack event?
                    case UnpackMythicPackageArgs _:
                        {
                            // warn the user the operation is complete
                            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_UnpackingFinished" ), false );

                            break;
                        }

                    // is this a spy event?
                    case SpyPathArgs _:
                    case SpyProcessArgs _:
                        {
                            // warn the user the spy process is terminated
                            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_ProcessTerminated" ), false );

                            // disable the detach and enable the start/attach process
                            MainMenuDictionarySpyStart.Enabled = true;
                            MainMenuDictionarySpyAttach.Enabled = true;
                            MainMenuDictionarySpyDetach.Enabled = false;

                            // refresh the treeview and files
                            RefreshBlocks();

                            // if we have new file names, we warn the user how many we found
                            if ( HashDictionary.NewFileNames - m_NewFileNames > 0 )
                                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewFileNames", ( HashDictionary.NewFileNames - m_NewFileNames ).ToString() ) );

                            break;
                        }

                    // is this the folder search event?
                    case SearchFolderArgs fs:
                        {
                            // flag that the search is over
                            SearchInProgess = false;

                            // refresh the tree and files
                            RefreshBlocks();

                            // warn that the search is terminated
                            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Folder_Search_Terminated", fs.TotalFound.ToString(), fs.OriginalCount.ToString() ), true );

                            break;
                        }

                    // is this the brute force search event?
                    case BruteForceArgs bf:
                        {
                            // flag that the search is over
                            SearchInProgess = false;

                            // refresh the tree and files
                            RefreshBlocks();

                            // warn that the search is terminated
                            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Brute_Search_Terminated", bf.TotalFound.ToString(), bf.OriginalCount.ToString() ), true );

                            break;
                        }

                    default:
                        break;
                }

            // reset the progress bar
            StatusProgressBar.Value = 0;
        }

        /// <summary>
        /// Async thread progress change event
        /// </summary>
        private void Worker_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            // update the status bar progress
            StatusProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Event to update the progree bar
        /// </summary>
        /// <param name="current">current progress</param>
        /// <param name="max">max progress</param>
        private void MythicPackage_UpdateProgress( int current, int max )
        {
            // update the progress
            Worker.ReportProgress( Math.Min( current * 100 / max, 100 ) );
        }

        #endregion

        /// <summary>
        /// Unset file name button click
        /// </summary>
        private void FileUnsetButton_Click( object sender, EventArgs e )
        {
            // do we have a file selected (with a name)?
            if ( ListBox.SelectedItem is MythicPackageFile file && !string.IsNullOrEmpty( file.FileName ) && HashDictionary.Unset( file.FileHash ) )
            {
                // remove the file name
                file.FileName = null;

                // update the file info tab
                txtFileFileNameInfo.Text = string.Empty;

                // hide the unset name button
                btnFileUnset.Visible = false;

                // re-set the file to the listbox
                ListBox.Items[ListBox.SelectedIndex] = file;

                // focus the listbox again
                ListBox.Focus();
            }
            else // can't remove the file name
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_ErrorUnset" ) );
        }

        /// <summary>
        /// Handle the UI update
        /// </summary>
        private void tmrUIUpdate_Tick( object sender, EventArgs e )
        {
            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out _ );

            // currently selected block
            MythicPackageBlock selectedBlock = GetSelectedBlock();

            // list of the currently selected files
            List<MythicPackageFile> selectedFiles = GetSelectedFiles();

            // save dictionary button enabled only if the dictionary has been modified
            MainMenuDictionarySave.Enabled = btnSaveDictionary.Enabled = HashDictionary.Modified && !Worker.IsBusy && !RefreshInProgess;

            // save, close, add file and add folder, only available if there is a package selected
            MainMenuFileSave.Enabled = btnSave.Enabled = MainMenuFileClose.Enabled = btnClose.Enabled = btnAddFolder.Enabled = btnAdd.Enabled = selectedUOP != null && !Worker.IsBusy && !RefreshInProgess;

            // remove block/file requires a block/file selected
            btnRemove.Enabled = ( selectedBlock != null || ( selectedFiles != null && selectedFiles.Count > 0 ) ) && !Worker.IsBusy && !RefreshInProgess;

            // unpack requires a UOP, a block or at least 1 file selected.
            btnUnpack.Enabled = ( selectedUOP != null || selectedBlock != null || ( selectedFiles != null && selectedFiles.Count > 0 ) ) && !Worker.IsBusy && !RefreshInProgess;

            // replace requires at least 1 file selected
            btnReplace.Enabled = selectedFiles != null && selectedFiles.Count == 1 && !Worker.IsBusy && !RefreshInProgess;

            // replace folder requires an UOP file selected
            btnReplaceFolder.Enabled = selectedUOP != null && !Worker.IsBusy && !RefreshInProgess;

            // the rest of the buttons is enabled when the async thread is NOT busy
            MainMenuFileNew.Enabled = btnNew.Enabled = MainMenuFileOpen.Enabled = btnOpen.Enabled = btnNew.Enabled = MainMenuDictionaryMerge.Enabled =
            btnMergeDictionary.Enabled = MainMenuDictionaryLoad.Enabled = btnOpenDictionary.Enabled = MainMenuEditSettings.Enabled = !Worker.IsBusy && !RefreshInProgess;

            // make sure there is something to search before we enable the search buttons
            btnClearSearch.Enabled = btnSearchText.Enabled = TreeView.Nodes.Count > 0 && !string.IsNullOrEmpty( txtSearchBox.Text ) && !RefreshInProgess;

            // the folder search is enabled only if there is a uop file selected and the async thread is NOT busy
            btnFolderSearch.Enabled = selectedUOP != null && int.Parse( txtUnnamedFilesInfo.Text ) > 0 && !Worker.IsBusy && !RefreshInProgess;

            // the brute force search is enabled only if there is a uop file selected and a pattern in the textbox and the async thread is NOT busy
            btnBruteSearch.Enabled = selectedUOP != null && int.Parse( txtUnnamedFilesInfo.Text ) > 0 && !string.IsNullOrEmpty( txtSearchBox.Text ) && !Worker.IsBusy && !RefreshInProgess;

            // the stop search is enabled when the async thread is busy and the search progress flag is active
            btnStopSearch.Enabled = Worker.IsBusy && SearchInProgess && !RefreshInProgess;

            // only visible on the preview page
            lblImageFormat.Visible = tabsData.SelectedTab == tabPreview;
        }

        /// <summary>
        /// Spy found something event
        /// </summary>
        /// <param name="hash">found hash</param>
        /// <param name="fileName">found file name</param>
        private void HashSpy_HashFound( ulong hash, string fileName )
        {
            // does the hash exist?
            if ( HashDictionary.Contains( hash ) )
            {
                // make sure we don't have the same file name for this hash
                if ( HashDictionary.Get( hash, false ) != fileName )
                {
                    // set the new file name for the hash
                    HashDictionary.Set( hash, fileName );

                    // show the user that we found a new file name!
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Spy_File_Found", fileName ), false );

                    // log that we found a new file name
                    Globals.Logger.Log( string.Format( "Found string for hash {0:X}: {1}", hash, fileName ) );
                }
            }
        }

        /// <summary>
        /// Copy to clipboad clicked
        /// </summary>
        private void CopyMenuStripButton_Click( object sender, EventArgs e )
        {
            Clipboard.SetText( ( (Label)mnuCopy.Tag ).Text, System.Windows.TextDataFormat.Text );
        }

        /// <summary>
        /// Name label click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFileFileNameInfo_MouseClick( object sender, MouseEventArgs e )
        {
            // left click?
            if ( e.Button == MouseButtons.Left )
            {
                // do we have a file selected without a name?
                if ( ListBox.SelectedItem is MythicPackageFile idx && idx.FileName == null )
                {
                    // show the guess file dialog
                    new GuessFile( idx ).ShowDialog();

                    // do we have a new file name?
                    if ( !string.IsNullOrEmpty( idx.FileName ) )
                    {
                        // set the new file name if we have one
                        txtFileFileNameInfo.Text = idx.FileName;

                        // refresh the tree and list
                        RefreshBlocks();
                    }
                }
            }
        }

        #endregion

        // --------------------------------------------------------------
        #region PUBLIC FUNCTIONS
        // --------------------------------------------------------------

        #endregion

        // --------------------------------------------------------------
        #region LOCAL FUNCTIONS
        // --------------------------------------------------------------

        // --------------------------------------------------------------
        #region TABS FILLING FUNCTIONS
        // --------------------------------------------------------------

        /// <summary>
        /// Set the currently active package (the one showing the info)
        /// </summary>
        /// <param name="package">package to select</param>
        private void ChangePackage( MythicPackage package )
        {
            // clear all tabs
            ClearAllTabs();

            // no package? we can get out
            if ( package == null )
                return;

            // enable the package tab and disable the rest
            tabDetailsPackage.Enabled = true;

            // do we have the package file info?
            if ( package.FileInfo != null )
            {
                // get the package file name
                txtPackageFullNameInfo.Text = package.FileInfo.FullName;

                // get the package attributes
                txtPackageAttributesInfo.Text = package.FileInfo.Attributes.ToString();

                // get the package date of creation
                txtPackageCreationInfo.Text = package.FileInfo.CreationTimeUtc.ToLocalTime().ToString();

                // get the package size
                txtPackageSizeInfo.Text = ConvertSize( package.FileInfo.Length );
            }

            // get the package version
            txtPackageVersionInfo.Text = package.Header.Version.ToString();

            // get the unknown value
            txtPackageMiscInfo.Text = package.Header.Misc.ToString( "X8" );

            // get the header size
            txtPackageHeaderSizeInfo.Text = package.Header.StartAddress.ToString( "X16" );

            // get the block size
            txtPackageBlockSizeInfo.Text = package.Header.BlockSize.ToString();

            // get the files count
            txtPackageFileCountInfo.Text = package.Header.FileCount.ToString();

            // get the unnamed files count
            txtUnnamedFilesInfo.Text = package.GetAllUnnamedFiles().Count.ToString();

            // clear the files list
            ClearFilesList();

            // select the package tab
            tabsData.SelectedTab = tabDetailsPackage;
        }

        /// <summary>
        /// Set the currently active block (the one showing the info)
        /// </summary>
        /// <param name="block"></param>
        private void ChangeBlock( MythicPackageBlock block )
        {
            // clear the block tab
            ClearBlock();

            // clear all tabs
            ClearFile();

            // enable the package tab
            tabDetailsPackage.Enabled = true;
            tabDetailsBlock.Enabled = true;
            tabDetailsFile.Enabled = false;
            HidePreviewTab();

            // set the block files count
            txtBlockFileCountInfo.Text = block.FileCount.ToString();

            // set the next block address (if we have one)
            if ( block.NextBlock != 0 )
            {
                // set the label text
                txtBlockNextBlockInfo.Text = block.NextBlock.ToString( "X16" );

                // enable the labels
                txtBlockNextBlockInfo.Enabled = true;
                lblBlockNextBlock.Enabled = true;
            }
            else // no next block
            {
                // disable the labels
                txtBlockNextBlockInfo.Enabled = false;
                lblBlockNextBlock.Enabled = false;
            }

            // get the block index
            txtBlockIndexInfo.Text = block.Index.ToString();

            // clear the files list
            ClearFilesList();

            // add the block's file to the list
            ListBox.Items.AddRange( block.Files.ToArray() );

            // select the block tab
            tabsData.SelectedTab = tabDetailsBlock;
        }

        /// <summary>
        /// Show the file data in the main form
        /// </summary>
        /// <param name="file">File data to show</param>
        private void ChangeFile( MythicPackageFile file )
        {
            // clear the preview tab
            ClearPreview();

            // clear the file tab
            ClearFile();

            // show hide the name unset button
            btnFileUnset.Visible = !string.IsNullOrEmpty( file.FileName );

            // get the full file name
            txtFileFileNameInfo.Text = file.FileName;

            // get the file hash
            txtFileHashInfo.Text = file.FileHash.ToString( "X16" );

            // get the file data hash
            txtFileDataHashInfo.Text = file.DataBlockHash.ToString( "X8" );

            // get the file compressed size
            txtFileCompressedInfo.Text = ConvertSize( file.CompressedSize );

            // get the file decompressed size
            txtFileDecompressedInfo.Text = ConvertSize( file.DecompressedSize );

            // get the file compression type
            txtFileCompressionTypeInfo.Text = file.Compression.ToString();

            // show the file details tab
            tabsData.SelectedIndex = 2;

            // initialize the bytes array of the file
            byte[] data;

            // if this is a new/modified file, we get the mime of the hdd file instead
            if ( file.Added || file.Modified )
                data = File.ReadAllBytes( file.SourceFileName );

            else // get the file bytes
                data = file.Unpack();

            // get the file mime type
            txtFileMimeInfo.Text = MythicPackageFile.GetMimeType( data );

            // get the file MD5 hash
            txtFileMD5Info.Text = MythicPackageFile.GetMD5Hash( data );

            // set the file preview if possible
            SetFilePreview( file );

            // get the file index
            txtFileIndexInfo.Text = string.Format( "{0:n0}", file.Index );

            // get the file global index
            txtFileGlobalIndexInfo.Text = string.Format( "{0:n0}", file.GlobalIndex );

            // enable all tabs
            tabDetailsPackage.Enabled = true;
            tabDetailsBlock.Enabled = true;
            tabDetailsFile.Enabled = true;

            // set the focus on the list
            ListBox.Focus();
        }

        /// <summary>
        /// Refresh all the blocks associated to a specific uop file
        /// </summary>
        private void RefreshBlocks()
        {
            // update the status with the new operation
            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Refresh" ), false );

            // currently selected UOP
            MythicPackage selectedUOP = GetSelectedPackage( out TreeNode root );

            // nothing selected? we can get out
            if ( selectedUOP == null )
            {
                // clear the status
                ShowInfo( string.Empty, false );

                return;
            }

            // flag that the refresh is in progress
            RefreshInProgess = true;

            // currently selected block
            MythicPackageBlock selectedBlock = GetSelectedBlock();

            // list of the currently selected files
            List<MythicPackageFile> selectedFiles = GetSelectedFiles();

            // refresh the package data
            ChangePackage( selectedUOP );

            // refresh the package name
            root.Text = selectedUOP.ToString();

            // update all block names
            root.Nodes.Cast<TreeNode>().ToList().ForEach( n => { if ( ( (MythicPackageBlock)n.Tag ).Modified || n.Text.EndsWith( "*" ) ) { n.Text = ( (MythicPackageBlock)n.Tag ).ToString(); } } );

            // re-select the block
            if ( selectedBlock != null )
                ChangeBlock( selectedBlock );

            // re-select the files
            if ( selectedFiles != null && selectedFiles.Count > 0 )
                foreach ( MythicPackageFile f in selectedFiles )
                    ListBox.SelectedIndices.Add( f.Index );

            // reset the refresh in progress flag
            RefreshInProgess = false;

            // clear the status
            ShowInfo( string.Empty, false );
        }

        /// <summary>
        /// Clear all tabs
        /// </summary>
        private void ClearAllTabs()
        {
            // clear the package tab
            ClearPackage();

            // clear the block tab
            ClearBlock();

            // clear the file tab
            ClearFile();

            // clear the preview tab
            ClearPreview();
        }

        /// <summary>
        /// Clear the package tab info
        /// </summary>
        private void ClearPackage()
        {
            // clear all labels
            txtPackageFullNameInfo.Text = string.Empty;
            txtPackageAttributesInfo.Text = string.Empty;
            txtPackageCreationInfo.Text = string.Empty;
            txtPackageSizeInfo.Text = string.Empty;
            txtPackageVersionInfo.Text = string.Empty;
            txtPackageMiscInfo.Text = string.Empty;
            txtPackageHeaderSizeInfo.Text = string.Empty;
            txtPackageBlockSizeInfo.Text = string.Empty;
            txtPackageFileCountInfo.Text = string.Empty;
            txtUnnamedFilesInfo.Text = string.Empty;

            // disable the package tab
            tabDetailsPackage.Enabled = false;
        }

        /// <summary>
        /// Clear the tab block data
        /// </summary>
        private void ClearBlock()
        {
            // clear the labels
            txtBlockFileCountInfo.Text = string.Empty;
            txtBlockNextBlockInfo.Text = string.Empty;

            // disable the block tab
            tabDetailsBlock.Enabled = false;
        }

        /// <summary>
        /// Clear the file tab data
        /// </summary>
        private void ClearFile()
        {
            // clear the labels
            txtFileFileNameInfo.Text = string.Empty;
            txtFileHashInfo.Text = string.Empty;
            txtFileDataHashInfo.Text = string.Empty;
            txtFileCompressedInfo.Text = string.Empty;
            txtFileDecompressedInfo.Text = string.Empty;
            txtFileCompressionTypeInfo.Text = string.Empty;
            txtFileIndexInfo.Text = string.Empty;
            txtFileGlobalIndexInfo.Text = string.Empty;
            txtFileMimeInfo.Text = string.Empty;
            txtFileMD5Info.Text = string.Empty;

            // disable the files tab
            tabDetailsFile.Enabled = false;
        }

        /// <summary>
        /// Clear the file preview tab
        /// </summary>
        private void ClearPreview()
        {
            // hide the preview tab
            HidePreviewTab();

            // clear the text preview
            txtPreview.Text = string.Empty;

            // hide the text preview
            txtPreview.Visible = false;

            // remove the picture preview
            picPreview.Image = null;

            // hide the picturebox
            pnlImagePreview.Visible = false;

            // clear the csv preview
            dgvPreview.DataSource = null;
            dgvPreview.Rows.Clear();
            dgvPreview.Columns.Clear();

            // hide the csv preview
            dgvPreview.Visible = false;

            // clear the image format
            lblImageFormat.Text = string.Empty;
        }

        /// <summary>
        /// Clear the files listbox
        /// </summary>
        private void ClearFilesList()
        {
            // clear the files list
            ListBox.Items.Clear();

            // remove the selected file
            ListBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Set the current file preview
        /// </summary>
        private void SetFilePreview( MythicPackageFile f )
        {
            // clear the preview tab
            ClearPreview();

            // initialize the bytes array of the file
            byte[] data;

            // if this is a new/modified file, we get the mime of the hdd file instead
            if ( f.Added || f.Modified )
                data = File.ReadAllBytes( f.SourceFileName );

            else // get the file bytes
                data = f.Unpack();

            // is this a text file?
            if ( txtFileMimeInfo.Text == "text/xml" || txtFileMimeInfo.Text == "text/html" || txtFileMimeInfo.Text == "text/plain" || ( !string.IsNullOrEmpty( f.FileName ) && textExtensions.Contains( Path.GetExtension( f.FileName ) ) ) )
            {
                // is this a CSV file? fill the CSV table
                if ( !string.IsNullOrEmpty( f.FileName ) && Path.GetExtension( f.FileName ) == ".csv" )
                    SetCSVPreview( data );

                // no file name?
                else if ( string.IsNullOrEmpty( f.FileName ) )
                {
                    // try to read the file as csv, if it fails, we read it as plain text
                    if ( !SetCSVPreview( data ) )
                        SetTextPreview( data, f.FileName );
                }
                else // for any other text file, we set the text preview
                    SetTextPreview( data, f.FileName );
            }
            // is this an image file?
            else if ( txtFileMimeInfo.Text == "image/pjpeg" || txtFileMimeInfo.Text == "image/vnd.ms-dds" || txtFileMimeInfo.Text == "image/x-tga" || txtFileMimeInfo.Text == "image/x-png" || ( !string.IsNullOrEmpty( f.FileName ) && imageExtensions.Contains( Path.GetExtension( f.FileName ) ) ) )
            {
                // set the image preview
                SetImagePreview( data, f.FileName );
            }
        }

        /// <summary>
        /// Hide the preview tab
        /// </summary>
        private void HidePreviewTab()
        {
            // store the preview page
            m_previewPage = tabPreview;

            // hide the preview tab
            tabsData.TabPages.Remove( tabPreview );
        }

        /// <summary>
        /// Show the preview tab
        /// </summary>
        private void ShowPreviewTab()
        {
            // hide the preview tab
            tabsData.TabPages.Add( m_previewPage );
        }

        /// <summary>
        /// Set the text file preview
        /// </summary>
        /// <param name="data">file data bytes array</param>
        /// <param name="fileName">file name</param>
        private void SetTextPreview( byte[] data, string fileName )
        {
            // is this an XML file? set the XML highlighting
            if ( txtFileMimeInfo.Text == "text/xml" || txtFileMimeInfo.Text == "text/html" || ( !string.IsNullOrEmpty( fileName ) && Path.GetExtension( fileName ) == ".xml" ) )
                txtPreview.Language = FastColoredTextBoxNS.Language.XML;

            // is this a lua file? set the LUA highlighting
            else if ( !string.IsNullOrEmpty( fileName ) && Path.GetExtension( fileName ) == ".lua" )
                txtPreview.Language = FastColoredTextBoxNS.Language.Lua;

            else // in any other case we just don't use the text highlighting
                txtPreview.Language = FastColoredTextBoxNS.Language.Custom;

            // set the text to show
            txtPreview.Text = System.Text.Encoding.UTF8.GetString( data );

            // show the text preview
            txtPreview.Visible = true;

            // enable the preview tab
            ShowPreviewTab();
        }

        /// <summary>
        /// Set the CSV file preview
        /// </summary>
        /// <param name="data">file data bytes array</param>
        /// <returns>true if the file has been read correctly, false if it hasn't</returns>
        private bool SetCSVPreview( byte[] data )
        {
            // get the text lines
            string[] lines = System.Text.Encoding.UTF8.GetString( data ).Split( '\n' );

            // index of the first line (header)
            int firstLine = 0;

            // do we have the text file lines?
            while ( lines.Length > 0 )
            {
                // if a line starts with ,,, or # it's not the header
                if ( lines[firstLine].StartsWith( ",,," ) || lines[firstLine].StartsWith( "#" ) )
                    firstLine++;

                else // if we found the header, we can get out of the loop
                    break;
            }

            // create a new data table
            DataTable dt = new DataTable();

            // get the header string
            string header = lines[firstLine];

            // create the array for the header labels
            string[] headerLabels = header.Split( ',' );

            // if we have less than 2 headers, it's not a csv
            if ( headerLabels.Length < 2 )
                return false;

            // create all columns for the table
            foreach ( string headerWord in headerLabels )
                dt.Columns.Add( new DataColumn( headerWord ) );

            // add all the lines
            for ( int i = firstLine + 1; i < lines.Length; i++ )
            {
                // get the content of the line
                string[] records = lines[i].Replace( "\r", "" ).Split( ',' );

                // make sure we have enough records to fill the row
                if ( records.Length < headerLabels.Length )
                    continue;

                // create the row
                DataRow row = dt.NewRow();

                // current cell index
                int cell = 0;

                // fill all the cells
                foreach ( string column in headerLabels )
                    row[column] = records[cell++];

                // add the row to the table
                dt.Rows.Add( row );
            }

            // do we have something to show?
            if ( dt.Rows.Count > 0 )
            {
                // set the data source for the table
                dgvPreview.DataSource = dt;

                // show the data table
                dgvPreview.Visible = true;

                // enable the preview tab
                ShowPreviewTab();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Set the preview for an image
        /// </summary>
        /// <param name="data">image data</param>
        /// <param name="fileName">image file name</param>
        private void SetImagePreview( byte[] data, string fileName )
        {
            // is this a jpg?
            if ( txtFileMimeInfo.Text == "image/pjpeg" || txtFileMimeInfo.Text == "image/x-png" || ( !string.IsNullOrEmpty( fileName ) && ( Path.GetExtension( fileName ) == ".jpg" || Path.GetExtension( fileName ) == ".png" ) ) )
            {
                // read the image data and show it
                using MemoryStream mStream = new MemoryStream( data );
                    picPreview.Image = new Bitmap( mStream );

                // get the pixel format
                lblImageFormat.Text = picPreview.Image.RawFormat.Equals( ImageFormat.Jpeg ) ? "JPG Image" : ( picPreview.Image.RawFormat.Equals( ImageFormat.Png ) ? "PNG Image" : "" );

                // show the image preview
                pnlImagePreview.Visible = true;

                // enable the preview tab
                ShowPreviewTab();
            }
            // is this a tga?
            else if ( txtFileMimeInfo.Text == "image/x-tga" || ( !string.IsNullOrEmpty( fileName ) && Path.GetExtension( fileName ) == ".tga" ) )
            {
                // show the image
                picPreview.Image = CreateTGAImage( data );

                // get the image format
                lblImageFormat.Text = "TGA Image";

                // show the image preview
                pnlImagePreview.Visible = true;

                // enable the preview tab
                ShowPreviewTab();
            }
            // is this a dds?
            else if ( txtFileMimeInfo.Text == "image/vnd.ms-dds" || ( !string.IsNullOrEmpty( fileName ) && Path.GetExtension( fileName ) == ".dds" ) )
            {
                try
                {
                    // create the image
                    ImageEngineImage img = new ImageEngineImage( data );

                    // show the dds image
                    picPreview.Image = BitmapSource2Bitmap( img.GetWPFBitmap( 0, true ) );

                    // get the pixel format
                    lblImageFormat.Text = "DDS " + img.Format.ToString().Replace( "DDS_", "" );

                    // show the image preview
                    pnlImagePreview.Visible = true;

                    // enable the preview tab
                    ShowPreviewTab();
                }
                catch { }
            }
        }

        /// <summary>
        /// Create a bitmap image from the image conversion
        /// </summary>
        /// <param name="uopData">image data from the UOP package</param>
        /// <returns>bitmap created from the data</returns>
        private Bitmap CreateTGAImage( byte[] uopData )
        {
            // generate the image
            ImageResult image = ImageResult.FromMemory( uopData, ColorComponents.RedGreenBlueAlpha );

            // get the image data
            byte[] data = image.Data;

            // convert rgba to bgra
            for ( int i = 0; i < image.Width * image.Height; i++ )
            {
                // get the colors
                byte r = data[i * 4];
                byte g = data[( i * 4 ) + 1];
                byte b = data[( i * 4 ) + 2];
                byte a = data[( i * 4 ) + 3];

                // replace the colors
                data[i * 4] = b;
                data[( i * 4 ) + 1] = g;
                data[( i * 4 ) + 2] = r;
                data[( i * 4 ) + 3] = a;
            }

            // create the bitmap image
            Bitmap bmp = new Bitmap( image.Width, image.Height, PixelFormat.Format32bppArgb );

            // draw the image
            BitmapData bmpData = bmp.LockBits( new Rectangle( 0, 0, image.Width, image.Height ), ImageLockMode.WriteOnly, bmp.PixelFormat );
            Marshal.Copy( data, 0, bmpData.Scan0, bmpData.Stride * bmp.Height );

            // image complete, we can release it from memory
            bmp.UnlockBits( bmpData );

            return bmp;
        }

        #endregion

        // --------------------------------------------------------------
        #region DIALOGS CALL
        // --------------------------------------------------------------

        /// <summary>
        /// Question dialog
        /// </summary>
        /// <param name="question">question to ask</param>
        /// <returns>Dialog result</returns>
        public DialogResult ShowQuestion( string question )
        {
            // create a question dialog with the specified text
            return MessageBox.Show( this, question, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );
        }

        /// <summary>
        /// Open .exe dialog
        /// </summary>
        /// <returns>Dialog result</returns>
        private DialogResult ShowOpenExecutable()
        {
            // set the dialog title
            OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Executable_Title" );

            // set the dialog files filter
            OpenFileDialog.Filter = "Executable files|*.exe";

            // disable multi files selection
            OpenFileDialog.Multiselect = false;

            return OpenFileDialog.ShowDialog( this );
        }

        /// <summary>
        /// Open .uop dialog
        /// </summary>
        /// <returns>Dialog result</returns>
        private DialogResult ShowOpenPackage()
        {
            // set the dialog title
            OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Package_Title" );

            // set the dialog files filter
            OpenFileDialog.Filter = "Mythic Package files|*.uop";

            // enable multi files selection
            OpenFileDialog.Multiselect = true;

            return OpenFileDialog.ShowDialog( this );
        }

        /// <summary>
        /// Save .uop dialog
        /// </summary>
        /// <param name="fileName">default file name to use</param>
        /// <returns>dialog result</returns>
        private DialogResult ShowSavePackage( string fileName = null )
        {
            // if we have a file name as parameter we suggest that
            if ( !string.IsNullOrEmpty( fileName ) )
                SaveFileDialog.FileName = fileName;

            // set the dialog title
            SaveFileDialog.Title = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Save" );

            // set the dialog files filter
            SaveFileDialog.Filter = "Mythic Package files|*.uop";

            return SaveFileDialog.ShowDialog( this );
        }

        /// <summary>
        /// Open .dic dialog
        /// </summary>
        /// <returns>dialog result</returns>
        private DialogResult ShowOpenDictionary()
        {
            // set the dialog title
            OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Dictionary_Title" );

            // set the dialog files filter
            OpenFileDialog.Filter = "Dictionary files|*.dic";

            // disable multi files selection
            OpenFileDialog.Multiselect = false;

            return OpenFileDialog.ShowDialog( this );
        }

        /// <summary>
        /// Show the add files dialog
        /// </summary>
        /// <returns>dialog result</returns>
        private DialogResult ShowAddFiles( MythicPackage package )
        {
            // allow the selection of multiple files
            AddFile.MultiFileSelect = true;

            // set the package to add the files to
            AddFile.PackageToAddTo = package;

            // change the window title
            AddFile.Title = Globals.LanguageManager.GetString( "AddFile_Title" );

            // clear the files list
            AddFile.ClearList();

            return AddFile.ShowDialog( this );
        }

        /// <summary>
        /// Show the replace file window
        /// </summary>
        /// <param name="file">file to be replaced</param>
        /// <returns>dialog result</returns>
        private DialogResult ShowReplaceFile( MythicPackageFile file )
        {
            // set the file relative path
            AddFile.InnerDirectory = file.FilePath;

            // set the file compression
            AddFile.Compression = file.Compression;

            // allow the selection of only 1 file
            AddFile.MultiFileSelect = false;

            // set the package to replace the file to
            AddFile.PackageToAddTo = file.Parent.Parent;

            // store the file to replace
            AddFile.FileToReplace = file;

            // change the window title
            AddFile.Title = "Replace File";

            // if the file has already been replaced, we show in the replace window the current file name we were plannig to load
            if ( !string.IsNullOrEmpty( file.SourceFileName ) )
                AddFile.SetCurrentReplacement( file.SourceFileName );

            else // reset the files list in the add window
                AddFile.ClearList();

            return AddFile.ShowDialog( this );
        }

        #endregion

        // --------------------------------------------------------------
        #region MESSAGE HANDLERS
        // --------------------------------------------------------------

        /// <summary>
        /// Show error dialog
        /// </summary>
        /// <param name="error">error text</param>
        /// <param name="showLog">open the errors log file?</param>
        public void ShowError( string error, bool showLog = true )
        {
            // show the error and open the errors log on confirm (if requested)
            if ( MessageBox.Show( this, error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error ) == DialogResult.OK && showLog )
                Process.Start( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Globals.Logger.FileName ) );
        }

        /// <summary>
        /// Show a warning dialog
        /// </summary>
        /// <param name="warning"></param>
        public void ShowWarning( string warning )
        {
            // create the warning dialog with the specified text
            MessageBox.Show( this, warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        /// <summary>
        ///  Show an info message in the status
        /// </summary>
        /// <param name="info">message to show</param>
        /// <param name="beep">do we have to play the beep sound?</param>
        public void ShowInfo( string info, bool beep = true )
        {
            // show the info in the status bar
            SetStatus( info );

            // play the system beep sound
            if ( beep )
                SystemSounds.Beep.Play();
        }

        #endregion

        // --------------------------------------------------------------
        #region THREAD FUNCTIONS
        // --------------------------------------------------------------

        private void LoadPackagesToTree( MythicPackage[] packs )
        {
            // scan all the loaded packages
            foreach ( MythicPackage p in packs )
            {
                // create a new node for the tree view and set the package as tag
                TreeNode parent = new TreeNode( p.FileInfo.Name ) { Tag = p };

                // add the node to the treeview
                TreeView.Nodes.Add( parent );

                // scan all the blocks of the package
                foreach ( MythicPackageBlock block in p.Blocks )
                {
                    // create a new child node and set the block as tag
                    TreeNode child = new TreeNode( block.ToString() ) { Tag = block };

                    // add the node to as package child
                    parent.Nodes.Add( child );
                }
            }
            // did we load anything?
            if ( TreeView.Nodes.Count > 0 )
            {
                // select the first node in the list
                TreeView.SelectedNode = TreeView.Nodes[0];

                // open the node
                TreeView.SelectedNode.Expand();
            }

            // warn the user that the loading is completed
            ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_LoadingFinished" ), false );

            // if we found new hashes, show the user how many we have found
            if ( HashDictionary.NewHashes - m_NewHashes > 0 )
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewHashes", ( HashDictionary.NewHashes - m_NewHashes ).ToString() ) );
        }

        /// <summary>
        /// Main loop for the folder search
        /// </summary>
        /// <param name="args">thread arguments</param>
        private void FolderSearchLoop( SearchFolderArgs args )
        {
            // reset the total files found
            args.TotalFound = 0;

            // amount of files without a name remaining
            int filesToFix = args.UnnamedFiles.Count;

            // create a queue for the file names to parse
            Queue<string> filesQueue = new Queue<string>( args.FilesToParse.Select( f => f.Replace( args.RootFolder, "" ).Replace(@"\", "/" ).ToLower() ) );

            // keep going until we parsed all files
            while ( filesQueue.Count > 0 && !Worker.CancellationPending )
            {
                // calculate the percentage of the current progress (we need to keep the cast or we always get 0 for some reason)
                int perc = (int)( decimal.Divide( args.FilesToParse.Count - filesQueue.Count , args.FilesToParse.Count ) * 100 );

                // update the search progress
                Worker.ReportProgress( perc );

                // get the current file name
                string filename = args.InnerPath + filesQueue.Dequeue();

                // search for files with an hash that matches the current file name hash
                List<MythicPackageFile> hashFound = args.UnnamedFiles.Where( f => f.FileHash == HashDictionary.HashFileName( filename ) ).ToList();

                // did we find any file name? (there can be only 1)
                if ( CheckHashFound( hashFound, filename ) )
                {
                    // remove the file from the list
                    args.UnnamedFiles.Remove( hashFound[0] );

                    // increase the amount of files found
                    args.TotalFound++;

                    // update the count of the files remaining
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Files_Found", args.TotalFound.ToString(), args.OriginalCount.ToString() ), false );

                    continue;
                }

                // get all the paths used in this package
                string[] paths = args.Package.GetAllPaths();

                // scan all the paths found in this package
                foreach ( string dir in paths )
                {
                    // create a new file name with the current dir
                    filename = Path.Combine( dir, Path.GetFileName( filename ) );

                    // search for files with an hash that matches the current file name hash
                    hashFound = args.UnnamedFiles.Where( f => f.FileHash == HashDictionary.HashFileName( filename ) ).ToList();

                    // did we find any file name? (there can be only 1)
                    if ( CheckHashFound( hashFound, filename ) )
                    {
                        // remove the file from the list
                        args.UnnamedFiles.Remove( hashFound[0] );

                        // increase the amount of files found
                        args.TotalFound++;

                        // update the count of the files remaining
                        ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Files_Found", args.TotalFound.ToString(), args.OriginalCount.ToString() ), false );

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Main loop for the brute force search
        /// </summary>
        /// <param name="bf">thread arguments</param>
        private void BruteSearchLoop( BruteForceArgs bf )
        {
            // reset the total files found
            bf.TotalFound = 0;

            // get the list of the brute force entries
            List<BruteForceEntry> entries = bf.Entries;

            // keep going until all entries are complete
            while ( !BruteForce.AllEntriesCompleted( ref entries ) && !Worker.CancellationPending && bf.UnnamedFiles.Count > 0 )
            {
                // get the next possible combination
                string fileName = BruteForce.GetNextBruteString( ref entries );

                // search for files with an hash that matches the current file name hash
                List<MythicPackageFile> hashFound = bf.UnnamedFiles.Where( f => f.FileHash == HashDictionary.HashFileName( fileName ) ).ToList();

                // did we find any file name? (there can be only 1)
                if ( CheckHashFound( hashFound, fileName ) )
                {
                    // remove the file from the list
                    bf.UnnamedFiles.Remove( hashFound[0] );

                    // increase the amount of files found
                    bf.TotalFound++;

                    // update the count of the files remaining
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_Files_Found", bf.TotalFound.ToString(), bf.OriginalCount.ToString() ), false );

                    continue;
                }
            }
        }

        /// <summary>
        /// Check a files result list if there is only 1 result and add the hash to the dicitonary
        /// </summary>
        /// <param name="hashFound">list to check</param>
        /// <param name="filename">filename used for the check</param>
        /// <returns></returns>
        private bool CheckHashFound( List<MythicPackageFile> hashFound, string filename )
        {
            // did we find any file name? (there can be only 1)
            if ( hashFound.Count == 1 )
            {
                // set the file name in the dictionary
                HashDictionary.Set( hashFound[0].FileHash, filename );

                // refresh the file name
                hashFound[0].RefreshFileName();

                // log that we found a new file name
                Globals.Logger.Log( string.Format( "Found string for hash {0:X}: {1}", hashFound[0].FileHash, filename ) );

                return true;
            }

            return false;
        }

        #endregion

        /// <summary>
        /// Initialize the form controls data
        /// </summary>
        private void Initialize()
        {
            // set the window title
            Text = Globals.LanguageManager.GetString( "MainForm_Title" );

            // set the icon to use
            Icon = Properties.Resources.Icon;

            // set the file menu text
            MainMenuFile.Text = Globals.LanguageManager.GetString( "MainForm_File" );
            MainMenuFileNew.Text = Globals.LanguageManager.GetString( "MainForm_File_New" );
            MainMenuFileOpen.Text = Globals.LanguageManager.GetString( "MainForm_File_Open" );
            MainMenuFileSave.Text = Globals.LanguageManager.GetString( "MainForm_File_Save" );
            MainMenuFileClose.Text = Globals.LanguageManager.GetString( "MainForm_File_Close" );
            MainMenuFileExit.Text = Globals.LanguageManager.GetString( "MainForm_File_Exit" );

            // set the edit menu text
            MainMenuEdit.Text = Globals.LanguageManager.GetString( "MainForm_Edit" );
            MainMenuEditSettings.Text = Globals.LanguageManager.GetString( "MainForm_Edit_Settings" );

            // set the dictionary menu text
            MainMenuDictionary.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary" );
            MainMenuDictionaryLoad.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Load" );
            MainMenuDictionarySave.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Save" );
            MainMenuDictionaryMerge.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Merge" );
            MainMenuDictionaryUpdate.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update" );
            MainMenuDictionarySpyStart.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Start" );
            MainMenuDictionarySpyAttach.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Attach" );
            MainMenuDictionarySpyDetach.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Detach" );

            // set the help menu text
            MainMenuHelp.Text = Globals.LanguageManager.GetString( "MainForm_Help" );
            MainMenuHelpAbout.Text = Globals.LanguageManager.GetString( "MainForm_Help_About" );

            // set the search buttons text
            btnSearchText.Text = Globals.LanguageManager.GetString( "MainForm_Button_SearchText" );

            // set the toolbar buttons text
            btnNew.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_New" );
            btnOpen.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Open" );
            btnSave.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Save" );
            btnClose.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Close" );

            btnOpenDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionaryOpen" );
            btnSaveDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionarySave" );
            btnMergeDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionaryMerge" );

            btnAdd.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Add" );
            btnAddFolder.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_AddFolder" );
            btnRemove.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Remove" );
            btnUnpack.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Unpack" );
            btnReplace.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Replace" );
            btnReplaceFolder.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_ReplaceFolder" );

            btnFolderSearch.Text = Globals.LanguageManager.GetString( "MainForm_Button_Folder_Search_ttp" );
            btnStopSearch.Text = Globals.LanguageManager.GetString( "MainForm_Button_Stop_Search_ttp" );
            btnBruteSearch.Text = Globals.LanguageManager.GetString( "MainForm_Button_Brute_Search_ttp" );
            btnShowLog.ToolTipText = Globals.LanguageManager.GetString( "MainForm_Button_Show_Log_ttp" );

            // set the package tab captions
            tabDetailsPackage.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Title" );
            lblPackageGeneral.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_General" );
            lblPackageFullName.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_FullName" );
            lblPackageAttributes.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Attributes" );
            lblPackageCreation.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Creation" );
            lblPackageSize.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Size" );

            lblPackageHeader.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Header" );
            lblPackageVersion.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Version" );
            lblPackageMisc.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Misc" );
            lblPackageHeaderSize.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_HeaderSize" );
            lblPackageBlockSize.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_BlockSize" );
            lblPackageFileCount.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_FileCount" );
            lblUnnamedFiles.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Unnamed_FileCount" );

            // set the Block tab captions
            tabDetailsBlock.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_Title" );
            lblBlockHeader.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_Header" );
            lblBlockFileCount.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_FileCount" );
            lblBlockNextBlock.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_NextBlock" );

            // set the File tab captions
            tabDetailsFile.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Title" );
            lblFileGeneral.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_General" );
            lblFileFileName.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Filename" );
            lblFileHash.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_FileHash" );
            lblFileDataHash.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_DataHash" );
            lblFileCompression.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Compression" );
            lblFileCompressionType.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_CompressionType" );
            lblFileCompressed.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_CompressedSize" );
            lblFileDecompressed.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_DecompressedSize" );
            lblMD5.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_MD5" );
            lblGlobalFileIndex.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Global_Index" );
            lblFileMime.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Mime_Type" );

            // set the preview tab captions
            tabPreview.Text = Globals.LanguageManager.GetString( "MainForm_PreviewTab_Title" );

            // initialize the error tooltip title
            ErrorTooltip.ToolTipTitle = Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_Title" );

            // search button tooltips
            ttpButtons.SetToolTip( btnSearchText, Globals.LanguageManager.GetString( "MainForm_Button_Text_Search_ttp" ) );
            ttpButtons.SetToolTip( btnClearSearch, Globals.LanguageManager.GetString( "MainForm_Button_Clear_Search_ttp" ) );

            // initialize dialogs
            SelectProcess = new SelectProcess();
            AddFile = new AddFile();
            FolderSearch = new FolderSearch();
            AddFolder = new AddFolder();
            About = new About();
            Settings = new SettingsDialog();

            // add the update progress event
            MythicPackageBlock.UpdateProgress += new UpdateProgress( MythicPackage_UpdateProgress );

            // add the hash found event
            Globals.HashSpy.HashFound += new HashFound( HashSpy_HashFound );

            // attach the application exit envet
            Application.ApplicationExit += new EventHandler( OnApplicationExit );

            // reset all tabs
            ClearAllTabs();
        }

        /// <summary>
        /// Disable form topmost event (called by the timer on show)
        /// </summary>
        private void DisableTopMost( object sender, ElapsedEventArgs e )
        {
            TopMost = false;
        }

        /// <summary>
        /// Determine if the app can be closed
        /// </summary>
        /// <returns>Can we close the form and end the application?</returns>
        private bool TryExit()
        {
            // either there are no threads running, or there is one and the user agrees to terminate it, we check if the files need saving.
            if ( !Worker.IsBusy || ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_WorkerTerminate" ) ) == DialogResult.Yes )
            {
                // scan all the tree nodes
                foreach ( TreeNode node in TreeView.Nodes )
                {
                    // is this an UOP package?
                    if ( node.Tag is MythicPackage package )
                    {
                        // has the package been modified?
                        if ( package != null && package.Modified )
                        {
                            // ask the user if he wants to save the changes
                            if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_SavePackage" ) ) == DialogResult.Yes )
                            {
                                // save the package (block exit if the save process starts)
                                return !SavePackage( package );
                            }
                        }
                    }
                }

                // has the dictionary been modified?
                if ( HashDictionary.Modified )
                {
                    // ask the user if he wants to save the changes
                    DialogResult result = ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_SaveDictionary", HashDictionary.NewHashes.ToString(), HashDictionary.NewFileNames.ToString() ) );

                    // if the user press cancel, we abort the app closing
                    if ( result == DialogResult.Cancel )
                        return false;

                    // if the user says yes, we save the changes
                    if ( result == DialogResult.Yes )
                    {
                        // update the status with the new operation
                        ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" ), false );

                        // start the background saving
                        Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.Actions.SAVE ) );
                    }

                    return true;
                }
                else // the dictionary doesn't need saving...
                    return true;
            }

            // if we got here, there is a background thread running and the user DO NOT want to terminate it.
            return false;
        }

        /// <summary>
        /// Convert the bytes in KB/MB/etc..
        /// </summary>
        /// <param name="bytes">size to measure</param>
        /// <returns>human readable bytes size</returns>
        private string ConvertSize( long bytes )
        {
            // all possible sizes
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            // initialize the index of the suffix to use
            int s = 0;

            // current size value
            double size = bytes;

            // keep going until the number is no longer divisible by 1024
            while ( size >= 1024 )
            {
                // increase the index
                s++;

                // divide the size by 1024
                size /= 1024;
            }

            return string.Format( "{0} {1}", size.ToString( "F2" ), suffixes[s] );
        }

        /// <summary>
        /// Save the uop file
        /// </summary>
        /// <returns>Did the save process started?</returns>
        private bool SavePackage( MythicPackage package, bool closeFile = false )
        {
            // show the save package dialog
            if ( ShowSavePackage( package.FileInfo?.Name ) == DialogResult.OK )
            {
                // if the file is in use we can get out
                if ( IsFileLocked( new FileInfo( SaveFileDialog.FileName ) ) )
                {
                    // warn the user the file is not accessible
                    ShowError( Globals.LanguageManager.GetString( "MainForm_Information_ErrorFileInaccessible" ), false );

                    // we return true here so on "tryexit" it will prevent the app from closing
                    return true;
                }

                // update the status with the new operation
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SavingPackage" ), false );

                // start the background thread to open the files
                Worker.RunWorkerAsync( new SaveMythicPackageArgs( package, SaveFileDialog.FileName, closeFile ) );

                return true;
            }

            return false;
        }

        /// <summary>
        /// Close a UOP file (NO SAVE CHECKS INCLUDED!!!)
        /// </summary>
        /// <param name="package">file to close</param>
        public void CloseFile( MythicPackage package )
        {
            // scan the tree
            foreach ( TreeNode node in TreeView.Nodes )
            {
                // is this the package we're looking for?
                if ( node.Tag is MythicPackage packageNode && packageNode == package )
                {
                    // close the file
                    CloseFile( packageNode );

                    return;
                }
            }
        }

        /// <summary>
        /// Close a UOP file (NO SAVE CHECKS INCLUDED!!!)
        /// </summary>
        /// <param name="packageNode">package tree node of the file</param>
        public void CloseFile( TreeNode packageNode )
        {
            // reset the search results
            results.Clear();

            // reset the text search key
            OldKeyword = null;

            // get the root node of the selected one
            TreeNode parent = TreeView.SelectedNode.Parent ?? TreeView.SelectedNode;

            // get the next node
            TreeNode next = SelectNextNode( parent );

            // remove the package node
            packageNode.Remove();

            // do we have a next node?
            if ( next == null )
            {
                // clear the files list
                ClearFilesList();

                // clear all tabs
                ClearAllTabs();
            }

            // select the next node
            TreeView.SelectedNode = next;
        }

        /// <summary>
        /// Determine if the UOP file is alraedy open
        /// </summary>
        /// <param name="fileName">file name to check</param>
        /// <returns>Is the file already open?</returns>
        private bool AlreadyOpen( string fileName )
        {
            // scan all the currently active UOP files
            foreach ( TreeNode n in TreeView.Nodes )
            {
                // get the UOP file data
                MythicPackage package = (MythicPackage)n.Tag;

                // do we have the file info (not a new UOP), and the file name is the one we're looking for?
                if ( package.FileInfo != null && package.FileInfo.FullName.Equals( fileName ) )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Get the next treeview node (after the one specified)
        /// </summary>
        /// <param name="node">Current node</param>
        /// <returns>Next node</returns>
        private TreeNode SelectNextNode( TreeNode node )
        {
            // get the next node
            TreeNode next = node.NextNode;

            // if we don't have a next node, we get the previous one
            if ( next == null )
                next = node.PrevNode;

            return next;
        }

        /// <summary>
        /// Check if the worker is busy and send the message to wait
        /// </summary>
        /// <param name="sendMessage">Send a message to the user?</param>
        /// <returns>is the worker busy?</returns>
        private bool CheckWorker( bool sendMessage = true )
        {
            if ( Worker.IsBusy )
            {
                // warn the user that he needs to wait
                if ( sendMessage )
                    ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );

                return true;
            }

            return false;
        }

        /// <summary>
        /// Get selected UOP file from the tree (if any)
        /// </summary>
        /// <returns>Selected UOP file</returns>
        private MythicPackage GetSelectedPackage( out TreeNode packageNode )
        {
            // get the selected node
            TreeNode node = TreeView.SelectedNode;

            // store the package node
            packageNode = node;

            // do we have a node selected?
            if ( node == null )
                return null;

            // does the node has a parent (the node is a block)? if so we use the parent instead.
            if ( node.Parent != null )
            {
                // change the package node (to the parent of the previous one)
                node = node.Parent;
                packageNode = node;
            }

            // get the UOP file data from the node (if available)
            return node.Tag is MythicPackage package ? package : null;
        }

        /// <summary>
        /// Get the selected block (if any)
        /// </summary>
        /// <returns>Selected block</returns>
        private MythicPackageBlock GetSelectedBlock()
        {
            // get the selected node
            TreeNode node = TreeView.SelectedNode;

            // do we have a node selected?
            if ( node == null )
                return null;

            // if the node has no parent, then it's not a block and we can go out
            if ( node.Parent == null )
                return null;

            // get the block file data from the node (if available)
            return node.Tag is MythicPackageBlock block ? block : null;
        }

        /// <summary>
        /// Get the selected file(s) (if any)
        /// </summary>
        /// <returns>Selected file(s)</returns>
        private List<MythicPackageFile> GetSelectedFiles()
        {
            // do we have selected items in the list?
            return ListBox.Items.Count == 0 || ListBox.SelectedItems.Count <= 0 ? null : ListBox.SelectedItems.Cast<MythicPackageFile>().ToList();
        }

        /// <summary>
        /// Check if a file is already in use
        /// </summary>
        /// <param name="file">file to check</param>
        /// <returns>is the file in use?</returns>
        protected virtual bool IsFileLocked( FileInfo file )
        {
            try
            {
                // create a temporary file to test if the location is accessible
                if ( !file.Exists )
                    using ( File.Create( file.FullName, 10, FileOptions.DeleteOnClose ) )
                    { }

                else // open and close the file to test if it's accessible
                    using ( FileStream stream = file.Open( FileMode.OpenOrCreate, FileAccess.Read, FileShare.None ) )
                    { }
            }
            catch ( IOException )
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// Find a specific file in the opened packages and select it in the list
        /// </summary>
        /// <param name="f">File to locate</param>
        private void LocateFileInList( MythicPackageFile f )
        {
            // search the files for all opened packages
            for ( int i = 0; i < TreeView.Nodes.Count; i++ )
            {
                // get the package node
                TreeNode node = TreeView.Nodes[ i ];

                // is this a package node?
                if ( node.Tag is MythicPackage && node.Tag == f.Parent.Parent )
                {
                    // expand the tree node
                    node.Expand();

                    // select the block
                    TreeView.SelectedNode = node.Nodes[f.Parent.Index];

                    // reset the selection
                    ListBox.SelectedIndex = -1;

                    // select the reult file
                    if ( f.Index < ListBox.Items.Count )
                        ListBox.SelectedIndex = f.Index;

                }
            }
        }

        /// <summary>
        /// Create a list of all the files
        /// </summary>
        /// <param name="sDir">Root folder</param>
        /// <returns>list of all the files inside the directory and sub-directory</returns>
        private List<string> DirSearch( string sDir )
        {
            // create the files list
            return Directory.GetFileSystemEntries( sDir, "*", SearchOption.AllDirectories ).Where( st => File.Exists( st ) ).ToList();
        }

        /// <summary>
        /// Set the text to the status from another thread
        /// </summary>
        /// <param name="value">text to set into the status</param>
        private void SetStatus( string value )
        {
            // is the call from another thread?
            if ( InvokeRequired )
            {
                // make the call from the correct thread
                Invoke( new Action<string>( SetStatus ), new object[] { value } );

                return;
            }

            // set the text
            StatusLabel.Text = value;
        }

        /// <summary>
        /// Search a text keyword inside part of a file name (of the currently selected uop file)
        /// </summary>
        /// <param name="keyword">keyword to search</param>
        /// <param name="next">are we looking for the next one?</param>
        /// <param name="next">are we looking for the previous one?</param>
        private void TextSearch( string keyword, bool next, bool prev = false )
        {
            // do we have a valid keyword to search?
            if ( string.IsNullOrEmpty( keyword ) )
            {
                // play the system beep sound
                SystemSounds.Beep.Play();

                return;
            }

            // initialize the list of the opened uops
            List<MythicPackage> uops = new List<MythicPackage>();

            // search all the opened uop files
            foreach ( TreeNode n in TreeView.Nodes )
            {
                // if this is a valid uop file, we add it to the list
                if ( n.Tag is MythicPackage pack )
                    uops.Add( pack );
            }

            // no uop loaded, we can get out
            if ( uops.Count <= 0 )
            {
                // play the system beep sound
                SystemSounds.Beep.Play();

                return;
            }

            // store the keyword for "search next"
            OldKeyword = txtSearchBox.Text;

            // are we beginning a new search?
            if ( !next )
            {
                // do we have to search for unnamed files?
                if ( txtSearchBox.Text == "?" )
                {
                    // scan all the packages and create a list of all the unnamed files
                    foreach ( MythicPackage pack in uops )
                        results.AddRange( pack.GetAllUnnamedFiles() );
                }
                else // get a list of all files matching the criteria
                    results = ( from p in uops
                                from b in p.Blocks
                                from f in b.Files
                                where !string.IsNullOrEmpty( f.FileName ) && f.FileName.Contains( keyword )
                                select f ).ToList();

                // reset the current file index
                m_searchIdx = -1;
            }

            // no results?
            if ( results.Count <= 0 )
            {
                // warn the user that we found nothing
                ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SearchNotFound", keyword ) );

                // reset the text search key
                OldKeyword = null;

                return;
            }

            // move to the previous file
            if ( prev )
                m_searchIdx--;
            else // move to the first/next index
                m_searchIdx++;

            // if we reached the last entry, we go back to the first one
            if ( m_searchIdx >= results.Count )
                m_searchIdx = 0;

            // if we reached the first entry, we go back to the last one
            if ( prev && m_searchIdx < 0 )
                m_searchIdx = results.Count - 1;

            // highlight the file in the list
            LocateFileInList( results[m_searchIdx] );
        }

        /// <summary>
        /// Convert a BitmapSource to Bitmap
        /// </summary>
        /// <param name="source">BitmapSource to convert</param>
        /// <returns>bitmap image</returns>
        private Bitmap BitmapSource2Bitmap( BitmapSource source )
        {
            // create the new bitmap
            Bitmap bmp = new Bitmap( source.PixelWidth, source.PixelHeight, PixelFormat.Format32bppPArgb );

            // get the bitmap data for the new image
            BitmapData data = bmp.LockBits( new Rectangle( System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb );

            // write the bitmap data from the source
            source.CopyPixels( Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride );

            // release the memory
            bmp.UnlockBits( data );

            return bmp;
        }

        #endregion
    }
}
