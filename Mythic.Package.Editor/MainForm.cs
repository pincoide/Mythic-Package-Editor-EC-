using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;
using DelayTimer = System.Timers.Timer;

using Mythic.Package;
using Mythic.Package.Spy;
using System.Linq;

namespace Mythic.Package.Editor
{
	public partial class MainForm : Form
	{
		private int m_NewHashes;
		private int m_NewFileNames;

		public MainForm()
		{
			InitializeComponent();
			Initialize();
		}

		#region Private
		private void Initialize()
		{
			// title
			Text = Globals.LanguageManager.GetString( "MainForm_Title" );

			// file drop down
			MainMenuFile.Text = Globals.LanguageManager.GetString( "MainForm_File" );
			MainMenuFileNew.Text = Globals.LanguageManager.GetString( "MainForm_File_New" );
			MainMenuFileOpen.Text = Globals.LanguageManager.GetString( "MainForm_File_Open" );
			MainMenuFileSave.Text = Globals.LanguageManager.GetString( "MainForm_File_Save" );
			MainMenuFileClose.Text = Globals.LanguageManager.GetString( "MainForm_File_Close" );
			MainMenuFileExit.Text = Globals.LanguageManager.GetString( "MainForm_File_Exit" );

			// dictionary drop down
			MainMenuDictionary.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary" );
			MainMenuDictionaryLoad.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Load" );
			MainMenuDictionarySave.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Save" );
			MainMenuDictionaryMerge.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Merge" );
			MainMenuDictionaryUpdate.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update" );
			MainMenuDictionarySpyStart.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Start" );
			MainMenuDictionarySpyAttach.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Attach" );
			MainMenuDictionarySpyDetach.Text = Globals.LanguageManager.GetString( "MainForm_Dictionary_Update_Detach" );

			// help drop down
			MainMenuHelp.Text = Globals.LanguageManager.GetString( "MainForm_Help" );
			MainMenuHelpAbout.Text = Globals.LanguageManager.GetString( "MainForm_Help_About" );

			// search buttons
			Search.Text = Globals.LanguageManager.GetString( "MainForm_Button_SearchText" );
			SearchHash.Text = Globals.LanguageManager.GetString( "MainForm_Button_SearchHash" );

			// toolbar
			ButtonNew.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_New" );
			ButtonOpen.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Open" );
			ButtonSave.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Save" );
			ButtonClose.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Close" );

			ButtonOpenDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionaryOpen" );
			ButtonSaveDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionarySave" );
			ButtonMergeDictionary.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_DictionaryMerge" );

			ButtonAdd.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Add" );
			ButtonRemove.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Remove" );
			ButtonUnpack.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Unpack" );
			ButtonReplace.Text = Globals.LanguageManager.GetString( "MainMenu_ToolBarToolTip_Replace" );

			// package tab
			DetailsPackage.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Title" );
			PackageGeneralLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_General" );
			PackageFullNameLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_FullName" );
			PackageAttributesLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Attributes" );
			PackageCreationLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Creation" );
			PackageSizeLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Size" );

			PackageHeader.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Header" );
			PackageVersionLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Version" );
			PackageMiscLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_Misc" );
			PackageHeaderSizeLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_HeaderSize" );
			PackageBlockSizeLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_BlockSize" );
			PackageFileCountLabel.Text = Globals.LanguageManager.GetString( "MainForm_PackageTab_FileCount" );

			// Block tab
			DetailsBlock.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_Title" );
			BlockHeader.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_Header" );
			BlockFileCountLabel.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_FileCount" );
			BlockNextBlockLabel.Text = Globals.LanguageManager.GetString( "MainForm_BlockTab_NextBlock" );

			// File tab
			DetailsFile.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Title" );
			FileGeneral.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_General" );
			FileFileNameLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Filename" );
			FileHashLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_FileHash" );
			FileDataHashLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_DataHash" );
			FileCompression.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_Compression" );
			FileCompressionTypeLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_CompressionType" );
			FileCompressedLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_CompressedSize" );
			FileDecompressedLabel.Text = Globals.LanguageManager.GetString( "MainForm_FileTab_DecompressedSize" );

			ErrorTooltip.ToolTipTitle = Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_Title" );

			// initialize forms
			SelectProcess = new SelectProcess();
			AddFile = new AddFile();
			AddFolder = new AddFolder();
			About = new About();
			Settings = new SettingsDialog();

			MythicPackageBlock.UpdateProgress += new UpdateProgress( MythicPackage_UpdateProgress );
			Globals.HashSpy.HashFound += new HashFound( HashSpy_HashFound );
		}

		private void ChangePackage( MythicPackage package )
		{
			if ( package.FileInfo != null )
			{
				PackageFullNameInfo.Text = package.FileInfo.FullName;
				PackageAttributesInfo.Text = package.FileInfo.Attributes.ToString();
				PackageCreationInfo.Text = package.FileInfo.CreationTimeUtc.ToLocalTime().ToString();
				PackageSizeInfo.Text = ConvertSize( package.FileInfo.Length );
			}
			else
			{
				PackageFullNameInfo.Text = String.Empty;
				PackageAttributesInfo.Text = String.Empty;
				PackageCreationInfo.Text = String.Empty;
				PackageSizeInfo.Text = String.Empty;
			}

			PackageVersionInfo.Text = package.Header.Version.ToString();
			PackageMiscInfo.Text = package.Header.Misc.ToString( "X8" );
			PackageHeaderSizeInfo.Text = package.Header.StartAddress.ToString( "X16" );
			PackageBlockSizeInfo.Text = package.Header.BlockSize.ToString();
			PackageFileCountInfo.Text = package.Header.FileCount.ToString();

			FileDetails.SelectedIndex = 0;

			ListBox.Items.Clear();
			ListBox.SelectedItem = -1;

			DetailsPackage.Enabled = true;
			DetailsBlock.Enabled = false;
			DetailsFile.Enabled = false;
		}

