#region Header
// /*
//  *    2018 - Pandora - ClientListRequest.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Requests a client list
	/// </summary>
	public class ClientListRequest : BoxMessage
	{
		public override BoxMessage Perform()
		{
			return new ClientListMessage();
		}
	}
}