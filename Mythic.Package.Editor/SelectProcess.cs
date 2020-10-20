using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class SelectProcess : Form
	{
		public SelectProcess()
		{
			InitializeComponent();
		}

		private void InitializeProcesses()
		{
			Process[] list = Process.GetProcesses();			
			ProcessList.Items.Clear();

			foreach ( Process p in list )
				ProcessList.Items.Add( new ProcessItem( p ) );
		}

		public Process GetSelectedProcess()
		{
			ProcessItem item = ProcessList.SelectedItem as ProcessItem;

			if ( item != null )
				return item.Process;

			return null;
		}

		private class ProcessItem
		{
			private Process m_Process;

			public Process Process{ get{ return m_Process; } }

			public ProcessItem( Process process )
			{
				m_Process = process;
			}

			public override string ToString()
			{
				if ( m_Process != null )
					return m_Process.ProcessName;

				return "Boogeyman";
			}
		}

		private void ButtonRefresh_Click( object sender, EventArgs e )
		{
			InitializeProcesses();
		}

		protected override void OnShown( EventArgs e )
		{
			base.OnShown( e );
						
			InitializeProcesses();
		}
	}
}
