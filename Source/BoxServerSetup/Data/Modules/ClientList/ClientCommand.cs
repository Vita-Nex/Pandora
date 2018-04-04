using System;
using System.Xml.Serialization;
using Server;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Summary description for ClientRequestHandler.
	/// </summary>
	public class ClientListCommand : BoxMessage, IAuthenticable
	{
		private string m_Command;
		private int m_Serial;

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the command string
		/// </summary>
		public string Command
		{
			get { return m_Command; }
			set { m_Command = value; }
		}

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the player serial
		/// </summary>
		public int Serial
		{
			get { return m_Serial; }
			set { m_Serial = value; }
		}

		public ClientListCommand()
		{
		}

		#region IAuthenticable Members

		public Server.AccessLevel MinAccessLevel
		{
			get
			{
				return AccessLevel.GameMaster;
			}
		}

		public bool RequireOnlineMobile
		{
			get
			{
				return true;
			}
		}

		#endregion

		public override BoxMessage Perform()
		{
			Mobile from = Authentication.GetOnlineMobile( Username );

			if ( from == null )
				return null;

			Mobile target = World.FindMobile( (Serial) m_Serial );

			if ( target == null || ! ( target is Server.Mobiles.PlayerMobile ) || target.NetState == null )
			{
				from.SendMessage( BoxConfig.MessageHue, "Invalid target. The user might no longer be online." );
				return null;
			}

			switch( m_Command.ToLower() )
			{
				case "go" : // Go to mobile

					from.Map = target.Map;
					from.Location = target.Location;
					break;

				case "props" : // View props

					from.SendGump( new Server.Gumps.PropertiesGump( from, target ) );
					break;

				case "client" : // View client

					from.SendGump( new Server.Gumps.ClientGump( from, target.NetState ) );
					break;

				case "account" : // View account information

					if ( from.AccessLevel == AccessLevel.Administrator || ( from.Account as Server.Accounting.Account ).AccessLevel == AccessLevel.Administrator )
					{
						from.SendGump( new Server.Gumps.AdminGump( from, Server.Gumps.AdminGumpPage.AccountDetails_Information, 0, null, "Request from Pandora's Box", target.Account ) );
					}
					else
					{
						from.SendMessage( BoxConfig.MessageHue, "That feature is only accessible to administrators." );
					}

					break;
			}

			return null;
		}

	}
}
