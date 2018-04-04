using System;
using System.Collections;
using System.Xml.Serialization;

using Server;
using Server.Accounting;
using Server.Network;

namespace TheBox.BoxServer
{
	[ Serializable, XmlInclude( typeof( ClientEntry ) ) ]
	/// <summary>
	/// Defines the list of clients currently connected
	/// </summary>
	public class ClientListMessage : BoxMessage
	{
		private ArrayList m_Clients;

		/// <summary>
		/// Gets or sets the list of connected clients
		/// </summary>
		public ArrayList Clients
		{
			get { return m_Clients; }
			set { m_Clients = value; }
		}

		public ClientListMessage()
		{
			m_Clients = new ArrayList();

			foreach( NetState ns in NetState.Instances )
			{
				if ( ns.Mobile.AccessLevel == AccessLevel.Player )
				{
					m_Clients.Add( new ClientEntry( ns ) );
				}
			}
		}
	}

	public class ClientEntry
	{
		private string m_Name;
		private string m_Account;
		private int m_X;
		private int m_Y;
		private int m_Map;
		private DateTime m_LastLogin;
		private int m_Serial;

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the name of the connected client
			/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the name of the connected client
			/// </summary>
		public string Account
		{
			get { return m_Account; }
			set { m_Account = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the X location of the connected client
			/// </summary>
		public int X
		{
			get { return m_X; }
			set { m_X = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the Y location of the connected client
			/// </summary>
		public int Y
		{
			get { return m_Y; }
			set { m_Y = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the map of the connected client
			/// </summary>
		public int Map
		{
			get { return m_Map; }
			set { m_Map = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the last login time
			/// </summary>
		public string LastLogin
		{
			get { return m_LastLogin.ToString(); }
			set
			{
				try { m_LastLogin = DateTime.Parse( value ); }
				catch { m_LastLogin = DateTime.MinValue; }
			}
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the mobile's serial
			/// </summary>
		public int Serial
		{
			get { return m_Serial; }
			set { m_Serial = value; }
		}

		public ClientEntry()
		{
		}

		public ClientEntry( NetState ns )
		{
			m_Name = ns.Mobile.Name;
			m_Serial = ns.Mobile.Serial;
			m_Account = ( ns.Account as Account ).Username;
			m_X = ns.Mobile.Location.X;
			m_Y = ns.Mobile.Location.Y;
			m_Map = ns.Mobile.Map.MapID;
			m_LastLogin = ( ns.Account as Account ).LastLogin;
		}
	}
}
