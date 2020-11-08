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

		/// <summary>
		/// Try to guess a file name
		/// </summary>
		private void CheckName()
		{
			// do we have a file selected?
			if ( m_File != null )
			{
				// make sure the specified file name is lower case
				string fileName = FileName.Text.ToLower();

				// is the name correct?
				if ( m_File.FileHash == HashDictionary.HashFileName( fileName ) )
				{
					// update the dictionary
					HashDictionary.Set( m_File.FileHash, fileName );

					// update the form
					m_File.RefreshFileName();

					// close the guess window
					Close();
				}
				else // file name is INCORRECT
					Status.Text = Globals.LanguageManager.GetString( "GuessFileDialog_InvalidName" );

				// show the hash for the name we specified
                Status.Text = HashDictionary.HashFileName(fileName).ToString("X16");
			}
		}

		/// <summary>
		/// Try to guess a file name by using a brute force numeric search given the file extension
		/// </summary>
		private void BruteForceNameNumeric()
		{
			// do we have a file selected?
			if ( m_File != null )
			{
				// make sure the extension is lower case
				string extension = txtExtension.Text.ToLower();

				// warn the user that we are trying a lot of combos
				Status.Text = "Ttring all possible numeric combos...";

				// try all the possible numbers between 0 and 100m
				for ( int i = 0; i < 99999999; i++ )
                {
					// generate the file name
					string fileName = i.ToString( "00000000" ) + "." + extension;

					// show the current file name in the textbox
					FileName.Text = fileName;

					// is the name correct?
					if ( m_File.FileHash == HashDictionary.HashFileName( fileName ) )
					{
						// update the dictionary
						HashDictionary.Set( m_File.FileHash, fileName );

						// update the form
						m_File.RefreshFileName();

						// close the guess window
						Close();
					}

					Application.DoEvents();
				}

				// warn the user we failed to find the file name
				Status.Text = "The file name is NOT numeric or uses a different extension...";
			}
		}
		#endregion

		#region Events
		private void Check_Click( object sender, EventArgs e )
		{

			// if we DON't have the file name, and we have the extension, we do the numeric brute force
			if ( FileName.Text == string.Empty && txtExtension.Text != string.Empty )
				BruteForceNameNumeric();

			else // use the specified file name
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
