
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace MessageBox
{
	public partial class Form1 : KryptonForm
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void kbtnTest_Click(object sender, System.EventArgs e)
        {
            KryptonMessageBoxExtended.Show("Test Message", "Hello World", ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.EXCLAMATION, false);
        }
	}
}
