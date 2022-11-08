#region Header
// /*
//  *    2018 - Pandora - Hues.cs
//  */
#endregion

#region References
using System;

using TheBox.ArtViewer;
using TheBox.Common;
#endregion

namespace TheBox.Options
{
	[Serializable]
	/// <summary>
	/// Summary description for Hues.
	/// </summary>
	public class HuesOptions
	{
		private int m_SelectedIndex = 1;
		private Art m_PreviewArt = Art.Items;
		private int m_PreviewIndex;
		private bool m_Scale = true;
		private bool m_RoomView = true;
		private bool m_Animate;
		private int m_Darkness = 28;
		private RecentIntList m_RecentHues;

		#region Events
		/// <summary>
		///     Occurs when the selected hue has changed
		/// </summary>
		public event EventHandler HueChanged;
		#endregion

		/// <summary>
		///     Gets or sets the index of the hue currently selected in the hue picker
		/// </summary>
		public int SelectedIndex
		{
			get => m_SelectedIndex;
			set
			{
				m_SelectedIndex = value;

				HueChanged?.Invoke(this, new EventArgs());
			}
		}

		/// <summary>
		///     Gets or sets the type of art being previed
		/// </summary>
		public Art Art { get => m_PreviewArt; set => m_PreviewArt = value; }

		/// <summary>
		///     Gets or sets the index of the previewed art
		/// </summary>
		public int PreviewIndex { get => m_PreviewIndex; set => m_PreviewIndex = value; }

		/// <summary>
		///     Gets or sets a value stating whether items should be scaled in the preview window
		/// </summary>
		public bool Scale { get => m_Scale; set => m_Scale = value; }

		/// <summary>
		///     Gets or sets a value stating whether items should be displayed using the room view
		/// </summary>
		public bool RoomView { get => m_RoomView; set => m_RoomView = value; }

		/// <summary>
		///     Gets or sets a value stating whether NPCs should be animated
		/// </summary>
		public bool Animate { get => m_Animate; set => m_Animate = value; }

		/// <summary>
		///     Gets or sets the brightness level on the hues chart
		/// </summary>
		public int Darkness
		{
			get => m_Darkness;
			set
			{
				m_Darkness = value;

				if (m_Darkness > 31)
				{
					m_Darkness = 31;
				}

				if (m_Darkness < 0)
				{
					m_Darkness = 0;
				}
			}
		}

		/// <summary>
		///     Gets or sets the recently used hues
		/// </summary>
		public RecentIntList RecentHues { get => m_RecentHues; set => m_RecentHues = value; }

		public HuesOptions()
		{
			m_RecentHues = new RecentIntList
			{
				Capacity = 10
			};
		}
	}
}