#region Header
// /*
//  *    2018 - Pandora - TreeSearch.cs
//  */
#endregion

#region References
using System.Collections.Generic;
using System.Windows.Forms;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Summary description for TreeSearch.
	/// </summary>
	public class TreeSearch
	{
		/// <summary>
		///     Scans a TreeView control searching for data
		/// </summary>
		/// <param name="tree">The TreeView control to search</param>
		/// <param name="text">The text to search for</param>
		/// <returns>A SearchResults object containing the results</returns>
		public static SearchResults Find(TreeView tree, string text)
		{
			var results = new SearchResults();

			foreach (TreeNode node in tree.Nodes)
			{
				DoNode(node, results, text);
			}

			return results;
		}

		private static void DoNode(TreeNode node, SearchResults results, string text)
		{
			foreach (TreeNode subNode in node.Nodes)
			{
				DoNode(subNode, results, text);
			}
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			if (node.Tag != null && node.Tag is List<object>)
			{
				var list = node.Tag as List<object>;
				// Issue 10 - End

				for (var i = 0; i < list.Count; i++)
				{
					var o = list[i];

					if (o is BoxMobile)
					{
						var mob = o as BoxMobile;

						if (mob.Name.ToLower().IndexOf(text.ToLower()) > -1)
						{
							var res = new Result(node, i);
							results.Add(res);
						}
					}
					else if (o is BoxItem)
					{
						var item = o as BoxItem;

						if (item.Name.ToLower().IndexOf(text.ToLower()) > -1)
						{
							var res = new Result(node, i);
							results.Add(res);
						}
					}
				}
			}
		}
	}
}