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
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnMessageIcon = new System.Windows.Forms.ToolStripDropDownButton();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.CopyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyMenuStripButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FileDetails = new System.Windows.Forms.TabControl();
            this.DetailsPackage = new System.Windows.Forms.TabPage();
            this.PackageSizeInfo = new System.Windows.Forms.Label();
            this.PackageSizeLabel = new System.Windows.Forms.Label();
            this.PackageCreationInfo = new System.Windows.Forms.Label();
            this.PackageCreationLabel = new System.Windows.Forms.Label();
            this.PackageAttributesInfo = new System.Windows.Forms.Label();
            this.PackageAttributesLabel = new System.Windows.Forms.Label();
            this.PackageFullNameInfo = new System.Windows.Forms.Label();
            this.PackageFullNameLabel = new System.Windows.Forms.Label();
            this.PackageGeneralLabel = new System.Windows.Forms.Label();
            this.PackageFileCountInfo = new System.Windows.Forms.Label();
            this.PackageFileCountLabel = new System.Windows.Forms.Label();
            this.PackageBlockSizeInfo = new System.Windows.Forms.Label();
            this.PackageBlockSizeLabel = new System.Windows.Forms.Label();
            this.PackageHeaderSizeInfo = new System.Windows.Forms.Label();
            this.PackageHeaderSizeLabel = new System.Windows.Forms.Label();
            this.PackageMiscInfo = new System.Windows.Forms.Label();
            this.PackageMiscLabel = new System.Windows.Forms.Label();
            this.PackageVersionInfo = new System.Windows.Forms.Label();
            this.PackageVersionLabel = new System.Windows.Forms.Label();
            this.PackageHeader = new System.Windows.Forms.Label();
            this.DetailsBlock = new System.Windows.Forms.TabPage();
            this.BlockNextBlockInfo = new System.Windows.Forms.Label();
            this.BlockNextBlockLabel = new System.Windows.Forms.Label();
            this.BlockHeader = new System.Windows.Forms.Label();
            this.BlockFileCountInfo = new System.Windows.Forms.Label();
            this.BlockFileCountLabel = new System.Windows.Forms.Label();
            this.DetailsFile = new System.Windows.Forms.TabPage();
            this.FileMimeLabel = new System.Windows.Forms.Label();
            this.FileMimeInfo = new System.Windows.Forms.Label();
            this.FileUnsetButton = new System.Windows.Forms.Button();
            this.FileCompressionTypeInfo = new System.Windows.Forms.Label();
            this.FileCompressionTypeLabel = new System.Windows.Forms.Label();
            this.FileCompression = new System.Windows.Forms.Label();
            this.FileGeneral = new System.Windows.Forms.Label();
            this.FileDecompressedInfo = new System.Windows.Forms.Label();
            this.FileFileNameInfo = new System.Windows.Forms.Label();
            this.FileDecompressedLabel = new System.Windows.Forms.Label();
            this.FileFileNameLabel = new System.Windows.Forms.Label();
            this.FileCompressedInfo = new System.Windows.Forms.Label();
            this.FileHashLabel = new System.Windows.Forms.Label();
            this.FileCompressedLabel = new System.Windows.Forms.Label();
            this.FileHashInfo = new System.Windows.Forms.Label();
            this.FileDataHashLabel = new System.Windows.Forms.Label();
            this.FileDataHashInfo = new System.Windows.Forms.Label();
            this.GeneralLabel = new System.Windows.Forms.Label();
            this.UncompressedInfo = new System.Windows.Forms.Label();
            this.UncompressedLabel = new System.Windows.Forms.Label();
            this.CompressedInfo = new System.Windows.Forms.Label();
            this.CompressedLabel = new System.Windows.Forms.Label();
            this.SizesLabel = new System.Windows.Forms.Label();
            this.DataOffsetInfo = new System.Windows.Forms.Label();
            this.DataOffsetLabel = new System.Windows.Forms.Label();
            this.UnknownInfo = new System.Windows.Forms.Label();
            this.UnknownLabel = new System.Windows.Forms.Label();
            this.HashInfo = new System.Windows.Forms.Label();
            this.HashLabel = new System.Windows.Forms.Label();
            this.FilenameInfo = new System.Windows.Forms.Label();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuToolStrip = new System.Windows.Forms.ToolStrip();
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.ButtonSave = new System.Windows.Forms.ToolStripButton();
            this.ButtonClose = new System.Windows.Forms.ToolStripButton();
            this.FileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonOpenDictionary = new System.Windows.Forms.ToolStripButton();
            this.ButtonSaveDictionary = new System.Windows.Forms.ToolStripButton();
            this.ButtonMergeDictionary = new System.Windows.Forms.ToolStripButton();
            this.DictionarySeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.ButtonAddFolder = new System.Windows.Forms.ToolStripButton();
            this.ButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.ButtonUnpack = new System.Windows.Forms.ToolStripButton();
            this.ButtonReplace = new System.Windows.Forms.ToolStripButton();
            this.ButtonReplaceFolder = new System.Windows.Forms.ToolStripButton();
            this.ErrorTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.Help = new System.Windows.Forms.HelpProvider();
            this.btnStopSearch = new System.Windows.Forms.Button();
            this.btnBrute = new System.Windows.Forms.Button();
            this.FolderFiles = new System.Windows.Forms.Button();
            this.SearchHash = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.txtLeadZeroes = new System.Windows.Forms.NumericUpDown();
            this.ttpButtons = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu.SuspendLayout();
            this.Status.SuspendLayout();
            this.CopyMenuStrip.SuspendLayout();
            this.FileDetails.SuspendLayout();
            this.DetailsPackage.SuspendLayout();
            this.DetailsBlock.SuspendLayout();
            this.DetailsFile.SuspendLayout();
            this.MenuToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadZeroes)).BeginInit();
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
            this.MainMenuFileNew.Size = new System.Drawing.Size(154, 22);
            this.MainMenuFileNew.Text = "New";
            this.MainMenuFileNew.Click += new System.EventHandler(this.MainMenuFileNew_Click);
            // 
            // MainMenuFileOpen
            // 
            this.MainMenuFileOpen.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileOpen.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.MainMenuFileOpen.Name = "MainMenuFileOpen";
            this.MainMenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MainMenuFileOpen.Size = new System.Drawing.Size(154, 22);
            this.MainMenuFileOpen.Text = "Open";
            this.MainMenuFileOpen.Click += new System.EventHandler(this.MainMenuFileOpen_Click);
            // 
            // MainMenuFileSave
            // 
            this.MainMenuFileSave.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuFileSave.Image")));
            this.MainMenuFileSave.Name = "MainMenuFileSave";
            this.MainMenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MainMenuFileSave.Size = new System.Drawing.Size(154, 22);
            this.MainMenuFileSave.Text = "Save";
            this.MainMenuFileSave.Click += new System.EventHandler(this.MainMenuFileSave_Click);
            // 
            // MainMenuFileClose
            // 
            this.MainMenuFileClose.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileClose.Image = ((System.Drawing.Image)(resources.GetObject("MainMenuFileClose.Image")));
            this.MainMenuFileClose.Name = "MainMenuFileClose";
            this.MainMenuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MainMenuFileClose.Size = new System.Drawing.Size(154, 22);
            this.MainMenuFileClose.Text = "Close";
            this.MainMenuFileClose.Click += new System.EventHandler(this.MainMenuFileClose_Click);
            // 
            // MainMenuFileSeparator
            // 
            this.MainMenuFileSeparator.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileSeparator.Name = "MainMenuFileSeparator";
            this.MainMenuFileSeparator.Size = new System.Drawing.Size(151, 6);
            // 
            // MainMenuFileExit
            // 
            this.MainMenuFileExit.ForeColor = System.Drawing.Color.Black;
            this.MainMenuFileExit.Name = "MainMenuFileExit";
            this.MainMenuFileExit.Size = new System.Drawing.Size(154, 22);
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
            this.TreeView.Location = new System.Drawing.Point(12, 52);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(150, 408);
            this.TreeView.TabIndex = 1;
            this.TreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView_BeforeSelect);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TreeView_KeyPress);
            // 
            // ListBox
            // 
            this.ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(168, 52);
            this.ListBox.Name = "ListBox";
            this.ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox.Size = new System.Drawing.Size(200, 407);
            this.ListBox.TabIndex = 2;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            this.ListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListBox_KeyPress);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusProgressBar,
            this.StatusLabel,
            this.btnMessageIcon});
            this.Status.Location = new System.Drawing.Point(0, 463);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(794, 22);
            this.Status.TabIndex = 4;
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Margin = new System.Windows.Forms.Padding(10, 3, 1, 3);
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
            // btnMessageIcon
            // 
            this.btnMessageIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMessageIcon.Image = global::Mythic.Package.Editor.Properties.Resources.Information;
            this.btnMessageIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMessageIcon.Name = "btnMessageIcon";
            this.btnMessageIcon.Size = new System.Drawing.Size(29, 20);
            this.btnMessageIcon.Text = "toolStripDropDownButton1";
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // CopyMenuStrip
            // 
            this.CopyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMenuStripButton});
            this.CopyMenuStrip.Name = "CopyMenuStrip";
            this.CopyMenuStrip.ShowImageMargin = false;
            this.CopyMenuStrip.Size = new System.Drawing.Size(147, 26);
            // 
            // CopyMenuStripButton
            // 
            this.CopyMenuStripButton.ForeColor = System.Drawing.Color.Black;
            this.CopyMenuStripButton.Name = "CopyMenuStripButton";
            this.CopyMenuStripButton.Size = new System.Drawing.Size(146, 22);
            this.CopyMenuStripButton.Text = "Copy to Clipboard";
            this.CopyMenuStripButton.Click += new System.EventHandler(this.CopyMenuStripButton_Click);
            // 
            // FileDetails
            // 
            this.FileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDetails.Controls.Add(this.DetailsPackage);
            this.FileDetails.Controls.Add(this.DetailsBlock);
            this.FileDetails.Controls.Add(this.DetailsFile);
            this.FileDetails.Location = new System.Drawing.Point(374, 52);
            this.FileDetails.Name = "FileDetails";
            this.FileDetails.Padding = new System.Drawing.Point(10, 3);
            this.FileDetails.SelectedIndex = 0;
            this.FileDetails.Size = new System.Drawing.Size(408, 356);
            this.FileDetails.TabIndex = 8;
            // 
            // DetailsPackage
            // 
            this.DetailsPackage.BackColor = System.Drawing.SystemColors.Control;
            this.DetailsPackage.Controls.Add(this.PackageSizeInfo);
            this.DetailsPackage.Controls.Add(this.PackageSizeLabel);
            this.DetailsPackage.Controls.Add(this.PackageCreationInfo);
            this.DetailsPackage.Controls.Add(this.PackageCreationLabel);
            this.DetailsPackage.Controls.Add(this.PackageAttributesInfo);
            this.DetailsPackage.Controls.Add(this.PackageAttributesLabel);
            this.DetailsPackage.Controls.Add(this.PackageFullNameInfo);
            this.DetailsPackage.Controls.Add(this.PackageFullNameLabel);
            this.DetailsPackage.Controls.Add(this.PackageGeneralLabel);
            this.DetailsPackage.Controls.Add(this.PackageFileCountInfo);
            this.DetailsPackage.Controls.Add(this.PackageFileCountLabel);
            this.DetailsPackage.Controls.Add(this.PackageBlockSizeInfo);
            this.DetailsPackage.Controls.Add(this.PackageBlockSizeLabel);
            this.DetailsPackage.Controls.Add(this.PackageHeaderSizeInfo);
            this.DetailsPackage.Controls.Add(this.PackageHeaderSizeLabel);
            this.DetailsPackage.Controls.Add(this.PackageMiscInfo);
            this.DetailsPackage.Controls.Add(this.PackageMiscLabel);
            this.DetailsPackage.Controls.Add(this.PackageVersionInfo);
            this.DetailsPackage.Controls.Add(this.PackageVersionLabel);
            this.DetailsPackage.Controls.Add(this.PackageHeader);
            this.DetailsPackage.Location = new System.Drawing.Point(4, 22);
            this.DetailsPackage.Name = "DetailsPackage";
            this.DetailsPackage.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsPackage.Size = new System.Drawing.Size(400, 330);
            this.DetailsPackage.TabIndex = 0;
            this.DetailsPackage.Text = "Package Details";
            // 
            // PackageSizeInfo
            // 
            this.PackageSizeInfo.BackColor = System.Drawing.Color.White;
            this.PackageSizeInfo.Location = new System.Drawing.Point(114, 96);
            this.PackageSizeInfo.Name = "PackageSizeInfo";
            this.PackageSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageSizeInfo.TabIndex = 19;
            this.PackageSizeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageSizeInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageSizeLabel
            // 
            this.PackageSizeLabel.Location = new System.Drawing.Point(3, 96);
            this.PackageSizeLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageSizeLabel.Name = "PackageSizeLabel";
            this.PackageSizeLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageSizeLabel.TabIndex = 18;
            this.PackageSizeLabel.Text = "Size:";
            this.PackageSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageCreationInfo
            // 
            this.PackageCreationInfo.BackColor = System.Drawing.Color.White;
            this.PackageCreationInfo.Location = new System.Drawing.Point(114, 78);
            this.PackageCreationInfo.Name = "PackageCreationInfo";
            this.PackageCreationInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageCreationInfo.TabIndex = 17;
            this.PackageCreationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageCreationInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageCreationLabel
            // 
            this.PackageCreationLabel.Location = new System.Drawing.Point(3, 78);
            this.PackageCreationLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageCreationLabel.Name = "PackageCreationLabel";
            this.PackageCreationLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PackageCreationLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageCreationLabel.TabIndex = 16;
            this.PackageCreationLabel.Text = "Creation:";
            this.PackageCreationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageAttributesInfo
            // 
            this.PackageAttributesInfo.BackColor = System.Drawing.Color.White;
            this.PackageAttributesInfo.Location = new System.Drawing.Point(114, 60);
            this.PackageAttributesInfo.Name = "PackageAttributesInfo";
            this.PackageAttributesInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageAttributesInfo.TabIndex = 15;
            this.PackageAttributesInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageAttributesInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageAttributesLabel
            // 
            this.PackageAttributesLabel.Location = new System.Drawing.Point(3, 60);
            this.PackageAttributesLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageAttributesLabel.Name = "PackageAttributesLabel";
            this.PackageAttributesLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageAttributesLabel.TabIndex = 14;
            this.PackageAttributesLabel.Text = "Attributes:";
            this.PackageAttributesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageFullNameInfo
            // 
            this.PackageFullNameInfo.BackColor = System.Drawing.Color.White;
            this.PackageFullNameInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PackageFullNameInfo.Location = new System.Drawing.Point(114, 28);
            this.PackageFullNameInfo.Name = "PackageFullNameInfo";
            this.PackageFullNameInfo.Size = new System.Drawing.Size(280, 26);
            this.PackageFullNameInfo.TabIndex = 13;
            this.PackageFullNameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PackageFullNameInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageFullNameLabel
            // 
            this.PackageFullNameLabel.Location = new System.Drawing.Point(3, 35);
            this.PackageFullNameLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageFullNameLabel.Name = "PackageFullNameLabel";
            this.PackageFullNameLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageFullNameLabel.TabIndex = 12;
            this.PackageFullNameLabel.Text = "Full name:";
            this.PackageFullNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageGeneralLabel
            // 
            this.PackageGeneralLabel.AutoSize = true;
            this.PackageGeneralLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackageGeneralLabel.Location = new System.Drawing.Point(6, 10);
            this.PackageGeneralLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.PackageGeneralLabel.Name = "PackageGeneralLabel";
            this.PackageGeneralLabel.Size = new System.Drawing.Size(51, 13);
            this.PackageGeneralLabel.TabIndex = 11;
            this.PackageGeneralLabel.Text = "General";
            // 
            // PackageFileCountInfo
            // 
            this.PackageFileCountInfo.BackColor = System.Drawing.Color.White;
            this.PackageFileCountInfo.Location = new System.Drawing.Point(114, 209);
            this.PackageFileCountInfo.Name = "PackageFileCountInfo";
            this.PackageFileCountInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageFileCountInfo.TabIndex = 10;
            this.PackageFileCountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageFileCountInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageFileCountLabel
            // 
            this.PackageFileCountLabel.Location = new System.Drawing.Point(3, 209);
            this.PackageFileCountLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageFileCountLabel.Name = "PackageFileCountLabel";
            this.PackageFileCountLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageFileCountLabel.TabIndex = 9;
            this.PackageFileCountLabel.Text = "File count:";
            this.PackageFileCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageBlockSizeInfo
            // 
            this.PackageBlockSizeInfo.BackColor = System.Drawing.Color.White;
            this.PackageBlockSizeInfo.Location = new System.Drawing.Point(114, 191);
            this.PackageBlockSizeInfo.Name = "PackageBlockSizeInfo";
            this.PackageBlockSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageBlockSizeInfo.TabIndex = 8;
            this.PackageBlockSizeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageBlockSizeInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageBlockSizeLabel
            // 
            this.PackageBlockSizeLabel.Location = new System.Drawing.Point(3, 191);
            this.PackageBlockSizeLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageBlockSizeLabel.Name = "PackageBlockSizeLabel";
            this.PackageBlockSizeLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageBlockSizeLabel.TabIndex = 7;
            this.PackageBlockSizeLabel.Text = "Block size:";
            this.PackageBlockSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageHeaderSizeInfo
            // 
            this.PackageHeaderSizeInfo.BackColor = System.Drawing.Color.White;
            this.PackageHeaderSizeInfo.Location = new System.Drawing.Point(114, 173);
            this.PackageHeaderSizeInfo.Name = "PackageHeaderSizeInfo";
            this.PackageHeaderSizeInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageHeaderSizeInfo.TabIndex = 6;
            this.PackageHeaderSizeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageHeaderSizeInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageHeaderSizeLabel
            // 
            this.PackageHeaderSizeLabel.Location = new System.Drawing.Point(3, 173);
            this.PackageHeaderSizeLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageHeaderSizeLabel.Name = "PackageHeaderSizeLabel";
            this.PackageHeaderSizeLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageHeaderSizeLabel.TabIndex = 5;
            this.PackageHeaderSizeLabel.Text = "Header size:";
            this.PackageHeaderSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageMiscInfo
            // 
            this.PackageMiscInfo.BackColor = System.Drawing.Color.White;
            this.PackageMiscInfo.Location = new System.Drawing.Point(114, 155);
            this.PackageMiscInfo.Name = "PackageMiscInfo";
            this.PackageMiscInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageMiscInfo.TabIndex = 4;
            this.PackageMiscInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageMiscInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageMiscLabel
            // 
            this.PackageMiscLabel.Location = new System.Drawing.Point(3, 155);
            this.PackageMiscLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageMiscLabel.Name = "PackageMiscLabel";
            this.PackageMiscLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageMiscLabel.TabIndex = 3;
            this.PackageMiscLabel.Text = "Misc:";
            this.PackageMiscLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageVersionInfo
            // 
            this.PackageVersionInfo.BackColor = System.Drawing.Color.White;
            this.PackageVersionInfo.Location = new System.Drawing.Point(114, 137);
            this.PackageVersionInfo.Name = "PackageVersionInfo";
            this.PackageVersionInfo.Size = new System.Drawing.Size(120, 13);
            this.PackageVersionInfo.TabIndex = 2;
            this.PackageVersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PackageVersionInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // PackageVersionLabel
            // 
            this.PackageVersionLabel.Location = new System.Drawing.Point(3, 137);
            this.PackageVersionLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.PackageVersionLabel.Name = "PackageVersionLabel";
            this.PackageVersionLabel.Size = new System.Drawing.Size(105, 13);
            this.PackageVersionLabel.TabIndex = 1;
            this.PackageVersionLabel.Text = "Version:";
            this.PackageVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PackageHeader
            // 
            this.PackageHeader.AutoSize = true;
            this.PackageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackageHeader.Location = new System.Drawing.Point(3, 119);
            this.PackageHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.PackageHeader.Name = "PackageHeader";
            this.PackageHeader.Size = new System.Drawing.Size(48, 13);
            this.PackageHeader.TabIndex = 0;
            this.PackageHeader.Text = "Header";
            // 
            // DetailsBlock
            // 
            this.DetailsBlock.BackColor = System.Drawing.SystemColors.Control;
            this.DetailsBlock.Controls.Add(this.BlockNextBlockInfo);
            this.DetailsBlock.Controls.Add(this.BlockNextBlockLabel);
            this.DetailsBlock.Controls.Add(this.BlockHeader);
            this.DetailsBlock.Controls.Add(this.BlockFileCountInfo);
            this.DetailsBlock.Controls.Add(this.BlockFileCountLabel);
            this.DetailsBlock.Location = new System.Drawing.Point(4, 22);
            this.DetailsBlock.Name = "DetailsBlock";
            this.DetailsBlock.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsBlock.Size = new System.Drawing.Size(400, 330);
            this.DetailsBlock.TabIndex = 1;
            this.DetailsBlock.Text = "Block Details";
            // 
            // BlockNextBlockInfo
            // 
            this.BlockNextBlockInfo.BackColor = System.Drawing.Color.White;
            this.BlockNextBlockInfo.Location = new System.Drawing.Point(114, 46);
            this.BlockNextBlockInfo.Name = "BlockNextBlockInfo";
            this.BlockNextBlockInfo.Size = new System.Drawing.Size(120, 13);
            this.BlockNextBlockInfo.TabIndex = 15;
            this.BlockNextBlockInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BlockNextBlockInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // BlockNextBlockLabel
            // 
            this.BlockNextBlockLabel.Location = new System.Drawing.Point(3, 46);
            this.BlockNextBlockLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.BlockNextBlockLabel.Name = "BlockNextBlockLabel";
            this.BlockNextBlockLabel.Size = new System.Drawing.Size(105, 13);
            this.BlockNextBlockLabel.TabIndex = 14;
            this.BlockNextBlockLabel.Text = "Next block:";
            this.BlockNextBlockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BlockHeader
            // 
            this.BlockHeader.AutoSize = true;
            this.BlockHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlockHeader.Location = new System.Drawing.Point(6, 10);
            this.BlockHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.BlockHeader.Name = "BlockHeader";
            this.BlockHeader.Size = new System.Drawing.Size(48, 13);
            this.BlockHeader.TabIndex = 13;
            this.BlockHeader.Text = "Header";
            // 
            // BlockFileCountInfo
            // 
            this.BlockFileCountInfo.BackColor = System.Drawing.Color.White;
            this.BlockFileCountInfo.Location = new System.Drawing.Point(114, 28);
            this.BlockFileCountInfo.Name = "BlockFileCountInfo";
            this.BlockFileCountInfo.Size = new System.Drawing.Size(120, 13);
            this.BlockFileCountInfo.TabIndex = 12;
            this.BlockFileCountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BlockFileCountInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // BlockFileCountLabel
            // 
            this.BlockFileCountLabel.Location = new System.Drawing.Point(3, 28);
            this.BlockFileCountLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.BlockFileCountLabel.Name = "BlockFileCountLabel";
            this.BlockFileCountLabel.Size = new System.Drawing.Size(105, 13);
            this.BlockFileCountLabel.TabIndex = 11;
            this.BlockFileCountLabel.Text = "File count:";
            this.BlockFileCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DetailsFile
            // 
            this.DetailsFile.BackColor = System.Drawing.SystemColors.Control;
            this.DetailsFile.Controls.Add(this.FileMimeLabel);
            this.DetailsFile.Controls.Add(this.FileMimeInfo);
            this.DetailsFile.Controls.Add(this.FileUnsetButton);
            this.DetailsFile.Controls.Add(this.FileCompressionTypeInfo);
            this.DetailsFile.Controls.Add(this.FileCompressionTypeLabel);
            this.DetailsFile.Controls.Add(this.FileCompression);
            this.DetailsFile.Controls.Add(this.FileGeneral);
            this.DetailsFile.Controls.Add(this.FileDecompressedInfo);
            this.DetailsFile.Controls.Add(this.FileFileNameInfo);
            this.DetailsFile.Controls.Add(this.FileDecompressedLabel);
            this.DetailsFile.Controls.Add(this.FileFileNameLabel);
            this.DetailsFile.Controls.Add(this.FileCompressedInfo);
            this.DetailsFile.Controls.Add(this.FileHashLabel);
            this.DetailsFile.Controls.Add(this.FileCompressedLabel);
            this.DetailsFile.Controls.Add(this.FileHashInfo);
            this.DetailsFile.Controls.Add(this.FileDataHashLabel);
            this.DetailsFile.Controls.Add(this.FileDataHashInfo);
            this.DetailsFile.Location = new System.Drawing.Point(4, 22);
            this.DetailsFile.Name = "DetailsFile";
            this.DetailsFile.Padding = new System.Windows.Forms.Padding(3);
            this.DetailsFile.Size = new System.Drawing.Size(400, 330);
            this.DetailsFile.TabIndex = 2;
            this.DetailsFile.Text = "File Details";
            // 
            // FileMimeLabel
            // 
            this.FileMimeLabel.Location = new System.Drawing.Point(20, 95);
            this.FileMimeLabel.Name = "FileMimeLabel";
            this.FileMimeLabel.Size = new System.Drawing.Size(88, 13);
            this.FileMimeLabel.TabIndex = 26;
            this.FileMimeLabel.Text = "Mime Type:";
            this.FileMimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileMimeInfo
            // 
            this.FileMimeInfo.BackColor = System.Drawing.Color.White;
            this.FileMimeInfo.Location = new System.Drawing.Point(114, 95);
            this.FileMimeInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileMimeInfo.Name = "FileMimeInfo";
            this.FileMimeInfo.Size = new System.Drawing.Size(280, 26);
            this.FileMimeInfo.TabIndex = 27;
            this.FileMimeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileMimeInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // FileUnsetButton
            // 
            this.FileUnsetButton.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.FileUnsetButton.Location = new System.Drawing.Point(23, 30);
            this.FileUnsetButton.Name = "FileUnsetButton";
            this.FileUnsetButton.Size = new System.Drawing.Size(23, 23);
            this.FileUnsetButton.TabIndex = 20;
            this.FileUnsetButton.UseVisualStyleBackColor = true;
            this.FileUnsetButton.Visible = false;
            this.FileUnsetButton.Click += new System.EventHandler(this.FileUnsetButton_Click);
            // 
            // FileCompressionTypeInfo
            // 
            this.FileCompressionTypeInfo.BackColor = System.Drawing.Color.White;
            this.FileCompressionTypeInfo.Location = new System.Drawing.Point(151, 143);
            this.FileCompressionTypeInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileCompressionTypeInfo.Name = "FileCompressionTypeInfo";
            this.FileCompressionTypeInfo.Size = new System.Drawing.Size(83, 13);
            this.FileCompressionTypeInfo.TabIndex = 25;
            this.FileCompressionTypeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileCompressionTypeLabel
            // 
            this.FileCompressionTypeLabel.Location = new System.Drawing.Point(3, 143);
            this.FileCompressionTypeLabel.Name = "FileCompressionTypeLabel";
            this.FileCompressionTypeLabel.Size = new System.Drawing.Size(142, 13);
            this.FileCompressionTypeLabel.TabIndex = 24;
            this.FileCompressionTypeLabel.Text = "Compression type:";
            this.FileCompressionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileCompression
            // 
            this.FileCompression.AutoSize = true;
            this.FileCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileCompression.Location = new System.Drawing.Point(6, 126);
            this.FileCompression.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.FileCompression.Name = "FileCompression";
            this.FileCompression.Size = new System.Drawing.Size(78, 13);
            this.FileCompression.TabIndex = 14;
            this.FileCompression.Text = "Compression";
            // 
            // FileGeneral
            // 
            this.FileGeneral.AutoSize = true;
            this.FileGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileGeneral.Location = new System.Drawing.Point(6, 10);
            this.FileGeneral.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.FileGeneral.Name = "FileGeneral";
            this.FileGeneral.Size = new System.Drawing.Size(51, 13);
            this.FileGeneral.TabIndex = 13;
            this.FileGeneral.Text = "General";
            // 
            // FileDecompressedInfo
            // 
            this.FileDecompressedInfo.BackColor = System.Drawing.Color.White;
            this.FileDecompressedInfo.Location = new System.Drawing.Point(151, 179);
            this.FileDecompressedInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileDecompressedInfo.Name = "FileDecompressedInfo";
            this.FileDecompressedInfo.Size = new System.Drawing.Size(83, 13);
            this.FileDecompressedInfo.TabIndex = 12;
            this.FileDecompressedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileDecompressedInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // FileFileNameInfo
            // 
            this.FileFileNameInfo.AutoEllipsis = true;
            this.FileFileNameInfo.BackColor = System.Drawing.Color.White;
            this.FileFileNameInfo.Location = new System.Drawing.Point(114, 28);
            this.FileFileNameInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileFileNameInfo.Name = "FileFileNameInfo";
            this.FileFileNameInfo.Size = new System.Drawing.Size(280, 26);
            this.FileFileNameInfo.TabIndex = 1;
            this.FileFileNameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileFileNameInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // FileDecompressedLabel
            // 
            this.FileDecompressedLabel.Location = new System.Drawing.Point(3, 179);
            this.FileDecompressedLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.FileDecompressedLabel.Name = "FileDecompressedLabel";
            this.FileDecompressedLabel.Size = new System.Drawing.Size(142, 13);
            this.FileDecompressedLabel.TabIndex = 11;
            this.FileDecompressedLabel.Text = "Decompressed size:";
            this.FileDecompressedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileFileNameLabel
            // 
            this.FileFileNameLabel.Location = new System.Drawing.Point(3, 35);
            this.FileFileNameLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.FileFileNameLabel.Name = "FileFileNameLabel";
            this.FileFileNameLabel.Size = new System.Drawing.Size(105, 13);
            this.FileFileNameLabel.TabIndex = 0;
            this.FileFileNameLabel.Text = "Filename:";
            this.FileFileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileCompressedInfo
            // 
            this.FileCompressedInfo.BackColor = System.Drawing.Color.White;
            this.FileCompressedInfo.Location = new System.Drawing.Point(151, 161);
            this.FileCompressedInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileCompressedInfo.Name = "FileCompressedInfo";
            this.FileCompressedInfo.Size = new System.Drawing.Size(83, 13);
            this.FileCompressedInfo.TabIndex = 10;
            this.FileCompressedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileCompressedInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // FileHashLabel
            // 
            this.FileHashLabel.Location = new System.Drawing.Point(3, 59);
            this.FileHashLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.FileHashLabel.Name = "FileHashLabel";
            this.FileHashLabel.Size = new System.Drawing.Size(105, 13);
            this.FileHashLabel.TabIndex = 2;
            this.FileHashLabel.Text = "Hash:";
            this.FileHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileCompressedLabel
            // 
            this.FileCompressedLabel.Location = new System.Drawing.Point(3, 161);
            this.FileCompressedLabel.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.FileCompressedLabel.Name = "FileCompressedLabel";
            this.FileCompressedLabel.Size = new System.Drawing.Size(142, 13);
            this.FileCompressedLabel.TabIndex = 9;
            this.FileCompressedLabel.Text = "Compressed size:";
            this.FileCompressedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileHashInfo
            // 
            this.FileHashInfo.BackColor = System.Drawing.Color.White;
            this.FileHashInfo.Location = new System.Drawing.Point(114, 59);
            this.FileHashInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileHashInfo.Name = "FileHashInfo";
            this.FileHashInfo.Size = new System.Drawing.Size(120, 13);
            this.FileHashInfo.TabIndex = 3;
            this.FileHashInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileHashInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // FileDataHashLabel
            // 
            this.FileDataHashLabel.Location = new System.Drawing.Point(20, 77);
            this.FileDataHashLabel.Name = "FileDataHashLabel";
            this.FileDataHashLabel.Size = new System.Drawing.Size(88, 13);
            this.FileDataHashLabel.TabIndex = 4;
            this.FileDataHashLabel.Text = "Data hash:";
            this.FileDataHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileDataHashInfo
            // 
            this.FileDataHashInfo.BackColor = System.Drawing.Color.White;
            this.FileDataHashInfo.Location = new System.Drawing.Point(114, 77);
            this.FileDataHashInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileDataHashInfo.Name = "FileDataHashInfo";
            this.FileDataHashInfo.Size = new System.Drawing.Size(120, 13);
            this.FileDataHashInfo.TabIndex = 5;
            this.FileDataHashInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileDataHashInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
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
            this.UncompressedInfo.Location = new System.Drawing.Point(93, 146);
            this.UncompressedInfo.Name = "UncompressedInfo";
            this.UncompressedInfo.Size = new System.Drawing.Size(60, 13);
            this.UncompressedInfo.TabIndex = 12;
            this.UncompressedInfo.Text = "999 KB";
            this.UncompressedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.CompressedInfo.Location = new System.Drawing.Point(93, 125);
            this.CompressedInfo.Name = "CompressedInfo";
            this.CompressedInfo.Size = new System.Drawing.Size(60, 13);
            this.CompressedInfo.TabIndex = 10;
            this.CompressedInfo.Text = "999 KB";
            this.CompressedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DataOffsetInfo.AutoSize = true;
            this.DataOffsetInfo.BackColor = System.Drawing.Color.White;
            this.DataOffsetInfo.Location = new System.Drawing.Point(93, 218);
            this.DataOffsetInfo.Name = "DataOffsetInfo";
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
            this.UnknownInfo.Location = new System.Drawing.Point(239, 81);
            this.UnknownInfo.Name = "UnknownInfo";
            this.UnknownInfo.Size = new System.Drawing.Size(76, 13);
            this.UnknownInfo.TabIndex = 5;
            this.UnknownInfo.Text = "B307A07F";
            this.UnknownInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.HashInfo.Location = new System.Drawing.Point(64, 81);
            this.HashInfo.Name = "HashInfo";
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
            this.FilenameInfo.AutoEllipsis = true;
            this.FilenameInfo.BackColor = System.Drawing.Color.White;
            this.FilenameInfo.Location = new System.Drawing.Point(64, 47);
            this.FilenameInfo.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.FilenameInfo.Name = "FilenameInfo";
            this.FilenameInfo.Size = new System.Drawing.Size(251, 26);
            this.FilenameInfo.TabIndex = 1;
            this.FilenameInfo.Text = "data/interface/interfacecore/fonts/neuehammerunzialeltstd.ttf";
            this.FilenameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Location = new System.Drawing.Point(374, 439);
            this.SearchBox.MaxLength = 256;
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(408, 20);
            this.SearchBox.TabIndex = 9;
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // SelectFolder
            // 
            this.SelectFolder.Description = "Select Folder";
            this.SelectFolder.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            // 
            // MenuToolStrip
            // 
            this.MenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonOpen,
            this.ButtonSave,
            this.ButtonClose,
            this.FileSeparator,
            this.ButtonOpenDictionary,
            this.ButtonSaveDictionary,
            this.ButtonMergeDictionary,
            this.DictionarySeparator,
            this.ButtonAdd,
            this.ButtonAddFolder,
            this.ButtonRemove,
            this.ButtonUnpack,
            this.ButtonReplace,
            this.ButtonReplaceFolder});
            this.MenuToolStrip.Location = new System.Drawing.Point(0, 24);
            this.MenuToolStrip.Name = "MenuToolStrip";
            this.MenuToolStrip.Size = new System.Drawing.Size(794, 25);
            this.MenuToolStrip.TabIndex = 12;
            // 
            // ButtonNew
            // 
            this.ButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonNew.Image = global::Mythic.Package.Editor.Properties.Resources.New;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(23, 22);
            this.ButtonNew.Click += new System.EventHandler(this.MainMenuFileNew_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonOpen.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.ButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.ButtonOpen.Click += new System.EventHandler(this.MainMenuFileOpen_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSave.Image")));
            this.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(23, 22);
            this.ButtonSave.Click += new System.EventHandler(this.MainMenuFileSave_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClose.Image")));
            this.ButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(23, 22);
            this.ButtonClose.Click += new System.EventHandler(this.MainMenuFileClose_Click);
            // 
            // FileSeparator
            // 
            this.FileSeparator.Name = "FileSeparator";
            this.FileSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonOpenDictionary
            // 
            this.ButtonOpenDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonOpenDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.ButtonOpenDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpenDictionary.Name = "ButtonOpenDictionary";
            this.ButtonOpenDictionary.Size = new System.Drawing.Size(23, 22);
            this.ButtonOpenDictionary.Click += new System.EventHandler(this.MainMenuDictionaryLoad_Click);
            // 
            // ButtonSaveDictionary
            // 
            this.ButtonSaveDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSaveDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.Save;
            this.ButtonSaveDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveDictionary.Name = "ButtonSaveDictionary";
            this.ButtonSaveDictionary.Size = new System.Drawing.Size(23, 22);
            this.ButtonSaveDictionary.Click += new System.EventHandler(this.MainMenuDictionarySave_Click);
            // 
            // ButtonMergeDictionary
            // 
            this.ButtonMergeDictionary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonMergeDictionary.Image = global::Mythic.Package.Editor.Properties.Resources.Merge;
            this.ButtonMergeDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonMergeDictionary.Name = "ButtonMergeDictionary";
            this.ButtonMergeDictionary.Size = new System.Drawing.Size(23, 22);
            this.ButtonMergeDictionary.Click += new System.EventHandler(this.MainMenuDictionaryMerge_Click);
            // 
            // DictionarySeparator
            // 
            this.DictionarySeparator.Name = "DictionarySeparator";
            this.DictionarySeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.ButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonAddFolder
            // 
            this.ButtonAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonAddFolder.Image = global::Mythic.Package.Editor.Properties.Resources.AddFolder;
            this.ButtonAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddFolder.Name = "ButtonAddFolder";
            this.ButtonAddFolder.Size = new System.Drawing.Size(23, 22);
            this.ButtonAddFolder.Click += new System.EventHandler(this.ButtonAddFolder_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRemove.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.ButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // ButtonUnpack
            // 
            this.ButtonUnpack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonUnpack.Image = global::Mythic.Package.Editor.Properties.Resources.Unpack;
            this.ButtonUnpack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonUnpack.Name = "ButtonUnpack";
            this.ButtonUnpack.Size = new System.Drawing.Size(23, 22);
            this.ButtonUnpack.Click += new System.EventHandler(this.ButtonUnpack_Click);
            // 
            // ButtonReplace
            // 
            this.ButtonReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonReplace.Image = global::Mythic.Package.Editor.Properties.Resources.Replace;
            this.ButtonReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonReplace.Name = "ButtonReplace";
            this.ButtonReplace.Size = new System.Drawing.Size(23, 22);
            this.ButtonReplace.Click += new System.EventHandler(this.ButtonReplace_Click);
            // 
            // ButtonReplaceFolder
            // 
            this.ButtonReplaceFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonReplaceFolder.Image = global::Mythic.Package.Editor.Properties.Resources.Replacefolder_fw;
            this.ButtonReplaceFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonReplaceFolder.Name = "ButtonReplaceFolder";
            this.ButtonReplaceFolder.Size = new System.Drawing.Size(23, 22);
            this.ButtonReplaceFolder.Click += new System.EventHandler(this.ButtonReplaceFolder_Click);
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
            // btnStopSearch
            // 
            this.btnStopSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopSearch.Enabled = false;
            this.btnStopSearch.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnStopSearch.Location = new System.Drawing.Point(749, 410);
            this.btnStopSearch.Name = "btnStopSearch";
            this.btnStopSearch.Size = new System.Drawing.Size(33, 23);
            this.btnStopSearch.TabIndex = 16;
            this.btnStopSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.btnStopSearch, "Stop the current search.");
            this.btnStopSearch.UseVisualStyleBackColor = true;
            this.btnStopSearch.Click += new System.EventHandler(this.btnStopSearch_Click);
            // 
            // btnBrute
            // 
            this.btnBrute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrute.Image = global::Mythic.Package.Editor.Properties.Resources.Wrench;
            this.btnBrute.Location = new System.Drawing.Point(571, 410);
            this.btnBrute.Name = "btnBrute";
            this.btnBrute.Size = new System.Drawing.Size(65, 23);
            this.btnBrute.TabIndex = 15;
            this.btnBrute.Text = "Brute";
            this.btnBrute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.btnBrute, "Brute force search for numeric file names with N leading zeroes (specified next t" +
        "o this button).");
            this.btnBrute.UseVisualStyleBackColor = true;
            this.btnBrute.Click += new System.EventHandler(this.btnBrute_Click);
            // 
            // FolderFiles
            // 
            this.FolderFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderFiles.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.FolderFiles.Location = new System.Drawing.Point(504, 410);
            this.FolderFiles.Name = "FolderFiles";
            this.FolderFiles.Size = new System.Drawing.Size(65, 23);
            this.FolderFiles.TabIndex = 14;
            this.FolderFiles.Text = "Folder";
            this.FolderFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.FolderFiles, "Search for all the files contained inside the selected folder.");
            this.FolderFiles.UseVisualStyleBackColor = true;
            this.FolderFiles.Click += new System.EventHandler(this.FolderFiles_Click);
            // 
            // SearchHash
            // 
            this.SearchHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchHash.Image = global::Mythic.Package.Editor.Properties.Resources.SearchExpression;
            this.SearchHash.Location = new System.Drawing.Point(374, 410);
            this.SearchHash.Name = "SearchHash";
            this.SearchHash.Size = new System.Drawing.Size(61, 23);
            this.SearchHash.TabIndex = 13;
            this.SearchHash.Text = "Hash";
            this.SearchHash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.SearchHash, "Search specific hash");
            this.SearchHash.UseVisualStyleBackColor = true;
            this.SearchHash.Click += new System.EventHandler(this.SearchHash_Click);
            // 
            // Search
            // 
            this.Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Search.Image = ((System.Drawing.Image)(resources.GetObject("Search.Image")));
            this.Search.Location = new System.Drawing.Point(437, 410);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(65, 23);
            this.Search.TabIndex = 7;
            this.Search.Text = "Search";
            this.Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ttpButtons.SetToolTip(this.Search, "Search for a specific file name.");
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // txtLeadZeroes
            // 
            this.txtLeadZeroes.Location = new System.Drawing.Point(705, 413);
            this.txtLeadZeroes.Name = "txtLeadZeroes";
            this.txtLeadZeroes.Size = new System.Drawing.Size(38, 20);
            this.txtLeadZeroes.TabIndex = 17;
            this.ttpButtons.SetToolTip(this.txtLeadZeroes, "Number of LEADING zeroes to use in the brute force search for the file names.");
            this.txtLeadZeroes.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 485);
            this.Controls.Add(this.txtLeadZeroes);
            this.Controls.Add(this.btnStopSearch);
            this.Controls.Add(this.btnBrute);
            this.Controls.Add(this.FolderFiles);
            this.Controls.Add(this.MenuToolStrip);
            this.Controls.Add(this.SearchHash);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.FileDetails);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 517);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mythic Package Editor";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.CopyMenuStrip.ResumeLayout(false);
            this.FileDetails.ResumeLayout(false);
            this.DetailsPackage.ResumeLayout(false);
            this.DetailsPackage.PerformLayout();
            this.DetailsBlock.ResumeLayout(false);
            this.DetailsBlock.PerformLayout();
            this.DetailsFile.ResumeLayout(false);
            this.DetailsFile.PerformLayout();
            this.MenuToolStrip.ResumeLayout(false);
            this.MenuToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeadZeroes)).EndInit();
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
		private System.Windows.Forms.Button Search;
		private System.Windows.Forms.ContextMenuStrip CopyMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem CopyMenuStripButton;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionary;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryUpdate;
		private System.Windows.Forms.TabControl FileDetails;
		private System.Windows.Forms.TabPage DetailsPackage;
		private System.Windows.Forms.TabPage DetailsBlock;
		private System.Windows.Forms.TabPage DetailsFile;
		private System.Windows.Forms.Label FileDecompressedInfo;
		private System.Windows.Forms.Label FileDecompressedLabel;
		private System.Windows.Forms.Label FileCompressedInfo;
		private System.Windows.Forms.Label FileCompressedLabel;
		private System.Windows.Forms.Label FileDataHashInfo;
		private System.Windows.Forms.Label FileDataHashLabel;
		private System.Windows.Forms.Label FileHashInfo;
		private System.Windows.Forms.Label FileHashLabel;
		private System.Windows.Forms.Label FileFileNameInfo;
		private System.Windows.Forms.Label FileFileNameLabel;
		private System.Windows.Forms.Label GeneralLabel;
		private System.Windows.Forms.Label UncompressedInfo;
		private System.Windows.Forms.Label UncompressedLabel;
		private System.Windows.Forms.Label CompressedInfo;
		private System.Windows.Forms.Label CompressedLabel;
		private System.Windows.Forms.Label SizesLabel;
		private System.Windows.Forms.Label DataOffsetInfo;
		private System.Windows.Forms.Label DataOffsetLabel;
		private System.Windows.Forms.Label UnknownInfo;
		private System.Windows.Forms.Label UnknownLabel;
		private System.Windows.Forms.Label HashInfo;
		private System.Windows.Forms.Label HashLabel;
		private System.Windows.Forms.Label FilenameInfo;
		private System.Windows.Forms.Label FilenameLabel;
		private System.Windows.Forms.Label PackageHeader;
		private System.Windows.Forms.Label PackageVersionLabel;
		private System.Windows.Forms.Label PackageVersionInfo;
		private System.Windows.Forms.Label PackageMiscLabel;
		private System.Windows.Forms.Label PackageMiscInfo;
		private System.Windows.Forms.Label PackageHeaderSizeLabel;
		private System.Windows.Forms.Label PackageHeaderSizeInfo;
		private System.Windows.Forms.Label PackageBlockSizeInfo;
		private System.Windows.Forms.Label PackageBlockSizeLabel;
		private System.Windows.Forms.Label PackageFileCountLabel;
		private System.Windows.Forms.Label PackageFileCountInfo;
		private System.Windows.Forms.Label PackageGeneralLabel;
		private System.Windows.Forms.Label PackageFullNameLabel;
		private System.Windows.Forms.Label PackageFullNameInfo;
		private System.Windows.Forms.Label PackageAttributesInfo;
		private System.Windows.Forms.Label PackageAttributesLabel;
		private System.Windows.Forms.Label PackageCreationLabel;
		private System.Windows.Forms.Label PackageCreationInfo;
		private System.Windows.Forms.Label PackageSizeLabel;
		private System.Windows.Forms.Label PackageSizeInfo;
		private System.Windows.Forms.Label BlockHeader;
		private System.Windows.Forms.Label BlockFileCountInfo;
		private System.Windows.Forms.Label BlockFileCountLabel;
		private System.Windows.Forms.Label BlockNextBlockInfo;
		private System.Windows.Forms.Label BlockNextBlockLabel;
		private System.Windows.Forms.Label FileGeneral;
		private System.Windows.Forms.Label FileCompression;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyStart;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyAttach;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySave;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionarySpyDetach;
		private System.Windows.Forms.ToolStripMenuItem MainMenuFileClose;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryLoad;
		private System.Windows.Forms.ToolStripMenuItem MainMenuDictionaryMerge;
		private System.Windows.Forms.TextBox SearchBox;
		private System.Windows.Forms.ToolStripSeparator MainMenuDictionarySeparator;
		private System.Windows.Forms.FolderBrowserDialog SelectFolder;
		private System.Windows.Forms.ToolStripMenuItem MainMenuHelp;
		private System.Windows.Forms.Label FileCompressionTypeLabel;
		private System.Windows.Forms.Label FileCompressionTypeInfo;
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
		private System.Windows.Forms.ToolStripButton ButtonNew;
		private System.Windows.Forms.ToolStripButton ButtonOpen;
		private System.Windows.Forms.ToolStripButton ButtonSave;
		private System.Windows.Forms.ToolStripButton ButtonClose;
		private System.Windows.Forms.ToolStripSeparator FileSeparator;
		private System.Windows.Forms.ToolStripButton ButtonAdd;
		private System.Windows.Forms.ToolStripButton ButtonRemove;
		private System.Windows.Forms.ToolStripButton ButtonUnpack;
		private System.Windows.Forms.ToolStripButton ButtonOpenDictionary;
		private System.Windows.Forms.ToolStripButton ButtonSaveDictionary;
		private System.Windows.Forms.ToolStripButton ButtonMergeDictionary;
		private System.Windows.Forms.ToolStripSeparator DictionarySeparator;
		private System.Windows.Forms.Button SearchHash;
		private System.Windows.Forms.ToolTip ErrorTooltip;
		private System.Windows.Forms.ToolStripMenuItem MainMenuEdit;
		private System.Windows.Forms.ToolStripMenuItem MainMenuEditSettings;
		private System.Windows.Forms.ToolStripButton ButtonReplace;
		private System.Windows.Forms.ToolStripMenuItem MainMenuHelpContent;
		private System.Windows.Forms.HelpProvider Help;
		private System.Windows.Forms.Button FileUnsetButton;
		private System.Windows.Forms.ToolStripButton ButtonAddFolder;
        private System.Windows.Forms.Button FolderFiles;
        private System.Windows.Forms.Button btnBrute;
        private System.Windows.Forms.Button btnStopSearch;
        private System.Windows.Forms.ToolStripButton ButtonReplaceFolder;
        private System.Windows.Forms.NumericUpDown txtLeadZeroes;
        private System.Windows.Forms.ToolTip ttpButtons;
        private System.Windows.Forms.ToolStripDropDownButton btnMessageIcon;
        private System.Windows.Forms.Label FileMimeLabel;
        private System.Windows.Forms.Label FileMimeInfo;
    }
}

