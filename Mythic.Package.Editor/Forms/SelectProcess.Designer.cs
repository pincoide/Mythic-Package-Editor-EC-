namespace Mythic.Package.Editor
{
	partial class SelectProcess
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
            this.lstProcess = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProcess
            // 
            this.lstProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstProcess.FormattingEnabled = true;
            this.lstProcess.HorizontalScrollbar = true;
            this.lstProcess.Location = new System.Drawing.Point(0, 0);
            this.lstProcess.Name = "lstProcess";
            this.lstProcess.Size = new System.Drawing.Size(276, 329);
            this.lstProcess.TabIndex = 0;
            this.lstProcess.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstProcess_MouseDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(8, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::Mythic.Package.Editor.Properties.Resources.Add;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.Location = new System.Drawing.Point(184, 335);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Okay";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Mythic.Package.Editor.Properties.Resources.Merge;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRefresh.Location = new System.Drawing.Point(96, 335);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // SelectProcess
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(276, 366);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectProcess";
            this.Text = "Select Process";
            this.Shown += new System.EventHandler(this.SelectProcess_Shown);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lstProcess;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRefresh;
	}
}