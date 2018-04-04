using System;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Requests a client list
	/// </summary>
	public class ClientListRequest : BoxMessage
	{
		public ClientListRequest()
		{
		}

		public override BoxMessage Perform()
		{
			return new ClientListMessage();
		}
	}
}