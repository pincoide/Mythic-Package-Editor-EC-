namespace Mythic.Package.Editor
{
	partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.LightGreen;
            this.lblProgress.Location = new System.Drawing.Point(12, 57);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(66, 16);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Loading...";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.Red;
            this.lblDetails.Location = new System.Drawing.Point(84, 57);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(58, 16);
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "(Details)";
            this.lblDetails.Visible = false;
            this.lblDetails.Click += new System.EventHandler(this.Details_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mythic.Package.Editor.Properties.Resources.Splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(640, 365);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mythic Package Editor";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblDetails;
	}
}