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
			this.LabelFiles = new System.Windows.Forms.Label();
			this.ButtonBrowseFolder = new System.Windows.Forms.Button();
			this.LabelCompression = new System.Windows.Forms.Label();
			this.TextCompression = new System.Windows.Forms.ComboBox();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonAdd = new System.Windows.Forms.Button();
			this.InvalidFolder = new System.Windows.Forms.ToolTip( this.components );
			this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.TextFolder = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// LabelFiles
			// 
			this.LabelFiles.Location = new System.Drawing.Point( 12, 9 );
			this.LabelFiles.Name = "LabelFiles";
			this.LabelFiles.Size = new System.Drawing.Size( 100, 23 );
			this.LabelFiles.TabIndex = 0;
			this.LabelFiles.Text = "Files to add:";
			this.LabelFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ButtonBrowseFolder
			// 
			this.ButtonBrowseFolder.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
			this.ButtonBrowseFolder.Location = new System.Drawing.Point( 413, 9 );
			this.ButtonBrowseFolder.Name = "ButtonBrowseFolder";
			this.ButtonBrowseFolder.Size = new System.Drawing.Size( 25, 23 );
			this.ButtonBrowseFolder.TabIndex = 3;
			this.ButtonBrowseFolder.UseVisualStyleBackColor = true;
			this.ButtonBrowseFolder.Click += new System.EventHandler( this.ButtonBrowseFolder_Click );
			// 
			// LabelCompression
			// 
			this.LabelCompression.Location = new System.Drawing.Point( 12, 35 );
			this.LabelCompression.Name = "LabelCompression";
			this.LabelCompression.Size = new System.Drawing.Size( 100, 23 );
			this.LabelCompression.TabIndex = 6;
			this.LabelCompression.Text = "Compression:";
			this.LabelCompression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextCompression
			// 
			this.TextCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TextCompression.FormattingEnabled = true;
			this.TextCompression.Location = new System.Drawing.Point( 118, 37 );
			this.TextCompression.Name = "TextCompression";
			this.TextCompression.Size = new System.Drawing.Size( 121, 21 );
			this.TextCompression.TabIndex = 7;
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
			this.ButtonCancel.Location = new System.Drawing.Point( 363, 64 );
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonCancel.TabIndex = 8;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
			this.ButtonAdd.Location = new System.Drawing.Point( 282, 64 );
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonAdd.TabIndex = 9;
			this.ButtonAdd.Text = "Add";
			this.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonAdd.UseVisualStyleBackColor = true;
			this.ButtonAdd.Click += new System.EventHandler( this.ButtonAdd_Click );
			// 
			// InvalidFolder
			// 
			this.InvalidFolder.IsBalloon = true;
			this.InvalidFolder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
			// 
			// OpenFolderDialog
			// 
			this.OpenFolderDialog.ShowNewFolderButton = false;
			// 
			// TextFolder
			// 
			this.TextFolder.Location = new System.Drawing.Point( 118, 11 );
			this.TextFolder.Name = "TextFolder";
			this.TextFolder.Size = new System.Drawing.Size( 289, 20 );
			this.TextFolder.TabIndex = 10;
			// 
			// AddFolder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size( 454, 103 );
			this.Controls.Add( this.TextFolder );
			this.Controls.Add( this.ButtonAdd );
			this.Controls.Add( this.ButtonCancel );
			this.Controls.Add( this.TextCompression );
			this.Controls.Add( this.LabelCompression );
			this.Controls.Add( this.ButtonBrowseFolder );
			this.Controls.Add( this.LabelFiles );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddFolder";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Folder";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelFiles;
		private System.Windows.Forms.Button ButtonBrowseFolder;
		private System.Windows.Forms.Label LabelCompression;
		private System.Windows.Forms.ComboBox TextCompression;
		private System.Windows.Forms.Button ButtonAdd;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.ToolTip InvalidFolder;
		private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
		private System.Windows.Forms.TextBox TextFolder;
	}
}