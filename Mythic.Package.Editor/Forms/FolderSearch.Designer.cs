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
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblRelativePath = new System.Windows.Forms.Label();
            this.cmbRelativePath = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.InvalidPath = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(12, 9);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(100, 23);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "Root folder to use:";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRelativePath
            // 
            this.lblRelativePath.Location = new System.Drawing.Point(12, 36);
            this.lblRelativePath.Name = "lblRelativePath";
            this.lblRelativePath.Size = new System.Drawing.Size(100, 23);
            this.lblRelativePath.TabIndex = 4;
            this.lblRelativePath.Text = "Inner directory:";
            this.lblRelativePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRelativePath
            // 
            this.cmbRelativePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRelativePath.FormattingEnabled = true;
            this.cmbRelativePath.Location = new System.Drawing.Point(118, 38);
            this.cmbRelativePath.MaxDropDownItems = 30;
            this.cmbRelativePath.Name = "cmbRelativePath";
            this.cmbRelativePath.Size = new System.Drawing.Size(289, 21);
            this.cmbRelativePath.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(363, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnParse
            // 
            this.btnParse.Image = global::Mythic.Package.Editor.Properties.Resources.Search;
            this.btnParse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnParse.Location = new System.Drawing.Point(282, 86);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 25);
            this.btnParse.TabIndex = 9;
            this.btnParse.Text = "Parse";
            this.btnParse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnOK_Click);
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
            // OpenFolderDialog
            // 
            this.OpenFolderDialog.ShowNewFolderButton = false;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
            this.btnBrowseFolder.Location = new System.Drawing.Point(413, 9);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseFolder.TabIndex = 13;
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(118, 11);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(289, 20);
            this.txtFolder.TabIndex = 14;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(118, 65);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(80, 17);
            this.chkShowAll.TabIndex = 15;
            this.chkShowAll.Text = "checkBox1";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // FolderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(453, 119);
            this.Controls.Add(this.chkShowAll);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbRelativePath);
            this.Controls.Add(this.lblRelativePath);
            this.Controls.Add(this.lblFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folder Search";
            this.Shown += new System.EventHandler(this.FolderSearch_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblRelativePath;
        private System.Windows.Forms.ComboBox cmbRelativePath;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolTip InvalidPath;
        private System.Windows.Forms.FolderBrowserDialog OpenFolderDialog;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.ToolTip ttp;
    }
}