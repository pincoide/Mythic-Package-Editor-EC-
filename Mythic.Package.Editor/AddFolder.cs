 using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class AddFolder : Form
	{
		#region Properties
		public string Folder
		{
			get
			{
				return TextFolder.Text;
			}
		}

		public CompressionFlag Compression
		{
			get
			{
				return (CompressionFlag) TextCompression.SelectedIndex;
			}
		}
		#endregion

		#region Constructors
		public AddFolder()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "AddFolder_Title" );

			LabelFiles.Text = Globals.LanguageManager.GetString( "AddFolder_File" );
			LabelCompression.Text = Globals.LanguageManager.GetString( "AddFolder_Compression" );

			ButtonCancel.Text = Globals.LanguageManager.GetString( "AddFolder_Button_Cancel" );
			ButtonAdd.Text = Globals.LanguageManager.GetString( "AddFolder_Button_Add" );

			TextCompression.Items.AddRange( Enum.GetNames( typeof( CompressionFlag ) ) );
			TextCompression.SelectedIndex = 0;

			InvalidFolder.SetToolTip( TextFolder, Globals.LanguageManager.GetString( "AddFile_ToolTip_Title" ) );
		}

		private bool CheckDirectory()
		{
			return Directory.Exists( TextFolder.Text );
		}
		#endregion

		#region Events
		private void ButtonAdd_Click( object sender, EventArgs e )
		{
			try
			{
				if ( CheckDirectory() )
					Close();
				else
					InvalidFolder.Show( Globals.LanguageManager.GetString( "AddFolder_ToolTip_Text" ), this );
			}
			catch
			{
				InvalidFolder.Show( Globals.LanguageManager.GetString( "AddFolder_ToolTip_Text" ), this );
			}
		}

		private void ButtonBrowseFolder_Click( object sender, EventArgs e )
		{
			if ( OpenFolderDialog.ShowDialog( this ) == DialogResult.OK )
				TextFolder.Text = OpenFolderDialog.SelectedPath;
		}
		#endregion
	}
}
