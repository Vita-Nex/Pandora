#region Header
// /*
//  *    2018 - Pandora - AdminOptions.cs
//  */
#endregion

#region References
using TheBox.Common;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Provides administration options
	/// </summary>
	public class AdminOptions
	{
		/// <summary>
		///     Creates a new AdminOptions object
		/// </summary>
		public AdminOptions()
		{
			ConsoleHidden = false;
			ConsoleTitle = null;
			Console = 0;
			ServerExe = null;
			FindByName = new RecentStringList();
			Args = new RecentStringList();
		}

		/// <summary>
		///     Gets or sets the recent searches
		/// </summary>
		public RecentStringList FindByName { get; set; }

		/// <summary>
		///     Gets or sets the Server executable file
		/// </summary>
		public string ServerExe { get; set; }

		/// <summary>
		///     Gets or sets the
		/// </summary>
		public int Console { get; set; }

		/// <summary>
		///     Gets or sets the title of the console window
		/// </summary>
		public string ConsoleTitle { get; set; }

		/// <summary>
		///     States whether the console has been hidden
		/// </summary>
		public bool ConsoleHidden { get; set; }

		/// <summary>
		///     Gets or sets the recent command line arguments
		/// </summary>
		public RecentStringList Args { get; set; }
	}
}