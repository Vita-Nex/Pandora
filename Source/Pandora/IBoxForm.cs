#region Header
// /*
//  *    2018 - Pandora - IBoxForm.cs
//  */
#endregion

#region References
using TheBox.Forms;
using TheBox.Pages;
#endregion

namespace TheBox
{
	public interface IBoxForm : IForm
	{
		Mobiles Mobiles { get; }
		string NextProfile { get; }
		Props Properties { get; }
		int SelectedHue { set; }
		Travel Travel { get; }

		string[] GetTabNames();
		void ChangeProfile(string nextProfile);
		void SelectSmallTab(SmallTabs tab);
		void UpdateBoxData();
		void UpdateButtonStyle();
	}
}