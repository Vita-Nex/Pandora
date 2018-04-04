#region Header
// /*
//  *    2018 - Pandora - BoxForm.cs
//  */
#endregion

#region References
using System.Windows.Forms;
#endregion

namespace TheBox
{
	/// <summary>
	///     Attempt to create an scalable form by Tarion
	///     Using newer .net functions like:
	///     - partial class
	///     - ContextMenuStrip
	///     The UserControls have to be rebuilded, too. This is not deployed until it is finished.
	/// </summary>
	public partial class BoxForm : Form
	{
		public BoxForm()
		{
			InitializeComponent();
		}
	}
}