using System;

using Server;

namespace TheBox.BoxServer
{
	/// <summary>
	/// Provides configuration settings for BoxServer
	/// </summary>
	public class BoxConfig
	{
		/// <summary>
		/// This is the port used by the tcp server
		/// </summary>
		public static readonly int Port = 8035;

		/// <summary>
		/// The hue used to display all BoxServer messages
		/// </summary>
		public static readonly int MessageHue = 52;

		/// <summary>
		/// The general access level needed to use BoxServer. Can be overridden in individual modules.
		/// </summary>
		public static readonly AccessLevel MinAccessLevel = AccessLevel.GameMaster;
	}
}