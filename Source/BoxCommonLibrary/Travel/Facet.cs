#region Header
// /*
//  *    2018 - BoxCommonLibrary - Facet.cs
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

namespace TheBox.Data
{
	/// <summary>
	///     Describes and categorizes all the locations for a given facet
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(GenericNode))]
	[XmlInclude(typeof(Location))]
	public class Facet
	{
		private byte m_Map;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<GenericNode> m_Nodes;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the map file corresponding to this facet
		/// </summary>
		[XmlAttribute]
		public byte MapValue { get => m_Map; set => m_Map = value; }

		/// <summary>
		///     Gets or sets the category nodes
		/// </summary>

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<GenericNode> Nodes
		// Issue 10 - End
		{
			get => m_Nodes;
			set => m_Nodes = value;
		}

		/// <summary>
		///     Creates a new facet
		/// </summary>
		public Facet()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Nodes = new List<GenericNode>();
			// Issue 10 - End
		}

		/// <summary>
		///     Gets a TreeNode corresponding to this facet
		/// </summary>
		/// <param name="name">The name of this facet</param>
		/// <returns></returns>
		public TreeNode GetTreeNode(string name)
		{
			var FacetNode = new TreeNode(name);

			foreach (var Category in m_Nodes)
			{
				var CategoryNode = new TreeNode(Category.Name);

				foreach (GenericNode Subsection in Category.Elements)
				{
					var SubsectionNode = new TreeNode(Subsection.Name)
					{
						Tag = Subsection.Elements
					};

					_ = CategoryNode.Nodes.Add(SubsectionNode);
				}

				_ = FacetNode.Nodes.Add(CategoryNode);
			}

			return FacetNode;
		}

		/// <summary>
		///     Creates a Facet object from a collection of tree nodes
		/// </summary>
		/// <param name="nodes">The TreeNodeCollection used as source for this Facet object</param>
		/// <param name="name">The map file index corresponding to this facet</param>
		/// <returns>A Facet object representing the nodes collection</returns>
		public static Facet FromTreeNodes(TreeNodeCollection nodes, byte name)
		{
			var facet = new Facet
			{
				MapValue = name
			};

			foreach (TreeNode CatNode in nodes)
			{
				var Category = new GenericNode(CatNode.Text);

				foreach (TreeNode SubNode in CatNode.Nodes)
				{
					var Subsection = new GenericNode(SubNode.Text)
					{
						// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
						Elements = (List<object>)SubNode.Tag
					};
					// Issue 10 - End

					Category.Elements.Add(Subsection);
				}

				facet.m_Nodes.Add(Category);
			}

			return facet;
		}

		/// <summary>
		///     Adds a new location to this facet
		/// </summary>
		/// <param name="loc">The location that should be added</param>
		/// <param name="category">The category name for the new location</param>
		/// <param name="subsection">The subsection name for the new location</param>
		public void AddLocation(Location loc, string category, string subsection)
		{
			GenericNode catNode = null;

			foreach (var cat in m_Nodes)
			{
				if (cat.Name.ToLower() == category.ToLower())
				{
					catNode = cat;
					break;
				}
			}

			if (catNode == null)
			{
				catNode = new GenericNode(category);
				m_Nodes.Add(catNode);
			}

			GenericNode subNode = null;

			foreach (GenericNode sub in catNode.Elements)
			{
				if (sub.Name.ToLower() == subsection.ToLower())
				{
					subNode = sub;
					break;
				}
			}

			if (subNode == null)
			{
				subNode = new GenericNode(subsection);
				catNode.Elements.Add(subNode);
			}

			subNode.Elements.Add(loc);
		}

		/// <summary>
		///     Removes a location from the list
		/// </summary>
		/// <param name="loc">The location object that should be deleted</param>
		/// <param name="category">The category it belongs to</param>
		/// <param name="subsection">The subsection parent of the location</param>
		public void DeleteLocation(Location loc, string category, string subsection)
		{
			foreach (var cat in m_Nodes)
			{
				if (cat.Name.ToLower() == category.ToLower())
				{
					foreach (GenericNode sub in cat.Elements)
					{
						if (sub.Name.ToLower() == subsection.ToLower())
						{
							foreach (Location l in sub.Elements)
							{
								if (l == loc)
								{
									_ = sub.Elements.Remove(loc);
									return;
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		///     Searches the current facet for locations according to an input text
		/// </summary>
		/// <param name="nodes">The TreeNodeCollection representing the category nodes of a facet</param>
		/// <param name="text">The text to search for in the location names</param>
		/// <returns>A SearchResults object</returns>
		public static SearchResults Search(TreeNodeCollection nodes, string text)
		{
			text = text.ToLower();
			var results = new SearchResults();

			foreach (TreeNode cat in nodes)
			{
				foreach (TreeNode sub in cat.Nodes)
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					foreach (Location loc in sub.Tag as List<object>)
					// Issue 10 - End
					{
						if (loc.Name.ToLower().IndexOf(text) != -1)
						{
							// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
							var res = new Result(sub, (sub.Tag as List<object>).IndexOf(loc));
							// Issue 10 - End
							results.Add(res);
						}
					}
				}
			}

			return results;
		}
	}
}