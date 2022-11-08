#region Header
// /*
//  *    2018 - Pandora - HueMenuItem.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Mul;
#endregion

namespace TheBox.Controls
{
	public class HueMenuItem : MenuItem
	{
		private Bitmap Image;
		private bool NoHue;

		public HueMenuItem(string text, short[] colors)
		{
			// Override Owner Draw
			OwnerDraw = true;

			Text = text;

			MakeImage(colors);
		}

		private void MakeImage(short[] colors)
		{
			Image = new Bitmap(34, 14);

			if (colors == null)
			{
				NoHue = true;
				return;
			}

			// Draw border
			for (var x = 0; x < 34; x++)
			{
				Image.SetPixel(x, 0, Color.Black);
				Image.SetPixel(x, 13, Color.Black);
			}
			for (var y = 1; y < 14; y++)
			{
				Image.SetPixel(0, y, Color.Black);
				Image.SetPixel(33, y, Color.Black);
			}

			for (var i = 0; i < 32; i++)
			{
				for (var y = 1; y < 13; y++)
				{
					Image.SetPixel(i + 1, y, Hue.ToColor(colors[i]));
				}
			}
		}

		protected override void OnMeasureItem(MeasureItemEventArgs e)
		{
			var MenuFont = SystemInformation.MenuFont;

			var stringformat = new StringFormat();

			var sizef = e.Graphics.MeasureString(Text, MenuFont, 1000, stringformat);

			e.ItemWidth = (int)Math.Ceiling(sizef.Width) + Image.Width;
			e.ItemHeight = Math.Max((int)Math.Ceiling(sizef.Height), Image.Height);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			var MenuFont = SystemInformation.MenuFont;

			SolidBrush menuBrush;
			if ((e.State & DrawItemState.Selected) != 0)
			{
				menuBrush = new SolidBrush(SystemColors.HighlightText);
			}
			else
			{
				menuBrush = new SolidBrush(SystemColors.MenuText);
			}

			_ = new StringFormat
			{
				LineAlignment = StringAlignment.Center
			};

			var rectImage = e.Bounds;

			rectImage.Width = Image.Width;
			rectImage.Height = Image.Height;

			var rectText = e.Bounds;

			rectText.X += rectImage.Width;

			// Draw rect
			if ((e.State & DrawItemState.Selected) != 0)
			{
				e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds);
			}

			if (NoHue)
			{
				// Draw rect
				var blackPen = new Pen(new SolidBrush(Color.Black));
				var redPen = new Pen(new SolidBrush(Color.Red));

				e.Graphics.DrawRectangle(blackPen, rectImage.X, rectImage.Y, rectImage.Width - 1, rectImage.Height - 1);
				e.Graphics.DrawLine(redPen, rectImage.Left, rectImage.Top, rectImage.Right - 1, rectImage.Bottom - 1);
				e.Graphics.DrawLine(redPen, rectImage.Left, rectImage.Bottom - 1, rectImage.Right - 1, rectImage.Top);
			}
			else
			{
				// Draw image
				e.Graphics.DrawImage(Image, rectImage);
			}

			// Draw text
			e.Graphics.DrawString(Text, MenuFont, menuBrush, e.Bounds.Left + Image.Width, e.Bounds.Top);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				if (Image != null)
				{
					Image.Dispose();
				}
			}
		}
	}
}