		private void ClearPackage()
		{
			PackageFullNameInfo.Text = String.Empty;
			PackageAttributesInfo.Text = String.Empty;
			PackageCreationInfo.Text = String.Empty;
			PackageSizeInfo.Text = String.Empty;
			PackageVersionInfo.Text = String.Empty;
			PackageMiscInfo.Text = String.Empty;
			PackageHeaderSizeInfo.Text = String.Empty;
			PackageBlockSizeInfo.Text = String.Empty;
			PackageFileCountInfo.Text = String.Empty;
			DetailsPackage.Enabled = false;
		}

		private void ChangeBlock( MythicPackageBlock block )
		{
			BlockFileCountInfo.Text = block.FileCount.ToString();
			BlockNextBlockInfo.Text = block.NextBlock.ToString( "X16" );

			ListBox.Items.Clear();
			ListBox.Items.AddRange( block.Files.ToArray() );

			FileDetails.SelectedIndex = 1;

			DetailsPackage.Enabled = true;
			DetailsBlock.Enabled = true;
			DetailsFile.Enabled = false;
		}

		private void ClearBlock()
		{
			BlockFileCountInfo.Text = String.Empty;
			BlockNextBlockInfo.Text = String.Empty;
			DetailsBlock.Enabled = false;
		}

		private void ChangeFile( MythicPackageFile file )
		{
			FileFileNameInfo.Text = file.FileName;
			FileHashInfo.Text = file.FileHash.ToString( "X16" );
			FileDataHashInfo.Text = file.DataBlockHash.ToString( "X8" );
			FileCompressedInfo.Text = ConvertSize( file.CompressedSize );
			FileDecompressedInfo.Text = ConvertSize( file.DecompressedSize );
			FileCompressionTypeInfo.Text = file.Compression.ToString();

			FileDetails.SelectedIndex = 2;

			DetailsPackage.Enabled = true;
			DetailsBlock.Enabled = true;
			DetailsFile.Enabled = true;
		}

		private void ClearFile()
		{
			FileFileNameInfo.Text = String.Empty;
			FileHashInfo.Text = String.Empty;
			FileDataHashInfo.Text = String.Empty;
			FileCompressedInfo.Text = String.Empty;
			FileDecompressedInfo.Text = String.Empty;
			FileCompressionTypeInfo.Text = String.Empty;
			DetailsFile.Enabled = false;
		}

		private void RefreshBlocks( MythicPackage package )
		{
			foreach ( TreeNode node in TreeView.Nodes )
			{
				if ( node.Tag == package )
				{
					node.Collapse();
					node.ForeColor = Color.Black;
					node.Nodes.Clear();

					for ( int i = 0; i < package.Blocks.Count; i++ )
					{
						MythicPackageBlock block = package.Blocks[ i ];
						TreeNode child = new TreeNode( block.ToString() );
						child.Tag = block;
						node.Nodes.Add( child );
					}

					TreeView.SelectedNode = node;
					ListBox.Items.Clear();
					break;
				}
			}
		}

		private bool AlreadyOpen( string fileName )
		{
			foreach ( TreeNode n in TreeView.Nodes )
			{
				MythicPackage package = (MythicPackage) n.Tag;

				if ( package.FileInfo != null && package.FileInfo.FullName.Equals( fileName ) )
					return true;
			}

			return false;
		}

		private string ConvertSize( long bytes )
		{
			if ( bytes >= 1024 )
			{
				double value = bytes / (double) 1024;

				if ( value >= 1024 )
				{
					value /= 1024;
					return String.Format( "{0} MB", value.ToString( "F2" ) );
				}

				return String.Format( "{0} KB", value.ToString( "F2" ) );
			}

			return String.Format( "{0} B", bytes );
		}

		private bool TryExit()
		{
			if ( !Worker.IsBusy || ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_WorkerTerminate" ) ) == DialogResult.Yes )
			{
				DialogResult result = DialogResult.None;

				foreach ( TreeNode node in TreeView.Nodes )
				{
					if ( node.Tag is MythicPackage )
					{
						MythicPackage package = (MythicPackage) node.Tag;

						if ( package != null && package.Modified )
						{
							result = ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_SavePackage" ) );

							if ( result == DialogResult.Yes )
							{
								if ( SaveFileDialog.ShowDialog( this ) == DialogResult.OK )
								{
									StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingPackage" );
									Worker.RunWorkerAsync( new SaveMythicPackageArgs( package, SaveFileDialog.FileName ) );
									return false;
								}
							}
						}
					}
				}

				if ( HashDictionary.Modified )
				{
					result = ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Information_SaveDictionary", HashDictionary.NewHashes.ToString(), HashDictionary.NewFileNames.ToString() ) );

					if ( result != DialogResult.Cancel )
					{
						if ( result == DialogResult.Yes )
						{
							StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" );
							Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.SAVE ) );
						}

						return true;
					}
				}
				else
					return true;
			}

			return false;
		}

		public void ShowError( string error )
		{
			if ( MessageBox.Show( this, error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error ) == DialogResult.OK )
				Process.Start( Path.Combine( AppDomain.CurrentDomain.BaseDirectory, Logger.FileName ) );
		}

