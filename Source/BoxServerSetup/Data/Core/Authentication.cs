using System;

using Server;
using Server.Accounting;
using Server.Network;
using Server.Misc;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Interface for messages that support advanced authentication
	/// </summary>
	public interface IAuthenticable
	{
		/// <summary>
		/// The minimum AccessLevel required for the message to perform
		/// </summary>
		AccessLevel MinAccessLevel
		{
			get;
		}

		/// <summary>
		/// Specifies if an online mobile is needed for the message to perform
		/// </summary>
		bool RequireOnlineMobile
		{
			get;
		}
	}

	/// <summary>
	/// Provides methods for authentication for Pandora's Box users
	/// </summary>
	public class Authentication
	{
		/// <summary>
		/// Gets an account given the username
		/// </summary>
		/// <param name="username">The username for the account</param>
		/// <returns>The Account object</returns>
		public static Account GetAccount( string username )
		{
			return Server.Accounting.Accounts.GetAccount( username );
		}

		/// <summary>
		/// Verifies if an account has a minimum access level
		/// </summary>
		/// <param name="account">The account to examine</param>
		/// <param name="MinAccessLevel">The required access level</param>
		/// <returns>True if the access level is allowed</returns>
		public static bool VerifyAccountAccessLevel( Account account, AccessLevel MinAccessLevel )
		{
			if ( account.AccessLevel >= MinAccessLevel )
			{
				return true; // Staff account
			}

			// Verify all characters
			for( int i = 0; i < 5; i++ )
			{
				if ( account[ i ] != null && account[ i ].AccessLevel >= MinAccessLevel )
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Verifies if an account has a minimum access level
		/// </summary>
		/// <param name="account">The username of the account to examine</param>
		/// <param name="MinAccessLevel">The required access level</param>
		/// <returns>True if the access level is allowed</returns>
		public static bool VerifyAccountAccessLevel( string username, AccessLevel MinAccessLevel )
		{
			return VerifyAccountAccessLevel( GetAccount( username ), MinAccessLevel );
		}

		/// <summary>
		/// Verify if an account has a valid mobile logged in
		/// </summary>
		/// <param name="account">The account to examine</param>
		/// <param name="MinAccessLevel">The required access level</param>
		/// <returns>True if the access level is allowed</returns>
		public static bool VerifyMobileAccessLevel( Account account, AccessLevel MinAccessLevel )
		{
			Mobile m = GetOnlineMobile( account );

			return ( m != null && m.AccessLevel >= MinAccessLevel );
		}

		/// <summary>
		/// Verify if an account has a valid mobile logged in
		/// </summary>
		/// <param name="username">The username of the account to examine</param>
		/// <param name="MinAccessLevel">The required access level</param>
		/// <returns>True if the access level is allowed</returns>
		public static bool VerifyMobileAccessLevel( string username, AccessLevel MinAccessLevel )
		{
			return VerifyMobileAccessLevel( GetAccount( username ), MinAccessLevel );
		}

		/// <summary>
		/// Gets the online mobile for a given account
		/// </summary>
		/// <param name="account">The account that's logged into the server</param>
		/// <returns>A Mobile if the account is logged in, null otherwise</returns>
		public static Mobile GetOnlineMobile( Account account )
		{
			foreach( NetState ns in NetState.Instances )
			{
				if ( ( ns.Account as Account ) == account )
				{
					return ns.Mobile;
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the online mobile for a given account
		/// </summary>
		/// <param name="username">The username corresponding to the given account</param>
		/// <returns>A Mobile if the account is logged in, null otherwise</returns>
		public static Mobile GetOnlineMobile( string username )
		{
			return GetOnlineMobile( GetAccount( username ) );
		}

		/// <summary>
		/// Performs authentication for a BoxMessage
		/// </summary>
		/// <param name="msg">The message to authenticate</param>
		/// <returns>The AuthenticationResult defininf the authentication process</returns>
		public static AuthenticationResult Authenticate( BoxMessage msg )
		{
			Account account = GetAccount( msg.Username );

			if ( account == null )
			{
				// Account doesn't exist
				return AuthenticationResult.WrongCredentials;
			}

			AuthenticationResult auth = AuthenticationResult.WrongCredentials;

			if ( AccountHandler.ProtectPasswords )
			{
				auth = msg.Authenticate( account.CryptPassword, true );
			}
			else
			{
				auth = msg.Authenticate( account.PlainPassword, false );
			}

			if ( auth == AuthenticationResult.Success )
			{
				IAuthenticable iAuth = msg as IAuthenticable;

				if ( iAuth != null )
				{
					// This message has further authentication properties
					if ( iAuth.RequireOnlineMobile )
					{
						// Check for online mobile
						if ( Authentication.VerifyMobileAccessLevel( account, iAuth.MinAccessLevel ) )
						{
							return AuthenticationResult.Success;
						}
						else
						{
							return AuthenticationResult.OnlineMobileRequired;
						}
					}
					else
					{
						if ( Authentication.VerifyAccountAccessLevel( account, iAuth.MinAccessLevel ) )
						{
							return AuthenticationResult.Success;
						}
						else
						{
							return AuthenticationResult.AccessLevelError;
						}
					}
				}
				else
				{
					// No need for advanced authentication, check only access level
					if ( Authentication.VerifyAccountAccessLevel( account, BoxConfig.MinAccessLevel ) )
						return AuthenticationResult.Success;
					else
						return AuthenticationResult.AccessLevelError;
				}
			}
			else
			{
				return auth;
			}
		}
	}
}
