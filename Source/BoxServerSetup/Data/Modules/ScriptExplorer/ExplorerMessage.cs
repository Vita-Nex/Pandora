using System;
using System.Collections;
using Server;
using Server.Misc;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// This is the base message for all Script Explorer actions
	/// </summary>
	public class ExplorerMessage : BoxMessage, IAuthenticable
	{
		/// <summary>
		/// The list of folders allowed for this user
		/// </summary>
		protected ArrayList m_Folders;

		public ExplorerMessage()
		{
		}

		#region IAuthenticable Members

		public Server.AccessLevel MinAccessLevel
		{
			get
			{
				return AccessLevel.Administrator;
			}
		}

		public bool RequireOnlineMobile
		{
			get
			{
				return false;
			}
		}

		#endregion

		public override AuthenticationResult Authenticate(string password, bool hashed)
		{
			AuthenticationResult auth = base.Authenticate( password, AccountHandler.ProtectPasswords );
			
			if ( auth == AuthenticationResult.Success )
			{
				string[] folders = RemoteExplorerConfig.GetExplorerFolder( Username );

				if ( folders != null && folders.Length > 0 )
				{
					m_Folders = new ArrayList( folders );
					return AuthenticationResult.Success;
				}
				else
				{
					return AuthenticationResult.UnregisteredUser;
				}
			}
			else
			{
				return auth;
			}
		}
	}
}