 using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class FolderSearch : Form
	{
		#region Properties
		public string[] Files
		{
			get
			{
				List<string> list = new List<string>();

				foreach( object o in TextFiles.Items )
				{
					if ( o is string )
						list.Add( (string) o );
				}

				return list.ToArray();
			}
		}

		public string InnerDirectory{ get { return TextInnerDirectory.Text; } }

		public string RootDirectory { get { return TextFiles.Text; } }
		#endregion

		#region Constructors
		public FolderSearch()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			LabelFiles.Text = Globals.LanguageManager.GetString( "AddFile_File" );
			LabelInnerDirectory.Text = Globals.LanguageManager.GetString( "AddFile_InnerDirectory" );

			ButtonCancel.Text = Globals.LanguageManager.GetString( "AddFile_Button_Cancel" );

			TextInnerDirectory.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

			if ( TextInnerDirectory.Items.Count > 0)
				TextInnerDirectory.SelectedIndex = 0;


			InvalidPath.SetToolTip( TextFiles, Globals.LanguageManager.GetString( "AddFile_ToolTip_Title" ) );
		}


		#endregion

		#region Events
		private void ButtonAdd_Click( object sender, EventArgs e )
		{
			try
			{
				Close();
			}
			catch
			{
				InvalidPath.Show( Globals.LanguageManager.GetString( "AddFile_ToolTip_Text" ), this );
			}
		}

		private void ButtonBrowseFile_Click( object sender, EventArgs e )
		{
			// set the root folder for the search
			OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

			// set the open folder description
			OpenFolderDialog.Description = "Select the folder containing the file names to check...";

			if ( OpenFolderDialog.ShowDialog( this ) == DialogResult.OK )
			{
				TextFiles.Items.Clear();
				TextFiles.Items.Add( OpenFolderDialog.SelectedPath );
				TextFiles.SelectedIndex = 0;
			}
		}
		#endregion
	}
}
