#region Header
// /*
//  *    2018 - Pandora - RandomTile.cs
//  */
#endregion

#region References
using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

using TheBox.Common;
#endregion

namespace TheBox.Data
{
	[Serializable, XmlInclude(typeof(RandomTilesList))]
	/// <summary>
	/// Collects the list of random tiles defined for a profile
	/// </summary>
	public class RandomTiles
	{
		private ArrayList m_List;

		/// <summary>
		///     Gets or sets the list of random tiles defined
		/// </summary>
		public ArrayList List { get { return m_List; } set { m_List = value; } }

		public RandomTiles()
		{
			m_List = new ArrayList();
		}

		/// <summary>
		///     Saves this object to XML
		/// </summary>
		public void Save()
		{
			Utility.SaveXml(this, Path.Combine(Pandora.Profile.BaseFolder, "RandomTiles.xml"));
		}

		/// <summary>
		///     Loads random tiles from XML
		/// </summary>
		/// <returns>A Random Tiles object</returns>
		public static RandomTiles Load()
		{
			return Utility.LoadXml(
				typeof(RandomTiles),
				Path.Combine(Pandora.Profile.BaseFolder, "RandomTiles.xml")) as RandomTiles;
		}
	}

	/// <summary>
	///     Defines a list of tiles that can be picked at random
	/// </summary>
	[Serializable, XmlInclude(typeof(RandomTile))]
	public class RandomTilesList
	{
		private ArrayList m_Tiles;
		private string m_Name;

		/// <summary>
		///     Gets or sets the list of tiles
		/// </summary>
		public ArrayList Tiles { get { return m_Tiles; } set { m_Tiles = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name for this group
		/// </summary>
		public string Name { get { return m_Name; } set { m_Name = value; } }

		public RandomTilesList(string name)
			: this()
		{
			m_Name = name;
		}

		public RandomTilesList()
		{
			m_Tiles = new ArrayList();
		}

		public override string ToString()
		{
			return m_Name;
		}
	}

	[Serializable]
	/// <summary>
	/// Describes a single tile that can be used in a random tiles group
	/// </summary>
	public class RandomTile
	{
		private ArrayList m_Items;
		private string m_Name;

		/// <summary>
		///     Gets or sets the list of items that should be created for this tile
		/// </summary>
		public ArrayList Items { get { return m_Items; } set { m_Items = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name for this tile
		/// </summary>
		public string Name { get { return m_Name; } set { m_Name = value; } }

		public RandomTile()
		{
			m_Items = new ArrayList();
		}

		public override string ToString()
		{
			return m_Name;
		}
	}
}