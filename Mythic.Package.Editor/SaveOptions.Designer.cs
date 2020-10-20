namespace Mythic.Package.Editor
{
	partial class SaveOptions
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
			this.LabelDestination = new System.Windows.Forms.Label();
			this.TextDestination = new System.Windows.Forms.TextBox();
			this.ButtonBrowse = new System.Windows.Forms.Button();
			this.LabelReleaseDate = new System.Windows.Forms.Label();
			this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonSave = new System.Windows.Forms.Button();
			this.InvalidPath = new System.Windows.Forms.ToolTip( this.components );
			this.SavePackageDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// LabelDestination
			// 
			this.LabelDestination.Location = new System.Drawing.Point( 12, 9 );
			this.LabelDestination.Name = "LabelDestination";
			this.LabelDestination.Size = new System.Drawing.Size( 100, 23 );
			this.LabelDestination.TabIndex = 0;
			this.LabelDestination.Text = "Destination:";
			this.LabelDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextDestination
			// 
			this.TextDestination.Location = new System.Drawing.Point( 118, 11 );
			this.TextDestination.Name = "TextDestination";
			this.TextDestination.Size = new System.Drawing.Size( 289, 20 );
			this.TextDestination.TabIndex = 1;
			// 
			// ButtonBrowse
			// 
			this.ButtonBrowse.Image = global::Mythic.Package.Editor.Properties.Resources.Folder;
			this.ButtonBrowse.Location = new System.Drawing.Point( 413, 9 );
			this.ButtonBrowse.Name = "ButtonBrowse";
			this.ButtonBrowse.Size = new System.Drawing.Size( 25, 23 );
			this.ButtonBrowse.TabIndex = 2;
			this.ButtonBrowse.UseVisualStyleBackColor = true;
			this.ButtonBrowse.Click += new System.EventHandler( this.ButtonBrowse_Click );
			// 
			// LabelReleaseDate
			// 
			this.LabelReleaseDate.Location = new System.Drawing.Point( 12, 36 );
			this.LabelReleaseDate.Name = "LabelReleaseDate";
			this.LabelReleaseDate.Size = new System.Drawing.Size( 100, 23 );
			this.LabelReleaseDate.TabIndex = 3;
			this.LabelReleaseDate.Text = "Release date:";
			this.LabelReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DateTimePicker
			// 
			this.DateTimePicker.Location = new System.Drawing.Point( 118, 37 );
			this.DateTimePicker.Name = "DateTimePicker";
			this.DateTimePicker.Size = new System.Drawing.Size( 220, 20 );
			this.DateTimePicker.TabIndex = 4;
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
			this.ButtonCancel.Location = new System.Drawing.Point( 363, 75 );
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonCancel.TabIndex = 5;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ButtonSave
			// 
			this.ButtonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonSave.Image = global::Mythic.Package.Editor.Properties.Resources.Save;
			this.ButtonSave.Location = new System.Drawing.Point( 282, 75 );
			this.ButtonSave.Name = "ButtonSave";
			this.ButtonSave.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonSave.TabIndex = 6;
			this.ButtonSave.Text = "Save";
			this.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonSave.UseVisualStyleBackColor = true;
			this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
			// 
			// InvalidPath
			// 
			this.InvalidPath.IsBalloon = true;
			this.InvalidPath.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
			// 
			// SavePackageDialog
			// 
			this.SavePackageDialog.DefaultExt = "*.uop";
			this.SavePackageDialog.Filter = "Mythic Package files|*.uop";
			// 
			// SaveOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size( 450, 110 );
			this.Controls.Add( this.ButtonSave );
			this.Controls.Add( this.ButtonCancel );
			this.Controls.Add( this.DateTimePicker );
			this.Controls.Add( this.LabelReleaseDate );
			this.Controls.Add( this.ButtonBrowse );
			this.Controls.Add( this.TextDestination );
			this.Controls.Add( this.LabelDestination );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save Options";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelDestination;
		private System.Windows.Forms.TextBox TextDestination;
		private System.Windows.Forms.Button ButtonBrowse;
		private System.Windows.Forms.Label LabelReleaseDate;
		private System.Windows.Forms.DateTimePicker DateTimePicker;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonSave;
		private System.Windows.Forms.ToolTip InvalidPath;
		private System.Windows.Forms.SaveFileDialog SavePackageDialog;

	}
}