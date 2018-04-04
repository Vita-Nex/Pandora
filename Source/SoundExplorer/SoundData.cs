#region Header
// /*
//  *    2018 - SoundExplorer - SoundData.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace SoundExplorer
{
	public class UOSound
	{
		public UOSound()
		{ }

		public UOSound(string name, int index)
		{
			Index = index;
			Name = name;
		}

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the sound index
		/// </summary>
		public int Index { get; set; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the sound name
		/// </summary>
		public string Name { get; set; }
	}

	[Serializable, XmlInclude(typeof(GenericNode)), XmlInclude(typeof(UOSound))]
	/// <summary>
	/// Summary description for SoundData.
	/// </summary>
	public class SoundData
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<GenericNode> m_Structure;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the sounds library structure
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<GenericNode> Structure
			// Issue 10 - End
		{
			get { return m_Structure; }
			set { m_Structure = value; }
		}

		public SoundData()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Structure = new List<GenericNode>();
			// Issue 10 - End
		}

		public SoundData(TreeNodeCollection nodes)
			: this()
		{
			foreach (TreeNode node in nodes)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				m_Structure.Add(DoNode(node) as GenericNode);
				// Issue 10 - End
			}
		}

		private object DoNode(TreeNode node)
		{
			if (node.Tag == null)
			{
				var cat = new GenericNode(node.Text);

				foreach (TreeNode child in node.Nodes)
				{
					cat.Elements.Add(DoNode(child));
				}

				return cat;
			}
			var snd = new UOSound(node.Text, (int)node.Tag);

			return snd;
		}

		public TreeNode[] TreeNodes
		{
			get
			{
				var nodes = new TreeNode[m_Structure.Count];

				for (var i = 0; i < nodes.Length; i++)
				{
					nodes[i] = GetNode(m_Structure[i]);
				}

				return nodes;
			}
		}

		private TreeNode GetNode(GenericNode gNode)
		{
			var node = new TreeNode(gNode.Name);

			foreach (var o in gNode.Elements)
			{
				var child = o as GenericNode;
				var item = o as UOSound;

				if (child != null)
				{
					node.Nodes.Add(GetNode(child));
				}
				else if (item != null)
				{
					var itemNode = new TreeNode(item.Name);
					itemNode.Tag = item.Index;
					node.Nodes.Add(itemNode);
				}
			}

			return node;
		}
	}
}