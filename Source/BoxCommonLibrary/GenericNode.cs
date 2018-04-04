#region Header
// /*
//  *    2018 - BoxCommonLibrary - GenericNode.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     GenericNode is a general purpose data structure shaped like a tree. Each node has
	///     a Name and a list of sub-items.
	/// </summary>
	public class GenericNode : IComparable
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the name of the node
		/// </summary>
		[XmlAttribute]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the subelements of this node
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> Elements
			// Issue 10 - End
		{
			get;
			set;
		}

		/// <summary>
		///     Creates a new generic node object
		/// </summary>
		public GenericNode()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			Elements = new List<object>();
			// Issue 10 - End
		}

		/// <summary>
		///     Creates a new generic node object
		/// </summary>
		/// <param name="name">The name of the node</param>
		public GenericNode(string name)
			: this()
		{
			Name = name;
		}

		#region IComparable Members
		/// <summary>
		///     Compares this GenericNode to a second GenericNode
		/// </summary>
		/// <param name="obj">The GenericNode to compare to</param>
		/// <returns>The comparison result</returns>
		public int CompareTo(object obj)
		{
			var cmp = obj as GenericNode;

			if (cmp != null)
			{
				return Name.CompareTo(cmp.Name);
			}
			return 0;
		}
		#endregion
	}
}