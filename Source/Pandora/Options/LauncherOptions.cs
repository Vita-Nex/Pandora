#region Header
// /*
//  *    2018 - Pandora - LauncherOptions.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Forms;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Options
{
	[Serializable, XmlInclude(typeof(LauncherEntry))]
	/// <summary>
	/// Summary description for LauncherOptions.
	/// </summary>
	public class LauncherOptions
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<LauncherEntry> m_Entries;

		/// <summary>
		///     Gets or sets the entires in the launcher
		/// </summary>
		public List<LauncherEntry> LauncherEntries
			// Issue 10 - End
		{
			get { return m_Entries; }
			set { m_Entries = value; }
		}

		public LauncherOptions()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Entries = new List<LauncherEntry>();
			// Issue 10 - End
		}

		/// <summary>
		///     Occurs when a modification is done to the entries
		/// </summary>
		public event EventHandler OnEntriesChanged;

		/// <summary>
		///     Gets the TreeNodes representing the entries
		/// </summary>
		/// <param name="img">The image list that will hold the icons</param>
		/// <returns>An array list of treenodes</returns>
		public TreeNode[] GetTreeNodes(ImageList img)
		{
			if (m_Entries.Count == 0)
			{
				return new TreeNode[0];
			}

			if (img == null)
				img = new ImageList();

			var nodes = new TreeNode[m_Entries.Count];
			img.Images.Clear();

			for (var i = 0; i < nodes.Length; i++)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				var entry = m_Entries[i];
				// Issue 10 - End
				nodes[i] = entry.TreeNode;

				if (entry.Valid)
				{
					var icon = FileIcon.GetSmallIcon(entry.Path);
					if (icon != null)
					{
						img.Images.Add(icon);
						nodes[i].ImageIndex = img.Images.Count - 1;
						nodes[i].SelectedImageIndex = img.Images.Count - 1;
					}
				}
			}

			return nodes;
		}

		/// <summary>
		///     Launches the programs that are set to run on startup
		/// </summary>
		public void PerformStartup()
		{
			foreach (var entry in m_Entries)
			{
				if (entry.Valid && entry.RunOnStartup)
				{
					entry.Run();
				}
			}
		}

		/// <summary>
		///     Removes a launcher entry from the list
		/// </summary>
		/// <param name="entry">The LauncherEntry that should be removed</param>
		public void DeleteEntry(LauncherEntry entry)
		{
			if (m_Entries.Contains(entry))
			{
				m_Entries.Remove(entry);

				if (OnEntriesChanged != null)
				{
					OnEntriesChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		///     Creates a new launcher entry
		/// </summary>
		public void CreateNewEntry()
		{
			var form = new LauncherForm();

			if (form.ShowDialog() == DialogResult.OK)
			{
				var entry = form.SelectedEntry;

				m_Entries.Add(entry);

				if (OnEntriesChanged != null)
				{
					OnEntriesChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		///     Edits an existing entry
		/// </summary>
		/// <param name="entry">The LauncherEntry to edit</param>
		public void EditEntry(LauncherEntry entry)
		{
			if (!m_Entries.Contains(entry))
				return;

			var form = new LauncherForm();
			form.SelectedEntry = entry;

			if (form.ShowDialog() == DialogResult.OK)
			{
				if (OnEntriesChanged != null)
				{
					OnEntriesChanged(this, new EventArgs());
				}
			}
		}
	}

	/// <summary>
	///     Provides information about a program that can be launched using Pandora's Box
	/// </summary>
	[Serializable]
	public class LauncherEntry
	{
		private string m_Path;
		private string m_Arguments;
		private string m_Name;
		private bool m_RunOnStartup;

		[XmlAttribute]
		/// <summary>
		/// The path to the file referenced by this entry
		/// </summary>
		public string Path { get { return m_Path; } set { m_Path = value; } }

		[XmlAttribute]
		/// <summary>
		/// The additional launch arguments
		/// </summary>
		public string Arguments { get { return m_Arguments; } set { m_Arguments = value; } }

		[XmlAttribute]
		/// <summary>
		/// The name of the entry
		/// </summary>
		public string Name { get { return m_Name; } set { m_Name = value; } }

		[XmlAttribute]
		/// <summary>
		/// States whether this entry should be launched when Pandora starts
		/// </summary>
		public bool RunOnStartup { get { return m_RunOnStartup; } set { m_RunOnStartup = value; } }

		[XmlIgnore]
		/// <summary>
		/// States whether the exists
		/// </summary>
		public bool Valid { get { return File.Exists(m_Path); } }

		/// <summary>
		///     Executes this entry
		/// </summary>
		public void Run()
		{
			if (Valid)
			{
				try
				{
					if (m_Arguments != null && m_Arguments.Length > 0)
					{
						Process.Start(m_Path, m_Arguments);
					}
					else
					{
						Process.Start(m_Path);
					}
				}
				catch (Exception err)
				{
					Pandora.Log.WriteError(err, "Error occurred when trying to run {0}", m_Name);
					MessageBox.Show(Pandora.Localization.TextProvider["Tools.LaunchErr"]);
				}
			}
		}

		/// <summary>
		///     Gets the TreeNode associated with this entry
		/// </summary>
		public TreeNode TreeNode
		{
			get
			{
				var node = new TreeNode();
				node.Text = m_Name;
				node.Tag = this;

				return node;
			}
		}
	}
}