namespace Mythic.Package.Editor
{
	partial class SettingsDialog
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstInnerFolders = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblInnerFolders = new System.Windows.Forms.Label();
            this.chkInnerFolder = new System.Windows.Forms.CheckBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.lblUnpacking = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblCurrentLangauge = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.ttpError = new System.Windows.Forms.ToolTip(this.components);
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDynamic = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Image = global::Mythic.Package.Editor.Properties.Resources.Undo;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReset.Location = new System.Drawing.Point(91, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(222, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Mythic.Package.Editor.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(303, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // lstInnerFolders
            // 
            this.lstInnerFolders.FormattingEnabled = true;
            this.lstInnerFolders.Location = new System.Drawing.Point(174, 141);
            this.lstInnerFolders.Name = "lstInnerFolders";
            this.lstInnerFolders.Size = new System.Drawing.Size(175, 69);
            this.lstInnerFolders.Sorted = true;
            this.lstInnerFolders.TabIndex = 26;
            this.lstInnerFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstInnerFolders_KeyDown);
            this.lstInnerFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstInnerFolders_DoubleClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnRemove.Location = new System.Drawing.Point(355, 170);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 23);
            this.btnRemove.TabIndex = 25;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(355, 141);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblInnerFolders
            // 
            this.lblInnerFolders.Location = new System.Drawing.Point(16, 142);
            this.lblInnerFolders.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblInnerFolders.Name = "lblInnerFolders";
            this.lblInnerFolders.Size = new System.Drawing.Size(150, 20);
            this.lblInnerFolders.TabIndex = 23;
            this.lblInnerFolders.Text = "Inner folders:";
            this.lblInnerFolders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkInnerFolder
            // 
            this.chkInnerFolder.AutoSize = true;
            this.chkInnerFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInnerFolder.Location = new System.Drawing.Point(45, 118);
            this.chkInnerFolder.Name = "chkInnerFolder";
            this.chkInnerFolder.Size = new System.Drawing.Size(144, 17);
            this.chkInnerFolder.TabIndex = 22;
            this.chkInnerFolder.Text = "Unpack with inner folder:";
            this.chkInnerFolder.UseVisualStyleBackColor = true;
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.btnOutputPath.Location = new System.Drawing.Point(355, 91);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(23, 23);
            this.btnOutputPath.TabIndex = 20;
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(174, 93);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(175, 20);
            this.txtOutputPath.TabIndex = 19;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.Location = new System.Drawing.Point(16, 92);
            this.lblOutputPath.Margin = new System.Windows.Forms.Padding(5);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(150, 20);
            this.lblOutputPath.TabIndex = 18;
            this.lblOutputPath.Text = "Unpack in:";
            this.lblOutputPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUnpacking
            // 
            this.lblUnpacking.AutoSize = true;
            this.lblUnpacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnpacking.Location = new System.Drawing.Point(13, 71);
            this.lblUnpacking.Margin = new System.Windows.Forms.Padding(5, 10, 5, 3);
            this.lblUnpacking.Name = "lblUnpacking";
            this.lblUnpacking.Size = new System.Drawing.Size(68, 13);
            this.lblUnpacking.TabIndex = 17;
            this.lblUnpacking.Text = "Unpacking";
            this.lblUnpacking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(174, 37);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 16;
            // 
            // lblCurrentLangauge
            // 
            this.lblCurrentLangauge.Location = new System.Drawing.Point(16, 36);
            this.lblCurrentLangauge.Margin = new System.Windows.Forms.Padding(5);
            this.lblCurrentLangauge.Name = "lblCurrentLangauge";
            this.lblCurrentLangauge.Size = new System.Drawing.Size(150, 20);
            this.lblCurrentLangauge.TabIndex = 15;
            this.lblCurrentLangauge.Text = "Current language:";
            this.lblCurrentLangauge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(13, 15);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(5, 10, 5, 3);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(63, 13);
            this.lblLanguage.TabIndex = 14;
            this.lblLanguage.Text = "Language";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpError
            // 
            this.ttpError.IsBalloon = true;
            this.ttpError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            // 
            // txtDynamic
            // 
            this.txtDynamic.BackColor = System.Drawing.SystemColors.Info;
            this.txtDynamic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDynamic.Location = new System.Drawing.Point(199, 122);
            this.txtDynamic.Name = "txtDynamic";
            this.txtDynamic.Size = new System.Drawing.Size(0, 20);
            this.txtDynamic.TabIndex = 27;
            this.txtDynamic.Visible = false;
            this.txtDynamic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDynamic_KeyDown);
            this.txtDynamic.Leave += new System.EventHandler(this.txtDynamic_LostFocus);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 264);
            this.Controls.Add(this.txtDynamic);
            this.Controls.Add(this.lstInnerFolders);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblInnerFolders);
            this.Controls.Add(this.chkInnerFolder);
            this.Controls.Add(this.btnOutputPath);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.lblOutputPath);
            this.Controls.Add(this.lblUnpacking);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblCurrentLangauge);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstInnerFolders;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblInnerFolders;
        private System.Windows.Forms.CheckBox chkInnerFolder;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.Label lblUnpacking;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblCurrentLangauge;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ToolTip ttpError;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.TextBox txtDynamic;
    }
}