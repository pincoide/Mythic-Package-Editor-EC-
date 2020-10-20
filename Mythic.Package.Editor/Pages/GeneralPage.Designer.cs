namespace Mythic.Package.Editor
{
	partial class GeneralPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.LabelLanguage = new System.Windows.Forms.Label();
			this.LabelCurrentLangauge = new System.Windows.Forms.Label();
			this.EditLanguage = new System.Windows.Forms.ComboBox();
			this.LabelUnpacking = new System.Windows.Forms.Label();
			this.LabelOutputPath = new System.Windows.Forms.Label();
			this.EditOutputPath = new System.Windows.Forms.TextBox();
			this.LabelInnerFolder = new System.Windows.Forms.Label();
			this.EditInnerFolder = new System.Windows.Forms.CheckBox();
			this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.ErrorTooltip = new System.Windows.Forms.ToolTip( this.components );
			this.LabelInnerFolders = new System.Windows.Forms.Label();
			this.ButtonRemove = new System.Windows.Forms.Button();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.ButtonOutputPath = new System.Windows.Forms.Button();
			this.EditInnerFolders = new System.Windows.Forms.ListBox();
			this.DynamicTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LabelLanguage
			// 
			this.LabelLanguage.AutoSize = true;
			this.LabelLanguage.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.LabelLanguage.Location = new System.Drawing.Point( 5, 10 );
			this.LabelLanguage.Margin = new System.Windows.Forms.Padding( 5, 10, 5, 3 );
			this.LabelLanguage.Name = "LabelLanguage";
			this.LabelLanguage.Size = new System.Drawing.Size( 63, 13 );
			this.LabelLanguage.TabIndex = 0;
			this.LabelLanguage.Text = "Language";
			this.LabelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelCurrentLangauge
			// 
			this.LabelCurrentLangauge.Location = new System.Drawing.Point( 8, 31 );
			this.LabelCurrentLangauge.Margin = new System.Windows.Forms.Padding( 5 );
			this.LabelCurrentLangauge.Name = "LabelCurrentLangauge";
			this.LabelCurrentLangauge.Size = new System.Drawing.Size( 150, 20 );
			this.LabelCurrentLangauge.TabIndex = 1;
			this.LabelCurrentLangauge.Text = "Current language:";
			this.LabelCurrentLangauge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// EditLanguage
			// 
			this.EditLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EditLanguage.FormattingEnabled = true;
			this.EditLanguage.Location = new System.Drawing.Point( 166, 32 );
			this.EditLanguage.Name = "EditLanguage";
			this.EditLanguage.Size = new System.Drawing.Size( 121, 21 );
			this.EditLanguage.TabIndex = 2;
			// 
			// LabelUnpacking
			// 
			this.LabelUnpacking.AutoSize = true;
			this.LabelUnpacking.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.LabelUnpacking.Location = new System.Drawing.Point( 5, 66 );
			this.LabelUnpacking.Margin = new System.Windows.Forms.Padding( 5, 10, 5, 3 );
			this.LabelUnpacking.Name = "LabelUnpacking";
			this.LabelUnpacking.Size = new System.Drawing.Size( 68, 13 );
			this.LabelUnpacking.TabIndex = 3;
			this.LabelUnpacking.Text = "Unpacking";
			this.LabelUnpacking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LabelOutputPath
			// 
			this.LabelOutputPath.Location = new System.Drawing.Point( 8, 87 );
			this.LabelOutputPath.Margin = new System.Windows.Forms.Padding( 5 );
			this.LabelOutputPath.Name = "LabelOutputPath";
			this.LabelOutputPath.Size = new System.Drawing.Size( 150, 20 );
			this.LabelOutputPath.TabIndex = 4;
			this.LabelOutputPath.Text = "Unpack in:";
			this.LabelOutputPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// EditOutputPath
			// 
			this.EditOutputPath.Location = new System.Drawing.Point( 166, 88 );
			this.EditOutputPath.Name = "EditOutputPath";
			this.EditOutputPath.Size = new System.Drawing.Size( 175, 20 );
			this.EditOutputPath.TabIndex = 5;
			// 
			// LabelInnerFolder
			// 
			this.LabelInnerFolder.Location = new System.Drawing.Point( 8, 112 );
			this.LabelInnerFolder.Margin = new System.Windows.Forms.Padding( 3, 0, 3, 5 );
			this.LabelInnerFolder.Name = "LabelInnerFolder";
			this.LabelInnerFolder.Size = new System.Drawing.Size( 150, 20 );
			this.LabelInnerFolder.TabIndex = 7;
			this.LabelInnerFolder.Text = "Unpack with inner folder:";
			this.LabelInnerFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// EditInnerFolder
			// 
			this.EditInnerFolder.AutoSize = true;
			this.EditInnerFolder.Location = new System.Drawing.Point( 166, 116 );
			this.EditInnerFolder.Name = "EditInnerFolder";
			this.EditInnerFolder.Size = new System.Drawing.Size( 15, 14 );
			this.EditInnerFolder.TabIndex = 8;
			this.EditInnerFolder.UseVisualStyleBackColor = true;
			// 
			// ErrorTooltip
			// 
			this.ErrorTooltip.IsBalloon = true;
			this.ErrorTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
			// 
			// LabelInnerFolders
			// 
			this.LabelInnerFolders.Location = new System.Drawing.Point( 8, 137 );
			this.LabelInnerFolders.Margin = new System.Windows.Forms.Padding( 3, 0, 3, 5 );
			this.LabelInnerFolders.Name = "LabelInnerFolders";
			this.LabelInnerFolders.Size = new System.Drawing.Size( 150, 20 );
			this.LabelInnerFolders.TabIndex = 9;
			this.LabelInnerFolders.Text = "Inner folders:";
			this.LabelInnerFolders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ButtonRemove
			// 
			this.ButtonRemove.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
			this.ButtonRemove.Location = new System.Drawing.Point( 347, 165 );
			this.ButtonRemove.Name = "ButtonRemove";
			this.ButtonRemove.Size = new System.Drawing.Size( 23, 23 );
			this.ButtonRemove.TabIndex = 12;
			this.ButtonRemove.UseVisualStyleBackColor = true;
			this.ButtonRemove.Click += new System.EventHandler( this.ButtonRemove_Click );
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
			this.ButtonAdd.Location = new System.Drawing.Point( 347, 136 );
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size( 23, 23 );
			this.ButtonAdd.TabIndex = 11;
			this.ButtonAdd.UseVisualStyleBackColor = true;
			this.ButtonAdd.Click += new System.EventHandler( this.ButtonAdd_Click );
			// 
			// ButtonOutputPath
			// 
			this.ButtonOutputPath.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
			this.ButtonOutputPath.Location = new System.Drawing.Point( 347, 86 );
			this.ButtonOutputPath.Name = "ButtonOutputPath";
			this.ButtonOutputPath.Size = new System.Drawing.Size( 23, 23 );
			this.ButtonOutputPath.TabIndex = 6;
			this.ButtonOutputPath.UseVisualStyleBackColor = true;
			this.ButtonOutputPath.Click += new System.EventHandler( this.ButtonOutputPath_Click );
			// 
			// EditInnerFolders
			// 
			this.EditInnerFolders.FormattingEnabled = true;
			this.EditInnerFolders.Location = new System.Drawing.Point( 166, 136 );
			this.EditInnerFolders.Name = "EditInnerFolders";
			this.EditInnerFolders.Size = new System.Drawing.Size( 175, 69 );
			this.EditInnerFolders.Sorted = true;
			this.EditInnerFolders.TabIndex = 13;
			this.EditInnerFolders.DoubleClick += new System.EventHandler( this.EditInnerFolders_DoubleClick );
			this.EditInnerFolders.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.EditInnerFolders_KeyPress );
			this.EditInnerFolders.KeyDown += new System.Windows.Forms.KeyEventHandler( this.EditInnerFolders_KeyDown );
			// 
			// DynamicTextBox
			// 
			this.DynamicTextBox.BackColor = System.Drawing.SystemColors.Info;
			this.DynamicTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DynamicTextBox.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.DynamicTextBox.Location = new System.Drawing.Point( 0, 0 );
			this.DynamicTextBox.Name = "DynamicTextBox";
			this.DynamicTextBox.Size = new System.Drawing.Size( 0, 20 );
			this.DynamicTextBox.TabIndex = 14;
			this.DynamicTextBox.Visible = false;
			this.DynamicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.DynamicTextBox_KeyPress );
			this.DynamicTextBox.LostFocus += new System.EventHandler( this.DynamicTextBox_LostFocus );
			// 
			// GeneralPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add( this.DynamicTextBox );
			this.Controls.Add( this.EditInnerFolders );
			this.Controls.Add( this.ButtonRemove );
			this.Controls.Add( this.ButtonAdd );
			this.Controls.Add( this.LabelInnerFolders );
			this.Controls.Add( this.EditInnerFolder );
			this.Controls.Add( this.LabelInnerFolder );
			this.Controls.Add( this.ButtonOutputPath );
			this.Controls.Add( this.EditOutputPath );
			this.Controls.Add( this.LabelOutputPath );
			this.Controls.Add( this.LabelUnpacking );
			this.Controls.Add( this.EditLanguage );
			this.Controls.Add( this.LabelCurrentLangauge );
			this.Controls.Add( this.LabelLanguage );
			this.Margin = new System.Windows.Forms.Padding( 0, 12, 12, 0 );
			this.Name = "GeneralPage";
			this.Size = new System.Drawing.Size( 538, 310 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelLanguage;
		private System.Windows.Forms.Label LabelCurrentLangauge;
		private System.Windows.Forms.ComboBox EditLanguage;
		private System.Windows.Forms.Label LabelUnpacking;
		private System.Windows.Forms.Label LabelOutputPath;
		private System.Windows.Forms.TextBox EditOutputPath;
		private System.Windows.Forms.Button ButtonOutputPath;
		private System.Windows.Forms.Label LabelInnerFolder;
		private System.Windows.Forms.CheckBox EditInnerFolder;
		private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
		private System.Windows.Forms.ToolTip ErrorTooltip;
		private System.Windows.Forms.Label LabelInnerFolders;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.Button ButtonRemove;
		private System.Windows.Forms.ListBox EditInnerFolders;
		private System.Windows.Forms.TextBox DynamicTextBox;

	}
}