		public void ShowWarning( string warning )
		{
			MessageBox.Show( this, warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
		}

		public void ShowInfo( string info )
		{
			MessageBox.Show( this, info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

		public DialogResult ShowQuestion( string question )
		{
			return MessageBox.Show( this, question, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );
		}

		private DialogResult ShowOpenFile()
		{
			OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_File_Title" );
			OpenFileDialog.Filter = "All files|*.*";
			OpenFileDialog.Multiselect = false;

			return OpenFileDialog.ShowDialog( this );
		}

		private DialogResult ShowOpenExecutable()
		{
			OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Executable_Title" );
			OpenFileDialog.Filter = "Executable files|*.exe";
			OpenFileDialog.Multiselect = false;

			return OpenFileDialog.ShowDialog( this );
		}

		private DialogResult ShowOpenPackage()
		{
			OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Package_Title" );
			OpenFileDialog.Filter = "Mythic Package files|*.uop";
			OpenFileDialog.Multiselect = true;

			return OpenFileDialog.ShowDialog( this );
		}

		private DialogResult ShowOpenDictionary()
		{
			OpenFileDialog.Title = Globals.LanguageManager.GetString( "OpenFileDialog_Dictionary_Title" );
			OpenFileDialog.Filter = "Dictionary files|*.dic";
			OpenFileDialog.Multiselect = false;

			return OpenFileDialog.ShowDialog( this );
		}

		private DialogResult ShowSaveDictionary()
		{
			SaveFileDialog.Title = Globals.LanguageManager.GetString( "SaveFileDialog_Dictionary_Title" );
			SaveFileDialog.Filter = "Dictionary files|*.dic";

			return SaveFileDialog.ShowDialog( this );
		}


		private void DisableTopMost( object sender, ElapsedEventArgs e )
		{
			TopMost = false;
		}
		#endregion

		#region Events

		#region MainMenu
		private void MainMenuFileNew_Click( object sender, EventArgs e )
		{
			MythicPackage package = new MythicPackage( 5 );

			TreeNode node = new TreeNode( "Unsaved package.uop" );
			node.Tag = package;
			node.ForeColor = Color.Green;

			TreeView.Nodes.Add( node );
			TreeView.SelectedNode = node;
		}

		private void MainMenuFileOpen_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( ShowOpenPackage() == DialogResult.OK )
				{
					List<string> files = new List<string>();

					foreach ( string fileName in OpenFileDialog.FileNames )
					{
						if ( !AlreadyOpen( fileName ) )
							files.Add( fileName );
					}

					m_NewHashes = HashDictionary.NewHashes;
					m_NewFileNames = HashDictionary.NewFileNames;

					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_LoadingPackages" );
					Worker.RunWorkerAsync( new LoadMythicPackageArgs( files.ToArray() ) );
				}
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuFileSave_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				TreeNode node = TreeView.SelectedNode;

				if ( node != null && node.Parent != null )
					node = node.Parent;

				if ( node != null )
				{
					MythicPackage package = node.Tag as MythicPackage;

					if ( package != null )
					{
						if ( SaveFileDialog.ShowDialog( this ) == DialogResult.OK )
						{
							StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingPackage" );
							Worker.RunWorkerAsync( new SaveMythicPackageArgs( package, SaveFileDialog.FileName ) );
						}
					}
					else
						ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuFileClose_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				TreeNode node = TreeView.SelectedNode;

				if ( node != null )
				{
					if ( node.Parent != null )
						node = node.Parent;

					TreeNode next = node.NextNode;

					if ( next == null )
						next = node.PrevNode;

					node.Remove();

					if ( next == null )
					{
						ListBox.Items.Clear();
						ListBox.SelectedItem = -1;

						ClearPackage();
						ClearBlock();
						ClearFile();

						DetailsPackage.Enabled = false;
						DetailsBlock.Enabled = false;
						DetailsFile.Enabled = false;
					}

					TreeView.SelectedNode = next;
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuFileExit_Click( object sender, EventArgs e )
		{
			TryExit();
		}

		private void MainMenuEditSettings_Click( object sender, EventArgs e )
		{
			Settings.ShowDialog( this );
		}

		private void MainMenuDictionaryLoad_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( HashDictionary.Modified )
				{
					if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_SaveDictionary" ) ) == DialogResult.Yes )
					{
						StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" );
						Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.SAVE ) );
					}
				}
				else if ( ShowOpenDictionary() == DialogResult.OK )
				{
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_LoadingDictionary" );
					Worker.RunWorkerAsync( new DictionaryArgs( OpenFileDialog.FileName, DictionaryArgs.LOAD ) );
				}
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuDictionarySave_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( HashDictionary.Modified )
				{
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingDictionary" );
					Worker.RunWorkerAsync( new DictionaryArgs( HashDictionary.FileName, DictionaryArgs.SAVE ) );
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_DictionaryNotChanged" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuDictionaryMerge_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( ShowOpenDictionary() == DialogResult.OK )
				{
					m_NewHashes = HashDictionary.NewHashes;
					m_NewFileNames = HashDictionary.NewFileNames;

					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_MergingDictionary" );
					Worker.RunWorkerAsync( new DictionaryArgs( OpenFileDialog.FileName, DictionaryArgs.MERGE ) );
				}
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuSpyStart_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( ShowOpenExecutable() == DialogResult.OK )
				{
					m_NewHashes = HashDictionary.NewHashes;
					m_NewFileNames = HashDictionary.NewFileNames;

					MainMenuDictionarySpyStart.Enabled = false;
					MainMenuDictionarySpyAttach.Enabled = false;
					MainMenuDictionarySpyDetach.Enabled = true;

					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SpyingOn", OpenFileDialog.FileName );
					Worker.RunWorkerAsync( new SpyPathArgs( Globals.HashSpy, OpenFileDialog.FileName ) );
				}
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuSpyAttach_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( SelectProcess.ShowDialog( this ) == DialogResult.OK )
				{
					Process process = SelectProcess.GetSelectedProcess();

					if ( process != null )
					{
						m_NewHashes = HashDictionary.NewHashes;
						m_NewFileNames = HashDictionary.NewFileNames;

						MainMenuDictionarySpyStart.Enabled = false;
						MainMenuDictionarySpyAttach.Enabled = false;
						MainMenuDictionarySpyDetach.Enabled = true;

						StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SpyingOn", process.ProcessName );
						Worker.RunWorkerAsync( new SpyProcessArgs( Globals.HashSpy, process ) );
					}
					else
						ShowError( Globals.LanguageManager.GetString( "MainForm_Information_InvalidProcess" ) );
				}
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void MainMenuSpyDetach_Click( object sender, EventArgs e )
		{
			MainMenuDictionarySpyStart.Enabled = true;
			MainMenuDictionarySpyAttach.Enabled = true;
			MainMenuDictionarySpyDetach.Enabled = false;

			if ( Globals.HashSpy != null )
				Globals.HashSpy.EndSpy();

			if ( HashDictionary.NewFileNames > m_NewFileNames )
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewFileNames" ) );

			foreach ( TreeNode node in TreeView.Nodes )
			{
				if ( node.Tag is MythicPackage )
					((MythicPackage) node.Tag).RefreshFileNames();
			}
		}

		private void MainMenuHelpContent_Click( object sender, EventArgs e )
		{
			Process.Start( "Help.chm" );
		}

		private void MainMenuHelpAbout_Click( object sender, EventArgs e )
		{
			About.ShowDialog( this );
		}
		#endregion

		#region Toolbar
		private void ButtonAdd_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				TreeNode node = TreeView.SelectedNode;

				if ( node != null )
				{
					if ( node.Parent != null )
						node = node.Parent;

					MythicPackage package = node.Tag as MythicPackage;

					if ( package != null )
					{
						if ( AddFile.ShowDialog( this ) == DialogResult.OK )
						{
							package.AddFiles( AddFile.Files, AddFile.InnerDirectory, AddFile.Compression );

							TreeView.Nodes[ TreeView.Nodes.Count - 1 ].ForeColor = Color.Red;

							if ( node.Nodes.Count < package.Blocks.Count )
							{
								for ( int i = node.Nodes.Count; i < package.Blocks.Count; i++ )
								{
									TreeNode child = new TreeNode( package.Blocks[ i ].ToString() );
									child.Tag = package.Blocks[ i ];
									child.ForeColor = Color.Green;
									node.Nodes.Add( child );
								}
							}
						}
					}
					else
						ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void ButtonAddFolder_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				TreeNode node = TreeView.SelectedNode;

				if ( node != null )
				{
					if ( node.Parent != null )
						node = node.Parent;

					MythicPackage package = node.Tag as MythicPackage;

					if ( package != null )
					{
						if ( AddFolder.ShowDialog( this ) == DialogResult.OK )
						{
							package.AddFolder( AddFolder.Folder, AddFolder.Compression );

							TreeView.Nodes[ TreeView.Nodes.Count - 1 ].ForeColor = Color.Red;

							if ( node.Nodes.Count < package.Blocks.Count )
							{
								for ( int i = node.Nodes.Count; i < package.Blocks.Count; i++ )
								{
									TreeNode child = new TreeNode( package.Blocks[ i ].ToString() );
									child.Tag = package.Blocks[ i ];
									child.ForeColor = Color.Green;
									node.Nodes.Add( child );
								}
							}
						}
					}
					else
						ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NothingSelected" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void ButtonRemove_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				TreeNode node = TreeView.SelectedNode;

				if ( node != null && ListBox.SelectedItems.Count == 0 )
				{
					MythicPackageBlock block = node.Tag as MythicPackageBlock;

					if ( block != null )
					{
						if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_Remove", block.ToString() ) ) == DialogResult.Yes )
						{
							TreeNode next = null;

							if ( node.Parent != null )
							{
								node.Parent.ForeColor = Color.Red;

								for ( int i = node.Index + 1; i < node.Parent.Nodes.Count; i++ )
								{
									next = node.Parent.Nodes[ i ];
									next.Text = String.Format( "Block_{0}", next.Index - 1 );
								}
							}

							next = node.NextNode;

							if ( next == null )
								next = node.PrevNode;

							node.Remove();
							block.Remove();

							if ( block.IsEmpty )
								TreeView.SelectedNode = node.Parent;
							else
								TreeView.SelectedNode = next;

							TreeView.Refresh();
						}
					}
					else
						ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectBlockFile" ) );
				}
				else if ( node != null && ListBox.SelectedItems.Count > 0 )
				{
					List<MythicPackageFile> files = new List<MythicPackageFile>();

					for ( int i = ListBox.SelectedItems.Count - 1; i >= 0; i-- )
					{
						if ( ListBox.Items[ i ] is MythicPackageFile )
							files.Add( (MythicPackageFile) ListBox.SelectedItems[ i ] );
					}

					if ( files.Count == 1 )
					{
						if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_Remove", files[ 0 ].ToString() ) ) != DialogResult.Yes )
							return;
					}
					else if ( files.Count > 1 )
					{
						if ( ShowQuestion( Globals.LanguageManager.GetString( "MainForm_Confirm_RemoveMultiple", files.Count.ToString() ) ) != DialogResult.Yes )
							return;
					}
					else
						return;

					MythicPackageBlock block = node.Tag as MythicPackageBlock;

					if ( block != null )
					{
						int index = -1;

						foreach ( MythicPackageFile file in files )
						{
							if ( file.Index < block.Files.Count - 1 )
								index = file.Index;
							else
								index = file.Index - 1;

							file.Remove();
						}

						if ( block.Files.Count == 0 )
						{
							if ( node.NextNode == null )
								TreeView.SelectedNode = node.PrevNode;
							else
								TreeView.SelectedNode = node.NextNode;

							node.Remove();
						}
						else
						{
							ListBox.Items.Clear();
							ListBox.Items.AddRange( block.Files.ToArray() );
							ListBox.SelectedIndex = index;

							node.ForeColor = Color.Red;
						}

						if ( node.Parent != null )
							node.Parent.ForeColor = Color.Red;
					}
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectBlockFile" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void ButtonUnpack_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				UnpackMythicPackageArgs args = null;
				string path = Globals.Settings.OutputPath;
				bool innerPath = Globals.Settings.WithInnerPath;

				if ( ListBox.SelectedItems.Count > 0 )
				{
					List<MythicPackageFile> files = new List<MythicPackageFile>();

					foreach ( object o in ListBox.SelectedItems )
					{
						if ( o != null && o is MythicPackageFile && ( (MythicPackageFile)o ).FileName != string.Empty )
							files.Add( (MythicPackageFile) o );
					}

					if ( files.Count > 0 )
						args = new UnpackMythicPackageArgs( files.ToArray(), path, innerPath );
				}
				else if ( TreeView.SelectedNode != null )
				{
					if ( TreeView.SelectedNode.Tag is MythicPackage )
					{
						MythicPackage package = (MythicPackage) TreeView.SelectedNode.Tag;
						args = new UnpackMythicPackageArgs( package, path, innerPath );
					}
					else if ( TreeView.SelectedNode.Tag is MythicPackageBlock )
					{
						MythicPackageBlock block = (MythicPackageBlock) TreeView.SelectedNode.Tag;
						args = new UnpackMythicPackageArgs( block, path, innerPath );
					}
				}

				if ( args != null )
				{
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_UnpackingIn", path );
					Worker.RunWorkerAsync( args );
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectPackageBlockFile" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void ButtonReplace_Click( object sender, EventArgs e )
		{
			if ( !Worker.IsBusy )
			{
				if ( TreeView.SelectedNode != null && ListBox.SelectedItems.Count == 1 )
				{
					MythicPackageFile file = ListBox.SelectedItem as MythicPackageFile;

					if ( file != null && AddFile.ShowDialog( this ) == DialogResult.OK )
					{
						if ( AddFile.Files.Length == 1 )
							file.Replace( AddFile.Files[ 0 ], AddFile.InnerDirectory, AddFile.Compression );

						if ( TreeView.SelectedNode.Parent != null )
							TreeView.SelectedNode.Parent.ForeColor = Color.Red;

						TreeView.SelectedNode.ForeColor = Color.Red;
						ChangeBlock( TreeView.SelectedNode.Tag as MythicPackageBlock );
						ListBox.SelectedItem = file;
					}
				}
				else
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SelectFile" ) );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}
		#endregion

		#region Search
		private string m_OldKeyword;

		private void HashSearch( string keyword )
		{
			if ( !Worker.IsBusy )
			{
				if ( !String.IsNullOrEmpty( keyword ) )
				{
					List<SearchExpressionEntry> entries = new List<SearchExpressionEntry>();
					char[] after = null;
					int s, e, nameLength = 0, end = 0, start = -1;

					do
					{
						s = keyword.IndexOf( '{', start + 1 );
						e = keyword.IndexOf( '}', start + 1 );

						if ( s < 0 && e < 0 )
						{
							if ( start == -1 )
								ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_MissingBracket", "{ and }" ), SearchBox, 0, -75 );

							break;
						}
						else if ( s < 0 )
						{
							ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_MissingBracket", "{" ), SearchBox, 0, -75 );
							break;
						}
						else if ( e < 0 )
						{
							ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_MissingBracket", "}" ), SearchBox, 0, -75 );
							break;
						}
						else if ( e < s )
						{
							ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_InvalidBracketOrder" ), SearchBox, 0, -75 );
							break;
						}
						else
						{
							string before, center;
							char[] from, to;

							before = keyword.Substring( start + 1, s - end );
							center = keyword.Substring( s + 1, e - s - 1 );
							after = keyword.Substring( e + 1, keyword.Length - e - 1 ).ToCharArray();

							int dash = center.IndexOf( '-' );
							int length;

							if ( dash > 0 )
							{
								from = center.Substring( 0, dash ).ToCharArray();
								to = center.Substring( dash + 1, center.Length - dash - 1 ).ToCharArray();

								if ( from.Length != to.Length )
								{
									ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_InvalidLength" ), SearchBox, s * 5, -75 );
									return;
								}

								length = from.Length;

								if ( length <= 0 )
								{
									ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_NullLength" ), SearchBox, s * 5, -75 );
									return;
								}
							}
							else
							{
								length = center.Length;

								if ( length <= 0 )
								{
									ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_NullLength" ), SearchBox, s * 5, -75 );
									return;
								}

								from = new String( '0', length ).ToCharArray();
								to = center.ToCharArray();
							}

							for ( int i = 0; i < length; i++ )
							{
								if ( from[ i ] < '0' || ( from[ i ] > '9' && from[ i ] < 'a' ) || from[ i ] > 'z' ||
									 to[ i ] < '0' || ( to[ i ] > '9' && to[ i ] < 'a' ) || to[ i ] > 'z' )
								{
									ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_InvalidCharacters" ), SearchBox, s * 5, -75 );
									return;
								}
							}

							nameLength += before.Length + length;
							entries.Add( new SearchExpressionEntry( before.ToCharArray(), from, to, nameLength - length, nameLength - 1 ) );
						}

						start = e;
						end = e + 1;
					}
					while ( s >= 0 && e >= 0 );

					if ( entries.Count > 0 )
					{
						object target = null;

						if ( ListBox.SelectedItems.Count > 0 )
						{
							List<MythicPackageFile> list = new List<MythicPackageFile>();

							for ( int i = ListBox.SelectedItems.Count - 1; i >= 0; i-- )
							{
								if ( ListBox.SelectedItems[ i ] is MythicPackageFile )
									list.Add( (MythicPackageFile) ListBox.SelectedItems[ i ] );
							}

							target = list.ToArray();
						}
						else if ( TreeView.SelectedNode != null )
						{
							if ( TreeView.SelectedNode.Tag is MythicPackage )
							{
								List<MythicPackage> list = new List<MythicPackage>();
								list.Add( (MythicPackage) TreeView.SelectedNode.Tag );
								target = list.ToArray();
							}
							else if ( TreeView.SelectedNode.Tag is MythicPackageBlock )
							{
								List<MythicPackageBlock> list = new List<MythicPackageBlock>();
								list.Add( (MythicPackageBlock) TreeView.SelectedNode.Tag );
								target = list.ToArray();
							}
						}
						else
						{
							List<MythicPackage> list = new List<MythicPackage>();

							foreach ( TreeNode node in TreeView.Nodes )
							{
								if ( node.Tag is MythicPackage )
									list.Add( (MythicPackage) node.Tag );
							}

							target = list.ToArray();

							if ( list.Count == 0 )
							{
								ShowInfo( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_NothingSelected" ) );
								return;
							}
						}

						StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_Searching" );
						StatusProgressBar.Style = ProgressBarStyle.Blocks;
						Worker.RunWorkerAsync( new SearchExpressionArgs( target, entries, after, nameLength + after.Length ) );
					}
				}
				else
					ErrorTooltip.Show( Globals.LanguageManager.GetString( "MainForm_SearchBox_ToolTip_Invalid" ), SearchBox, 0, -75 );
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_WorkerBusy" ) );
		}

		private void TextSearch( string keyword, bool next )
		{
			SearchResult result = SearchResult.NotFound;
			MythicPackage package = null;
			int pindex = 0, bindex = 0, findex = 0;

			if ( TreeView.SelectedNode != null )
			{
				if ( TreeView.SelectedNode.Parent != null )
				{
					pindex = TreeView.SelectedNode.Parent.Index;
					bindex = TreeView.SelectedNode.Index;

					if ( ListBox.SelectedIndex > -1 )
						findex = ListBox.SelectedIndex;
				}
				else
					pindex = TreeView.SelectedNode.Index;

				package = TreeView.Nodes[ pindex ].Tag as MythicPackage;
			}

			if ( package != null )
			{
				if ( next )
				{
					findex += 1;

					if ( findex == ListBox.Items.Count )
					{
						bindex += 1;
						findex = 0;

						if ( bindex == package.Blocks.Count )
						{
							pindex += 1;
							bindex = 0;
						}
					}
				}
			}

			if ( pindex < TreeView.Nodes.Count )
			{
				package = TreeView.Nodes[ pindex ].Tag as MythicPackage;

				if ( package != null )
				{
					result = package.Search( bindex, findex, keyword );

					if ( !result.Found )
						pindex += 1;
				}
			}

			for ( int i = pindex; i < TreeView.Nodes.Count && !result.Found; i++ )
			{
				TreeNode node = TreeView.Nodes[ i ];

				if ( node.Tag is MythicPackage )
				{
					result = ((MythicPackage) node.Tag).Search( keyword );

					if ( result.Found )
						pindex = i;
				}
			}

			if ( result.Found )
			{
				TreeNode node = TreeView.Nodes[ pindex ];
				node.Expand();
				TreeView.SelectedNode = node.Nodes[ result.Block ];
				ListBox.SelectedIndex = -1;
				ListBox.SelectedIndex = result.File;

				SearchBox.Focus();
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SearchNotFound", keyword ) );
		}

		private bool Advance( List<SearchExpressionEntry> entries, ref char[] name )
		{
			int entIdx = entries.Count - 1;
			SearchExpressionEntry current = entries[ entIdx ];
			int genIdx = current.End;
			int locIdx = current.To.Length - 1;

			while ( current != null )
			{
				name[ genIdx ]++;

				if ( name[ genIdx ] == 0x3A )
					name[ genIdx ] = (char) 0x61;

				if ( name[ genIdx ] > current.To[ locIdx ] ) // overflow
				{
					name[ genIdx ] = current.From[ locIdx ];

					genIdx--;
					locIdx--;

					if ( locIdx < 0 )
					{
						entIdx--;

						if ( entIdx >= 0 )
							current = entries[ entIdx ];
						else
							return true;

						genIdx = current.End;
						locIdx = current.To.Length - 1;
					}
				}
				else
					current = null;
			}

			return false;
		}

		private void Search_Click( object sender, EventArgs e )
		{
			if ( !String.IsNullOrEmpty( SearchBox.Text ) )
				TextSearch( SearchBox.Text, String.Equals( SearchBox.Text, m_OldKeyword ) );
			else
				SearchBox.Focus();

			m_OldKeyword = SearchBox.Text;
		}

		private void SearchHash_Click( object sender, EventArgs e )
		{
			if ( !String.IsNullOrEmpty( SearchBox.Text ) )
				HashSearch( SearchBox.Text.ToLower() );
			else
				SearchBox.Focus();
		}
		#endregion

		#region Threads
		private void Worker_DoWork( object sender, DoWorkEventArgs e )
		{
			if ( e.Argument is DictionaryArgs )
			{
				DictionaryArgs args = (DictionaryArgs) e.Argument;

				if ( args.Load )
					HashDictionary.LoadDictionary( args.Name );
				else if ( args.Save )
					HashDictionary.SaveDictionary( args.Name );
				else if ( args.Merge )
					HashDictionary.MergeDictionary( args.Name );
			}
			else if ( e.Argument is LoadMythicPackageArgs )
			{
				LoadMythicPackageArgs args = (LoadMythicPackageArgs) e.Argument;
				MythicPackage[] packs = new MythicPackage[ args.Names.Length ];

				for ( int i = 0; i < args.Names.Length; i ++ )
					packs[ i ] = new MythicPackage( args.Names[ i ] );

				args.Result = packs;
			}
			else if ( e.Argument is SaveMythicPackageArgs )
			{
				SaveMythicPackageArgs args = (SaveMythicPackageArgs) e.Argument;
				args.Package.Save( args.FileName );
			}
			else if ( e.Argument is SpyProcessArgs )
			{
				SpyProcessArgs args = (SpyProcessArgs) e.Argument;

				args.HashSpy.Init( args.Process );
				args.HashSpy.MainLoop();
			}
			else if ( e.Argument is SpyPathArgs )
			{
				SpyPathArgs args = (SpyPathArgs) e.Argument;

				args.HashSpy.Init( args.Path );
				args.HashSpy.MainLoop();
			}
			else if ( e.Argument is UnpackMythicPackageArgs )
			{
				UnpackMythicPackageArgs args = (UnpackMythicPackageArgs) e.Argument;

				if ( args.IsPackage )
				{
					args.Package.Unpack( args.Folder, args.FullPath );
				}
				else if ( args.IsBlock )
				{
					args.Block.Unpack( args.Folder, args.FullPath );
				}
				else if ( args.IsFile )
				{
					foreach ( MythicPackageFile file in args.Files )
						file.Unpack( args.Folder, args.FullPath );
				}
			}
			else if ( e.Argument is SearchExpressionArgs )
			{
				SearchExpressionArgs args = (SearchExpressionArgs) e.Argument;

				args.Found = 0;

				char[] name = new char[ args.Length ];
				int idx = 0;

				foreach ( SearchExpressionEntry entry in args.Entries )
				{
					entry.Before.CopyTo( name, idx );
					idx += entry.Before.Length;
					entry.From.CopyTo( name, idx );
					idx += entry.From.Length;
				}

				args.After.CopyTo( name, idx );

				ulong hash;

				if ( args.Source is MythicPackage[] )
				{
					MythicPackage[] packages = (MythicPackage[]) args.Source;
					MythicPackage package;
					MythicPackageBlock block;
					MythicPackageFile file;

					do
					{
						hash = HashDictionary.HashFileName( name );

						for ( int l = 0; l < packages.Length; l++ )
						{
							package = packages[ l ];

							for ( int k = 0; k < package.Blocks.Count; k++ )
							{
								block = package.Blocks[ k ];

								for ( int j = 0; j < block.Files.Count; j++ )
								{
									file = block.Files[ j ];

									if ( file.SearchHash( hash, name ) )
										args.Found += 1;
								}
							}
						}
					}
					while ( !Advance( args.Entries, ref name ) );
				}
				else if ( args.Source is MythicPackage )
				{
					MythicPackage package = (MythicPackage) args.Source;
					MythicPackageBlock block;
					MythicPackageFile file;

					do
					{
						hash = HashDictionary.HashFileName( name );

						for ( int k = 0; k < package.Blocks.Count; k++ )
						{
							block = package.Blocks[ k ];

							for ( int j = 0; j < block.Files.Count; j++ )
							{
								file = block.Files[ j ];

								if ( file.SearchHash( hash, name ) )
									args.Found += 1;
							}
						}
					}
					while ( !Advance( args.Entries, ref name ) );
				}
				else if ( args.Source is MythicPackageBlock )
				{
					MythicPackageBlock block = (MythicPackageBlock) args.Source;
					MythicPackageFile file;

					do
					{
						hash = HashDictionary.HashFileName( name );

						for ( int j = 0; j < block.Files.Count; j++ )
						{
							file = block.Files[ j ];

							if ( file.SearchHash( hash, name ) )
								args.Found += 1;
						}
					}
					while ( !Advance( args.Entries, ref name ) );
				}
				else if ( args.Source is MythicPackageFile[] )
				{
					MythicPackageFile[] files = (MythicPackageFile[]) args.Source;

					do
					{
						hash = HashDictionary.HashFileName( name );

						for ( int j = 0; j < files.Length; j++ )
						{
							if ( files[ j ].SearchHash( hash, name ) )
								args.Found += 1;
						}
					}
					while ( !Advance( args.Entries, ref name ) ) ;
				}
			}

			e.Result = e.Argument;
		}

		private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			if ( e.Error != null )
			{
				Globals.Logger.LogException( e.Error );

				MainMenuDictionarySpyStart.Enabled = true;
				MainMenuDictionarySpyAttach.Enabled = true;
				MainMenuDictionarySpyDetach.Enabled = false;
				MainMenuDictionary.Enabled = true;

				StatusLabel.Text = String.Empty;
				ShowError( String.Format( Globals.LanguageManager.GetString( "MainForm_Information_WorkerError" ), Logger.FileName ) );
			}
			else if ( e.Result is DictionaryArgs )
			{
				DictionaryArgs args = (DictionaryArgs) e.Result;

				if ( args.Load )
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_DictionaryLoadingFinished" );
				else if ( args.Save )
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_DictionarySavingFinished" );
				else if ( args.Merge )
				{
					StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_DictionaryMergingFinished" );
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_MergingSummary", ( HashDictionary.NewHashes - m_NewHashes ).ToString(), ( HashDictionary.NewFileNames - m_NewFileNames ).ToString() ) );
				}

				MainMenuDictionary.Enabled = true;
			}
			else if ( e.Result is LoadMythicPackageArgs )
			{
				LoadMythicPackageArgs args = (LoadMythicPackageArgs) e.Result;
				TreeNode parent, child;

				foreach ( MythicPackage p in args.Result )
				{
					parent = new TreeNode( p.FileInfo.Name );
					parent.Tag = p;
					TreeView.Nodes.Add( parent );

					for ( int i = 0; i < p.Blocks.Count; i ++ )
					{
						child = new TreeNode( String.Format( "Block_{0}", i ) );
						child.Tag = p.Blocks[ i ];
						parent.Nodes.Add( child );
					}
				}

				if ( TreeView.Nodes.Count > 0 )
					TreeView.SelectedNode = TreeView.Nodes[ 0 ];

				StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_LoadingFinished" );

				if ( HashDictionary.NewHashes - m_NewHashes > 0 )
				{
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewHashes", ( HashDictionary.NewHashes - m_NewHashes ).ToString() ) );
				}
			}
			else if ( e.Result is SaveMythicPackageArgs )
			{
				SaveMythicPackageArgs args = (SaveMythicPackageArgs) e.Result;



				RefreshBlocks( args.Package );

				StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_SavingFinished" );
			}
			else if ( e.Result is SpyPathArgs || e.Result is SpyProcessArgs )
			{
				StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_ProcessTerminated" );

				MainMenuDictionarySpyStart.Enabled = true;
				MainMenuDictionarySpyAttach.Enabled = true;
				MainMenuDictionarySpyDetach.Enabled = false;

				if ( ListBox.Items.Count > 0 && ListBox.Items[ 0 ] is MythicPackageFile )
					ChangeBlock( ((MythicPackageFile) ListBox.Items[ 0 ]).Parent );


				if ( HashDictionary.NewFileNames - m_NewFileNames > 0 )
				{
					ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_NewFileNames", ( HashDictionary.NewFileNames - m_NewFileNames ).ToString() ) );
				}
			}
			else if ( e.Result is UnpackMythicPackageArgs )
			{
				StatusLabel.Text = Globals.LanguageManager.GetString( "MainForm_Information_UnpackingFinished" );
			}
			else if ( e.Result is SearchExpressionArgs )
			{
				SearchExpressionArgs args = (SearchExpressionArgs) e.Result;

				StatusLabel.Text = String.Empty;
				StatusProgressBar.Style = ProgressBarStyle.Blocks;

				if ( args.Found > 0 )
				{
					if ( TreeView.SelectedNode != null && TreeView.SelectedNode.Tag is MythicPackageBlock )
						ChangeBlock( TreeView.SelectedNode.Tag as MythicPackageBlock );
				}

				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_SearchExpressionFound", args.Found.ToString() ) );
			}

			StatusProgressBar.Value = 0;
		}
		#endregion

		#region Misc
		private void TreeView_BeforeSelect( object sender, TreeViewCancelEventArgs e )
		{
			if ( TreeView.SelectedNode != null )
				TreeView.SelectedNode.BackColor = Color.Transparent;
		}

		private void TreeView_AfterSelect( object sender, TreeViewEventArgs e )
		{
			e.Node.BackColor = Color.LightGray;

			if ( e.Node.Tag is MythicPackage )
			{
				ChangePackage( (MythicPackage) e.Node.Tag );
				ClearBlock();
				ClearFile();
			}
			else if ( e.Node.Tag is MythicPackageBlock )
			{
				ChangeBlock( (MythicPackageBlock) e.Node.Tag );
				ClearFile();
			}
			else
			{
				ClearPackage();
				ClearBlock();
				ClearFile();
			}

			m_OldKeyword = null;
		}

		private void TreeView_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( (Keys) e.KeyChar == Keys.Escape )
			{
				if ( TreeView.SelectedNode != null )
					TreeView.SelectedNode.BackColor = Color.Transparent;

				TreeView.SelectedNode = null;
			}
			else if ( (Keys) e.KeyChar == Keys.Delete )
			{
				ButtonRemove.PerformClick();
			}
		}

		private void ListBox_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( (Keys) e.KeyChar == Keys.Delete )
			{
				ButtonRemove.PerformClick();
			}
		}

		private void ListBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			MythicPackageFile file = ListBox.SelectedItem as MythicPackageFile;

			if ( file != null )
			{
				if ( file.FileName != null )
					FileUnsetButton.Visible = true;
				else
					FileUnsetButton.Visible = false;

				ChangeFile( file );
			}
			else
			{
				ClearFile();
			}

			m_OldKeyword = null;
		}

		private void MainForm_Shown( object sender, EventArgs e )
		{
			DelayTimer timer = new DelayTimer( 100 );
			timer.Elapsed += new ElapsedEventHandler( DisableTopMost );
			timer.SynchronizingObject = this;
			timer.AutoReset = false;
			timer.Start();
		}

		private void Main_FormClosing( object sender, FormClosingEventArgs e )
		{
			e.Cancel = !TryExit();
		}

		private void HashSpy_HashFound( ulong hash, string fileName )
		{
            if (HashDictionary.Contains(hash))
            {
                HashDictionary.Set(hash, fileName);
                Globals.Logger.LogMessage(String.Format("Found string for hash {0:X}: {1}", hash, fileName));
            }
		}

		private void MythicPackage_UpdateProgress( int current, int max )
		{
			Worker.ReportProgress( Math.Min( current * 100 / max, 100 ) );
		}

		private void Worker_ProgressChanged( object sender, ProgressChangedEventArgs e )
		{
			StatusProgressBar.Value = e.ProgressPercentage;
		}

		private void SearchBox_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( (Keys) e.KeyChar == Keys.Enter )
			{
				TextSearch( SearchBox.Text, String.Equals( SearchBox.Text, m_OldKeyword ) );
				m_OldKeyword = SearchBox.Text;
			}
		}

		private void CopyMenuStripButton_Click( object sender, EventArgs e )
		{
			Clipboard.SetText( ((Label) CopyMenuStrip.Tag).Text, TextDataFormat.Text );
		}

		private void Label_MouseClick( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Right )
			{
				Label label = (Label) sender;

				CopyMenuStrip.Tag = label;
				CopyMenuStrip.Show( label, e.Location );
			}
			else if ( e.Button == MouseButtons.Left )
			{

				if ( ListBox.SelectedIndex > -1 )
				{
					MythicPackageFile idx = ListBox.SelectedItem as MythicPackageFile;

					if ( idx != null && idx.FileName == null )
					{
						new GuessFile( idx ).ShowDialog();
						FileFileNameInfo.Text = idx.FileName;
					}
				}
			}
		}

		private void FileUnsetButton_Click( object sender, EventArgs e )
		{
			MythicPackageFile file = ListBox.SelectedItem as MythicPackageFile;

			if ( file != null && file.FileName != null && HashDictionary.Unset( file.FileHash ) )
			{
				file.FileName = null;
				FileFileNameInfo.Text = String.Empty;
				FileUnsetButton.Visible = false;

				ListBox.Items[ ListBox.SelectedIndex ] = file;
				ListBox.Focus();
			}
			else
				ShowInfo( Globals.LanguageManager.GetString( "MainForm_Information_ErrorUnset" ) );
		}
        #endregion

        #endregion

        private void FolderFiles_Click( object sender, EventArgs e )
        {
			// set the root folder for the search
			SelectFolder.RootFolder = Environment.SpecialFolder.MyComputer;

			// select the folder containing all files
			if ( SelectFolder.ShowDialog() == DialogResult.OK )
            {
				// get the list of all files in the folder (and sub-folders)
				List<String> files = DirSearch( SelectFolder.SelectedPath );

				// base search result variable
				SearchResult result = SearchResult.NotFound;

				// total files found
				int total = 0;

				// scan all files
				for ( int f = 0; f < files.Count; f++ )
				{
					// search the files for all opened packages
					for ( int i = 0; i < TreeView.Nodes.Count; i++ )
					{
						// get the package node
						TreeNode node = TreeView.Nodes[ i ];

						// is this a package node?
						if ( node.Tag is MythicPackage )
						{
							// search the file in the package
							result = ( (MythicPackage)node.Tag ).Search( Path.GetFileName( files[f] ).ToLower() );

							// if we found the file, we increase the counter
							if ( result.Found )
								total++;
						}
					}
				}

				// show how many we have found
				ShowInfo( "Found: " + total + "/" + files.Count );
			}
		}

		private List<String> DirSearch( string sDir )
		{
			List<String> files = new List<String>();
			try
			{
				foreach ( string f in Directory.GetFiles( sDir ) )
				{
					files.Add( f );
				}
				foreach ( string d in Directory.GetDirectories( sDir ) )
				{
					files.AddRange( DirSearch( d ) );
				}
			}
			catch ( System.Exception excpt )
			{
				MessageBox.Show( excpt.Message );
			}

			return files;
		}
	}
}
