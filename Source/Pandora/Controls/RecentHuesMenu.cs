#region Header
// /*
//  *    2018 - Pandora - RecentHuesMenu.cs
//  */
#endregion

#region References
using System;
using System.Windows.Forms;

using TheBox.Common;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     The menu that displays the recently used hues
	/// </summary>
	public class RecentHuesMenu : ContextMenu
	{
		private readonly RecentIntList m_List;
		private int m_SelectedHue;

		/// <summary>
		///     Gets the hue value that has been selected by the user
		/// </summary>
		public int SelectedHue { get { return m_SelectedHue; } }

		/// <summary>
		///     Creates a RecentHuesMenu that can
		/// </summary>
		/// <param name="list"></param>
		public RecentHuesMenu(RecentIntList list)
		{
			m_List = list;
			m_List.ListChanged += m_List_ListChanged;
			MakeMenu();
		}

		private void m_List_ListChanged(object sender, EventArgs e)
		{
			DisposeMenu();
			MakeMenu();
		}

		private void DisposeMenu()
		{
			while (MenuItems.Count > 0)
				MenuItems[0].Dispose();
		}

		private void MakeMenu()
		{
			foreach (var i in m_List.List)
			{
				HueMenuItem mi = null;

				if (i == 0)
					mi = new HueMenuItem(i.ToString(), null);
				else
					mi = new HueMenuItem(i.ToString(), Pandora.Hues[i].ColorTable);

				MenuItems.Add(mi);

				mi.Click += mi_Click;
			}
		}

		private void mi_Click(object sender, EventArgs e)
		{
			var mi = sender as HueMenuItem;

			if (mi != null)
			{
				m_SelectedHue = Convert.ToInt32(mi.Text);
				OnHueClicked(new EventArgs());
			}
		}

		public event EventHandler HueClicked;

		protected virtual void OnHueClicked(EventArgs e)
		{
			if (HueClicked != null)
			{
				HueClicked(this, e);
			}
		}
	}
}