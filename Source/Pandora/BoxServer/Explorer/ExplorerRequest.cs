#region Header
// /*
//  *    2018 - Pandora - ExplorerRequest.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Requests BoxServer to provide information about the folders and files available for remote manipulation
	/// </summary>
	public class ExplorerRequest : ExplorerMessage
	{ }
}