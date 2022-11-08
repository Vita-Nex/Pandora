#region Header
// /*
//  *    2018 - Pandora - CreateFolder.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Creates a new folder on the server
	/// </summary>
	public class CreateFolder : ExplorerMessage
	{
		private string m_Folder;

		/// <summary>
		///     Gets or sets the name of the new folder
		/// </summary>
		public string Folder { get => m_Folder; set => m_Folder = value; }
	}
}