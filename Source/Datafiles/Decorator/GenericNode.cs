using System;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
using System.Collections.Generic;
// Issue 10 - End
using System.Xml.Serialization;

namespace TheBox.Common
{
	/// <summary>
	/// Summary description for GenericNode.
	/// </summary>
	public class GenericNode : IComparable
	{
		private string m_Name;
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<object> m_Elements;
		// Issue 10 - End

		[ XmlAttribute ]
		/// <summary>
		/// Gets or sets the name of the node
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// Gets or sets the subelements of this node
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<object> Elements
		// Issue 10 - End
		{
			get { return m_Elements; }
			set { m_Elements = value; }
		}

		/// <summary>
		/// Creates a new generic node object
		/// </summary>
		public GenericNode()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Elements = new List<object>();
			// Issue 10 - End
		}

		/// <summary>
		/// Creates a new generic node object
		/// </summary>
		/// <param name="name">The name of the node</param>
		public GenericNode( string name ) : this ()
		{
			m_Name = name;
		}

		#region IComparable Members

		public int CompareTo(object obj)
		{
			GenericNode cmp = obj as GenericNode;

			if ( cmp == null )
				return 0;

			return this.Name.CompareTo( cmp.Name );
		}

		#endregion
	}
}
