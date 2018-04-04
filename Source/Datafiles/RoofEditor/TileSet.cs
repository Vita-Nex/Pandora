using System;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
using System.Collections.Generic;
// Issue 10 - End
using System.IO;

namespace TheBox.Roofing
{
	/// <summary>
	/// Defines a tile set used to create a roof
	/// </summary>
	public class TileSet
	{
		private string m_Name;
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<TileMask> m_Tiles;
		// Issue 10 - End

		/// <summary>
		/// Gets the name of this tileset
		/// </summary>
		public string Name
		{
			get { return m_Name; }
		}

		/// <summary>
		/// Gets the tiles included in this tileset
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<TileMask> Tiles
		// Issue 10 - End
		{
			get { return m_Tiles; }
		}

		/// <summary>
		/// Creates a new tile set
		/// </summary>
		public TileSet()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Tiles = new List<TileMask>();
			// Issue 10 - End
		}

		/// <summary>
		/// Finds the ID of the tile corresponding to a given flag
		/// </summary>
		/// <param name="flags">The flag to search for</param>
		/// <returns>The ID of the corresponding tile</returns>
		public int FindID( uint flags )
		{
			foreach ( TileMask tile in m_Tiles )
			{
				if ( ( flags & ~tile.Flags ) == 0 )
				{
					return tile.ID;
				}
			}

			return 0;
		}

		/// <summary>
		/// Loads the roof tiles defined in rooftiles.cfg
		/// </summary>
		/// <returns>An array list of tilesets</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public static List<TileSet> Load()
		{
			List<TileSet> list = new List<TileSet>();
			// Issue 10 - End

			StreamReader reader = new StreamReader( @"D:\Dev\Pandora 2.0\Data\rooftiles.cfg" );

			TileSet tileset = null;

			while ( reader.Peek() > -1 )
			{
				string line = reader.ReadLine();
				line.Trim();

				if ( line == null || line.Length == 0 || line.StartsWith( "#" ) )
				{
					continue;
				}

				if ( line.StartsWith( "[" ) )
				{
					line = line.Replace( "[", "" );
					line = line.Replace( "]", "" );

					tileset = new TileSet();
					tileset.m_Name = line;
					list.Add( tileset );

					continue;
				}

				string[] values = line.Split( ' ' );

				if ( values.Length == 2 )
				{
					uint flags = Convert.ToUInt32( values[ 0 ], 16 );
					int tile = Convert.ToInt32( values[ 1 ] );

					TileMask mask = new TileMask( flags, tile );
					tileset.m_Tiles.Add( mask );
				}
			}

			reader.Close();

			return list;
		}

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public static void Save( List<TileSet> list )
		// Issue 10 - End
		{
			StreamWriter writer = new StreamWriter( @"D:\Dev\Pandora 2.0\Data\rooftiles.cfg" );

			foreach ( TileSet tileset in list )
			{
				writer.WriteLine( "[{0}]", tileset.m_Name );

				foreach( TileMask mask in tileset.m_Tiles )
				{
					writer.WriteLine( "{0} {1}", mask.Flags.ToString( "X" ), mask.ID.ToString() );
				}

				writer.WriteLine();
			}

			writer.Close();
		}

		public override string ToString()
		{
			return m_Name;
		}
	}
}
