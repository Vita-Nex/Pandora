/*///////////////////////////////////////////////////////////////////////////////////////////////////////////
 * 
 * Remote Explorer is a component that allows a remote user to access a folder within
 * the server's Scripts folder. The remote user can download, upload, delete and rename
 * scripts files (*.cs), and create/delete folders.
 * 
 * Each account that is allowed to use the remote explorer must be explicitly specified in
 * this file, and assigned the parent folder for its operation. Registering an account is very
 * easy:
 * 
 * RegisterAccount( string AccountName, params string[] folders );
 * 
 * the AccountName is the user's account name. The folders parameters is a list of folders the user
 * is allowed to access on the server. Folders are specified relatively to the RunUO folder:
 * 
 * "Scripts" - will allows access to ALL the scripts.
 * "Scripts\Custom\Arya" - will allow access only to a subfolder.
 * 
 * Please take most care when assigning folders, I suggest you don't assign the whole Scripts
 * folder to anyone else than yourself, and that you assign your staff custom folders as in the
 * example. This is a powerful but potentially dangerous feature, please be careful who you give
 * access to your scripts. 
 * 
 *///////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Provides configuration for the Remote Explorer
	/// </summary>
	public class RemoteExplorerConfig
	{
		/// <summary>
		/// This is the maximum size in bytes for a file that will be downloaded from the server
		/// </summary>
		public static readonly int MaxFileSize = 100000;

		public static void Initialize()
		{
			/*////////////////////////////////////////////////////////////
			 * 
			 * Register accounts and access folders here.
			 * Example:
			 * 
			 * RegisterAccount( "arya", "Scripts\\Custom\\Arya", "Scripts\\Items", "Scripts\\Mobiles" );
			 * 
			 *////////////////////////////////////////////////////////////
		}

		#region Implementation

		/// <summary>
		/// Registers an account for access to the remote explorer in Pandora's Box
		/// </summary>
		/// <param name="username">The username that should receive access</param>
		/// <param name="folders">A list of folder, specified relative to the RunUO folder (must start with "Scripts\\"</param>
		private static void RegisterAccount( string username, params string[] folders )
		{
			m_Table[ username.ToLower() ] = folders;
		}

		/// <summary>
		/// Contains all the allowed user accounts
		/// </summary>
		private static Hashtable m_Table;

		/// <summary>
		/// Static init
		/// </summary>
		static RemoteExplorerConfig()
		{
			m_Table = new Hashtable();
		}

		/// <summary>
		/// Gets the base folder for the remote explorer for a given username
		/// </summary>
		/// <param name="username">The user's account name</param>
		/// <returns>The full path to the user's allowed folder</returns>
		public static string[] GetExplorerFolder( string username )
		{
			return (string[]) m_Table[ username.ToLower() ];
		}

		/// <summary>
		/// Verifies if a user can access a given folder
		/// </summary>
		/// <param name="username">The user requesting to access the folder</param>
		/// <param name="folder">The path to the requested folder, relative to the RunUO folder</param>
		/// <returns>True if allowed</returns>
		public static bool AllowAccess( string username, string folder )
		{
			string[] allowedfolders = (string[]) m_Table[ username.ToLower() ];

			if ( allowedfolders == null )
				return false;

			string requested = System.IO.Path.Combine( BoxUtil.RunUOFolder, folder );
			requested = System.IO.Path.GetDirectoryName( requested );

			foreach( string allowed in allowedfolders )
			{
				string a = System.IO.Path.Combine( BoxUtil.RunUOFolder, allowed );

				if ( requested.IndexOf( a ) > -1 )
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Verifies if a file can be processed through the remote explorer
		/// </summary>
		/// <param name="file">The filename to evaluate</param>
		/// <returns>True if the extension is supported</returns>
		public static bool VeirfyExtension( string file )
		{
			string ext = System.IO.Path.GetExtension( file );

			return ( 
				ext == ".txt" ||
				ext == ".xml" ||
				ext == ".cs" ||
				ext == ".vb" );
		}

		#endregion
	}
}