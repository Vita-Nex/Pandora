#region Header
// /*
//  *    2018 - Pandora - DoorsData.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Provides access to information about doors
	/// </summary>
	public class DoorsData
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private readonly List<GenericNode> m_Structure;
		// Issue 10 - End

		private string m_PortNS;
		private string m_PortEW;
		private int m_PortNSBase;
		private int m_PortEWBase;
		private string m_PortName;

		private ContextMenu m_Menu;

		/// <summary>
		///     Gets the doors context menu
		/// </summary>
		public ContextMenu Menu { get { return m_Menu; } }

		/// <summary>
		///     Occurs when a door is selected
		/// </summary>
		public event DoorEventHandler DoorSelected;

		/// <summary>
		///     Occurs when a portcullis is selected
		/// </summary>
		public event PortcullisEventHandler PortcullisSelected;

		/// <summary>
		///     Creates a new DoorsData object
		/// </summary>
		public DoorsData()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Structure = new List<GenericNode>();
			// Issue 10 - End
			Load();
			BuildMenu();
		}

		/// <summary>
		///     Loads the DoorsData from the Data assembly
		/// </summary>
		private void Load()
		{
			var stream = Pandora.DataAssembly.GetManifestResourceStream("Data.Doors.xml");
			var dom = new XmlDocument();
			dom.Load(stream);
			stream.Close();

			var root = dom.ChildNodes[1];

			foreach (XmlNode xNode in root.ChildNodes)
			{
				if (xNode.ChildNodes.Count == 0)
				{
					// Portcullis
					m_PortNS = xNode.Attributes["itemNS"].Value;
					m_PortEW = xNode.Attributes["itemEW"].Value;
					m_PortName = xNode.Attributes["name"].Value;
					m_PortEWBase = int.Parse(xNode.Attributes["EW"].Value);
					m_PortNSBase = int.Parse(xNode.Attributes["NS"].Value);
				}
				else
				{
					var gNode = new GenericNode(xNode.Attributes["name"].Value);
					m_Structure.Add(gNode);

					foreach (XmlNode doorNode in xNode.ChildNodes)
					{
						gNode.Elements.Add(DoorInfo.FromXmlNode(doorNode));
					}
				}
			}
		}

		/// <summary>
		///     Builds the context menu used to select doors
		/// </summary>
		private void BuildMenu()
		{
			m_Menu = new ContextMenu();

			foreach (var gNode in m_Structure)
			{
				var category = new MenuItem(gNode.Name);
				m_Menu.MenuItems.Add(category);

				foreach (DoorInfo door in gNode.Elements)
				{
					var mi = new InternalMenuItem(door);
					mi.Click += DoorClicked;
					category.MenuItems.Add(mi);
				}
			}

			var port = new MenuItem(m_PortName);
			port.Click += PortcullisClicked;
			m_Menu.MenuItems.Add(port);
		}

		/// <summary>
		///     User clicks a door menu item
		/// </summary>
		private void DoorClicked(object sender, EventArgs e)
		{
			var mi = sender as InternalMenuItem;

			if (DoorSelected != null)
			{
				string category = null;

				foreach (MenuItem parent in m_Menu.MenuItems)
				{
					if (parent.MenuItems.Contains(mi))
					{
						category = parent.Text;
						break;
					}
				}

				DoorSelected(new DoorEventArgs(mi.Door, category));
			}
		}

		/// <summary>
		///     User clicks the portcullis menu item
		/// </summary>
		private void PortcullisClicked(object sender, EventArgs e)
		{
			if (PortcullisSelected != null)
			{
				var args = new PortcullisEventArgs(m_PortName, m_PortNS, m_PortEW, m_PortNSBase, m_PortEWBase);
				PortcullisSelected(args);
			}
		}

		#region Internal Menu Item
		private class InternalMenuItem : MenuItem
		{
			private readonly DoorInfo m_Door;

			/// <summary>
			///     Gets the door represented by this menu item
			/// </summary>
			public DoorInfo Door { get { return m_Door; } }

			public InternalMenuItem(DoorInfo info)
				: base(info.Name)
			{
				m_Door = info;
			}
		}
		#endregion
	}

	#region Delegates
	public delegate void DoorEventHandler(DoorEventArgs e);

	public delegate void PortcullisEventHandler(PortcullisEventArgs e);
	#endregion

	#region Event Args
	/// <summary>
	///     Defines arguments when a portcullis is being selected
	/// </summary>
	public class PortcullisEventArgs : EventArgs
	{
		private readonly string m_Name;
		private readonly string m_ItemNS;
		private readonly string m_ItemEW;
		private readonly int m_ArtNS;
		private readonly int m_ArtEW;

		/// <summary>
		///     Gets the Portcullis door name
		/// </summary>
		public string Name { get { return m_Name; } }

		/// <summary>
		///     Gets the item name for the NS orientation
		/// </summary>
		public string ItemNS { get { return m_ItemNS; } }

		/// <summary>
		///     Gets the item name for the EW orientation
		/// </summary>
		public string ItemEW { get { return m_ItemEW; } }

		/// <summary>
		///     Gets the art for the NS orientation
		/// </summary>
		public int ArtNS { get { return m_ArtNS; } }

		/// <summary>
		///     Gets the art for the EW orientation
		/// </summary>
		public int ArtEW { get { return m_ArtEW; } }

		public PortcullisEventArgs(string name, string itemNS, string itemEW, int artNS, int artEW)
		{
			m_Name = name;
			m_ItemNS = itemNS;
			m_ItemEW = itemEW;
			m_ArtNS = artNS;
			m_ArtEW = artEW;
		}
	}

	/// <summary>
	///     Defines the arguments of a door selected event
	/// </summary>
	public class DoorEventArgs : EventArgs
	{
		private readonly string m_Name;
		private readonly string m_Item;
		private readonly int m_BaseID;
		private readonly string m_Category;

		/// <summary>
		///     Gets the door name
		/// </summary>
		public string Name
		{
			get
			{
				if (m_Category != null)
					return string.Format("{0}:\n{1}", m_Category, m_Name);
				return m_Name;
			}
		}

		/// <summary>
		///     Gets the item name
		/// </summary>
		public string Item { get { return m_Item; } }

		/// <summary>
		///     Gets the item base ID
		/// </summary>
		public int BaseID { get { return m_BaseID; } }

		/// <summary>
		///     Creates a new DoorEventArgs object
		/// </summary>
		/// <param name="info">The DoorInfo object describing the door</param>
		/// <param name="category">The category this door belongs to</param>
		public DoorEventArgs(DoorInfo info, string category)
		{
			m_Name = info.Name;
			m_Item = info.Item;
			m_BaseID = info.BaseID;
			m_Category = category;
		}
	}
	#endregion

	#region DoorInfo
	/// <summary>
	///     Defines a Door
	/// </summary>
	public class DoorInfo
	{
		/// <summary>
		///     Gets or sets the door name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the door's item name
		/// </summary>
		public string Item { get; set; }

		/// <summary>
		///     Gets or sets the door's base ID
		/// </summary>
		public int BaseID { get; set; }

		/// <summary>
		///     Creates a new DoorInfo object
		/// </summary>
		private DoorInfo()
		{ }

		/// <summary>
		///     Creates a DoorInfo from an Xml node
		/// </summary>
		/// <param name="xNode">The XmlNode to convert to a door info</param>
		/// <returns>A Door Info object</returns>
		public static DoorInfo FromXmlNode(XmlNode xNode)
		{
			var door = new DoorInfo();

			door.Name = xNode.Attributes["name"].Value;
			door.Item = xNode.Attributes["item"].Value;
			door.BaseID = int.Parse(xNode.Attributes["base"].Value);

			return door;
		}
	}
	#endregion
}