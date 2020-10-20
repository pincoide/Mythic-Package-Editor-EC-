using System;
using System.Reflection;
using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();

			// version
			Assembly asm = Assembly.GetExecutingAssembly();
			Version.Text = asm.GetName().Version.ToString();
		}
	}
}
