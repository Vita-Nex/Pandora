#region Header
// /*
//  *    2018 - Pandora - BoxDeco.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Provides information about a static deco item
	/// </summary>
	[Serializable]
	public class BoxDeco : IComparable
	{
		private string m_Name;
		private int m_ID;

		/// <summary>
		///     Gets or sets the name of the decoration object
		/// </summary>
		[XmlAttribute]
		public string Name { get => m_Name; set => m_Name = value; }

		/// <summary>
		///     Gets or sets the ID of the decoration object
		/// </summary>
		[XmlAttribute]
		public int ID { get => m_ID; set => m_ID = value; }

		[XmlIgnore, Browsable(false)]
		/// <summary>
		/// Gets the TreeNode corresponding to this BoxDeco object
		/// </summary>
		public TreeNode TreeNode
		{
			get
			{
				var node = new TreeNode(m_Name)
				{
					Tag = this
				};

				return node;
			}
		}

		#region IComparable Members
		public int CompareTo(object obj)
		{
			if (!(obj is BoxDeco cmp))
			{
				return 0;
			}

			var res = m_Name.CompareTo(cmp.m_Name);

			if (res == 0)
			{
				return m_ID.CompareTo(cmp.m_ID);
			}
			return res;
		}
		#endregion
	}

	/// <summary>
	///     Provides a the list of available decoration items
	/// </summary>
	[Serializable, XmlInclude(typeof(BoxDeco)), XmlInclude(typeof(GenericNode))]
	public class BoxDecoList
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<GenericNode> m_Structure;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the structure of the decoration items available
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<GenericNode> Structure
		// Issue 10 - End
		{
			get => m_Structure;
			set => m_Structure = value;
		}

		/// <summary>
		///     Creates a new BoxDecoList object
		/// </summary>
		public BoxDecoList()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Structure = new List<GenericNode>();
			// Issue 10 - End
		}

		/// <summary>
		///     Loads a BoxDecoList from file
		/// </summary>
		/// <param name="filename">The file to read from</param>
		/// <returns>The BoxDecoList read from the specified file</returns>
		public static BoxDecoList FromFile(string filename)
		{
			try
			{
				var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				var serializer = new XmlSerializer(typeof(BoxDecoList));
				var list = serializer.Deserialize(stream) as BoxDecoList;
				stream.Close();
				return list;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		///     Saves the BoxDecoList to file
		/// </summary>
		/// <param name="filename">The file to save to</param>
		public void Save(string filename)
		{
			try
			{
				var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read);
				var serializer = new XmlSerializer(typeof(BoxDecoList));
				serializer.Serialize(stream, this);
				stream.Close();
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn't save custom deco to {0}", filename);
			}
		}
	}
}