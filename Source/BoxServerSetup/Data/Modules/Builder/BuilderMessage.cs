using System;
using System.Collections;
using System.Xml.Serialization;
using Server;

namespace TheBox.BoxServer
{
	[ Serializable, XmlInclude( typeof( BuildItem ) ) ]
	/// <summary>
	/// Requests the server to build a structure
	/// </summary>
	public class BuildMessage : BoxMessage, IAuthenticable
	{
		private ArrayList m_Items;

		/// <summary>
		/// Gets or sets the items composing this structure
		/// </summary>
		public ArrayList Items
		{
			get { return m_Items; }
			set { m_Items = value; }
		}

		/// <summary>
		/// Creates a new build request
		/// </summary>
		public BuildMessage()
		{
		}

		public override BoxMessage Perform()
		{
			Mobile m = Authentication.GetOnlineMobile( Username );

			if ( m == null )
			{
				return new TheBox.BoxServer.LoginError( AuthenticationResult.OnlineMobileRequired );
			}

			Map map = m.Map;

			BuilderCore.Build( Username, m_Items, map );

			return null;
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
	}
}