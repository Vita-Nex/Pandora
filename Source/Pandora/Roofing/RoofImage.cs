#region Header
// /*
//  *    2018 - Pandora - RoofImage.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Drawing;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Defines the image of the roof being created by the user
	/// </summary>
	public class RoofImage
	{

		/// <summary>
		///     Gets or sets the data containing the structure of the roof
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<int> Data
		// Issue 10 - End
		{
			get;
			set;
		}

		/// <summary>
		///     Gets or sets the image width
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		///     Gets or sets the image height
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		///     Gets the roof image
		/// </summary>
		public Bitmap Image { get; }

		/// <summary>
		///     Creates a new RoofImage object
		/// </summary>
		public RoofImage()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			Data = new List<int>();
			// Issue 10 - End
			Height = 0;
			Width = 0;
			Image = new Bitmap(240, 240);
		}

		/// <summary>
		///     Paints a rectangle portion of the image
		/// </summary>
		/// <param name="rect">The rectangle bounds that will be painted</param>
		/// <param name="color">The color used for the paining</param>
		private void PaintRect(Rectangle rect, Color color)
		{
			for (var i = rect.Left; i <= rect.Right; i++)
			{
				for (var j = rect.Top; j <= rect.Bottom; j++)
				{
					Image.SetPixel(i, j, color);
				}
			}
		}

		/// <summary>
		///     Calculates and creates the image
		/// </summary>
		public void CreateImage()
		{
			// Use white background
			for (var x = 0; x < Image.Width; x++)
			{
				for (var y = 0; y < Image.Height; y++)
				{
					Image.SetPixel(x, y, Color.White);
				}
			}

			if (Data.Count == 0)
			{
				return; // No data
			}

			// Scale factor
			var dw = Image.Width / Width;
			var dh = Image.Height / Height;

			if (dh > dw)
			{
				dh = dw;
			}
			else
			{
				dw = dh;
			}

			var basePoint = Point.Empty;

			basePoint.X = (Image.Width - (Width * dw)) / 2;
			basePoint.Y = (Image.Height - (Height * dh)) / 2;

			var p = 0; // Counter for the data
			var rect = Rectangle.Empty;

			for (var y = 0; y < Height; y++)
			{
				rect.Y = (y * dh) + basePoint.Y;
				rect.Height = ((y + 1) * dh) + basePoint.Y - rect.Y;

				for (var x = 0; x < Width; x++)
				{
					rect.X = (x * dw) + basePoint.X;
					rect.Width = ((x + 1) * dw) + basePoint.X - rect.X;

					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					if (Data[p] > 0)
					{
						// Data positive: valid piece - Use Green
						PaintRect(rect, Color.FromArgb(0, Math.Min(255, (Data[p] * 10) + 100), 0));
					}
					else if (Data[p] < 0)
					// Issue 10 - End
					{
						// Data negative: not valid piece - Use Red
						PaintRect(rect, Color.FromArgb(Math.Max(-255, (-Data[p] * 10) + 100), 0, 0));
					}

					p++;
				}
			}
		}
	}
}