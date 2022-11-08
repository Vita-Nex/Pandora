#region Header
// /*
//  *    2018 - Pandora - Item.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	[Serializable]
	/// <summary>
	/// Defines the art and hue of an item
	/// </summary>
	public class ItemDef : ICloneable
	{
		private int m_Art;
		private int m_Hue;

		/// <summary>
		///     Creates a new ItemAppearance object
		/// </summary>
		public ItemDef()
		{ }

		/// <summary>
		///     Creates a new ItemAppearance object
		/// </summary>
		/// <param name="art">The ID of the art corresponding to the item</param>
		/// <param name="hue">The hue of the item</param>
		public ItemDef(int art, int hue)
		{
			m_Art = art;
			m_Hue = hue;
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the item ID
		/// </summary>
		public int Art { get => m_Art; set => m_Art = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the hue
		/// </summary>
		public int Hue { get => m_Hue; set => m_Hue = value; }

		#region ICloneable Members
		/// <summary>
		///     Clones this ItemDef object
		/// </summary>
		/// <returns>A new ItemDef object with the same values</returns>
		public object Clone()
		{
			return new ItemDef(m_Art, m_Hue);
		}
		#endregion
	}

	[Serializable]
	/// <summary>
	/// Defines a parameter used in an additional constructor
	/// </summary>
	public class ParamDef
	{
		private string m_Name;

		private BoxPropType m_ParamType;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> m_EnumValues;
		// Issue 10 - End

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the parameter name
		/// </summary>
		public string Name { get => m_Name; set => m_Name = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the type of this parameter
		/// </summary>
		public BoxPropType ParamType { get => m_ParamType; set => m_ParamType = value; }

		/// <summary>
		///     Gets or sets the list of values for an enum parameter
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> EnumValues
		// Issue 10 - End
		{
			get => m_EnumValues;
			set => m_EnumValues = value;
		}
	}

	[Serializable, XmlInclude(typeof(ParamDef))]
	/// <summary>
	/// Defines an additional constructor available for an item
	/// </summary>
	public class ConstructorDef
	{
		private ItemDef m_DefaultArt;
		private ParamDef m_Param1;

		private ParamDef m_Param2;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> m_List1;

		private List<object> m_List2;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the appearance of the item created by the constructor with default parameters
		/// </summary>
		public ItemDef DefaultArt { get => m_DefaultArt; set => m_DefaultArt = value; }

		/// <summary>
		///     Gets or sets the first parameter of the constructor
		/// </summary>
		public ParamDef Param1 { get => m_Param1; set => m_Param1 = value; }

		/// <summary>
		///     Gets or sets the second parameter of the constructor (if any)
		/// </summary>
		public ParamDef Param2 { get => m_Param2; set => m_Param2 = value; }

		/// <summary>
		///     Gets or sets the list of item definitions corresponding to the first parameter (if appliable)
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> List1
		// Issue 10 - End
		{
			get => m_List1;
			set => m_List1 = value;
		}

		/// <summary>
		///     Gets or sets the list of item definitions for the second parameter (if appliable)
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> List2
		// Issue 10 - End
		{
			get => m_List2;
			set => m_List2 = value;
		}
	}

	[Serializable, XmlInclude(typeof(ConstructorDef))]
	/// <summary>
	/// Defines an item that can be added through Pandora's Box
	/// </summary>
	public class BoxItem : IComparable, ICloneable
	{
		private bool m_EmptyCtor;
		private ItemDef m_Item;

		private string m_Name;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> m_AdditionalCtors;
		// Issue 10 - End

		[XmlAttribute, Description("The name of the class representing the item, should not contain spaces.")]
		/// <summary>
		/// Get or sets the name of the item
		/// </summary>
		public string Name { get => m_Name; set => m_Name = value; }

		[XmlAttribute, Description("Specifies if the item can be added without specifying any additional options")]
		/// <summary>
		/// States whether the item has a default constructor
		/// </summary>
		public bool EmptyCtor { get => m_EmptyCtor; set => m_EmptyCtor = value; }

		[Browsable(false)]
		/// <summary>
		/// Gets or sets the appearance of the item
		/// </summary>
		public ItemDef Item { get => m_Item; set => m_Item = value; }

		[Description("The ID of the item's graphics.")]
		/// <summary>
		/// Gets or sets the item id
		/// </summary>
		public int ItemID { get => m_Item.Art; set => m_Item.Art = value; }

		[Description("The hue of the item.")]
		/// <summary>
		/// Gets or sets the item hue
		/// </summary>
		public int Hue { get => m_Item.Hue; set => m_Item.Hue = value; }

		[Browsable(false)]
		/// <summary>
		/// Lists the additional constructors available for this item
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> AdditionalCtors
		// Issue 10 - End
		{
			get => m_AdditionalCtors;
			set => m_AdditionalCtors = value;
		}

		/// <summary>
		///     Creates a new BoxItem object
		/// </summary>
		public BoxItem()
		{
			m_Item = new ItemDef();
		}

		#region IComparable Members
		public int CompareTo(object obj)
		{
			if (obj is BoxItem)
			{
				var item = obj as BoxItem;

				return m_Name.CompareTo(item.m_Name);
			}
			return 0;
		}
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			var item = new BoxItem
			{
				m_Item = m_Item.Clone() as ItemDef,
				m_Name = m_Name
			};

			return item;
		}
		#endregion
	}
}