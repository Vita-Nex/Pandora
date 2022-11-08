#region Header
// /*
//  *    2018 - Pandora - PopUpForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	public delegate void PopUpCallback();

	/// <summary>
	///     Summary description for PopUpForm.
	/// </summary>
	public class PopUpForm : Form
	{
		private enum HotSpot
		{
			None,
			Title,
			Close
		}

		private IContainer components;

		private static readonly Color m_TopColor = Color.LightSkyBlue;
		private static readonly Color m_BottomColor = Color.AliceBlue;
		private static readonly Color m_BorderColor = Color.SteelBlue;
		private static readonly Color m_TextColor = Color.SlateBlue;
		private string m_Title;
		private string m_Message;
		private Rectangle m_TitleBounds;
		private ImageList imgList;
		private Rectangle m_MessageBounds;
		private Rectangle m_CloseBounds;
		private HotSpot m_HotSpot = HotSpot.None;
		private bool m_ToolTipMode;
		private PopUpCallback m_Callback;

		public PopUpForm()
		{
			InitializeComponent();
			Pandora.Localization.LocalizeControl(this);

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
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			var resources = new System.Resources.ResourceManager(typeof(PopUpForm));
			this.imgList = new System.Windows.Forms.ImageList(this.components)
			{
				// 
				// imgList
				// 
				ImageSize = new System.Drawing.Size(13, 13),
				ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList.ImageStream"),
				TransparentColor = System.Drawing.Color.Transparent
			};
			// 
			// PopUpForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.AliceBlue;
			this.ClientSize = new System.Drawing.Size(264, 144);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PopUpForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopUpForm_MouseDown);
			this.Load += new System.EventHandler(this.PopUpForm_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PopUpForm_MouseUp);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PopUpForm_MouseMove);
			this.MouseLeave += new System.EventHandler(this.PopUpForm_MouseLeave);
		}
		#endregion

		#region Events
		private void Calculate()
		{
			var g = CreateGraphics();
			_ = new Rectangle(0, 0, Width - 1, Height - 1);

			var font = new Font("Arial", 8.25f);

			var titleStyle = FontStyle.Bold;

			if (m_HotSpot == HotSpot.Title)
			{
				titleStyle |= FontStyle.Underline;
			}

			var titleFont = new Font("Arial", 8.25f, titleStyle);

			var size1 = g.MeasureString(m_Title, titleFont, 256);
			var size2 = g.MeasureString(m_Message, font, 256);

			var size = new Size(
				(int)Math.Ceiling(Math.Max(size1.Width, size2.Width)) + 12 + 13,
				(int)Math.Ceiling(size1.Height + size2.Height) + 12);
			Size = size;

			m_CloseBounds = new Rectangle(size.Width - 17, 4, 13, 13);

			m_TitleBounds = new Rectangle(4, 4, (int)Math.Ceiling(size1.Width), (int)Math.Ceiling(size1.Height));
			m_MessageBounds = new Rectangle(
				4,
				8 + (int)Math.Ceiling(size1.Height),
				(int)Math.Ceiling(size2.Width),
				(int)Math.Ceiling(size2.Height));

			font.Dispose();
			titleFont.Dispose();
			g.Dispose();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			var rect = new Rectangle(0, 0, Width - 1, Height - 1);

			var brush = new LinearGradientBrush(rect, m_BottomColor, m_TopColor, -90);
			var pen = new Pen(m_BorderColor);
			Brush titleBrush = new SolidBrush(Color.DarkBlue);
			Brush textBrush = new SolidBrush(Color.SlateBlue);
			var font = new Font("Arial", 8.25f);
			var titleStyle = m_HotSpot == HotSpot.Title && m_Callback != null
				? FontStyle.Underline | FontStyle.Bold
				: FontStyle.Bold;
			var titleFont = new Font("Arial", 8.25f, titleStyle);

			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.DrawRectangle(pen, rect);

			e.Graphics.DrawString(m_Title, titleFont, titleBrush, m_TitleBounds);
			e.Graphics.DrawString(m_Message, font, textBrush, m_MessageBounds);

			brush.Dispose();
			pen.Dispose();
			titleBrush.Dispose();
			textBrush.Dispose();
			titleFont.Dispose();
			font.Dispose();

			if (m_HotSpot == HotSpot.Close)
			{
				if (MouseButtons == MouseButtons.Left)
				{
					e.Graphics.DrawImage(imgList.Images[2], m_CloseBounds);
				}
				else
				{
					e.Graphics.DrawImage(imgList.Images[1], m_CloseBounds);
				}
			}
			else
			{
				e.Graphics.DrawImage(imgList.Images[0], m_CloseBounds);
			}
		}

		private void PopUpForm_MouseLeave(object sender, EventArgs e)
		{
			if (m_ToolTipMode)
			{
				Close();
			}
		}
		#endregion

		#region Showing
		public static void PopUp(Form owner, string title, string message, bool toolTipMode, PopUpCallback callback)
		{
			var form = new PopUpForm
			{
				m_Title = title,
				m_Message = message,
				m_ToolTipMode = toolTipMode,
				m_Callback = callback
			};

			form.Calculate();

			_ = form.ShowDialog(owner);
		}
		#endregion

		private void PopUpForm_Load(object sender, EventArgs e)
		{
			Location = MousePosition;

			// Verify Visibility
			var screen = SystemInformation.WorkingArea;
			var form = new Rectangle(Location, Size);

			if (!screen.Contains(form))
			{
				var dX = Right - screen.Width;
				var dY = Bottom - screen.Height;

				if (dX > 0)
				{
					dX = -dX;
				}
				else
				{
					dX = 0;
				}

				if (dY > 0)
				{
					dY = -dY;
				}
				else
				{
					dY = 0;
				}

				Location = new Point(Location.X + dX, Location.Y + dY);
			}
		}

		private void PopUpForm_MouseMove(object sender, MouseEventArgs e)
		{
			var spot = HotSpot.None;

			if (m_TitleBounds.Contains(e.X, e.Y))
			{
				spot = HotSpot.Title;
			}
			else if (m_CloseBounds.Contains(e.X, e.Y))
			{
				spot = HotSpot.Close;
			}

			if (m_HotSpot != spot)
			{
				m_HotSpot = spot;
				Refresh();
			}

			if (m_HotSpot == HotSpot.Title && m_Callback != null)
			{
				Cursor = Cursors.Hand;
			}
			else
			{
				Cursor = Cursors.Arrow;
			}
		}

		private void PopUpForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_HotSpot == HotSpot.Close)
			{
				Refresh();
			}
		}

		private void PopUpForm_MouseUp(object sender, MouseEventArgs e)
		{
			if (m_HotSpot == HotSpot.Close)
			{
				Close();
			}
			else if (m_HotSpot == HotSpot.Title)
			{
				if (m_Callback != null)
				{
					try
					{
						_ = m_Callback.DynamicInvoke(null);
					}
					catch
					{ }

					Close();
				}
			}
		}
	}
}