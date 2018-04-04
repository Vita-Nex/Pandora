#region Header
// /*
//  *    2018 - BoxCommonLibrary - SearchResults.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
#endregion

// Issue 10 - End

namespace TheBox.Common
{
	/// <summary>
	///     Provides easy access to search results over TreeViews
	/// </summary>
	public class SearchResults
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private readonly List<Result> m_Results;

		// Issue 10 - End
		private int m_Index;

		/// <summary>
		///     Creates a new SearchResults object
		/// </summary>
		public SearchResults()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Results = new List<Result>();
			// Issue 10 - End
		}

		/// <summary>
		///     Adds a new item to the results list
		/// </summary>
		/// <param name="result">The Result object being added to the results list</param>
		public void Add(Result result)
		{
			m_Results.Add(result);
		}

		/// <summary>
		///     Gets the number of results found by the search
		/// </summary>
		public int Count { get { return m_Results.Count; } }

		/// <summary>
		///     Gets the next result in the list
		/// </summary>
		/// <returns>
		///     The Result object corresponding to the next result in the list. Null if no results are in the list, or if the
		///     end of the list has been reached.
		/// </returns>
		public Result GetNext()
		{
			if (m_Index == m_Results.Count)
			{
				return null;
			}

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			return m_Results[m_Index++];
			// Issue 10 - End
		}

		/// <summary>
		///     Getst the previous result in the list
		/// </summary>
		/// <returns>The Result object corresponding to the previous result in the list. Null if the current is the first item.</returns>
		public Result GetPrevious()
		{
			if (m_Index == 0)
			{
				return null;
			}

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			return m_Results[--m_Index];
			// Issue 10 - End
		}

		/// <summary>
		///     Merges the results provided by a second search results
		/// </summary>
		/// <param name="moreResults"></param>
		public void MergeWith(SearchResults moreResults)
		{
			m_Results.AddRange(moreResults.m_Results);
		}
	}

	/// <summary>
	///     Defines a single search result
	/// </summary>
	public class Result : IComparable
	{
		/// <summary>
		///     Creates a Result object
		/// </summary>
		/// <param name="node">The TreeNode containing the result</param>
		/// <param name="index">The index of the </param>
		public Result(TreeNode node, int index)
		{
			Node = node;
			Index = index;
		}

		/// <summary>
		///     Gets or sets the category node for this item
		/// </summary>
		public TreeNode Node { get; set; }

		/// <summary>
		///     Gets or sets the index for the element to be displayed on the second treenode
		/// </summary>
		public int Index { get; set; }

		#region IComparable Members
		/// <summary>
		///     Compares this result to another
		/// </summary>
		/// <param name="obj">The Result to compare to</param>
		/// <returns>The comparison result</returns>
		public int CompareTo(object obj)
		{
			if (obj is Result)
			{
				var cmp = obj as Result;

				if (cmp.Node.FullPath.ToLower() == Node.FullPath.ToLower())
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					var one = ((List<object>)Node.Tag)[Index] as IComparable;
					var two = ((List<object>)cmp.Node.Tag)[cmp.Index] as IComparable;
					// Issue 10 - End

					return one.CompareTo(two);
				}
				return Node.FullPath.CompareTo(cmp.Node.FullPath);
			}
			throw new Exception(string.Format("Cannot compare Result to {0}", obj.GetType().Name));
		}
		#endregion
	}
}