#region Header
// /*
//  *    2018 - Pandora - MoveRequest.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Requests a rename or move action on the server
	/// </summary>
	public class MoveRequest : ExplorerMessage
	{
		private string m_OldPath;

		/// <summary>
		///     Gets or sets the previous name of location to move
		/// </summary>
		public string OldPath { get { return m_OldPath; } set { m_OldPath = value; } }

		private string m_NewPath;

		/// <summary>
		///     Gets or sets the new location of the object
		/// </summary>
		public string NewPath { get { return m_NewPath; } set { m_NewPath = value; } }
	}
}