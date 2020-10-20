using System;
using System.Windows.Forms;

using Mythic.Package;

namespace Mythic.Package.Editor
{
	public partial class GuessFile : Form
	{
		private MythicPackageFile m_File;

		#region Constructors
		public GuessFile( MythicPackageFile file )
		{
			m_File = file;

			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "GuessFileDialog_Title" );

			ButtonCheck.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Check" );
			ButtonCancel.Text = Globals.LanguageManager.GetString( "GuessFileDialog_Button_Cancel" );
		}

		private void CheckName()
		{
			if ( m_File != null )
			{
				string fileName = FileName.Text.ToLower();
                //FileName.Text = HashDictionary.HashFileName(fileName).ToString("X16");

				if ( m_File.FileHash == HashDictionary.HashFileName( fileName ) )
				{
					HashDictionary.Set( m_File.FileHash, fileName );
					m_File.RefreshFileName();

					Close();
				}
				else
					Status.Text = Globals.LanguageManager.GetString( "GuessFileDialog_InvalidName" );
                Status.Text = HashDictionary.HashFileName(fileName).ToString("X16");
			}
		}
		#endregion

		#region Events
		private void Check_Click( object sender, EventArgs e )
		{
			CheckName();
		}

		private void FileName_KeyDown( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
				CheckName();
		}
		#endregion
	}
}
