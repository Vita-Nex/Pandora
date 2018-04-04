#region Header
// /*
//  *    2018 - Pandora - SoundData.cs
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
	///     Defines a sound in UO
	/// </summary>
	public class UOSound
	{
		/// <summary>
		///     Creates a new UOSound object
		/// </summary>
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
	/// Defines the Sounds that can be played in game
	/// </summary>
	public class SoundData
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<GenericNode> m_Structure;

		// Issue 10 - End
		private ContextMenu m_Menu;

		private UOSound m_SelectedSound;

		/// <summary>
		///     Occurs when the selected sound has changed
		/// </summary>
		public event EventHandler SoundChanged;

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

		/// <summary>
		///     Creates a new SoundData object
		/// </summary>
		public SoundData()
		{
			m_Structure = new List<GenericNode>();
		}

		[XmlIgnore]
		/// <summary>
		/// Gets or sets the currently selected sound
		/// </summary>
		public UOSound SelectedSound
		{
			get { return m_SelectedSound; }
			set
			{
				m_SelectedSound = value;

				if (SoundChanged != null)
				{
					SoundChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		///     Gets the context menu representing the sounds structure
		/// </summary>
		public ContextMenu Menu
		{
			get
			{
				if (m_Menu == null)
				{
					m_Menu = new ContextMenu();

					foreach (var gNode in m_Structure)
					{
						var mitem = new MenuItem(gNode.Name);
						mitem.MenuItems.AddRange(DoNode(gNode));

						m_Menu.MenuItems.Add(mitem);
					}
				}

				return m_Menu;
			}
		}

		/// <summary>
		///     Processes a GenericNode and created the menu items for it
		/// </summary>
		/// <param name="gNode">The GenericNode to evaluate</param>
		/// <returns>A collection of MenuItem objects</returns>
		private MenuItem[] DoNode(GenericNode gNode)
		{
			var mitems = new MenuItem[gNode.Elements.Count];

			for (var i = 0; i < mitems.Length; i++)
			{
				var node = gNode.Elements[i] as GenericNode;
				var snd = gNode.Elements[i] as UOSound;

				if (node != null)
				{
					mitems[i] = new MenuItem(node.Name);
					mitems[i].MenuItems.AddRange(DoNode(node));
				}
				else if (snd != null)
				{
					mitems[i] = new InternalMenuItem(snd);
					mitems[i].Click += SoundData_Click;
				}
			}

			return mitems;
		}

		/// <summary>
		///     An item is selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SoundData_Click(object sender, EventArgs e)
		{
			var mi = sender as InternalMenuItem;

			if (mi != null)
			{
				SelectedSound = mi.Sound;
			}
		}

		/// <summary>
		///     Defines a menu item used to display sound data
		/// </summary>
		private class InternalMenuItem : MenuItem
		{
			/// <summary>
			///     Gets or sets the index of the sound represented by the menu
			/// </summary>
			public UOSound Sound { get; set; }

			public InternalMenuItem(UOSound snd)
				: base(snd.Name)
			{
				Sound = snd;
			}
		}
	}
}