#region Header
// /*
//  *    2018 - Pandora - Notes.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

using TheBox.Forms.Editors;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Defines the priorities in notes
	/// </summary>
	public enum NotePriority
	{
		Urgent = 3,
		High = 2,
		Normal = 1,
		Low = 0
	}

	public enum NoteSorting
	{
		Name,
		Date,
		Priority
	}

	[Serializable, XmlInclude(typeof(Note))]
	/// <summary>
	/// Summary description for Notes.
	/// </summary>
	public class Notes
	{
		private static NoteSorting m_Sorting = NoteSorting.Name;
		private static bool m_Ascending = true;

		/// <summary>
		///     Occurs when the sorting has been changed
		/// </summary>
		public event EventHandler SortingChanged;

		/// <summary>
		///     States the type of sorting that should be used for notes
		/// </summary>
		public static NoteSorting Sorting { get { return m_Sorting; } }

		/// <summary>
		///     States whether the notes should be sorted in ascending order
		/// </summary>
		public static bool Ascending { get { return m_Ascending; } }

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<Note> m_Notes;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the list of available notes
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<Note> NotesList
			// Issue 10 - End
		{
			get { return m_Notes; }
			set { m_Notes = value; }
		}

		/// <summary>
		///     Gets or sets the sorting type for the notes
		/// </summary>
		public NoteSorting NoteSorting
		{
			get { return m_Sorting; }
			set
			{
				m_Sorting = value;

				m_Notes.Sort();

				if (SortingChanged != null)
				{
					SortingChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		///     States whether sorting should be done in ascending order
		/// </summary>
		public bool AscendingSorting
		{
			get { return m_Ascending; }
			set
			{
				m_Ascending = value;

				m_Notes.Sort();

				if (SortingChanged != null)
				{
					SortingChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		///     Creates a new Notes object
		/// </summary>
		public Notes()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Notes = new List<Note>();
			// Issue 10 - End
		}

		public TreeNode[] TreeNodes
		{
			get
			{
				var nodes = new TreeNode[m_Notes.Count];

				for (var i = 0; i < nodes.Length; i++)
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					var note = m_Notes[i];
					// Issue 10 - End

					nodes[i] = new TreeNode(note.Name);
					nodes[i].Tag = note;
					nodes[i].ImageIndex = (int)note.Priority;
					nodes[i].SelectedImageIndex = (int)note.Priority;
				}

				return nodes;
			}
		}
	}

	[Serializable, XmlInclude(typeof(Location))]
	public class Note : IComparable
	{
		private string m_Name = "";
		private string[] m_Text;
		private NotePriority m_Priority = NotePriority.Normal;

		// Issue 51:  	 Note's does not save the correct time od day. - Tarion
		private DateTime m_Date = DateTime.Now;

		// Issue 51 - End
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<Location> m_Locations = new List<Location>();

		// Issue 10 - End
		private ContextMenu m_LocationsMenu;

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the name of the note
		/// </summary>
		public string Name { get { return m_Name; } set { m_Name = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the note priority
		/// </summary>
		public NotePriority Priority { get { return m_Priority; } set { m_Priority = value; } }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the date for this note
		/// </summary>
		public string Date { get { return m_Date.ToString(); } set { m_Date = DateTime.Parse(value); } }

		/// <summary>
		///     Gets or sets the text of the note
		/// </summary>
		public string[] Text { get { return m_Text; } set { m_Text = value; } }

		/// <summary>
		///     Gets or sets the locations associated with this note
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<Location> Locations
			// Issue 10 - End
		{
			get { return m_Locations; }
			set { m_Locations = value; }
		}

		/// <summary>
		///     Gets the created string for this note
		/// </summary>
		public string CreatedString
		{
			get
			{
				return string.Format(
					Pandora.Localization.TextProvider["Notes.Created"],
					m_Date.ToShortDateString(),
					m_Date.ToShortTimeString());
			}
		}

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public Note(string name)
		{
			m_Name = name;
		}

		/// <summary>
		///     Used to deserialize
		/// </summary>
		public Note()
		{ }

		// Issue 10 - End

		/// <summary>
		///     Gets the locations menu
		/// </summary>
		public ContextMenu LocationsMenu
		{
			get
			{
				if (m_LocationsMenu == null)
				{
					RebuildMenu();
				}

				return m_LocationsMenu;
			}
		}

		/// <summary>
		///     Rebuilds the locations menu
		/// </summary>
		private void RebuildMenu()
		{
			if (m_LocationsMenu != null)
			{
				m_LocationsMenu.Dispose();
			}

			m_LocationsMenu = new ContextMenu();

			// Add new location
			var miAdd = new MenuItem(Pandora.Localization.TextProvider["Notes.AddLoc"]);
			miAdd.Click += miAdd_Click;
			m_LocationsMenu.MenuItems.Add(miAdd);

			// Delete locations
			var miDel = new MenuItem(Pandora.Localization.TextProvider["Notes.DelLoc"]);
			miDel.Enabled = m_Locations.Count > 0;
			m_LocationsMenu.MenuItems.Add(miDel);

			m_LocationsMenu.MenuItems.Add(new MenuItem("-"));

			foreach (var loc in m_Locations)
			{
				var miLoc = new MenuItem(loc.Name);
				miLoc.Click += miLoc_Click;
				miDel.MenuItems.Add(miLoc);

				var miLocList = new MenuItem(loc.Name);
				miLocList.Click += miLocList_Click;
				m_LocationsMenu.MenuItems.Add(miLocList);
			}
		}

		#region IComparable Members
		public int CompareTo(object obj)
		{
			var cmp = obj as Note;

			if (cmp == null)
			{
				return 0;
			}

			switch (Notes.Sorting)
			{
				case NoteSorting.Name:

					if (Notes.Ascending)
					{
						return m_Name.CompareTo(cmp.m_Name);
					}
					else
					{
						return cmp.m_Name.CompareTo(m_Name);
					}

				case NoteSorting.Date:

					if (Notes.Ascending)
					{
						return m_Date.CompareTo(cmp.m_Date);
					}
					else
					{
						return cmp.m_Date.CompareTo(m_Date);
					}

				case NoteSorting.Priority:

					if (Notes.Ascending)
					{
						return m_Priority.CompareTo(cmp.m_Priority);
					}
					else
					{
						return cmp.m_Priority.CompareTo(m_Priority);
					}
			}

			return 0;
		}
		#endregion

		/// <summary>
		///     Add a new location
		/// </summary>
		private void miAdd_Click(object sender, EventArgs e)
		{
			var form = new QuickLocation();

			if (form.ShowDialog() == DialogResult.OK)
			{
				var loc = form.CurrentLocation;

				m_Locations.Add(loc);
				RebuildMenu();
			}
		}

		/// <summary>
		///     Delete a location
		/// </summary>
		private void miLoc_Click(object sender, EventArgs e)
		{
			var parent = m_LocationsMenu.MenuItems[1];

			var index = parent.MenuItems.IndexOf(sender as MenuItem);

			m_Locations.RemoveAt(index);
			RebuildMenu();
		}

		/// <summary>
		///     Go to a location
		/// </summary>
		private void miLocList_Click(object sender, EventArgs e)
		{
			var index = m_LocationsMenu.MenuItems.IndexOf(sender as MenuItem) - 3;

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			var loc = m_Locations[index];
			// Issue 10 - End

			Pandora.Profile.Commands.DoGo(loc.X, loc.Y, loc.Z, loc.Map);
		}
	}
}