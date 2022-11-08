#region Header
// /*
//  *    2018 - Pandora - FolderInfo.cs
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

namespace TheBox.BoxServer
{
	/// <summary>
	///     Provides Pandora with information about files and folders on the server
	/// </summary>
	[Serializable, XmlInclude(typeof(GenericNode))]
	public class FolderInfo : ExplorerMessage
	{
		private GenericNode m_Structure;

		/// <summary>
		///     Gets or sets the Structure of the allowed folders on the server
		/// </summary>
		public GenericNode Structure { get => m_Structure; set => m_Structure = value; }

		/// <summary>
		///     Gets the TreeNodes corresponding to the folder structure
		/// </summary>
		/// <returns>The TreeNode corresponding to the top of the hierarchy</returns>
		public TreeNode[] GetTreeNodes()
		{
			var nodes = new TreeNode[m_Structure.Elements.Count];

			for (var i = 0; i < nodes.Length; i++)
			{
				var gNode = m_Structure.Elements[i] as GenericNode;

				var node = new TreeNode(gNode.Name)
				{
					ImageIndex = 1,
					SelectedImageIndex = 1
				};

				node.Nodes.AddRange(DoElements(gNode.Elements));

				nodes[i] = node;
			}

			return nodes;
		}

		/// <summary>
		///     Processes the elements of a folder
		/// </summary>
		/// <param name="elements">An array list of items in a folder</param>
		/// <returns>The corresponding tree nodes</returns>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private TreeNode[] DoElements(List<object> elements)
		// Issue 10 - End
		{
			var nodes = new TreeNode[elements.Count];

			for (var i = 0; i < elements.Count; i++)
			{
				var obj = elements[i];

				if (obj is GenericNode)
				{
					var gNode = obj as GenericNode;

					var folder = new TreeNode(gNode.Name)
					{
						ImageIndex = 1,
						SelectedImageIndex = 1
					};

					folder.Nodes.AddRange(DoElements(gNode.Elements));

					nodes[i] = folder;
				}
				else if (obj is string file)
				{
					var fileNode = new TreeNode(file);

					if (file.ToLower().EndsWith(".cs"))
					{
						fileNode.ImageIndex = 0;
						fileNode.SelectedImageIndex = 0;
					}
					else if (file.ToLower().EndsWith(".vb"))
					{
						fileNode.ImageIndex = 2;
						fileNode.SelectedImageIndex = 2;
					}
					else if (file.ToLower().EndsWith(".txt"))
					{
						fileNode.ImageIndex = 3;
						fileNode.SelectedImageIndex = 3;
					}
					else if (file.ToLower().EndsWith(".xml"))
					{
						fileNode.ImageIndex = 4;
						fileNode.SelectedImageIndex = 4;
					}

					nodes[i] = fileNode;
				}
			}

			return nodes;
		}
	}
}