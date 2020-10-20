namespace Mythic.Package.Editor
{
	partial class SettingsDialog
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
			this.SplitMenu = new System.Windows.Forms.SplitContainer();
			this.TreeView = new System.Windows.Forms.TreeView();
			this.SplitContent = new System.Windows.Forms.SplitContainer();
			this.ButtonReset = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonSave = new System.Windows.Forms.Button();
			this.Worker = new System.ComponentModel.BackgroundWorker();
			this.SplitMenu.Panel1.SuspendLayout();
			this.SplitMenu.Panel2.SuspendLayout();
			this.SplitMenu.SuspendLayout();
			this.SplitContent.Panel2.SuspendLayout();
			this.SplitContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitMenu
			// 
			this.SplitMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitMenu.IsSplitterFixed = true;
			this.SplitMenu.Location = new System.Drawing.Point( 0, 0 );
			this.SplitMenu.Name = "SplitMenu";
			// 
			// SplitMenu.Panel1
			// 
			this.SplitMenu.Panel1.Controls.Add( this.TreeView );
			// 
			// SplitMenu.Panel2
			// 
			this.SplitMenu.Panel2.Controls.Add( this.SplitContent );
			this.SplitMenu.Size = new System.Drawing.Size( 594, 293 );
			this.SplitMenu.SplitterDistance = 198;
			this.SplitMenu.TabIndex = 0;
			// 
			// TreeView
			// 
			this.TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.TreeView.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.TreeView.ItemHeight = 18;
			this.TreeView.Location = new System.Drawing.Point( 12, 12 );
			this.TreeView.Name = "TreeView";
			this.TreeView.Size = new System.Drawing.Size( 183, 269 );
			this.TreeView.TabIndex = 0;
			this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.TreeView_AfterSelect );
			// 
			// SplitContent
			// 
			this.SplitContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContent.IsSplitterFixed = true;
			this.SplitContent.Location = new System.Drawing.Point( 0, 0 );
			this.SplitContent.Name = "SplitContent";
			this.SplitContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContent.Panel2
			// 
			this.SplitContent.Panel2.Controls.Add( this.ButtonReset );
			this.SplitContent.Panel2.Controls.Add( this.ButtonCancel );
			this.SplitContent.Panel2.Controls.Add( this.ButtonSave );
			this.SplitContent.Size = new System.Drawing.Size( 392, 293 );
			this.SplitContent.SplitterDistance = 239;
			this.SplitContent.TabIndex = 0;
			// 
			// ButtonReset
			// 
			this.ButtonReset.Image = global::Mythic.Package.Editor.Properties.Resources.Undo;
			this.ButtonReset.Location = new System.Drawing.Point( 3, 10 );
			this.ButtonReset.Name = "ButtonReset";
			this.ButtonReset.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonReset.TabIndex = 2;
			this.ButtonReset.Text = "Reset";
			this.ButtonReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonReset.UseVisualStyleBackColor = true;
			this.ButtonReset.Click += new System.EventHandler( this.ButtonDefault_Click );
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Image = global::Mythic.Package.Editor.Properties.Resources.Close;
			this.ButtonCancel.Location = new System.Drawing.Point( 224, 10 );
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonCancel.TabIndex = 1;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ButtonSave
			// 
			this.ButtonSave.Image = global::Mythic.Package.Editor.Properties.Resources.Save;
			this.ButtonSave.Location = new System.Drawing.Point( 305, 10 );
			this.ButtonSave.Name = "ButtonSave";
			this.ButtonSave.Size = new System.Drawing.Size( 75, 23 );
			this.ButtonSave.TabIndex = 0;
			this.ButtonSave.Text = "Save";
			this.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonSave.UseVisualStyleBackColor = true;
			this.ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
			// 
			// Worker
			// 
			this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.Worker_DoWork );
			this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.Worker_RunWorkerCompleted );
			// 
			// SettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 594, 293 );
			this.Controls.Add( this.SplitMenu );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.SplitMenu.Panel1.ResumeLayout( false );
			this.SplitMenu.Panel2.ResumeLayout( false );
			this.SplitMenu.ResumeLayout( false );
			this.SplitContent.Panel2.ResumeLayout( false );
			this.SplitContent.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.SplitContainer SplitMenu;
		private System.Windows.Forms.SplitContainer SplitContent;
		private System.Windows.Forms.TreeView TreeView;
		private System.Windows.Forms.Button ButtonSave;
		private System.Windows.Forms.Button ButtonReset;
		private System.Windows.Forms.Button ButtonCancel;
		private System.ComponentModel.BackgroundWorker Worker;


	}
}