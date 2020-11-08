namespace Mythic.Package.Editor
{
    partial class FolderSearch
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
            this.LabelInnerDirectory = new System.Windows.Forms.Label();
            this.TextInnerDirectory = new System.Windows.Forms.ComboBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InvalidPath = new System.Windows.Forms.ToolTip(this.components);
            this.TextFiles = new System.Windows.Forms.ComboBox();
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ButtonBrowseFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelFiles
            // 
            this.LabelFiles.Location = new System.Drawing.Point(12, 9);
            this.LabelFiles.Name = "LabelFiles";
            this.LabelFiles.Size = new System.Drawing.Size(100, 23);
            this.LabelFiles.TabIndex = 0;
            this.LabelFiles.Text = "Root folder to use:";
            this.LabelFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelInnerDirectory
            // 
            this.LabelInnerDirectory.Location = new System.Drawing.Point(12, 36);
            this.LabelInnerDirectory.Name = "LabelInnerDirectory";
            this.LabelInnerDirectory.Size = new System.Drawing.Size(100, 23);
            this.LabelInnerDirectory.TabIndex = 4;
            this.LabelInnerDirectory.Text = "Inner directory:";
            this.LabelInnerDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextInnerDirectory
            // 
            this.TextInnerDirectory.FormattingEnabled = true;
            this.TextInnerDirectory.Location = new System.Drawing.Point(118, 38);
            this.TextInnerDirectory.MaxDropDownItems = 30;
            this.TextInnerDirectory.Name = "TextInnerDirectory";
            this.TextInnerDirectory.Size = new System.Drawing.Size(289, 21);
            this.TextInnerDirectory.TabIndex = 5;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.ButtonCancel.Location = new System.Drawing.Point(363, 73);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonAdd.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.ButtonAdd.Location = new System.Drawing.Point(282, 73);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 9;
            this.ButtonAdd.Text = "Parse";
            this.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.CheckFileExists = false;
            this.OpenFileDialog.DefaultExt = "*.*";
            this.OpenFileDialog.Filter = "All files|*.*";
            this.OpenFileDialog.Multiselect = true;
            // 
            // InvalidPath
            // 
            this.InvalidPath.IsBalloon = true;
            this.InvalidPath.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // TextFiles
            // 
            this.TextFiles.FormattingEnabled = true;
            this.TextFiles.Location = new System.Drawing.Point(118, 11);
            this.TextFiles.Name = "TextFiles";
            this.TextFiles.Size = new System.Drawing.Size(289, 21);
            this.TextFiles.TabIndex = 12;
            // 
            // OpenFolderDialog
            // 
            this.OpenFolderDialog.ShowNewFolderButton = false;
            // 
            // ButtonBrowseFile
            // 
            this.ButtonBrowseFile.Image = global::Mythic.Package.Editor.Properties.Resources.New;
            this.ButtonBrowseFile.Location = new System.Drawing.Point(413, 9);
            this.ButtonBrowseFile.Name = "ButtonBrowseFile";
            this.ButtonBrowseFile.Size = new System.Drawing.Size(25, 23);
            this.ButtonBrowseFile.TabIndex = 13;
            this.ButtonBrowseFile.UseVisualStyleBackColor = true;
            this.ButtonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // FolderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(453, 107);
            this.Controls.Add(this.ButtonBrowseFile);
            this.Controls.Add(this.TextFiles);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextInnerDirectory);
            this.Controls.Add(this.LabelInnerDirectory);
            this.Controls.Add(this.LabelFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folder Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelFiles;
        private System.Windows.Forms.Label LabelInnerDirectory;
        private System.Windows.Forms.ComboBox TextInnerDirectory;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolTip InvalidPath;
        private System.Windows.Forms.ComboBox TextFiles;
        private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
        private System.Windows.Forms.Button ButtonBrowseFile;
    }
}