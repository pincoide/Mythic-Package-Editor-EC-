namespace Mythic.Package.Editor
{
	partial class AddFile
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
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblRelativePath = new System.Windows.Forms.Label();
            this.cmbRelativePath = new System.Windows.Forms.ComboBox();
            this.lblCompression = new System.Windows.Forms.Label();
            this.cmbCompression = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ttpError = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.ttpBase = new System.Windows.Forms.ToolTip(this.components);
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblFiles
            // 
            this.lblFiles.Location = new System.Drawing.Point(12, 9);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(100, 23);
            this.lblFiles.TabIndex = 0;
            this.lblFiles.Text = "Files to add:";
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRelativePath
            // 
            this.lblRelativePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRelativePath.Location = new System.Drawing.Point(12, 41);
            this.lblRelativePath.Name = "lblRelativePath";
            this.lblRelativePath.Size = new System.Drawing.Size(100, 23);
            this.lblRelativePath.TabIndex = 4;
            this.lblRelativePath.Text = "Inner directory:";
            this.lblRelativePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRelativePath
            // 
            this.cmbRelativePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbRelativePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRelativePath.FormattingEnabled = true;
            this.cmbRelativePath.Location = new System.Drawing.Point(118, 43);
            this.cmbRelativePath.MaxDropDownItems = 30;
            this.cmbRelativePath.Name = "cmbRelativePath";
            this.cmbRelativePath.Size = new System.Drawing.Size(289, 21);
            this.cmbRelativePath.TabIndex = 5;
            // 
            // lblCompression
            // 
            this.lblCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompression.Location = new System.Drawing.Point(12, 88);
            this.lblCompression.Name = "lblCompression";
            this.lblCompression.Size = new System.Drawing.Size(100, 23);
            this.lblCompression.TabIndex = 6;
            this.lblCompression.Text = "Compression:";
            this.lblCompression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCompression
            // 
            this.cmbCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompression.FormattingEnabled = true;
            this.cmbCompression.Location = new System.Drawing.Point(118, 90);
            this.cmbCompression.Name = "cmbCompression";
            this.cmbCompression.Size = new System.Drawing.Size(121, 21);
            this.cmbCompression.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(390, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.Location = new System.Drawing.Point(332, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Add";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.CheckFileExists = false;
            this.OpenFileDialog.DefaultExt = "*.*";
            this.OpenFileDialog.Filter = "All files|*.*";
            this.OpenFileDialog.Multiselect = true;
            // 
            // ttpError
            // 
            this.ttpError.IsBalloon = true;
            this.ttpError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // OpenFolderDialog
            // 
            this.OpenFolderDialog.ShowNewFolderButton = false;
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnBrowseFile.Location = new System.Drawing.Point(413, 12);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseFile.TabIndex = 13;
            this.ttpBase.SetToolTip(this.btnBrowseFile, "Add files");
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(118, 12);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(289, 17);
            this.lstFiles.TabIndex = 14;
            this.lstFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFiles_DrawItem);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = global::Mythic.Package.Editor.Properties.Resources.Remove;
            this.btnDeleteFile.Location = new System.Drawing.Point(442, 12);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(25, 23);
            this.btnDeleteFile.TabIndex = 15;
            this.ttpBase.SetToolTip(this.btnDeleteFile, "Delete selected file");
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // chkShowAll
            // 
            this.chkShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(118, 67);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(80, 17);
            this.chkShowAll.TabIndex = 16;
            this.chkShowAll.Text = "checkBox1";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(480, 141);
            this.Controls.Add(this.chkShowAll);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbCompression);
            this.Controls.Add(this.lblCompression);
            this.Controls.Add(this.cmbRelativePath);
            this.Controls.Add(this.lblRelativePath);
            this.Controls.Add(this.lblFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add File";
            this.Shown += new System.EventHandler(this.AddFile_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFiles;
		private System.Windows.Forms.Label lblRelativePath;
		private System.Windows.Forms.ComboBox cmbRelativePath;
		private System.Windows.Forms.Label lblCompression;
		private System.Windows.Forms.ComboBox cmbCompression;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.ToolTip ttpError;
		private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
		private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.ToolTip ttpBase;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.ToolTip ttp;
    }
}