#region Header
// /*
//  *    2018 - Pandora - RandomItem.cs
//  */
#endregion

#region References
using System;
using System.Collections;
using System.Xml.Serialization;

using TheBox.Data;
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(RandomTile))]
	/// <summary>
	/// Allows the user to click multiple times and add a different item each time
	/// </summary>
	public class RandomItem : BoxMessage
	{
		private ArrayList m_Hues;
		private ArrayList m_Items;

		/// <summary>
		///     Gets or sets the list of hues to be used for the tiled items
		/// </summary>
		public ArrayList Hues { get => m_Hues; set => m_Hues = value; }

		/// <summary>
		///     Gets or sets the list of items that can be randomly picked
		/// </summary>
		public ArrayList Items { get => m_Items; set => m_Items = value; }

		public RandomItem()
		{
			m_Hues = new ArrayList();
			m_Items = new ArrayList();
		}

		public RandomItem(RandomTilesList tileset, HuesCollection hues)
			: this()
		{
			m_Hues.AddRange(hues.Hues);
			m_Items.AddRange(tileset.Tiles);
		}

		public RandomItem(RandomTilesList tileset, int hue)
			: this()
		{
			_ = m_Hues.Add(hue);
			m_Items.AddRange(tileset.Tiles);
		}

		public RandomItem(RandomTilesList tileset)
			: this(tileset, 0)
		{ }
	}
}