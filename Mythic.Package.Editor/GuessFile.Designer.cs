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
			this.FileName = new System.Windows.Forms.TextBox();
			this.ButtonCheck = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.Status = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// FileName
			// 
			this.FileName.Location = new System.Drawing.Point( 12, 12 );
			this.FileName.Name = "FileName";
			this.FileName.Size = new System.Drawing.Size( 350, 20 );
			this.FileName.TabIndex = 0;
			this.FileName.KeyDown += new System.Windows.Forms.KeyEventHandler( this.FileName_KeyDown );
			// 
			// ButtonCheck
			// 
			this.ButtonCheck.Image = global::Mythic.Package.Editor.Properties.Resources.Guess;
			this.ButtonCheck.Location = new System.Drawing.Point( 287, 38 );
			this.ButtonCheck.Name = "ButtonCheck";
			this.ButtonCheck.Size = new System.Drawing.Size( 75, 25 );
			this.ButtonCheck.TabIndex = 1;
			this.ButtonCheck.Text = "Check";
			this.ButtonCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCheck.UseVisualStyleBackColor = true;
			this.ButtonCheck.Click += new System.EventHandler( this.Check_Click );
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
			this.ButtonCancel.Location = new System.Drawing.Point( 206, 38 );
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size( 75, 25 );
			this.ButtonCancel.TabIndex = 2;
			this.ButtonCancel.Text = "Close";
			this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// Status
			// 
			this.Status.AutoSize = true;
			this.Status.Location = new System.Drawing.Point( 12, 44 );
			this.Status.Name = "Status";
			this.Status.Size = new System.Drawing.Size( 0, 13 );
			this.Status.TabIndex = 3;
			// 
			// GuessFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 374, 68 );
			this.Controls.Add( this.Status );
			this.Controls.Add( this.ButtonCancel );
			this.Controls.Add( this.ButtonCheck );
			this.Controls.Add( this.FileName );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GuessFile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Guess File Name";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox FileName;
		private System.Windows.Forms.Button ButtonCheck;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Label Status;
	}
}