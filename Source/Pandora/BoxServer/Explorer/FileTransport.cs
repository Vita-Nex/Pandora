#region Header
// /*
//  *    2018 - Pandora - FileTransport.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Uploads a file to the server or downloads a file to Pandora
	/// </summary>
	public class FileTransport : ExplorerMessage
	{
		private string m_Filename;
		private string m_Text;

		/// <summary>
		///     Gets or sets the path to the file relative to the RunUO folder
		/// </summary>
		public string Filename { get => m_Filename; set => m_Filename = value; }

		/// <summary>
		///     Gets or sets the content of the file
		/// </summary>
		public string Text { get => m_Text; set => m_Text = value; }
	}
}