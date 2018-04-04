#region Header
// /*
//  *    2018 - Pandora - ClientCommand.cs
//  */
#endregion

#region References
using System.Xml.Serialization;
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     Summary description for ClientRequestHandler.
	/// </summary>
	public class ClientListCommand : BoxMessage
	{
		[XmlAttribute]
		/// <summary>
		/// Gets or sets the command string
		/// </summary>
		public string Command { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the player serial
		/// </summary>
		public int Serial { get; set; }

		public ClientListCommand()
		{ }

		public ClientListCommand(int serial, string command)
		{
			Serial = serial;
			Command = command;
		}
	}
}