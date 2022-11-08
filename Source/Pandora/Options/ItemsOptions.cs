#region Header
// /*
//  *    2018 - Pandora - ItemsOptions.cs
//  */
#endregion

#region References
using TheBox.Common;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Provides options for the Items tab
	/// </summary>
	public class ItemsOptions
	{
		private int m_Nudge;
		private int m_Tile;

		// <summary>
		/// Gets or sets the spawn amount
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
		///     Gets or sets the ID of the art displayed by the viewer
		/// </summary>
		public int ArtIndex { get; set; }

		/// <summary>
		///     Gets or sets the hue of the art displayed by the viewer
		/// </summary>
		public int ArtHue { get; set; }

		/// <summary>
		///     Gets or sets the position of the splitter
		/// </summary>
		public int Splitter { get; set; }

		/// <summary>
		///     States whether the user wishes to use an additional constructor when available
		/// </summary>
		public bool UseOptions { get; set; }

		/// <summary>
		///     States whether the use custom parameters checkbox is checked
		/// </summary>
		public bool UseCustomParams { get; set; }

		/// <summary>
		///     Gets or sets the recently used custom parameters
		/// </summary>
		public RecentStringList CustomParams { get; set; }

		/// <summary>
		///     Gets or sets the nudge amount displayed by the nudge numeric up and down
		/// </summary>
		public int Nudge { get => m_Nudge; set => m_Nudge = Utility.ValidateNumber(value, 0, 127); }

		/// <summary>
		///     Gets or sets the items tile height
		/// </summary>
		public int Tile { get => m_Tile; set => m_Tile = Utility.ValidateNumber(value, -128, 127); }

		/// <summary>
		///     Creates a new ItemsOptions object
		/// </summary>
		public ItemsOptions()
		{
			UseCustomParams = false;
			UseOptions = false;
			Splitter = 0;
			ArtHue = 0;
			ArtIndex = 0;
			Extra = 0;
			Team = 0;
			CustomParams = new RecentStringList();
		}
	}
}