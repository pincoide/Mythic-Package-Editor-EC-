using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class SettingsDialog : Form
	{
		#region Properties
		private UserControl m_Current;
		#endregion

		#region Constructors
		public SettingsDialog()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Private
		private void Initialize()
		{
			m_Current = null;

			foreach ( string name in Globals.Settings.SettingsPages )
			{
				UserControl page = (UserControl) Activator.CreateInstance( Type.GetType( name, true ) );
				
				TreeNode node = new TreeNode( page.Tag.ToString() );
				node.Tag = page;
				TreeView.Nodes.Add( node );

				if ( m_Current == null )
				{
					m_Current = page;
				}
				else
					page.Visible = false;
				
				SplitContent.Panel1.Controls.Add( page );
				page.Location = new Point( page.Margin.Left, page.Margin.Top );
				page.Size = new Size( SplitContent.Panel1.Width - page.Margin.Right - page.Margin.Left, SplitContent.Panel1.Height - page.Margin.Top - page.Margin.Bottom );
			}

			Text = Globals.LanguageManager.GetString( "SettingsDialog_Title" );
			ButtonReset.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Reset" );
			ButtonCancel.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Cancel" );
			ButtonSave.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Save" );
		}

		#region Events
		private void TreeView_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if ( e.Node != null && e.Node.Tag is UserControl )
			{
				if ( m_Current is ISettingsPage && !((ISettingsPage) m_Current).Verify() )
					return;

				m_Current.Visible = false;
				m_Current = (UserControl) e.Node.Tag;
				m_Current.Visible = true;
			}
		}

		private void ButtonSave_Click( object sender, EventArgs e )
		{
			if ( m_Current is ISettingsPage && !((ISettingsPage) m_Current).Verify() )
				return;
			
			foreach ( TreeNode node in TreeView.Nodes )
			{
				if ( node.Tag is ISettingsPage )
					((ISettingsPage) node.Tag).Save();
			}

			Cursor = Cursors.WaitCursor;
			Worker.RunWorkerAsync();
		}

		private void Worker_DoWork( object sender, DoWorkEventArgs e )
		{
			Globals.Settings.Save();
		}

		private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			Cursor = Cursors.Default;

			if ( e.Error != null )
			{
				Globals.Logger.LogException( e.Error );
				MessageBox.Show( this, Globals.LanguageManager.GetString( "MainForm_Information_ErrorSaving" ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			else
				Close();
		}
		#endregion

		private void ButtonDefault_Click( object sender, EventArgs e )
		{			
			foreach ( TreeNode node in TreeView.Nodes )
			{
				if ( node.Tag is ISettingsPage )
					((ISettingsPage) node.Tag).Reset();
			}
		}
		#endregion
	}
}
