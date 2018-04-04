#region Header
// /*
//  *    2018 - Pandora - TileSet.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.IO;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Defines a tile set used to create a roof
	/// </summary>
	public class TileSet
	{
		private string m_Name;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private readonly List<TileMask> m_Tiles;
		// Issue 10 - End

		/// <summary>
		///     Gets the name of this tileset
		/// </summary>
		public string Name { get { return m_Name; } }

		/// <summary>
		///     Gets the tiles included in this tileset
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<TileMask> Tiles
			// Issue 10 - End
		{
			get { return m_Tiles; }
		}

		/// <summary>
		///     Creates a new tile set
		/// </summary>
		public TileSet()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Tiles = new List<TileMask>();
			// Issue 10 - End
		}

		/// <summary>
		///     Finds the ID of the tile corresponding to a given flag
		/// </summary>
		/// <param name="flags">The flag to search for</param>
		/// <returns>The ID of the corresponding tile</returns>
		public int FindID(uint flags)
		{
			foreach (var tile in m_Tiles)
			{
				if ((flags & ~tile.Flags) == 0)
				{
					return tile.ID;
				}
			}

			return 0;
		}

		/// <summary>
		///     Loads the roof tiles defined in rooftiles.cfg
		/// </summary>
		/// <returns>An array list of tilesets</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public static List<TileSet> Load()
		{
			var list = new List<TileSet>();
			// Issue 10 - End

			var reader = new StreamReader(Pandora.DataAssembly.GetManifestResourceStream("Data.rooftiles.cfg"));

			TileSet tileset = null;

			while (reader.Peek() > -1)
			{
				var line = reader.ReadLine();
				line.Trim();

				if (line == null || line.Length == 0 || line.StartsWith("#"))
				{
					continue;
				}

				if (line.StartsWith("["))
				{
					line = line.Replace("[", "");
					line = line.Replace("]", "");

					tileset = new TileSet();
					tileset.m_Name = line;
					list.Add(tileset);

					continue;
				}

				var values = line.Split(' ');

				if (values.Length == 2)
				{
					var flags = Convert.ToUInt32(values[0], 16);
					var tile = Convert.ToInt32(values[1]);

					var mask = new TileMask(flags, tile);
					tileset.m_Tiles.Add(mask);
				}
			}

			return list;
		}

		public override string ToString()
		{
			return m_Name;
		}
	}
}