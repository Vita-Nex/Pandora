#region Header
// /*
//  *    2018 - BoxCommonLibrary - HuesChart.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for HuesChart.
	/// </summary>
	public class HuesChart : Control
	{
		#region Variables
		private int m_SelectedIndex = 1;
		private int m_ColorTableIndex = 28;
		#endregion

		#region Properties
		/// <summary>
		///     Gets or sets the index of the selected hue
		/// </summary>
		public int SelectedIndex
		{
			get => m_SelectedIndex;
			set
			{
				if (value >= 0 && value <= 3000)
				{
					if (m_SelectedIndex != value)
					{
						m_SelectedIndex = value;

						Refresh();

						OnHueChanged(new EventArgs());
					}
				}
			}
		}

		/// <summary>
		///     Gets the selected Hue object
		/// </summary>
		public Ultima.Hue SelectedHue => Ultima.Hues.GetHue(m_SelectedIndex);

		/// <summary>
		///     Gets or sets the value that specifies which color from each hue is used to draw the hue
		/// </summary>
		public int ColorTableIndex
		{
			get => m_ColorTableIndex;
			set
			{
				if (m_ColorTableIndex == value)
				{
					return;
				}

				m_ColorTableIndex = value;

				if (m_ColorTableIndex < 0)
				{
					m_ColorTableIndex = 0;
				}

				if (m_ColorTableIndex > 31)
				{
					m_ColorTableIndex = 31;
				}

				Refresh();
			}
		}
		#endregion

		/// <summary>
		///     Occurs when the selected hue has changed
		/// </summary>
		public event EventHandler HueChanged;

		/// <summary>
		///     Fires the HueChanged event
		/// </summary>
		protected virtual void OnHueChanged(EventArgs e)
		{
			HueChanged?.Invoke(this, e);
		}

		/// <summary>
		///     Creates a HueChart control
		/// </summary>
		public HuesChart()
		{
			Width = 452;
			Height = 302;

			// Flickering fix
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		/// <summary>
		///     Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{ }
			base.Dispose(disposing);
		}

		/// <summary>
		///     Don't allow resisizing, size must fit the hue chart size
		/// </summary>
		protected override void OnResize(EventArgs e)
		{
			Width = 452;
			Height = 302;
		}

		/// <summary>
		///     Painting routine
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			for (var i = 1; i < 3001; i++)
			{
				PaintHue(i, e.Graphics);
			}

			var black = new Pen(Color.Black);
			var white = new Pen(Color.White);

			e.Graphics.DrawRectangle(black, 0, 0, Width - 1, Height - 1);

			if (m_SelectedIndex > 0 && m_SelectedIndex <= 3000)
			{
				var column = (m_SelectedIndex - 1) / 60;
				var row = (m_SelectedIndex - 1) % 60;

				var x = column * 9;
				var y = row * 5;

				e.Graphics.DrawRectangle(white, x, y, 10, 6);
			}

			black.Dispose();
			white.Dispose();
		}

		/// <summary>
		///     Paints the rectangle corresponding to a specified hue on the supplied greaphics object
		/// </summary>
		/// <param name="index">The index of the hue that should be painted</param>
		/// <param name="g">The Graphics object used for the painting</param>
		private void PaintHue(int index, Graphics g)
		{
			var column = (index - 1) / 60;
			var row = (index - 1) % 60;

			var x = column * 9;
			var y = row * 5;

			var hue = Ultima.Hues.GetHue(index);

			Brush brush = new SolidBrush(Ultima.Hues.HueToColor(hue.Colors[m_ColorTableIndex]));

			g.FillRectangle(brush, x + 1, y + 1, 9, 5);

			brush.Dispose();
		}

		/// <summary>
		///     Handles the MouseDown event and fires the SelectedIndexChanged event
		/// </summary>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			_ = e.X - 1;
			_ = e.Y - 1;

			var column = e.X / 9;
			var row = e.Y / 5;

			var index = (column * 60) + row + 1;

			SelectedIndex = index;
		}

		/// <summary>
		///     Provides keyboard navigation of the chart
		/// </summary>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			switch (e.KeyCode)
			{
				case Keys.Left:

					SelectedIndex -= 60;
					break;

				case Keys.Right:

					SelectedIndex += 60;
					break;

				case Keys.Up:

					SelectedIndex--;
					break;

				case Keys.Down:

					SelectedIndex++;
					break;
			}
		}

		/// <summary>
		///     Keys handling
		/// </summary>
		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Left:
				case Keys.Right:
				case Keys.Up:
				case Keys.Down:
					return true;
			}

			return base.IsInputKey(keyData);
		}
	}
}
