#region Header
// /*
//  *    2018 - Pandora - BoxData.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Contains data used for display of items and mobiles in PB
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(BoxMobile))]
	[XmlInclude(typeof(BoxItem))]
	[XmlInclude(typeof(GenericNode))]
	public class BoxData
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> m_Items;

		private List<object> m_Mobiles;
		// Issue 10 - End

		/// <summary>
		///     Creates a new BoxData object
		/// </summary>
		public BoxData()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Items = new List<object>();
			m_Mobiles = new List<object>();
			// Issue 10 - End
		}

		/// <summary>
		///     Gets or sets the Items structure
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> Items
		// Issue 10 - End
		{
			get => m_Items;
			set => m_Items = value;
		}

		/// <summary>
		///     Gets or sets the Mobiles structure
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> Mobiles
		// Issue 10 - End
		{
			get => m_Mobiles;
			set => m_Mobiles = value;
		}

		//		/// <summary>
		//		/// Creates a BoxData object provided the items and mobiles
		//		/// </summary>
		//		/// <param name="boxItems">A list of BoxItem objects</param>
		//		/// <param name="boxMobiles">A list of BoxMobile objects</param>
		//		/// <returns>A BoxData object containing a categories structure</returns>
		//		public static BoxData Create( ArrayList boxItems, ArrayList boxMobiles )
		//		{
		//			BoxData data = new BoxData();
		//
		//			// Items
		//			foreach ( BoxItem item in boxItems )
		//			{
		//				GenericNode node = data.GetNode( data.m_Items, item.Path );
		//				node.Elements.Add( item );
		//			}
		//
		//			// Mobiles
		//			foreach ( BoxMobile mobile in boxMobiles )
		//			{
		//				GenericNode node = data.GetNode( data.m_Mobiles, mobile.Path );
		//				node.Elements.Add( mobile );
		//			}
		//
		//			return data;
		//		}

		/// <summary>
		///     Gets a GenericNode corresponding to the provided path
		/// </summary>
		/// <param name="where">The list to search for the node</param>
		/// <param name="path"></param>
		/// <returns></returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private GenericNode GetNode(List<object> where, StringCollection path)
		{
			var list = where;
			// Issue 10 - End
			GenericNode node = null;

			foreach (var s in path)
			{
				node = FindNode(list, s);

				if (node == null)
				{
					node = new GenericNode(s);
					list.Add(node);
				}

				list = node.Elements;
			}

			if (node == null)
			{
				node = FindNode(where, "Uncategorized");

				if (node == null)
				{
					node = new GenericNode("Uncategorized");
					where.Add(node);
				}
			}

			return node;
		}

		/// <summary>
		///     Finds a GenericNode in a list of items
		/// </summary>
		/// <param name="where">The list of items to search for the node</param>
		/// <param name="name">The name of the node to search for</param>
		/// <returns>The node, if found. Null otherwise.</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private GenericNode FindNode(List<object> where, string name)
		// Issue 10 - End
		{
			name = name.ToLower();

			foreach (var o in where)
			{
				if (o is GenericNode)
				{
					var node = o as GenericNode;

					if (node.Name.ToLower() == name)
					{
						return node;
					}
				}
			}

			return null;
		}

		/// <summary>
		///     Loads the BoxData from file
		/// </summary>
		/// <returns></returns>
		public static BoxData Load()
		{
			var data = new BoxData();

			var filename = Path.Combine(Pandora.Profile.BaseFolder, "BoxData.xml");

			if (File.Exists(filename))
			{
				try
				{
					var serializer = new XmlSerializer(typeof(BoxData));
					var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
					data = serializer.Deserialize(stream) as BoxData;
					stream.Close();
					Pandora.Log.WriteEntry(String.Format("BoxData read correctly from file: {0}", filename));
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, String.Format("Cannot read BoxData from file {0}", filename));
				}
			}

			return data;
		}

		/// <summary>
		///     Saves the BoxData object to the xml file
		/// </summary>
		public void Save()
		{
			var filename = Path.Combine(Pandora.Profile.BaseFolder, "BoxData.xml");

			try
			{
				var serializer = new XmlSerializer(typeof(BoxData));
				var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
				serializer.Serialize(stream, this);
				stream.Close();

				Pandora.Log.WriteEntry(String.Format("BoxData saved correctly to {0}", filename));
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't save BoxData to file: {0}", filename);
			}
		}
	}

	#region BoxMobile
	/// <summary>
	///     Contains data used to describe a mobile in PB
	/// </summary>
	[Serializable]
	public class BoxMobile : IComparable
	{
		private string m_Name;
		private int m_Art;
		private int m_Hue;

		private bool m_CanBeNamed;

		[Description("The name of the mobile. This must not include spaces"), Category("Mobile")]
		/// <summary>
		/// Gets or sets the name of the mobile (Type name)
		/// </summary>
		[XmlAttribute]
		public string Name { get => m_Name; set => m_Name = value; }

		[Description("The number corresponding to the body of this mobile"), Category("Mobile")]
		/// <summary>
		/// Gets or sets the ID used to display the mobile
		/// </summary>
		[XmlAttribute]
		public int Art { get => m_Art; set => m_Art = value; }

		[Description("The number corresponding to the hue of this mobile"), Category("Mobile")]
		/// <summary>
		/// Gets or sets the hue number
		/// </summary>
		[XmlAttribute]
		public int Hue
		{
			get => m_Hue;
			set
			{
				m_Hue = value;
				if (m_Hue >= 3000)
				{
					m_Hue = 0;
				}
			}
		}

		[Description("Specifies whether this mobile accepts a name as additional parameter"), Category("Mobile")]
		/// <summary>
		/// Gets or sets a value stating whether the mobile has a constructor allowing to name it
		/// </summary>
		[XmlAttribute]
		public bool CanBeNamed { get => m_CanBeNamed; set => m_CanBeNamed = value; }

		#region IComparable Members
		public int CompareTo(object obj)
		{
			var cmp = obj as BoxMobile;

			return m_Name.CompareTo(cmp.m_Name);
		}
		#endregion
	}
	#endregion

	[XmlInclude(typeof(SupportBoxItem))]
	public class SupportBoxData : BoxData
	{
		public List<GenericNode> ItemsS { get; set; }

		public List<GenericNode> MobilesS { get; set; }
	}

	[XmlInclude(typeof(SupportConstructorDef))]
	public class SupportBoxItem : BoxItem
	{
		public List<SupportConstructorDef> AdditionalConstructorsS { get; set; }
	}

	[XmlInclude(typeof(ItemDef))]
	public class SupportConstructorDef : ConstructorDef
	{
		public List<ItemDef> List1S { get; set; }

		public List<ItemDef> List2S { get; set; }
	}
}