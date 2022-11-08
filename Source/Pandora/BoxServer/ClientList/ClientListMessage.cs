#region Header
// /*
//  *    2018 - Pandora - ClientListMessage.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - end
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(ClientEntry))]
	/// <summary>
	/// Defines the list of clients currently connected
	/// </summary>
	public class ClientListMessage : BoxMessage
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<ClientEntry> m_Clients;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the list of connected clients
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<ClientEntry> Clients
		// Issue 10 - End
		{
			get => m_Clients;
			set => m_Clients = value;
		}
	}

	public class ClientEntry
	{
		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name of the connected client
		/// </summary>
		public string Name { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name of the connected client
		/// </summary>
		public string Account { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the X location of the connected client
		/// </summary>
		public int X { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Y location of the connected client
		/// </summary>
		public int Y { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the map of the connected client
		/// </summary>
		public int Map { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the last login time
		/// </summary>
		public string LastLogin
		{
			get => LoggedIn.ToString();
			set
			{
				try
				{
					LoggedIn = DateTime.Parse(value);
				}
				catch
				{
					LoggedIn = DateTime.MinValue;
				}
			}
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the mobile's serial
		/// </summary>
		public int Serial { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets the last login time
		/// </summary>
		public DateTime LoggedIn { get; private set; }
	}
}