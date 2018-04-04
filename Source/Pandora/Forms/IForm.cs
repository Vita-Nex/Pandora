#region Header
// /*
//  *    2018 - Pandora - IForm.cs
//  */
#endregion

namespace TheBox.Forms
{
	public interface IForm
	{
		bool TopMost { get; set; }
		bool ShowInTaskbar { get; set; }
		double Opacity { get; set; }
		bool Visible { get; set; }
		void Show();
		void Close();
		void Dispose();
	}
}