#region Header
// /*
//  *    2018 - Pandora - RandomPalettes.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Drawing;

using TheBox.BoxServer;
using TheBox.MapViewer;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	#region Random Rectangle
	/// <summary>
	///     Creates a random rectangle tiling
	/// </summary>
	public class RandomRectangle
	{
		private readonly RandomTilesList m_TileSet;
		private Rectangle m_Rectangle;
		private bool[,] m_Grid;
		private readonly double m_Fill;
		private BuildMessage m_Message;
		private readonly int m_Map;

		private int m_Hue;

		/// <summary>
		///     Gets or sets the hue used to hue the items
		/// </summary>
		public int Hue
		{
			get { return m_Hue; }
			set
			{
				m_Hue = value;
				RandomHues = null;
			}
		}

		/// <summary>
		///     Gets or sets the random hues collection used to hue the items
		/// </summary>
		public HuesCollection RandomHues { get; set; }

		/// <summary>
		///     Gets or sets the Z at which tiling occurs
		/// </summary>
		public int Z { get; set; }

		/// <summary>
		///     Creates a BoxMessage by applying the random logic to the structure
		/// </summary>
		/// <returns>The calculated BoxMessage</returns>
		public BuildMessage CreateMessage()
		{
			GenerateGrid();
			GenerateItems();

			return m_Message;
		}

		/// <summary>
		///     Creates a new random rectangle tiler
		/// </summary>
		/// <param name="tileset">The random tileset to use</param>
		/// <param name="rectangle">The rectangle for the tiling</param>
		/// <param name="fillpercentage">The percentage of the rectangle that should be filled</param>
		/// <param name="map">The map on which the tiling will occur</param>
		public RandomRectangle(RandomTilesList tileset, Rectangle rectangle, double fillpercentage, int map)
		{
			m_TileSet = tileset;
			m_Rectangle = rectangle;
			m_Fill = fillpercentage;
			m_Map = map;
		}

		/// <summary>
		///     Generates the grid for the tiling according to the fill percentage
		/// </summary>
		private void GenerateGrid()
		{
			m_Grid = new bool[m_Rectangle.Width, m_Rectangle.Height];
			var rnd = new Random();

			for (var x = 0; x < m_Rectangle.Width; x++)
			{
				for (var y = 0; y < m_Rectangle.Height; y++)
				{
					m_Grid[x, y] = rnd.NextDouble() <= m_Fill;
				}
			}
		}

		/// <summary>
		///     Generates the items
		/// </summary>
		private void GenerateItems()
		{
			var rnd = new Random();
			m_Message = new BuildMessage();

			var oldMap = Pandora.Map.Map;
			Pandora.Map.Map = (Maps)m_Map;

			for (var x = 0; x < m_Rectangle.Width; x++)
			{
				for (var y = 0; y < m_Rectangle.Height; y++)
				{
					if (!m_Grid[x, y])
						continue;

					var tile = m_TileSet.Tiles[rnd.Next(m_TileSet.Tiles.Count)] as RandomTile;

					foreach (int id in tile.Items)
					{
						var item = new BuildItem();
						item.ID = id;

						// Hue
						var hue = m_Hue;

						if (RandomHues != null)
						{
							// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
							hue = RandomHues.Hues[rnd.Next(RandomHues.Hues.Count)];
							// Issue 10 - End
						}

						item.Hue = hue;

						// Location
						item.X = m_Rectangle.X + x;
						item.Y = m_Rectangle.Y + y;

						if (Z != -1)
							item.Z = Pandora.Map.GetMapHeight(new Point(item.X, item.Y));
						else
							item.Z = Z;

						m_Message.Items.Add(item);
					}
				}
			}

			Pandora.Map.Map = oldMap;
		}
	}
	#endregion

	#region Random Brush
	/// <summary>
	///     Defines a brush that can be randomized
	/// </summary>
	public class RandomBrush
	{
		private bool[,] m_Grid;

		/// <summary>
		///     Gets or sets the brush width
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		///     Gets or sets the brush height
		/// </summary>
		public int Height { get; set; }

		public RandomBrush(int width, int height)
		{
			Width = width;
			Height = height;
		}

		/// <summary>
		///     Randomizes the brush
		/// </summary>
		/// <param name="fill">The percentage of the brush area to fill</param>
		public void RandomizeBrush(double fill)
		{
			m_Grid = new bool[Width, Height];

			var rnd = new Random();

			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					m_Grid[x, y] = rnd.NextDouble() < fill;
				}
			}
		}

		/// <summary>
		///     Creates the message that performs the brush
		/// </summary>
		/// <param name="tileset">The tileset for the brush</param>
		/// <param name="hues">A list of hues to use for the brush</param>
		/// <param name="fill">The are percentage to fill</param>
		/// <returns>The server message created</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private RandomBrushMessage CreateMessage(RandomTilesList tileset, List<int> hues, double fill)
			// Issue 10 - End
		{
			var msg = new RandomBrushMessage();
			var rnd = new Random();

			RandomizeBrush(fill);

			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					if (m_Grid[x, y])
					{
						var tile = tileset.Tiles[rnd.Next(tileset.Tiles.Count)] as RandomTile;

						foreach (int id in tile.Items)
						{
							var item = new BuildItem();

							item.ID = id;
							// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
							item.Hue = hues[rnd.Next(hues.Count)];
							// Issue 10 - End

							item.X = x - (Width / 2);
							item.Y = y - (Height / 2);

							msg.Items.Add(item);
						}
					}
				}
			}

			return msg;
		}

		/// <summary>
		///     Creates the message that will perform the brush using a random hue
		/// </summary>
		/// <param name="tileset">The tileset to choose items from</param>
		/// <param name="hues">The hues list to choose hues from</param>
		/// <param name="fill">The percentage of the area to fill</param>
		/// <returns>A message that can be sent to the server</returns>
		public RandomBrushMessage CreateMessage(RandomTilesList tileset, HuesCollection hues, double fill)
		{
			return CreateMessage(tileset, hues.Hues, fill);
		}

		/// <summary>
		///     Creates the message that will perform the brush using a single hue
		/// </summary>
		/// <param name="tileset">The tileset to use in the message</param>
		/// <param name="hue">The hue to use for the items</param>
		/// <param name="fill">Percentage of the area to fill</param>
		/// <returns>A message that can be sent to the server</returns>
		public RandomBrushMessage CreateMessage(RandomTilesList tileset, int hue, double fill)
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			var list = new List<int>();
			// Issue 10 - End
			list.Add(hue);

			return CreateMessage(tileset, list, fill);
		}
	}
	#endregion
}