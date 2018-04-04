using System;
using System.Collections;
using System.Xml.Serialization;

namespace TheBox.Data
{
	[ Serializable ]
	/// <summary>
	/// Describes a single tile that can be used in a random tiles group
	/// </summary>
	public class RandomTile
	{
		private ArrayList m_Items;
		private string m_Name;

		/// <summary>
		/// Gets or sets the list of items that should be created for this tile
		/// </summary>
		public ArrayList Items
		{
			get { return m_Items; }
			set { m_Items = value; }
		}

		[ XmlAttribute ]
			/// <summary>
			/// Gets or sets the name for this tile
			/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public RandomTile()
		{
			m_Items = new ArrayList();
		}
	}
}
