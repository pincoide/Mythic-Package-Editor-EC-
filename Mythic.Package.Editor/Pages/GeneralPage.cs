using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class GeneralPage : UserControl, ISettingsPage
	{
		#region Constructors
		public GeneralPage()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			Tag = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Title" );

			LabelLanguage.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Language" );
			LabelCurrentLangauge.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_CurrentLanguage" );
			LabelUnpacking.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Unpacking" );
			LabelOutputPath.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_OutputPath" );
			LabelInnerFolder.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_InnerFolder" );
			LabelInnerFolders.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_InnerFolders" );
			ErrorTooltip.ToolTipTitle = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_ErrorTitle" );

			EditLanguage.Items.AddRange( Globals.Settings.LanguageOptions.ToArray() );
			EditLanguage.SelectedItem = Globals.Settings.Language;
			EditOutputPath.Text = Globals.Settings.OutputPath;
			EditInnerFolder.Checked = Globals.Settings.WithInnerPath;
			EditInnerFolders.Items.AddRange( Globals.Settings.InnerDirectoryOptions.ToArray() );

			FolderBrowser.Description = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Description" );
		}

		private void ShowTextBox()
		{
			int selected = EditInnerFolders.SelectedIndex;

			if ( selected > -1 )
			{
				Rectangle rec = EditInnerFolders.GetItemRectangle( selected );
				Point loc = EditInnerFolders.Location;

				DynamicTextBox.Location = new Point( loc.X + rec.X + 3 , loc.Y + rec.Y + 7 );
				DynamicTextBox.Size = new Size( rec.Width , rec.Height );
				DynamicTextBox.Text = (string) EditInnerFolders.Items[ selected ];
				DynamicTextBox.Show();
				DynamicTextBox.Focus();
				DynamicTextBox.SelectAll();
			}
		}

		private void HideTextBox()
		{
			int selected = EditInnerFolders.SelectedIndex;

			if ( selected > -1 )
				EditInnerFolders.Items[ selected ] = DynamicTextBox.Text;

			DynamicTextBox.Hide();
		}
		#endregion

		#region Events
		private void ButtonOutputPath_Click( object sender, EventArgs e )
		{
			if ( FolderBrowser.ShowDialog( this ) == DialogResult.OK )
				EditOutputPath.Text = FolderBrowser.SelectedPath;
		}

		private void ButtonAdd_Click( object sender, EventArgs e )
		{
			EditInnerFolders.Items.Add( String.Empty );
		}

		private void ButtonRemove_Click( object sender, EventArgs e )
		{
			int selected = EditInnerFolders.SelectedIndex;

			if ( selected > -1 )
			{
				EditInnerFolders.Items.RemoveAt( selected );

				if ( selected >= EditInnerFolders.Items.Count )
					EditInnerFolders.SelectedIndex = selected - 1;
				else
					EditInnerFolders.SelectedIndex = selected;
			}
		}

		private void DynamicTextBox_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == 13 )
				HideTextBox();
		}

		private void DynamicTextBox_LostFocus( object sender, EventArgs e )
		{
			HideTextBox();
		}

		private void EditInnerFolders_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == 13 )
				ShowTextBox();
		}

		private void EditInnerFolders_DoubleClick( object sender, EventArgs e )
		{
			ShowTextBox();
		}

		private void EditInnerFolders_KeyDown( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.F2 )				
				ShowTextBox();
			else if ( e.KeyCode == Keys.Delete )
			{
				int selected = EditInnerFolders.SelectedIndex;

				if ( selected > -1 )
				{
					EditInnerFolders.Items.RemoveAt( selected );

					if ( selected >= EditInnerFolders.Items.Count )
						EditInnerFolders.SelectedIndex = selected - 1;
					else
						EditInnerFolders.SelectedIndex = selected;
				}
			}
		}
		#endregion

		#region ISettingsPage
		public void Reset()
		{
			EditLanguage.SelectedItem = "Eng.txt";
			EditOutputPath.Text = "C:\\";
			EditInnerFolder.Checked = true;
		}

		public bool Verify()
		{
			if ( !Directory.Exists( EditOutputPath.Text ) )
			{
				ErrorTooltip.Show( Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_ErrorText" ), EditOutputPath, 0, -70 );
				return false;
			}

			return true;
		}

		public void Save()
		{
			Globals.Settings.OutputPath = EditOutputPath.Text;
			Globals.Settings.Language = EditLanguage.SelectedItem.ToString();
			Globals.Settings.WithInnerPath = EditInnerFolder.Checked;

			List<string> list = Globals.Settings.InnerDirectoryOptions;

			if ( list != null )
			{
				list.Clear();
								
				foreach ( string s in EditInnerFolders.Items )
					list.Add( s );
			}
		}
		#endregion
	}
}
