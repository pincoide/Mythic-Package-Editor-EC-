 using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class AddFile : Form
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

		/// <summary>
		/// Relative path of the file(s) to add/replace
		/// </summary>
		public string InnerDirectory{ get { return TextInnerDirectory.Text; } set { TextInnerDirectory.Text = value; } }

		/// <summary>
		/// Type of compression to use for the file(s)
		/// </summary>
		public CompressionFlag Compression{ get { return (CompressionFlag) TextCompression.SelectedIndex; } set { TextCompression.SelectedIndex = TextCompression.Items.IndexOf( value.ToString() ); } }

		/// <summary>
		/// Set if the file browse should allow multiple files selection
		/// </summary>
		public bool MultiFileSelect { get { return OpenFileDialog.Multiselect; } set { OpenFileDialog.Multiselect = value; } }
		#endregion

		#region Constructors
		public AddFile()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "AddFile_Title" );

			LabelFiles.Text = Globals.LanguageManager.GetString( "AddFile_File" );
			LabelInnerDirectory.Text = Globals.LanguageManager.GetString( "AddFile_InnerDirectory" );
			LabelCompression.Text = Globals.LanguageManager.GetString( "AddFile_Compression" );

			ButtonCancel.Text = Globals.LanguageManager.GetString( "AddFile_Button_Cancel" );
			ButtonAdd.Text = Globals.LanguageManager.GetString( "AddFile_Button_Add" );

			OpenFileDialog.Title = Globals.LanguageManager.GetString( "AddFile_Dialog_Title" );

			TextInnerDirectory.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

			if ( TextInnerDirectory.Items.Count > 0 )
				TextInnerDirectory.SelectedIndex = 0;

			TextCompression.Items.AddRange( Enum.GetNames( typeof( CompressionFlag ) ) );
			TextCompression.SelectedIndex = 0;

			InvalidPath.SetToolTip( TextFiles, Globals.LanguageManager.GetString( "AddFile_ToolTip_Title" ) );
		}

		private bool CheckFiles()
		{
			foreach ( object o in TextFiles.Items )
			{
				string file = o as string;

				if ( file == null || !File.Exists( file ) )
					return false;
			}

			return true;
		}
		#endregion

		#region Events
		private void ButtonAdd_Click( object sender, EventArgs e )
		{
			try
			{
				if ( CheckFiles() )
					Close();
				else
					InvalidPath.Show( Globals.LanguageManager.GetString( "AddFile_ToolTip_Text" ), this );
			}
			catch
			{
				InvalidPath.Show( Globals.LanguageManager.GetString( "AddFile_ToolTip_Text" ), this );
			}
		}

		private void ButtonBrowseFile_Click( object sender, EventArgs e )
		{
			if ( OpenFileDialog.ShowDialog( this ) == DialogResult.OK )
			{
				TextFiles.Items.Clear();
				TextFiles.Items.AddRange( OpenFileDialog.FileNames );

				if ( TextFiles.Items.Count > 0 )
					TextFiles.SelectedIndex = 0;
			}
		}
		#endregion
	}
}
