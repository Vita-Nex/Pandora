#region Header
// /*
//  *    2018 - Pandora - ISplash.cs
//  */
#endregion

namespace TheBox.Common
{
	public interface ISplash
	{
		void Close();
		void SetStatusText(string text);
		void Show();
	}
}