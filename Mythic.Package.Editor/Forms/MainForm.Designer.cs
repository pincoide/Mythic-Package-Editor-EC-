namespace Mythic.Package.Editor
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuEditSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionaryLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionarySave = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionaryMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionarySeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenuDictionaryUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionarySpyStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionarySpyAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuDictionarySpyDetach = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuHelpContent = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.btnShowLog = new System.Windows.Forms.ToolStripSplitButton();
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.mnuCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyMenuStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsData = new System.Windows.Forms.TabControl();
            this.tabDetailsPackage = new System.Windows.Forms.TabPage();
            this.txtUnnamedFilesInfo = new System.Windows.Forms.TextBox();
            this.lblUnnamedFiles = new System.Windows.Forms.Label();
            this.txtPackageSizeInfo = new System.Windows.Forms.TextBox();
            this.lblPackageSize = new System.Windows.Forms.Label();
            this.txtPackageCreationInfo = new System.Windows.Forms.TextBox();
            this.lblPackageCreation = new System.Windows.Forms.Label();
            this.txtPackageAttributesInfo = new System.Windows.Forms.TextBox();
            this.lblPackageAttributes = new System.Windows.Forms.Label();
            this.txtPackageFullNameInfo = new System.Windows.Forms.TextBox();
            this.lblPackageFullName = new System.Windows.Forms.Label();
            this.lblPackageGeneral = new System.Windows.Forms.Label();
            this.txtPackageFileCountInfo = new System.Windows.Forms.TextBox();
            this.lblPackageFileCount = new System.Windows.Forms.Label();
            this.txtPackageBlockSizeInfo = new System.Windows.Forms.TextBox();
            this.lblPackageBlockSize = new System.Windows.Forms.Label();
            this.txtPackageHeaderSizeInfo = new System.Windows.Forms.TextBox();
            this.lblPackageHeaderSize = new System.Windows.Forms.Label();
            this.txtPackageMiscInfo = new System.Windows.Forms.TextBox();
            this.lblPackageMisc = new System.Windows.Forms.Label();
            this.txtPackageVersionInfo = new System.Windows.Forms.TextBox();
            this.lblPackageVersion = new System.Windows.Forms.Label();
            this.lblPackageHeader = new System.Windows.Forms.Label();
            this.tabDetailsBlock = new System.Windows.Forms.TabPage();
            this.txtBlockIndexInfo = new System.Windows.Forms.TextBox();
            this.lblBlockIndex = new System.Windows.Forms.Label();
            this.txtBlockNextBlockInfo = new System.Windows.Forms.TextBox();
            this.lblBlockNextBlock = new System.Windows.Forms.Label();
            this.lblBlockHeader = new System.Windows.Forms.Label();
            this.txtBlockFileCountInfo = new System.Windows.Forms.TextBox();
            this.lblBlockFileCount = new System.Windows.Forms.Label();
            this.tabDetailsFile = new System.Windows.Forms.TabPage();
            this.btnFileUnset = new System.Windows.Forms.Button();
            this.lblMD5 = new System.Windows.Forms.Label();
            this.txtFileMD5Info = new System.Windows.Forms.TextBox();
            this.lblGlobalFileIndex = new System.Windows.Forms.Label();
            this.txtFileGlobalIndexInfo = new System.Windows.Forms.TextBox();
            this.lblFileIndex = new System.Windows.Forms.Label();
            this.txtFileIndexInfo = new System.Windows.Forms.TextBox();
            this.lblFileMime = new System.Windows.Forms.Label();
            this.txtFileMimeInfo = new System.Windows.Forms.TextBox();
            this.txtFileCompressionTypeInfo = new System.Windows.Forms.TextBox();
            this.lblFileCompressionType = new System.Windows.Forms.Label();
            this.lblFileCompression = new System.Windows.Forms.Label();
            this.lblFileGeneral = new System.Windows.Forms.Label();
            this.txtFileDecompressedInfo = new System.Windows.Forms.TextBox();
            this.txtFileFileNameInfo = new System.Windows.Forms.TextBox();
            this.lblFileDecompressed = new System.Windows.Forms.Label();
            this.lblFileFileName = new System.Windows.Forms.Label();
            this.txtFileCompressedInfo = new System.Windows.Forms.TextBox();
            this.lblFileHash = new System.Windows.Forms.Label();
            this.lblFileCompressed = new System.Windows.Forms.Label();
            this.txtFileHashInfo = new System.Windows.Forms.TextBox();
            this.lblFileDataHash = new System.Windows.Forms.Label();
            this.txtFileDataHashInfo = new System.Windows.Forms.TextBox();
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.pnlImagePreview = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtPreview = new FastColoredTextBoxNS.FastColoredTextBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.GeneralLabel = new System.Windows.Forms.Label();
            this.UncompressedInfo = new System.Windows.Forms.TextBox();
            this.UncompressedLabel = new System.Windows.Forms.Label();
            this.CompressedInfo = new System.Windows.Forms.TextBox();
            this.CompressedLabel = new System.Windows.Forms.Label();
            this.SizesLabel = new System.Windows.Forms.Label();
            this.DataOffsetInfo = new System.Windows.Forms.TextBox();
            this.DataOffsetLabel = new System.Windows.Forms.Label();
            this.UnknownInfo = new System.Windows.Forms.TextBox();
            this.UnknownLabel = new System.Windows.Forms.Label();
            this.HashInfo = new System.Windows.Forms.TextBox();
            this.HashLabel = new System.Windows.Forms.Label();
            this.FilenameInfo = new System.Windows.Forms.TextBox();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.FileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenDictionary = new System.Windows.Forms.ToolStripButton();
            this.btnMergeDictionary = new System.Windows.Forms.ToolStripButton();
            this.btnSaveDictionary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnAddFolder = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.btnReplace = new System.Windows.Forms.ToolStripButton();
            this.btnReplaceFolder = new System.Windows.Forms.ToolStripButton();
            this.btnUnpack = new System.Windows.Forms.ToolStripButton();
            this.btnStopSearch = new System.Windows.Forms.ToolStripButton();
            this.btnBruteSearch = new System.Windows.Forms.ToolStripButton();
            this.btnFolderSearch = new System.Windows.Forms.ToolStripButton();
            this.ErrorTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Help = new System.Windows.Forms.HelpProvider();
            this.ttpButtons = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearchText = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.tmrUIUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblImageFormat = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.Status.SuspendLayout();
            this.mnuCopy.SuspendLayout();
            this.tabsData.SuspendLayout();
            this.tabDetailsPackage.SuspendLayout();
            this.tabDetailsBlock.SuspendLayout();
            this.tabDetailsFile.SuspendLayout();
            this.tabPreview.SuspendLayout();
            this.pnlImagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.MenuToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuFile,
            this.MainMenuEdit,
            this.MainMenuDictionary,
            this.MainMenuHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(794, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Menu";
            // 
            // MainMenuFile
            // 
            this.MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuFileNew,
            this.MainMenuFileOpen,
            this.MainMenuFileSave,
            this.MainMenuFileClose,
            this.MainMenuFileSeparator,
            this.MainMenuFileExit});
            this.MainMenuFile.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFile.Name = "MainMenuFile";
            this.MainMenuFile.Size = new System.Drawing.Size(37, 20);
            this.MainMenuFile.Text = "File";
            // 
            // MainMenuFileNew
            // 
            this.MainMenuFileNew.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileNew.Image = global::Mythic.Package.Editor.Properties.Resources.New;
            this.MainMenuFileNew.Name = "MainMenuFileNew";
            this.MainMenuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MainMenuFileNew.Size = new System.Drawing.Size(157, 22);
            this.MainMenuFileNew.Text = "New";
            this.MainMenuFileNew.Click += new System.EventHandler(this.MainMenuFileNew_Click);
            // 
            // MainMenuFileOpen
            // 
            this.MainMenuFileOpen.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileOpen.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.MainMenuFileOpen.Name = "MainMenuFileOpen";
            this.MainMenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MainMenuFileOpen.Size = new System.Drawing.Size(157, 22);
            this.MainMenuFileOpen.Text = "Open";
            this.MainMenuFileOpen.Click += new System.EventHandler(this.MainMenuFileOpen_Click);
            // 
            // MainMenuFileSave
            // 
            this.MainMenuFileSave.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuFileSave.Image")));
            this.MainMenuFileSave.Name = "MainMenuFileSave";
            this.MainMenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MainMenuFileSave.Size = new System.Drawing.Size(157, 22);
            this.MainMenuFileSave.Text = "Save";
            this.MainMenuFileSave.Click += new System.EventHandler(this.MainMenuFileSave_Click);
            // 
            // MainMenuFileClose
            // 
            this.MainMenuFileClose.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileClose.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuFileClose.Image")));
            this.MainMenuFileClose.Name = "MainMenuFileClose";
            this.MainMenuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.MainMenuFileClose.Size = new System.Drawing.Size(157, 22);
            this.MainMenuFileClose.Text = "Close";
            this.MainMenuFileClose.Click += new System.EventHandler(this.MainMenuFileClose_Click);
            // 
            // MainMenuFileSeparator
            // 
            this.MainMenuFileSeparator.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileSeparator.Name = "MainMenuFileSeparator";
            this.MainMenuFileSeparator.Size = new System.Drawing.Size(154, 6);
            // 
            // MainMenuFileExit
            // 
            this.MainMenuFileExit.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileExit.Name = "MainMenuFileExit";
            this.MainMenuFileExit.Size = new System.Drawing.Size(157, 22);
            this.MainMenuFileExit.Text = "Exit";
            this.MainMenuFileExit.Click += new System.EventHandler(this.MainMenuFileExit_Click);
            // 
            // MainMenuEdit
            // 
            this.MainMenuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuEditSettings});
            this.MainMenuEdit.ForeColor = System.Drawing.Color.Black;
            this.MainMenuEdit.Name = "MainMenuEdit";
            this.MainMenuEdit.Size = new System.Drawing.Size(39, 20);
            this.MainMenuEdit.Text = "Edit";
            // 
            // MainMenuEditSettings
            // 
            this.MainMenuEditSettings.ForeColor = System.Drawing.Color.Black;
            this.MainMenuEditSettings.Image = global::Mythic.Package.Editor.Properties.Resources.Wrench;
            this.MainMenuEditSettings.Name = "MainMenuEditSettings";
            this.MainMenuEditSettings.Size = new System.Drawing.Size(116, 22);
            this.MainMenuEditSettings.Text = "Settings";
            this.MainMenuEditSettings.Click += new System.EventHandler(this.MainMenuEditSettings_Click);
            // 
            // MainMenuDictionary
            // 
            this.MainMenuDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuDictionaryLoad,
            this.MainMenuDictionarySave,
            this.MainMenuDictionaryMerge,
            this.MainMenuDictionarySeparator,
            this.MainMenuDictionaryUpdate});
            this.MainMenuDictionary.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionary.Name = "MainMenuDictionary";
            this.MainMenuDictionary.Size = new System.Drawing.Size(73, 20);
            this.MainMenuDictionary.Text = "Dictionary";
            // 
            // MainMenuDictionaryLoad
            // 
            this.MainMenuDictionaryLoad.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionaryLoad.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.MainMenuDictionaryLoad.Name = "MainMenuDictionaryLoad";
            this.MainMenuDictionaryLoad.Size = new System.Drawing.Size(112, 22);
            this.MainMenuDictionaryLoad.Text = "Load";
            this.MainMenuDictionaryLoad.Click += new System.EventHandler(this.MainMenuDictionaryLoad_Click);
            // 
            // MainMenuDictionarySave
            // 
            this.MainMenuDictionarySave.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionarySave.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuDictionarySave.Image")));
            this.MainMenuDictionarySave.Name = "MainMenuDictionarySave";
            this.MainMenuDictionarySave.Size = new System.Drawing.Size(112, 22);
            this.MainMenuDictionarySave.Text = "Save";
            this.MainMenuDictionarySave.Click += new System.EventHandler(this.MainMenuDictionarySave_Click);
            // 
            // MainMenuDictionaryMerge
            // 
            this.MainMenuDictionaryMerge.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionaryMerge.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuDictionaryMerge.Image")));
            this.MainMenuDictionaryMerge.Name = "MainMenuDictionaryMerge";
            this.MainMenuDictionaryMerge.Size = new System.Drawing.Size(112, 22);
            this.MainMenuDictionaryMerge.Text = "Merge";
            this.MainMenuDictionaryMerge.Click += new System.EventHandler(this.MainMenuDictionaryMerge_Click);
            // 
            // MainMenuDictionarySeparator
            // 
            this.MainMenuDictionarySeparator.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionarySeparator.Name = "MainMenuDictionarySeparator";
            this.MainMenuDictionarySeparator.Size = new System.Drawing.Size(109, 6);
            // 
            // MainMenuDictionaryUpdate
            // 
            this.MainMenuDictionaryUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuDictionarySpyStart,
            this.MainMenuDictionarySpyAttach,
            this.MainMenuDictionarySpyDetach});
            this.MainMenuDictionaryUpdate.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionaryUpdate.Image = global::Mythic.Package.Editor.Properties.Resources.Eye;
            this.MainMenuDictionaryUpdate.Name = "MainMenuDictionaryUpdate";
            this.MainMenuDictionaryUpdate.Size = new System.Drawing.Size(112, 22);
            this.MainMenuDictionaryUpdate.Text = "Update";
            // 
            // MainMenuDictionarySpyStart
            // 
            this.MainMenuDictionarySpyStart.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionarySpyStart.Name = "MainMenuDictionarySpyStart";
            this.MainMenuDictionarySpyStart.Size = new System.Drawing.Size(131, 22);
            this.MainMenuDictionarySpyStart.Text = "Spy Start";
            this.MainMenuDictionarySpyStart.Click += new System.EventHandler(this.MainMenuSpyStart_Click);
            // 
            // MainMenuDictionarySpyAttach
            // 
            this.MainMenuDictionarySpyAttach.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionarySpyAttach.Name = "MainMenuDictionarySpyAttach";
            this.MainMenuDictionarySpyAttach.Size = new System.Drawing.Size(131, 22);
            this.MainMenuDictionarySpyAttach.Text = "Spy Attach";
            this.MainMenuDictionarySpyAttach.Click += new System.EventHandler(this.MainMenuSpyAttach_Click);
            // 
            // MainMenuDictionarySpyDetach
            // 
            this.MainMenuDictionarySpyDetach.Enabled = false;
            this.MainMenuDictionarySpyDetach.ForeColor = System.Drawing.Color.Black;
            this.MainMenuDictionarySpyDetach.Name = "MainMenuDictionarySpyDetach";
            this.MainMenuDictionarySpyDetach.Size = new System.Drawing.Size(131, 22);
            this.MainMenuDictionarySpyDetach.Text = "Detach";
            this.MainMenuDictionarySpyDetach.Click += new System.EventHandler(this.MainMenuSpyDetach_Click);
            // 
            // MainMenuHelp
            // 
            this.MainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuHelpContent,
            this.MainMenuHelpAbout});
            this.MainMenuHelp.ForeColor = System.Drawing.Color.Black;
            this.MainMenuHelp.Name = "MainMenuHelp";
            this.MainMenuHelp.Size = new System.Drawing.Size(44, 20);
            this.MainMenuHelp.Text = "Help";
            // 
            // MainMenuHelpContent
            // 
            this.MainMenuHelpContent.ForeColor = System.Drawing.Color.Black;
            this.MainMenuHelpContent.Name = "MainMenuHelpContent";
            this.MainMenuHelpContent.Size = new System.Drawing.Size(117, 22);
            this.MainMenuHelpContent.Text = "Content";
            this.MainMenuHelpContent.Click += new System.EventHandler(this.MainMenuHelpContent_Click);
            // 
            // MainMenuHelpAbout
            // 
            this.MainMenuHelpAbout.ForeColor = System.Drawing.Color.Black;
            this.MainMenuHelpAbout.Image = global::Mythic.Package.Editor.Properties.Resources.Information;
            this.MainMenuHelpAbout.Name = "MainMenuHelpAbout";
            this.MainMenuHelpAbout.Size = new System.Drawing.Size(117, 22);
            this.MainMenuHelpAbout.Text = "About";
            this.MainMenuHelpAbout.Click += new System.EventHandler(this.MainMenuHelpAbout_Click);
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.TreeView.HideSelection = false;
            this.TreeView.Location = new System.Drawing.Point(12, 52);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(150, 408);
            this.TreeView.TabIndex = 1;
            this.TreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TreeView_DrawNode);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeView_KeyDown);
            // 
            // ListBox
            // 
            this.ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(168, 52);
            this.ListBox.Name = "ListBox";
            this.ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox.Size = new System.Drawing.Size(200, 407);
            this.ListBox.TabIndex = 2;
            this.ListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            this.ListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox_KeyDown);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowLog,
            this.StatusProgressBar,
            this.StatusLabel});
            this.Status.Location = new System.Drawing.Point(0, 463);
            this.Status.Name = "Status";
            this.Status.ShowItemToolTips = true;
            this.Status.Size = new System.Drawing.Size(794, 22);
            this.Status.TabIndex = 4;
            // 
            // btnShowLog
            // 
            this.btnShowLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowLog.DropDownButtonWidth = 0;
            this.btnShowLog.Image = global::Mythic.Package.Editor.Properties.Resources.Alert;
            this.btnShowLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowLog.Margin = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(21, 20);
            this.btnShowLog.Text = "toolStripSplitButton1";
            this.btnShowLog.ButtonClick += new System.EventHandler(this.btnShowLog_ButtonClick);
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Margin = new System.Windows.Forms.Padding(5, 3, 1, 3);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(150, 16);
            this.StatusProgressBar.Step = 1;
            this.StatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMenuStripButton});
            this.mnuCopy.Name = "CopyMenuStrip";
            this.mnuCopy.ShowImageMargin = false;
            this.mnuCopy.Size = new System.Drawing.Size(147, 26);
            // 
            // CopyMenuStripButton
            // 
            this.CopyMenuStripButton.ForeColor = System.Drawing.Color.Black;
            this.CopyMenuStripButton.Name = "CopyMenuStripButton";
            this.CopyMenuStripButton.Size = new System.Drawing.Size(146, 22);
            this.CopyMenuStripButton.Text = "Copy to Clipboard";
            this.CopyMenuStripButton.Click += new System.EventHandler(this.CopyMenuStripButton_Click);
            // 
            // tabsData
            // 
            this.tabsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsData.Controls.Add(this.tabDetailsPackage);
            this.tabsData.Controls.Add(this.tabDetailsBlock);
            this.tabsData.Controls.Add(this.tabDetailsFile);
            this.tabsData.Controls.Add(this.tabPreview);
            this.tabsData.Location = new System.Drawing.Point(374, 52);
            this.tabsData.Name = "tabsData";
            this.tabsData.Padding = new System.Drawing.Point(10, 3);
            this.tabsData.SelectedIndex = 0;
            this.tabsData.Size = new System.Drawing.Size(408, 356);
            this.tabsData.TabIndex = 8;
            // 
            // tabDetailsPackage
            // 
            this.tabDetailsPackage.BackColor = System.Drawing.SystemColors.Control;
            this.tabDetailsPackage.Controls.Add(this.txtUnnamedFilesInfo);
            this.tabDetailsPackage.Controls.Add(this.lblUnnamedFiles);
            this.tabDetailsPackage.Controls.Add(this.txtPackageSizeInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageSize);
            this.tabDetailsPackage.Controls.Add(this.txtPackageCreationInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageCreation);
            this.tabDetailsPackage.Controls.Add(this.txtPackageAttributesInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageAttributes);
            this.tabDetailsPackage.Controls.Add(this.txtPackageFullNameInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageFullName);
            this.tabDetailsPackage.Controls.Add(this.lblPackageGeneral);
            this.tabDetailsPackage.Controls.Add(this.txtPackageFileCountInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageFileCount);
            this.tabDetailsPackage.Controls.Add(this.txtPackageBlockSizeInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageBlockSize);
            this.tabDetailsPackage.Controls.Add(this.txtPackageHeaderSizeInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageHeaderSize);
            this.tabDetailsPackage.Controls.Add(this.txtPackageMiscInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageMisc);
            this.tabDetailsPackage.Controls.Add(this.txtPackageVersionInfo);
            this.tabDetailsPackage.Controls.Add(this.lblPackageVersion);
            this.tabDetailsPackage.Controls.Add(this.lblPackageHeader);
            this.tabDetailsPackage.Location = new System.Drawing.Point(4, 22);
            this.tabDetailsPackage.Name = "tabDetailsPackage";
            this.tabDetailsPackage.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetailsPackage.Size = new System.Drawing.Size(400, 330);
            this.tabDetailsPackage.TabIndex = 0;
            this.tabDetailsPackage.Text = "Package Details";
            // 
            // txtUnnamedFilesInfo
            // 
            this.txtUnnamedFilesInfo.BackColor = System.Drawing.Color.White;
            this.txtUnnamedFilesInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnnamedFilesInfo.ContextMenuStrip = this.mnuCopy;
            this.txtUnnamedFilesInfo.Location = new System.Drawing.Point(114, 289);
            this.txtUnnamedFilesInfo.Name = "txtUnnamedFilesInfo";
            this.txtUnnamedFilesInfo.ReadOnly = true;
            this.txtUnnamedFilesInfo.Size = new System.Drawing.Size(120, 13);
            this.txtUnnamedFilesInfo.TabIndex = 21;
            // 
            // lblUnnamedFiles
            // 
            this.lblUnnamedFiles.Location = new System.Drawing.Point(3, 289);
            this.lblUnnamedFiles.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblUnnamedFiles.Name = "lblUnnamedFiles";
            this.lblUnnamedFiles.Size = new System.Drawing.Size(105, 13);
            this.lblUnnamedFiles.TabIndex = 20;
            this.lblUnnamedFiles.Text = "File count:";
            this.lblUnnamedFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageSizeInfo
            // 
            this.txtPackageSizeInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageSizeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageSizeInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageSizeInfo.Location = new System.Drawing.Point(114, 107);
            this.txtPackageSizeInfo.Name = "txtPackageSizeInfo";
            this.txtPackageSizeInfo.ReadOnly = true;
            this.txtPackageSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageSizeInfo.TabIndex = 19;
            // 
            // lblPackageSize
            // 
            this.lblPackageSize.Location = new System.Drawing.Point(3, 107);
            this.lblPackageSize.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageSize.Name = "lblPackageSize";
            this.lblPackageSize.Size = new System.Drawing.Size(105, 13);
            this.lblPackageSize.TabIndex = 18;
            this.lblPackageSize.Text = "Size:";
            this.lblPackageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageCreationInfo
            // 
            this.txtPackageCreationInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageCreationInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageCreationInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageCreationInfo.Location = new System.Drawing.Point(114, 85);
            this.txtPackageCreationInfo.Name = "txtPackageCreationInfo";
            this.txtPackageCreationInfo.ReadOnly = true;
            this.txtPackageCreationInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageCreationInfo.TabIndex = 17;
            // 
            // lblPackageCreation
            // 
            this.lblPackageCreation.Location = new System.Drawing.Point(3, 85);
            this.lblPackageCreation.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageCreation.Name = "lblPackageCreation";
            this.lblPackageCreation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPackageCreation.Size = new System.Drawing.Size(105, 13);
            this.lblPackageCreation.TabIndex = 16;
            this.lblPackageCreation.Text = "Creation:";
            this.lblPackageCreation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageAttributesInfo
            // 
            this.txtPackageAttributesInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageAttributesInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageAttributesInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageAttributesInfo.Location = new System.Drawing.Point(114, 63);
            this.txtPackageAttributesInfo.Name = "txtPackageAttributesInfo";
            this.txtPackageAttributesInfo.ReadOnly = true;
            this.txtPackageAttributesInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageAttributesInfo.TabIndex = 15;
            // 
            // lblPackageAttributes
            // 
            this.lblPackageAttributes.Location = new System.Drawing.Point(3, 63);
            this.lblPackageAttributes.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageAttributes.Name = "lblPackageAttributes";
            this.lblPackageAttributes.Size = new System.Drawing.Size(105, 13);
            this.lblPackageAttributes.TabIndex = 14;
            this.lblPackageAttributes.Text = "Attributes:";
            this.lblPackageAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageFullNameInfo
            // 
            this.txtPackageFullNameInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageFullNameInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageFullNameInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageFullNameInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPackageFullNameInfo.Location = new System.Drawing.Point(114, 28);
            this.txtPackageFullNameInfo.Multiline = true;
            this.txtPackageFullNameInfo.Name = "txtPackageFullNameInfo";
            this.txtPackageFullNameInfo.ReadOnly = true;
            this.txtPackageFullNameInfo.Size = new System.Drawing.Size(280, 26);
            this.txtPackageFullNameInfo.TabIndex = 13;
            // 
            // lblPackageFullName
            // 
            this.lblPackageFullName.Location = new System.Drawing.Point(3, 34);
            this.lblPackageFullName.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageFullName.Name = "lblPackageFullName";
            this.lblPackageFullName.Size = new System.Drawing.Size(105, 13);
            this.lblPackageFullName.TabIndex = 12;
            this.lblPackageFullName.Text = "Full name:";
            this.lblPackageFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPackageGeneral
            // 
            this.lblPackageGeneral.AutoSize = true;
            this.lblPackageGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageGeneral.Location = new System.Drawing.Point(6, 10);
            this.lblPackageGeneral.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblPackageGeneral.Name = "lblPackageGeneral";
            this.lblPackageGeneral.Size = new System.Drawing.Size(51, 13);
            this.lblPackageGeneral.TabIndex = 11;
            this.lblPackageGeneral.Text = "General";
            // 
            // txtPackageFileCountInfo
            // 
            this.txtPackageFileCountInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageFileCountInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageFileCountInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageFileCountInfo.Location = new System.Drawing.Point(114, 264);
            this.txtPackageFileCountInfo.Name = "txtPackageFileCountInfo";
            this.txtPackageFileCountInfo.ReadOnly = true;
            this.txtPackageFileCountInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageFileCountInfo.TabIndex = 10;
            // 
            // lblPackageFileCount
            // 
            this.lblPackageFileCount.Location = new System.Drawing.Point(3, 264);
            this.lblPackageFileCount.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageFileCount.Name = "lblPackageFileCount";
            this.lblPackageFileCount.Size = new System.Drawing.Size(105, 13);
            this.lblPackageFileCount.TabIndex = 9;
            this.lblPackageFileCount.Text = "File count:";
            this.lblPackageFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageBlockSizeInfo
            // 
            this.txtPackageBlockSizeInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageBlockSizeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageBlockSizeInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageBlockSizeInfo.Location = new System.Drawing.Point(114, 239);
            this.txtPackageBlockSizeInfo.Name = "txtPackageBlockSizeInfo";
            this.txtPackageBlockSizeInfo.ReadOnly = true;
            this.txtPackageBlockSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageBlockSizeInfo.TabIndex = 8;
            // 
            // lblPackageBlockSize
            // 
            this.lblPackageBlockSize.Location = new System.Drawing.Point(3, 239);
            this.lblPackageBlockSize.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageBlockSize.Name = "lblPackageBlockSize";
            this.lblPackageBlockSize.Size = new System.Drawing.Size(105, 13);
            this.lblPackageBlockSize.TabIndex = 7;
            this.lblPackageBlockSize.Text = "Block size:";
            this.lblPackageBlockSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageHeaderSizeInfo
            // 
            this.txtPackageHeaderSizeInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageHeaderSizeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageHeaderSizeInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageHeaderSizeInfo.Location = new System.Drawing.Point(114, 214);
            this.txtPackageHeaderSizeInfo.Name = "txtPackageHeaderSizeInfo";
            this.txtPackageHeaderSizeInfo.ReadOnly = true;
            this.txtPackageHeaderSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageHeaderSizeInfo.TabIndex = 6;
            // 
            // lblPackageHeaderSize
            // 
            this.lblPackageHeaderSize.Location = new System.Drawing.Point(3, 214);
            this.lblPackageHeaderSize.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageHeaderSize.Name = "lblPackageHeaderSize";
            this.lblPackageHeaderSize.Size = new System.Drawing.Size(105, 13);
            this.lblPackageHeaderSize.TabIndex = 5;
            this.lblPackageHeaderSize.Text = "Header size:";
            this.lblPackageHeaderSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageMiscInfo
            // 
            this.txtPackageMiscInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageMiscInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageMiscInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageMiscInfo.Location = new System.Drawing.Point(114, 189);
            this.txtPackageMiscInfo.Name = "txtPackageMiscInfo";
            this.txtPackageMiscInfo.ReadOnly = true;
            this.txtPackageMiscInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageMiscInfo.TabIndex = 4;
            // 
            // lblPackageMisc
            // 
            this.lblPackageMisc.Location = new System.Drawing.Point(3, 189);
            this.lblPackageMisc.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageMisc.Name = "lblPackageMisc";
            this.lblPackageMisc.Size = new System.Drawing.Size(105, 13);
            this.lblPackageMisc.TabIndex = 3;
            this.lblPackageMisc.Text = "Misc:";
            this.lblPackageMisc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackageVersionInfo
            // 
            this.txtPackageVersionInfo.BackColor = System.Drawing.Color.White;
            this.txtPackageVersionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPackageVersionInfo.ContextMenuStrip = this.mnuCopy;
            this.txtPackageVersionInfo.Location = new System.Drawing.Point(114, 164);
            this.txtPackageVersionInfo.Name = "txtPackageVersionInfo";
            this.txtPackageVersionInfo.ReadOnly = true;
            this.txtPackageVersionInfo.Size = new System.Drawing.Size(120, 13);
            this.txtPackageVersionInfo.TabIndex = 2;
            // 
            // lblPackageVersion
            // 
            this.lblPackageVersion.Location = new System.Drawing.Point(3, 164);
            this.lblPackageVersion.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblPackageVersion.Name = "lblPackageVersion";
            this.lblPackageVersion.Size = new System.Drawing.Size(105, 13);
            this.lblPackageVersion.TabIndex = 1;
            this.lblPackageVersion.Text = "Version:";
            this.lblPackageVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPackageHeader
            // 
            this.lblPackageHeader.AutoSize = true;
            this.lblPackageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageHeader.Location = new System.Drawing.Point(3, 147);
            this.lblPackageHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblPackageHeader.Name = "lblPackageHeader";
            this.lblPackageHeader.Size = new System.Drawing.Size(48, 13);
            this.lblPackageHeader.TabIndex = 0;
            this.lblPackageHeader.Text = "Header";
            // 
            // tabDetailsBlock
            // 
            this.tabDetailsBlock.BackColor = System.Drawing.SystemColors.Control;
            this.tabDetailsBlock.Controls.Add(this.txtBlockIndexInfo);
            this.tabDetailsBlock.Controls.Add(this.lblBlockIndex);
            this.tabDetailsBlock.Controls.Add(this.txtBlockNextBlockInfo);
            this.tabDetailsBlock.Controls.Add(this.lblBlockNextBlock);
            this.tabDetailsBlock.Controls.Add(this.lblBlockHeader);
            this.tabDetailsBlock.Controls.Add(this.txtBlockFileCountInfo);
            this.tabDetailsBlock.Controls.Add(this.lblBlockFileCount);
            this.tabDetailsBlock.Location = new System.Drawing.Point(4, 22);
            this.tabDetailsBlock.Name = "tabDetailsBlock";
            this.tabDetailsBlock.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetailsBlock.Size = new System.Drawing.Size(400, 330);
            this.tabDetailsBlock.TabIndex = 1;
            this.tabDetailsBlock.Text = "Block Details";
            // 
            // txtBlockIndexInfo
            // 
            this.txtBlockIndexInfo.BackColor = System.Drawing.Color.White;
            this.txtBlockIndexInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlockIndexInfo.ContextMenuStrip = this.mnuCopy;
            this.txtBlockIndexInfo.Location = new System.Drawing.Point(114, 51);
            this.txtBlockIndexInfo.Name = "txtBlockIndexInfo";
            this.txtBlockIndexInfo.ReadOnly = true;
            this.txtBlockIndexInfo.Size = new System.Drawing.Size(83, 13);
            this.txtBlockIndexInfo.TabIndex = 17;
            // 
            // lblBlockIndex
            // 
            this.lblBlockIndex.Location = new System.Drawing.Point(3, 51);
            this.lblBlockIndex.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblBlockIndex.Name = "lblBlockIndex";
            this.lblBlockIndex.Size = new System.Drawing.Size(105, 13);
            this.lblBlockIndex.TabIndex = 16;
            this.lblBlockIndex.Text = "Block Index:";
            this.lblBlockIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBlockNextBlockInfo
            // 
            this.txtBlockNextBlockInfo.BackColor = System.Drawing.Color.White;
            this.txtBlockNextBlockInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlockNextBlockInfo.ContextMenuStrip = this.mnuCopy;
            this.txtBlockNextBlockInfo.Location = new System.Drawing.Point(114, 74);
            this.txtBlockNextBlockInfo.Name = "txtBlockNextBlockInfo";
            this.txtBlockNextBlockInfo.ReadOnly = true;
            this.txtBlockNextBlockInfo.Size = new System.Drawing.Size(120, 13);
            this.txtBlockNextBlockInfo.TabIndex = 15;
            // 
            // lblBlockNextBlock
            // 
            this.lblBlockNextBlock.Location = new System.Drawing.Point(3, 74);
            this.lblBlockNextBlock.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblBlockNextBlock.Name = "lblBlockNextBlock";
            this.lblBlockNextBlock.Size = new System.Drawing.Size(105, 13);
            this.lblBlockNextBlock.TabIndex = 14;
            this.lblBlockNextBlock.Text = "Next block:";
            this.lblBlockNextBlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBlockHeader
            // 
            this.lblBlockHeader.AutoSize = true;
            this.lblBlockHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockHeader.Location = new System.Drawing.Point(6, 10);
            this.lblBlockHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblBlockHeader.Name = "lblBlockHeader";
            this.lblBlockHeader.Size = new System.Drawing.Size(48, 13);
            this.lblBlockHeader.TabIndex = 13;
            this.lblBlockHeader.Text = "Header";
            // 
            // txtBlockFileCountInfo
            // 
            this.txtBlockFileCountInfo.BackColor = System.Drawing.Color.White;
            this.txtBlockFileCountInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlockFileCountInfo.ContextMenuStrip = this.mnuCopy;
            this.txtBlockFileCountInfo.Location = new System.Drawing.Point(114, 28);
            this.txtBlockFileCountInfo.Name = "txtBlockFileCountInfo";
            this.txtBlockFileCountInfo.ReadOnly = true;
            this.txtBlockFileCountInfo.Size = new System.Drawing.Size(83, 13);
            this.txtBlockFileCountInfo.TabIndex = 12;
            // 
            // lblBlockFileCount
            // 
            this.lblBlockFileCount.Location = new System.Drawing.Point(3, 28);
            this.lblBlockFileCount.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblBlockFileCount.Name = "lblBlockFileCount";
            this.lblBlockFileCount.Size = new System.Drawing.Size(105, 13);
            this.lblBlockFileCount.TabIndex = 11;
            this.lblBlockFileCount.Text = "File count:";
            this.lblBlockFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabDetailsFile
            // 
            this.tabDetailsFile.BackColor = System.Drawing.SystemColors.Control;
            this.tabDetailsFile.Controls.Add(this.btnFileUnset);
            this.tabDetailsFile.Controls.Add(this.lblMD5);
            this.tabDetailsFile.Controls.Add(this.txtFileMD5Info);
            this.tabDetailsFile.Controls.Add(this.lblGlobalFileIndex);
            this.tabDetailsFile.Controls.Add(this.txtFileGlobalIndexInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileIndex);
            this.tabDetailsFile.Controls.Add(this.txtFileIndexInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileMime);
            this.tabDetailsFile.Controls.Add(this.txtFileMimeInfo);
            this.tabDetailsFile.Controls.Add(this.txtFileCompressionTypeInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileCompressionType);
            this.tabDetailsFile.Controls.Add(this.lblFileCompression);
            this.tabDetailsFile.Controls.Add(this.lblFileGeneral);
            this.tabDetailsFile.Controls.Add(this.txtFileDecompressedInfo);
            this.tabDetailsFile.Controls.Add(this.txtFileFileNameInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileDecompressed);
            this.tabDetailsFile.Controls.Add(this.lblFileFileName);
            this.tabDetailsFile.Controls.Add(this.txtFileCompressedInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileHash);
            this.tabDetailsFile.Controls.Add(this.lblFileCompressed);
            this.tabDetailsFile.Controls.Add(this.txtFileHashInfo);
            this.tabDetailsFile.Controls.Add(this.lblFileDataHash);
            this.tabDetailsFile.Controls.Add(this.txtFileDataHashInfo);
            this.tabDetailsFile.Location = new System.Drawing.Point(4, 22);
            this.tabDetailsFile.Name = "tabDetailsFile";
            this.tabDetailsFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetailsFile.Size = new System.Drawing.Size(400, 330);
            this.tabDetailsFile.TabIndex = 2;
            this.tabDetailsFile.Text = "File Details";
            // 
            // btnFileUnset
            // 
            this.btnFileUnset.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnFileUnset.Location = new System.Drawing.Point(23, 28);
            this.btnFileUnset.Name = "btnFileUnset";
            this.btnFileUnset.Size = new System.Drawing.Size(23, 24);
            this.btnFileUnset.TabIndex = 20;
            this.btnFileUnset.UseVisualStyleBackColor = true;
            this.btnFileUnset.Visible = false;
            this.btnFileUnset.Click += new System.EventHandler(this.FileUnsetButton_Click);
            // 
            // lblMD5
            // 
            this.lblMD5.Location = new System.Drawing.Point(20, 99);
            this.lblMD5.Name = "lblMD5";
            this.lblMD5.Size = new System.Drawing.Size(88, 13);
            this.lblMD5.TabIndex = 32;
            this.lblMD5.Text = "MD5 hash:";
            this.lblMD5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileMD5Info
            // 
            this.txtFileMD5Info.BackColor = System.Drawing.Color.White;
            this.txtFileMD5Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileMD5Info.ContextMenuStrip = this.mnuCopy;
            this.txtFileMD5Info.Location = new System.Drawing.Point(114, 99);
            this.txtFileMD5Info.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileMD5Info.Name = "txtFileMD5Info";
            this.txtFileMD5Info.ReadOnly = true;
            this.txtFileMD5Info.Size = new System.Drawing.Size(221, 13);
            this.txtFileMD5Info.TabIndex = 33;
            // 
            // lblGlobalFileIndex
            // 
            this.lblGlobalFileIndex.Location = new System.Drawing.Point(20, 139);
            this.lblGlobalFileIndex.Name = "lblGlobalFileIndex";
            this.lblGlobalFileIndex.Size = new System.Drawing.Size(88, 13);
            this.lblGlobalFileIndex.TabIndex = 30;
            this.lblGlobalFileIndex.Text = "Global File Index:";
            this.lblGlobalFileIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileGlobalIndexInfo
            // 
            this.txtFileGlobalIndexInfo.BackColor = System.Drawing.Color.White;
            this.txtFileGlobalIndexInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileGlobalIndexInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileGlobalIndexInfo.Location = new System.Drawing.Point(114, 139);
            this.txtFileGlobalIndexInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileGlobalIndexInfo.Name = "txtFileGlobalIndexInfo";
            this.txtFileGlobalIndexInfo.ReadOnly = true;
            this.txtFileGlobalIndexInfo.Size = new System.Drawing.Size(83, 13);
            this.txtFileGlobalIndexInfo.TabIndex = 31;
            // 
            // lblFileIndex
            // 
            this.lblFileIndex.Location = new System.Drawing.Point(20, 119);
            this.lblFileIndex.Name = "lblFileIndex";
            this.lblFileIndex.Size = new System.Drawing.Size(88, 13);
            this.lblFileIndex.TabIndex = 28;
            this.lblFileIndex.Text = "File Index:";
            this.lblFileIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileIndexInfo
            // 
            this.txtFileIndexInfo.BackColor = System.Drawing.Color.White;
            this.txtFileIndexInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileIndexInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileIndexInfo.Location = new System.Drawing.Point(114, 119);
            this.txtFileIndexInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileIndexInfo.Name = "txtFileIndexInfo";
            this.txtFileIndexInfo.ReadOnly = true;
            this.txtFileIndexInfo.Size = new System.Drawing.Size(83, 13);
            this.txtFileIndexInfo.TabIndex = 29;
            // 
            // lblFileMime
            // 
            this.lblFileMime.Location = new System.Drawing.Point(20, 159);
            this.lblFileMime.Name = "lblFileMime";
            this.lblFileMime.Size = new System.Drawing.Size(88, 13);
            this.lblFileMime.TabIndex = 26;
            this.lblFileMime.Text = "Mime Type:";
            this.lblFileMime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileMimeInfo
            // 
            this.txtFileMimeInfo.BackColor = System.Drawing.Color.White;
            this.txtFileMimeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileMimeInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileMimeInfo.Location = new System.Drawing.Point(114, 159);
            this.txtFileMimeInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileMimeInfo.Multiline = true;
            this.txtFileMimeInfo.Name = "txtFileMimeInfo";
            this.txtFileMimeInfo.ReadOnly = true;
            this.txtFileMimeInfo.Size = new System.Drawing.Size(280, 27);
            this.txtFileMimeInfo.TabIndex = 27;
            // 
            // txtFileCompressionTypeInfo
            // 
            this.txtFileCompressionTypeInfo.BackColor = System.Drawing.Color.White;
            this.txtFileCompressionTypeInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileCompressionTypeInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileCompressionTypeInfo.Location = new System.Drawing.Point(151, 226);
            this.txtFileCompressionTypeInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileCompressionTypeInfo.Name = "txtFileCompressionTypeInfo";
            this.txtFileCompressionTypeInfo.ReadOnly = true;
            this.txtFileCompressionTypeInfo.Size = new System.Drawing.Size(83, 13);
            this.txtFileCompressionTypeInfo.TabIndex = 25;
            // 
            // lblFileCompressionType
            // 
            this.lblFileCompressionType.Location = new System.Drawing.Point(3, 226);
            this.lblFileCompressionType.Name = "lblFileCompressionType";
            this.lblFileCompressionType.Size = new System.Drawing.Size(142, 13);
            this.lblFileCompressionType.TabIndex = 24;
            this.lblFileCompressionType.Text = "Compression type:";
            this.lblFileCompressionType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileCompression
            // 
            this.lblFileCompression.AutoSize = true;
            this.lblFileCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCompression.Location = new System.Drawing.Point(6, 203);
            this.lblFileCompression.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblFileCompression.Name = "lblFileCompression";
            this.lblFileCompression.Size = new System.Drawing.Size(78, 13);
            this.lblFileCompression.TabIndex = 14;
            this.lblFileCompression.Text = "Compression";
            // 
            // lblFileGeneral
            // 
            this.lblFileGeneral.AutoSize = true;
            this.lblFileGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileGeneral.Location = new System.Drawing.Point(6, 10);
            this.lblFileGeneral.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblFileGeneral.Name = "lblFileGeneral";
            this.lblFileGeneral.Size = new System.Drawing.Size(51, 13);
            this.lblFileGeneral.TabIndex = 13;
            this.lblFileGeneral.Text = "General";
            // 
            // txtFileDecompressedInfo
            // 
            this.txtFileDecompressedInfo.BackColor = System.Drawing.Color.White;
            this.txtFileDecompressedInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileDecompressedInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileDecompressedInfo.Location = new System.Drawing.Point(151, 266);
            this.txtFileDecompressedInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileDecompressedInfo.Name = "txtFileDecompressedInfo";
            this.txtFileDecompressedInfo.ReadOnly = true;
            this.txtFileDecompressedInfo.Size = new System.Drawing.Size(83, 13);
            this.txtFileDecompressedInfo.TabIndex = 12;
            // 
            // txtFileFileNameInfo
            // 
            this.txtFileFileNameInfo.BackColor = System.Drawing.Color.White;
            this.txtFileFileNameInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileFileNameInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileFileNameInfo.Location = new System.Drawing.Point(114, 28);
            this.txtFileFileNameInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileFileNameInfo.Multiline = true;
            this.txtFileFileNameInfo.Name = "txtFileFileNameInfo";
            this.txtFileFileNameInfo.ReadOnly = true;
            this.txtFileFileNameInfo.Size = new System.Drawing.Size(280, 24);
            this.txtFileFileNameInfo.TabIndex = 1;
            this.txtFileFileNameInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFileFileNameInfo_MouseClick);
            // 
            // lblFileDecompressed
            // 
            this.lblFileDecompressed.Location = new System.Drawing.Point(3, 266);
            this.lblFileDecompressed.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblFileDecompressed.Name = "lblFileDecompressed";
            this.lblFileDecompressed.Size = new System.Drawing.Size(142, 13);
            this.lblFileDecompressed.TabIndex = 11;
            this.lblFileDecompressed.Text = "Decompressed size:";
            this.lblFileDecompressed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileFileName
            // 
            this.lblFileFileName.Location = new System.Drawing.Point(3, 33);
            this.lblFileFileName.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblFileFileName.Name = "lblFileFileName";
            this.lblFileFileName.Size = new System.Drawing.Size(105, 13);
            this.lblFileFileName.TabIndex = 0;
            this.lblFileFileName.Text = "Filename:";
            this.lblFileFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileCompressedInfo
            // 
            this.txtFileCompressedInfo.BackColor = System.Drawing.Color.White;
            this.txtFileCompressedInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileCompressedInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileCompressedInfo.Location = new System.Drawing.Point(151, 246);
            this.txtFileCompressedInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileCompressedInfo.Name = "txtFileCompressedInfo";
            this.txtFileCompressedInfo.ReadOnly = true;
            this.txtFileCompressedInfo.Size = new System.Drawing.Size(83, 13);
            this.txtFileCompressedInfo.TabIndex = 10;
            // 
            // lblFileHash
            // 
            this.lblFileHash.Location = new System.Drawing.Point(3, 59);
            this.lblFileHash.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblFileHash.Name = "lblFileHash";
            this.lblFileHash.Size = new System.Drawing.Size(105, 13);
            this.lblFileHash.TabIndex = 2;
            this.lblFileHash.Text = "Hash:";
            this.lblFileHash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileCompressed
            // 
            this.lblFileCompressed.Location = new System.Drawing.Point(3, 246);
            this.lblFileCompressed.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lblFileCompressed.Name = "lblFileCompressed";
            this.lblFileCompressed.Size = new System.Drawing.Size(142, 13);
            this.lblFileCompressed.TabIndex = 9;
            this.lblFileCompressed.Text = "Compressed size:";
            this.lblFileCompressed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileHashInfo
            // 
            this.txtFileHashInfo.BackColor = System.Drawing.Color.White;
            this.txtFileHashInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileHashInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileHashInfo.Location = new System.Drawing.Point(114, 59);
            this.txtFileHashInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileHashInfo.Name = "txtFileHashInfo";
            this.txtFileHashInfo.ReadOnly = true;
            this.txtFileHashInfo.Size = new System.Drawing.Size(120, 13);
            this.txtFileHashInfo.TabIndex = 3;
            // 
            // lblFileDataHash
            // 
            this.lblFileDataHash.Location = new System.Drawing.Point(20, 79);
            this.lblFileDataHash.Name = "lblFileDataHash";
            this.lblFileDataHash.Size = new System.Drawing.Size(88, 13);
            this.lblFileDataHash.TabIndex = 4;
            this.lblFileDataHash.Text = "Data hash:";
            this.lblFileDataHash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFileDataHashInfo
            // 
            this.txtFileDataHashInfo.BackColor = System.Drawing.Color.White;
            this.txtFileDataHashInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileDataHashInfo.ContextMenuStrip = this.mnuCopy;
            this.txtFileDataHashInfo.Location = new System.Drawing.Point(114, 79);
            this.txtFileDataHashInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.txtFileDataHashInfo.Name = "txtFileDataHashInfo";
            this.txtFileDataHashInfo.ReadOnly = true;
            this.txtFileDataHashInfo.Size = new System.Drawing.Size(120, 13);
            this.txtFileDataHashInfo.TabIndex = 5;
            // 
            // tabPreview
            // 
            this.tabPreview.BackColor = System.Drawing.SystemColors.Control;
            this.tabPreview.Controls.Add(this.pnlImagePreview);
            this.tabPreview.Controls.Add(this.txtPreview);
            this.tabPreview.Controls.Add(this.dgvPreview);
            this.tabPreview.Location = new System.Drawing.Point(4, 22);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreview.Size = new System.Drawing.Size(400, 330);
            this.tabPreview.TabIndex = 3;
            this.tabPreview.Text = "Preview";
            // 
            // pnlImagePreview
            // 
            this.pnlImagePreview.AutoScroll = true;
            this.pnlImagePreview.Controls.Add(this.picPreview);
            this.pnlImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagePreview.Location = new System.Drawing.Point(3, 3);
            this.pnlImagePreview.Name = "pnlImagePreview";
            this.pnlImagePreview.Size = new System.Drawing.Size(394, 324);
            this.pnlImagePreview.TabIndex = 3;
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(100, 50);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPreview.TabIndex = 1;
            this.picPreview.TabStop = false;
            // 
            // txtPreview
            // 
            this.txtPreview.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtPreview.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
            this.txtPreview.AutoScrollMinSize = new System.Drawing.Size(154, 14);
            this.txtPreview.BackBrush = null;
            this.txtPreview.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.txtPreview.CharHeight = 14;
            this.txtPreview.CharWidth = 8;
            this.txtPreview.CommentPrefix = "--";
            this.txtPreview.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPreview.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtPreview.IsReplaceMode = false;
            this.txtPreview.Language = FastColoredTextBoxNS.Language.Lua;
            this.txtPreview.LeftBracket = '(';
            this.txtPreview.LeftBracket2 = '{';
            this.txtPreview.Location = new System.Drawing.Point(3, 3);
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Paddings = new System.Windows.Forms.Padding(0);
            this.txtPreview.RightBracket = ')';
            this.txtPreview.RightBracket2 = '}';
            this.txtPreview.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtPreview.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtPreview.ServiceColors")));
            this.txtPreview.Size = new System.Drawing.Size(394, 324);
            this.txtPreview.TabIndex = 0;
            this.txtPreview.Text = "fastColoredTextBox1";
            this.txtPreview.Zoom = 100;
            // 
            // dgvPreview
            // 
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(3, 3);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.Size = new System.Drawing.Size(394, 324);
            this.dgvPreview.TabIndex = 2;
            // 
            // GeneralLabel
            // 
            this.GeneralLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralLabel.Location = new System.Drawing.Point(6, 26);
            this.GeneralLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.GeneralLabel.Name = "GeneralLabel";
            this.GeneralLabel.Size = new System.Drawing.Size(309, 13);
            this.GeneralLabel.TabIndex = 13;
            this.GeneralLabel.Text = "General";
            // 
            // UncompressedInfo
            // 
            this.UncompressedInfo.BackColor = System.Drawing.Color.White;
            this.UncompressedInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UncompressedInfo.ContextMenuStrip = this.mnuCopy;
            this.UncompressedInfo.Location = new System.Drawing.Point(93, 146);
            this.UncompressedInfo.Name = "UncompressedInfo";
            this.UncompressedInfo.ReadOnly = true;
            this.UncompressedInfo.Size = new System.Drawing.Size(60, 13);
            this.UncompressedInfo.TabIndex = 12;
            this.UncompressedInfo.Text = "999 KB";
            // 
            // UncompressedLabel
            // 
            this.UncompressedLabel.AutoSize = true;
            this.UncompressedLabel.Location = new System.Drawing.Point(6, 146);
            this.UncompressedLabel.Margin = new System.Windows.Forms.Padding(30, 8, 3, 0);
            this.UncompressedLabel.Name = "UncompressedLabel";
            this.UncompressedLabel.Size = new System.Drawing.Size(81, 13);
            this.UncompressedLabel.TabIndex = 11;
            this.UncompressedLabel.Text = "Uncompressed:";
            // 
            // CompressedInfo
            // 
            this.CompressedInfo.BackColor = System.Drawing.Color.White;
            this.CompressedInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CompressedInfo.ContextMenuStrip = this.mnuCopy;
            this.CompressedInfo.Location = new System.Drawing.Point(93, 125);
            this.CompressedInfo.Name = "CompressedInfo";
            this.CompressedInfo.ReadOnly = true;
            this.CompressedInfo.Size = new System.Drawing.Size(60, 13);
            this.CompressedInfo.TabIndex = 10;
            this.CompressedInfo.Text = "999 KB";
            // 
            // CompressedLabel
            // 
            this.CompressedLabel.AutoSize = true;
            this.CompressedLabel.Location = new System.Drawing.Point(6, 125);
            this.CompressedLabel.Margin = new System.Windows.Forms.Padding(30, 8, 3, 0);
            this.CompressedLabel.Name = "CompressedLabel";
            this.CompressedLabel.Size = new System.Drawing.Size(68, 13);
            this.CompressedLabel.TabIndex = 9;
            this.CompressedLabel.Text = "Compressed:";
            // 
            // SizesLabel
            // 
            this.SizesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizesLabel.Location = new System.Drawing.Point(6, 104);
            this.SizesLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.SizesLabel.Name = "SizesLabel";
            this.SizesLabel.Size = new System.Drawing.Size(309, 13);
            this.SizesLabel.TabIndex = 8;
            this.SizesLabel.Text = "Sizes";
            // 
            // DataOffsetInfo
            // 
            this.DataOffsetInfo.BackColor = System.Drawing.Color.White;
            this.DataOffsetInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataOffsetInfo.ContextMenuStrip = this.mnuCopy;
            this.DataOffsetInfo.Location = new System.Drawing.Point(93, 218);
            this.DataOffsetInfo.Name = "DataOffsetInfo";
            this.DataOffsetInfo.ReadOnly = true;
            this.DataOffsetInfo.Size = new System.Drawing.Size(36, 13);
            this.DataOffsetInfo.TabIndex = 7;
            this.DataOffsetInfo.Text = "ADAS";
            // 
            // DataOffsetLabel
            // 
            this.DataOffsetLabel.AutoSize = true;
            this.DataOffsetLabel.Location = new System.Drawing.Point(6, 218);
            this.DataOffsetLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.DataOffsetLabel.Name = "DataOffsetLabel";
            this.DataOffsetLabel.Size = new System.Drawing.Size(62, 13);
            this.DataOffsetLabel.TabIndex = 6;
            this.DataOffsetLabel.Text = "Data offset:";
            // 
            // UnknownInfo
            // 
            this.UnknownInfo.BackColor = System.Drawing.Color.White;
            this.UnknownInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UnknownInfo.ContextMenuStrip = this.mnuCopy;
            this.UnknownInfo.Location = new System.Drawing.Point(239, 81);
            this.UnknownInfo.Name = "UnknownInfo";
            this.UnknownInfo.ReadOnly = true;
            this.UnknownInfo.Size = new System.Drawing.Size(76, 13);
            this.UnknownInfo.TabIndex = 5;
            this.UnknownInfo.Text = "B307A07F";
            // 
            // UnknownLabel
            // 
            this.UnknownLabel.AutoSize = true;
            this.UnknownLabel.Location = new System.Drawing.Point(177, 81);
            this.UnknownLabel.Name = "UnknownLabel";
            this.UnknownLabel.Size = new System.Drawing.Size(56, 13);
            this.UnknownLabel.TabIndex = 4;
            this.UnknownLabel.Text = "Unknown:";
            // 
            // HashInfo
            // 
            this.HashInfo.BackColor = System.Drawing.Color.White;
            this.HashInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HashInfo.ContextMenuStrip = this.mnuCopy;
            this.HashInfo.Location = new System.Drawing.Point(64, 81);
            this.HashInfo.Name = "HashInfo";
            this.HashInfo.ReadOnly = true;
            this.HashInfo.Size = new System.Drawing.Size(107, 13);
            this.HashInfo.TabIndex = 3;
            this.HashInfo.Text = "897E9F7AB307A07F";
            // 
            // HashLabel
            // 
            this.HashLabel.AutoSize = true;
            this.HashLabel.Location = new System.Drawing.Point(6, 81);
            this.HashLabel.Name = "HashLabel";
            this.HashLabel.Size = new System.Drawing.Size(35, 13);
            this.HashLabel.TabIndex = 2;
            this.HashLabel.Text = "Hash:";
            // 
            // FilenameInfo
            // 
            this.FilenameInfo.BackColor = System.Drawing.Color.White;
            this.FilenameInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilenameInfo.ContextMenuStrip = this.mnuCopy;
            this.FilenameInfo.Location = new System.Drawing.Point(64, 47);
            this.FilenameInfo.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.FilenameInfo.Name = "FilenameInfo";
            this.FilenameInfo.ReadOnly = true;
            this.FilenameInfo.Size = new System.Drawing.Size(251, 13);
            this.FilenameInfo.TabIndex = 1;
            this.FilenameInfo.Text = "data/interface/interfacecore/fonts/neuehammerunzialeltstd.ttf";
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Location = new System.Drawing.Point(6, 47);
            this.FilenameLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(52, 13);
            this.FilenameLabel.TabIndex = 0;
            this.FilenameLabel.Text = "Filename:";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBox.Location = new System.Drawing.Point(401, 439);
            this.txtSearchBox.MaxLength = 256;
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(381, 20);
            this.txtSearchBox.TabIndex = 9;
            this.txtSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // SelectFolder
            // 
            this.SelectFolder.Description = "Select Folder";
            this.SelectFolder.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            // 
            // MenuToolStrip
            // 
            this.MenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnClose,
            this.FileSeparator,
            this.btnOpenDictionary,
            this.btnMergeDictionary,
            this.btnSaveDictionary,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnAddFolder,
            this.btnRemove,
            this.btnReplace,
            this.btnReplaceFolder,
            this.btnUnpack,
            this.btnStopSearch,
            this.btnBruteSearch,
            this.btnFolderSearch});
            this.MenuToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MenuToolStrip.Name = "MenuToolStrip";
            this.MenuToolStrip.Size = new System.Drawing.Size(794, 25);
            this.MenuToolStrip.TabIndex = 12;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::Mythic.Package.Editor.Properties.Resources.New;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Click += new System.EventHandler(this.MainMenuFileNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Click += new System.EventHandler(this.MainMenuFileOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Click += new System.EventHandler(this.MainMenuFileSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Click += new System.EventHandler(this.MainMenuFileClose_Click);
            // 
            // FileSeparator
            // 
            this.FileSeparator.Name = "FileSeparator";
            this.FileSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenDictionary
            // 
            this.btnOpenDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.OpenDictionary;
            this.btnOpenDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDictionary.Name = "btnOpenDictionary";
            this.btnOpenDictionary.Size = new System.Drawing.Size(23, 22);
            this.btnOpenDictionary.Click += new System.EventHandler(this.MainMenuDictionaryLoad_Click);
            // 
            // btnMergeDictionary
            // 
            this.btnMergeDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMergeDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.MergeDictionary;
            this.btnMergeDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMergeDictionary.Name = "btnMergeDictionary";
            this.btnMergeDictionary.Size = new System.Drawing.Size(23, 22);
            this.btnMergeDictionary.Click += new System.EventHandler(this.MainMenuDictionaryMerge_Click);
            // 
            // btnSaveDictionary
            // 
            this.btnSaveDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.SaveDictionary;
            this.btnSaveDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDictionary.Name = "btnSaveDictionary";
            this.btnSaveDictionary.Size = new System.Drawing.Size(23, 22);
            this.btnSaveDictionary.Click += new System.EventHandler(this.MainMenuDictionarySave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFolder.Image = global::Mythic.Package.Editor.Properties.Resources.AddFolder;
            this.btnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(23, 22);
            this.btnAddFolder.Click += new System.EventHandler(this.ButtonAddFolder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemove.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 22);
            this.btnRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplace.Image = global::Mythic.Package.Editor.Properties.Resources.Replace;
            this.btnReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(23, 22);
            this.btnReplace.Click += new System.EventHandler(this.ButtonReplace_Click);
            // 
            // btnReplaceFolder
            // 
            this.btnReplaceFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplaceFolder.Image = global::Mythic.Package.Editor.Properties.Resources.Replacefolder;
            this.btnReplaceFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplaceFolder.Name = "btnReplaceFolder";
            this.btnReplaceFolder.Size = new System.Drawing.Size(23, 22);
            this.btnReplaceFolder.Click += new System.EventHandler(this.ButtonReplaceFolder_Click);
            // 
            // btnUnpack
            // 
            this.btnUnpack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnpack.Image = global::Mythic.Package.Editor.Properties.Resources.Unpack;
            this.btnUnpack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnpack.Name = "btnUnpack";
            this.btnUnpack.Size = new System.Drawing.Size(23, 22);
            this.btnUnpack.Click += new System.EventHandler(this.ButtonUnpack_Click);
            // 
            // btnStopSearch
            // 
            this.btnStopSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnStopSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopSearch.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnStopSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopSearch.Name = "btnStopSearch";
            this.btnStopSearch.Size = new System.Drawing.Size(23, 22);
            this.btnStopSearch.Text = "toolStripButton1";
            this.btnStopSearch.Click += new System.EventHandler(this.BtnStopSearch_Click);
            // 
            // btnBruteSearch
            // 
            this.btnBruteSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBruteSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBruteSearch.Image = global::Mythic.Package.Editor.Properties.Resources.Wrench;
            this.btnBruteSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBruteSearch.Name = "btnBruteSearch";
            this.btnBruteSearch.Size = new System.Drawing.Size(23, 22);
            this.btnBruteSearch.Text = "toolStripButton1";
            this.btnBruteSearch.Click += new System.EventHandler(this.btnBruteSearch_Click);
            // 
            // btnFolderSearch
            // 
            this.btnFolderSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFolderSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFolderSearch.Image = global::Mythic.Package.Editor.Properties.Resources.SearchFolder;
            this.btnFolderSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFolderSearch.Name = "btnFolderSearch";
            this.btnFolderSearch.Size = new System.Drawing.Size(23, 22);
            this.btnFolderSearch.Text = "toolStripButton1";
            this.btnFolderSearch.Click += new System.EventHandler(this.btnFolderSearch_Click);
            // 
            // ErrorTooltip
            // 
            this.ErrorTooltip.IsBalloon = true;
            this.ErrorTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // Help
            // 
            this.Help.HelpNamespace = "C:\\Documents and Settings\\Administrator\\My Documents\\Visual Studio 2008\\Projects\\" +
    "Mythic\\Mythic.Package.Editor\\Help.chm";
            // 
            // btnSearchText
            // 
            this.btnSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchText.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchText.Image")));
            this.btnSearchText.Location = new System.Drawing.Point(374, 410);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(65, 24);
            this.btnSearchText.TabIndex = 7;
            this.btnSearchText.Text = "Search";
            this.btnSearchText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.btnSearchText, "Search for a specific file name.");
            this.btnSearchText.UseVisualStyleBackColor = true;
            this.btnSearchText.Click += new System.EventHandler(this.Search_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearSearch.Enabled = false;
            this.btnClearSearch.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnClearSearch.Location = new System.Drawing.Point(374, 439);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(24, 20);
            this.btnClearSearch.TabIndex = 17;
            this.btnClearSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.btnClearSearch, "Stop the current search.");
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // tmrUIUpdate
            // 
            this.tmrUIUpdate.Enabled = true;
            this.tmrUIUpdate.Tick += new System.EventHandler(this.tmrUIUpdate_Tick);
            // 
            // lblImageFormat
            // 
            this.lblImageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageFormat.Location = new System.Drawing.Point(381, 377);
            this.lblImageFormat.Name = "lblImageFormat";
            this.lblImageFormat.Size = new System.Drawing.Size(394, 23);
            this.lblImageFormat.TabIndex = 2;
            this.lblImageFormat.Text = "Image Format";
            this.lblImageFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 485);
            this.Controls.Add(this.lblImageFormat);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.MenuToolStrip);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.tabsData);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.btnSearchText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 517);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mythic Package Editor";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.mnuCopy.ResumeLayout(false);
            this.tabsData.ResumeLayout(false);
            this.tabDetailsPackage.ResumeLayout(false);
            this.tabDetailsPackage.PerformLayout();
            this.tabDetailsBlock.ResumeLayout(false);
            this.tabDetailsBlock.PerformLayout();
            this.tabDetailsFile.ResumeLayout(false);
            this.tabDetailsFile.PerformLayout();
            this.tabPreview.ResumeLayout(false);
            this.pnlImagePreview.ResumeLayout(false);
            this.pnlImagePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.MenuToolStrip.ResumeLayout(false);
            this.MenuToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFile;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileOpen;
		private System.Windows.Forms.ToolStripSeparator MainMenuFileSeparator;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileExit;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.TreeView TreeView;
		private System.Windows.Forms.ListBox ListBox;
		private System.Windows.Forms.StatusStrip Status;
		private System.ComponentModel.BackgroundWorker Worker;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.Button btnSearchText;
		private System.Windows.Forms.ContextMenuStrip mnuCopy;
		private System.Windows.Forms.ToolStripMenuItem CopyMenuStripButton;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionary;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryUpdate;
		private System.Windows.Forms.TabControl tabsData;
		private System.Windows.Forms.TabPage tabDetailsPackage;
		private System.Windows.Forms.TabPage tabDetailsBlock;
		private System.Windows.Forms.TabPage tabDetailsFile;
		private System.Windows.Forms.TextBox txtFileDecompressedInfo;
		private System.Windows.Forms.Label lblFileDecompressed;
		private System.Windows.Forms.TextBox txtFileCompressedInfo;
		private System.Windows.Forms.Label lblFileCompressed;
		private System.Windows.Forms.TextBox txtFileDataHashInfo;
		private System.Windows.Forms.Label lblFileDataHash;
		private System.Windows.Forms.TextBox txtFileHashInfo;
		private System.Windows.Forms.Label lblFileHash;
		private System.Windows.Forms.TextBox txtFileFileNameInfo;
		private System.Windows.Forms.Label lblFileFileName;
		private System.Windows.Forms.Label GeneralLabel;
		private System.Windows.Forms.TextBox UncompressedInfo;
		private System.Windows.Forms.Label UncompressedLabel;
		private System.Windows.Forms.TextBox CompressedInfo;
		private System.Windows.Forms.Label CompressedLabel;
		private System.Windows.Forms.Label SizesLabel;
		private System.Windows.Forms.TextBox DataOffsetInfo;
		private System.Windows.Forms.Label DataOffsetLabel;
		private System.Windows.Forms.TextBox UnknownInfo;
		private System.Windows.Forms.Label UnknownLabel;
		private System.Windows.Forms.TextBox HashInfo;
		private System.Windows.Forms.Label HashLabel;
		private System.Windows.Forms.TextBox FilenameInfo;
		private System.Windows.Forms.Label FilenameLabel;
		private System.Windows.Forms.Label lblPackageHeader;
		private System.Windows.Forms.Label lblPackageVersion;
		private System.Windows.Forms.TextBox txtPackageVersionInfo;
		private System.Windows.Forms.Label lblPackageMisc;
		private System.Windows.Forms.TextBox txtPackageMiscInfo;
		private System.Windows.Forms.Label lblPackageHeaderSize;
		private System.Windows.Forms.TextBox txtPackageHeaderSizeInfo;
		private System.Windows.Forms.TextBox txtPackageBlockSizeInfo;
		private System.Windows.Forms.Label lblPackageBlockSize;
		private System.Windows.Forms.Label lblPackageFileCount;
		private System.Windows.Forms.TextBox txtPackageFileCountInfo;
		private System.Windows.Forms.Label lblPackageGeneral;
		private System.Windows.Forms.Label lblPackageFullName;
		private System.Windows.Forms.TextBox txtPackageFullNameInfo;
		private System.Windows.Forms.TextBox txtPackageAttributesInfo;
		private System.Windows.Forms.Label lblPackageAttributes;
		private System.Windows.Forms.Label lblPackageCreation;
		private System.Windows.Forms.TextBox txtPackageCreationInfo;
		private System.Windows.Forms.Label lblPackageSize;
		private System.Windows.Forms.TextBox txtPackageSizeInfo;
		private System.Windows.Forms.Label lblBlockHeader;
		private System.Windows.Forms.TextBox txtBlockFileCountInfo;
		private System.Windows.Forms.Label lblBlockFileCount;
		private System.Windows.Forms.TextBox txtBlockNextBlockInfo;
		private System.Windows.Forms.Label lblBlockNextBlock;
		private System.Windows.Forms.Label lblFileGeneral;
		private System.Windows.Forms.Label lblFileCompression;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyStart;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyAttach;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySave;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyDetach;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileClose;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryLoad;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryMerge;
		private System.Windows.Forms.TextBox txtSearchBox;
		private System.Windows.Forms.ToolStripSeparator MainMenuDictionarySeparator;
		private System.Windows.Forms.FolderBrowserDialog SelectFolder;
		private System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
		private System.Windows.Forms.Label lblFileCompressionType;
		private System.Windows.Forms.TextBox txtFileCompressionTypeInfo;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileSave;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileNew;
		private System.Windows.Forms.ToolStripMenuItem MainMenuHelpAbout;
		private System.Windows.Forms.SaveFileDialog SaveFileDialog;
		private System.Windows.Forms.ToolStripProgressBar StatusProgressBar;
		private Mythic.Package.Editor.SelectProcess SelectProcess;
		private Mythic.Package.Editor.AddFile AddFile;
		private Mythic.Package.Editor.FolderSearch FolderSearch;
        private Mythic.Package.Editor.AddFolder AddFolder;
		private Mythic.Package.Editor.About About;
		private Mythic.Package.Editor.SettingsDialog Settings;
		private System.Windows.Forms.ToolStrip MenuToolStrip;
		private System.Windows.Forms.ToolStripButton btnNew;
		private System.Windows.Forms.ToolStripButton btnOpen;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnClose;
		private System.Windows.Forms.ToolStripSeparator FileSeparator;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnRemove;
		private System.Windows.Forms.ToolStripButton btnUnpack;
		private System.Windows.Forms.ToolStripButton btnOpenDictionary;
		private System.Windows.Forms.ToolStripButton btnSaveDictionary;
		private System.Windows.Forms.ToolStripButton btnMergeDictionary;
		private System.Windows.Forms.ToolTip ErrorTooltip;
		private System.Windows.Forms.ToolStripMenuItem MainMenuEdit;
		private System.Windows.Forms.ToolStripMenuItem MainMenuEditSettings;
		private System.Windows.Forms.ToolStripButton btnReplace;
		private System.Windows.Forms.ToolStripMenuItem MainMenuHelpContent;
		private System.Windows.Forms.HelpProvider Help;
		private System.Windows.Forms.Button btnFileUnset;
		private System.Windows.Forms.ToolStripButton btnAddFolder;
        private System.Windows.Forms.ToolStripButton btnReplaceFolder;
        private System.Windows.Forms.ToolTip ttpButtons;
        private System.Windows.Forms.Label lblFileMime;
        private System.Windows.Forms.TextBox txtFileMimeInfo;
        private System.Windows.Forms.Label lblFileIndex;
        private System.Windows.Forms.TextBox txtFileIndexInfo;
        private System.Windows.Forms.Label lblGlobalFileIndex;
        private System.Windows.Forms.TextBox txtFileGlobalIndexInfo;
        private System.Windows.Forms.TextBox txtBlockIndexInfo;
        private System.Windows.Forms.Label lblBlockIndex;
        private System.Windows.Forms.Label lblMD5;
        private System.Windows.Forms.TextBox txtFileMD5Info;
        private System.Windows.Forms.TabPage tabPreview;
        private FastColoredTextBoxNS.FastColoredTextBox txtPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer tmrUIUpdate;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Panel pnlImagePreview;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ToolStripButton btnStopSearch;
        private System.Windows.Forms.ToolStripButton btnBruteSearch;
        private System.Windows.Forms.ToolStripButton btnFolderSearch;
        private System.Windows.Forms.ToolStripSplitButton btnShowLog;
        private System.Windows.Forms.TextBox txtUnnamedFilesInfo;
        private System.Windows.Forms.Label lblUnnamedFiles;
        private System.Windows.Forms.Label lblImageFormat;
    }
}

