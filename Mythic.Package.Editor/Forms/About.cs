using System.Windows.Forms;

namespace Mythic.Package.Editor
{
	public partial class About : Form
	{
		public About()
		{
			// initialize the components
			InitializeComponent();

			// set the version
			lblVersionInfo.Text = Application.ProductVersion;
		}
	}
}
