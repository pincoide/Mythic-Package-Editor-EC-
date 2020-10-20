using System;
using System.IO;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class SaveOptions : Form
	{
		#region Properties
		public string Destination
		{ 
			get{ return TextDestination.Text; } 
			set{ TextDestination.Text = value; }
		}

		public DateTime Value{ get{ return DateTimePicker.Value; } }
		#endregion

		#region Constructors
		public SaveOptions()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Properties
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "SaveOptions_Title" );

			LabelDestination.Text = Globals.LanguageManager.GetString( "SaveOptions_Destination" );
			LabelReleaseDate.Text = Globals.LanguageManager.GetString( "SaveOptions_ReleaseDate" );

			ButtonCancel.Text = Globals.LanguageManager.GetString( "SaveOptions_Button_Cancel" );
			ButtonSave.Text = Globals.LanguageManager.GetString( "SaveOptions_Button_Save" );

			DateTimePicker.Value = DateTime.Now;

			InvalidPath.SetToolTip( TextDestination, Globals.LanguageManager.GetString( "SaveOptions_ToolTip_Title" ) );
		}
		#endregion

		#region Events
		private void ButtonSave_Click( object sender, EventArgs e )
		{
			try
			{
				if ( Directory.Exists( TextDestination.Text ) )
					Close();
				else
					InvalidPath.Show( Globals.LanguageManager.GetString( "SaveOptions_ToolTip_Text" ), this );
			}
			catch
			{
				InvalidPath.Show( Globals.LanguageManager.GetString( "SaveOptions_ToolTip_Text" ), this );
			}
		}

		private void ButtonBrowse_Click( object sender, EventArgs e )
		{
			if ( SavePackageDialog.ShowDialog( this ) == DialogResult.OK )
				TextDestination.Text = SavePackageDialog.FileName;
		}
		#endregion
	}
}
