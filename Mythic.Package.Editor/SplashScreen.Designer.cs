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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SplashScreen ) );
			this.ProgressText = new System.Windows.Forms.Label();
			this.DetailsText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ProgressText
			// 
			this.ProgressText.AutoSize = true;
			this.ProgressText.BackColor = System.Drawing.Color.Transparent;
			this.ProgressText.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.ProgressText.ForeColor = System.Drawing.Color.LightGreen;
			this.ProgressText.Location = new System.Drawing.Point( 12, 57 );
			this.ProgressText.Name = "ProgressText";
			this.ProgressText.Size = new System.Drawing.Size( 66, 16 );
			this.ProgressText.TabIndex = 0;
			this.ProgressText.Text = "Loading...";
			// 
			// DetailsText
			// 
			this.DetailsText.AutoSize = true;
			this.DetailsText.BackColor = System.Drawing.Color.Transparent;
			this.DetailsText.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DetailsText.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.DetailsText.ForeColor = System.Drawing.Color.Red;
			this.DetailsText.Location = new System.Drawing.Point( 84, 57 );
			this.DetailsText.Name = "DetailsText";
			this.DetailsText.Size = new System.Drawing.Size( 58, 16 );
			this.DetailsText.TabIndex = 1;
			this.DetailsText.Text = "(Details)";
			this.DetailsText.Visible = false;
			this.DetailsText.Click += new System.EventHandler( this.Details_Click );
			// 
			// SplashScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Mythic.Package.Editor.Properties.Resources.Splash;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size( 640, 365 );
			this.Controls.Add( this.DetailsText );
			this.Controls.Add( this.ProgressText );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "SplashScreen";
			this.Opacity = 0;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mythic Package Editor";
			this.TopMost = true;
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ProgressText;
		private System.Windows.Forms.Label DetailsText;
	}
}