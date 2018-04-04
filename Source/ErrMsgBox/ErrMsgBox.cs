#region Header
// /*
//  *    2018 - ErrMsgBox - ErrMsgBox.cs
//  */
#endregion

#region References
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.CustomMessageBox
{
	public class ErrMsgBox
	{
		static public DialogResult Show(string message)
		{
			return Show(message, string.Empty, MessageBoxButtons.OK);
		}

		static public DialogResult Show(string message, string title)
		{
			return Show(message, title, MessageBoxButtons.OK);
		}

		static public DialogResult Show(string message, string title, MessageBoxButtons buttons)
		{
			// Create a host form that is a TopMost window which will be the 

			// parent of the MessageBox.

			var topmostForm = new Form();
			// We do not want anyone to see this window so position it off the 

			// visible screen and make it as small as possible

			topmostForm.Size = new Size(1, 1);
			topmostForm.StartPosition = FormStartPosition.Manual;
			var rect = SystemInformation.VirtualScreen;
			topmostForm.Location = new Point(rect.Bottom + 10, rect.Right + 10);
			topmostForm.Show();
			// Make this form the active form and make it TopMost

			topmostForm.Focus();
			topmostForm.BringToFront();
			topmostForm.TopMost = true;
			// Finally show the MessageBox with the form just created as its owner

			var result = MessageBox.Show(topmostForm, message, title, buttons);
			topmostForm.Dispose(); // clean it up all the way

			return result;
		}
	}
}