namespace Mythic.Package.Editor
{
	partial class AddFolder
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
            this.lblFolder = new System.Windows.Forms.Label();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.lblCompression = new System.Windows.Forms.Label();
            this.cmbCompression = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ttpError = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(12, 9);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(100, 23);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "Folder:";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.btnBrowseFolder.Location = new System.Drawing.Point(413, 9);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseFolder.TabIndex = 3;
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // lblCompression
            // 
            this.lblCompression.Location = new System.Drawing.Point(12, 35);
            this.lblCompression.Name = "lblCompression";
            this.lblCompression.Size = new System.Drawing.Size(100, 23);
            this.lblCompression.TabIndex = 6;
            this.lblCompression.Text = "Compression:";
            this.lblCompression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCompression
            // 
            this.cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompression.FormattingEnabled = true;
            this.cmbCompression.Location = new System.Drawing.Point(118, 37);
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
            this.btnCancel.Location = new System.Drawing.Point(363, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.Location = new System.Drawing.Point(282, 64);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Add";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(118, 11);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(289, 20);
            this.txtFolder.TabIndex = 10;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // AddFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(454, 103);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbCompression);
            this.Controls.Add(this.lblCompression);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.lblFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFolder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFolder;
		private System.Windows.Forms.Button btnBrowseFolder;
		private System.Windows.Forms.Label lblCompression;
		private System.Windows.Forms.ComboBox cmbCompression;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolTip ttpError;
		private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
		private System.Windows.Forms.TextBox txtFolder;
	}
}