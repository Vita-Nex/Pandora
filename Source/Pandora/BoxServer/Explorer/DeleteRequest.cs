#region Header
// /*
//  *    2018 - Pandora - DeleteRequest.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Processes a request to delete a file or a folder
	/// </summary>
	public class DeleteRequest : ExplorerMessage
	{
		private string m_Path;

		/// <summary>
		///     Gets or sets the path that must be deleted
		/// </summary>
		public string Path { get => m_Path; set => m_Path = value; }

		/// <summary>
		///     Creates a new delete request
		/// </summary>
		public DeleteRequest()
		{ }

		/// <summary>
		///     Creates a new DeleteRequest
		/// </summary>
		/// <param name="path">The relative path that should be deleted</param>
		public DeleteRequest(string path)
		{
			m_Path = path;
		}
	}
}