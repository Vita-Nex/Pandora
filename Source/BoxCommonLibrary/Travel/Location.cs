#region Header
// /*
//  *    2018 - BoxCommonLibrary - Location.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
#endregion

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert

namespace TheBox.Data
{
	/// <summary>
	///     Describes a location entry for Pandora's travel agent
	/// </summary>
	public class Location : IComparable
	{
		private byte m_Map;

		/// <summary>
		///     Gets or sets the name of the location
		/// </summary>
		[XmlAttribute]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the X coordinate of the location
		/// </summary>
		[XmlAttribute]
		public short X { get; set; }

		/// <summary>
		///     Gets or sets the Y coordinate of the location
		/// </summary>
		[XmlAttribute]
		public short Y { get; set; }

		/// <summary>
		///     Gets or sets the Z coordinate of the location
		/// </summary>
		[XmlAttribute]
		public sbyte Z { get; set; }

		/// <summary>
		///     Gets or sets the map the location resides on
		/// </summary>
		public int Map { get => m_Map; set => m_Map = (byte)value; }

		/// <summary>
		///     Converts a collection of Location structures to a TreeNodeCollection
		/// </summary>
		/// <param name="list">A collection of Location structures</param>
		/// <returns>A TreeNodeCollection object containing nodes for all the locations in the list</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public static TreeNode[] ArrayToNodes(List<object> list)
		// Issue 10 - End
		{
			var nodes = new TreeNode[list.Count];

			for (var i = 0; i < list.Count; i++)
			{
				var loc = list[i] as Location;

				var node = new TreeNode(loc.Name)
				{
					Tag = loc
				};

				nodes[i] = node;
			}

			return nodes;
		}

		/// <summary>
		///     Converts this location to a string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return String.Format("{0} ({1},{2},{3})", Name, X, Y, Z);
		}

		#region IComparable Members
		/// <summary>
		///     Compares this Location to another object
		/// </summary>
		/// <param name="obj">The object to compare to</param>
		/// <returns>The result value of the comparison</returns>
		public int CompareTo(object obj)
		{
			if (!(obj is Location o))
			{
				throw new Exception(String.Format("Cannot compare Location to {0}", obj.GetType().Name));
			}

			return Name.CompareTo(o.Name);
		}
		#endregion
	}
}