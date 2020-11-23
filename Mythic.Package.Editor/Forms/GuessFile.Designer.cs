namespace Mythic.Package.Editor
{
	partial class GuessFile
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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFileHash = new System.Windows.Forms.Label();
            this.lblTypeHash = new System.Windows.Forms.Label();
            this.ttpError = new System.Windows.Forms.ToolTip(this.components);
            this.cmbRelativePath = new System.Windows.Forms.ComboBox();
            this.lblRelativePath = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.btnBrute = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFileName.Location = new System.Drawing.Point(12, 65);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(366, 20);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 49);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(71, 13);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Guess Name:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(9, 165);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(365, 43);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Type the file name. When you type the correct name the dialog will close automati" +
    "cally!";
            // 
            // lblFileHash
            // 
            this.lblFileHash.AutoSize = true;
            this.lblFileHash.Location = new System.Drawing.Point(26, 88);
            this.lblFileHash.Name = "lblFileHash";
            this.lblFileHash.Size = new System.Drawing.Size(54, 13);
            this.lblFileHash.TabIndex = 7;
            this.lblFileHash.Text = "File Hash:";
            // 
            // lblTypeHash
            // 
            this.lblTypeHash.AutoSize = true;
            this.lblTypeHash.Location = new System.Drawing.Point(12, 104);
            this.lblTypeHash.Name = "lblTypeHash";
            this.lblTypeHash.Size = new System.Drawing.Size(68, 13);
            this.lblTypeHash.TabIndex = 8;
            this.lblTypeHash.Text = "Typed Hash:";
            // 
            // ttpError
            // 
            this.ttpError.IsBalloon = true;
            this.ttpError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // cmbRelativePath
            // 
            this.cmbRelativePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbRelativePath.FormattingEnabled = true;
            this.cmbRelativePath.Location = new System.Drawing.Point(89, 11);
            this.cmbRelativePath.MaxDropDownItems = 30;
            this.cmbRelativePath.Name = "cmbRelativePath";
            this.cmbRelativePath.Size = new System.Drawing.Size(289, 21);
            this.cmbRelativePath.TabIndex = 10;
            // 
            // lblRelativePath
            // 
            this.lblRelativePath.Location = new System.Drawing.Point(-17, 9);
            this.lblRelativePath.Name = "lblRelativePath";
            this.lblRelativePath.Size = new System.Drawing.Size(100, 23);
            this.lblRelativePath.TabIndex = 9;
            this.lblRelativePath.Text = "Inner directory:";
            this.lblRelativePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(89, 33);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(80, 17);
            this.chkShowAll.TabIndex = 11;
            this.chkShowAll.Text = "checkBox1";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // btnBrute
            // 
            this.btnBrute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrute.Enabled = false;
            this.btnBrute.Image = global::Mythic.Package.Editor.Properties.Resources.Wrench;
            this.btnBrute.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrute.Location = new System.Drawing.Point(285, 128);
            this.btnBrute.Name = "btnBrute";
            this.btnBrute.Size = new System.Drawing.Size(89, 25);
            this.btnBrute.TabIndex = 5;
            this.btnBrute.Text = "Bruteforce";
            this.btnBrute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrute.UseVisualStyleBackColor = true;
            this.btnBrute.Click += new System.EventHandler(this.btnBrute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(204, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // GuessFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(386, 211);
            this.Controls.Add(this.chkShowAll);
            this.Controls.Add(this.cmbRelativePath);
            this.Controls.Add(this.lblRelativePath);
            this.Controls.Add(this.lblTypeHash);
            this.Controls.Add(this.lblFileHash);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBrute);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuessFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Guess File Name";
            this.Shown += new System.EventHandler(this.GuessFile_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnBrute;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFileHash;
        private System.Windows.Forms.Label lblTypeHash;
        private System.Windows.Forms.ToolTip ttpError;
        private System.Windows.Forms.ComboBox cmbRelativePath;
        private System.Windows.Forms.Label lblRelativePath;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.ToolTip ttp;
    }
}