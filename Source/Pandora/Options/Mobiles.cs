#region Header
// /*
//  *    2018 - Pandora - Mobiles.cs
//  */
#endregion

#region References
using TheBox.Common;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Contains options relating to Mobiles
	/// </summary>
	public class MobilesOptions
	{
		/// <summary>
		///     Creates a new MobilesOptions object
		/// </summary>
		public MobilesOptions()
		{
			NameMount = false;
			Extra = 0;
			Team = 0;
			ArtIndex = 0;
			RecentNames = new RecentStringList();
		}

		/// <summary>
		///     Gets or sets the value representing the selected art for Mobiles
		/// </summary>
		public int ArtIndex { get; set; }

		/// <summary>
		///     Gets or sets the spawn amount
		/// </summary>
		public int Amount { get; set; } = 1;

		/// <summary>
		///     Gets or sets the spawn range
		/// </summary>
		public int Range { get; set; } = 1;

		/// <summary>
		///     Gets or sets the min delay for the spawn
		/// </summary>
		public int MinDelay { get; set; } = 5;

		/// <summary>
		///     Gets or sets the max delay for the spawn
		/// </summary>
		public int MaxDelay { get; set; } = 10;

		/// <summary>
		///     Gets or sets the spawn team
		/// </summary>
		public int Team { get; set; }

		/// <summary>
		///     Gets or sets the additional extra property for spawns
		/// </summary>
		public int Extra { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used names
		/// </summary>
		public RecentStringList RecentNames { get; set; }

		/// <summary>
		///     Gets or sets a value stating whether to name mounts when adding them
		/// </summary>
		public bool NameMount { get; set; }
	}
}