#region Header
// /*
//  *    2018 - Pandora - TopBar.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Common;
using TheBox.Forms;
using TheBox.Properties;
#endregion

namespace TheBox.Controls
{
	public partial class TopBar : UserControl
	{
		private readonly HuePicker _huePicker;

		public TopBar()
		{
			InitializeComponent();

			try
			{
				Pandora.Localization.LocalizeMenu(contextMenuStrip);
				_huePicker = new HuePicker();
			}
			catch (Exception)
			{
				// For designer
			}
		}

		private void btnBoxMenu_MouseEnter(object sender, EventArgs e)
		{
			btnBoxMenu.BackgroundImage = Resources.box_down;
		}

		private void btnBoxMenu_MouseLeave(object sender, EventArgs e)
		{
			btnBoxMenu.BackgroundImage = Resources.box_normal;
		}

		private void btnBoxMenu_Click(object sender, EventArgs e)
		{
			contextMenuStrip.Show(Cursor.Position);
			//TrayMenu.Show(bMenu, new Point(e.X, e.Y));
		}

		private void pctCap_MouseEnter(object sender, EventArgs e)
		{
			pctCap.BackColor = SystemColors.ControlLightLight;
		}

		private void pctCap_MouseDown(object sender, MouseEventArgs e)
		{
			pctCap.BackColor = SystemColors.Window;

			if (e.Button == MouseButtons.Left)
			{
				// Take screenie
				Pandora.Profile.Screenshots.Capture();
			}
			else
			{
				// Show screenshot control
				var form = new CapForm();
				_ = form.ShowDialog();
			}
		}

		private void pctCap_MouseLeave(object sender, EventArgs e)
		{
			pctCap.BackColor = SystemColors.Control;
		}

		private void pctCap_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.X >= 0 && e.X < pctCap.Right && e.Y >= 0 && e.Y <= pctCap.Bottom)
			{
				pctCap.BackColor = SystemColors.ControlLightLight;
			}
			else
			{
				pctCap.BackColor = SystemColors.Control;
			}
		}

		private void pctCap_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(pctCap, e.Graphics);
		}

		private void imgHue_Click(object sender, EventArgs e)
		{ }

		private void numHue_ValueChanged(object sender, EventArgs e)
		{
			if (!Created)
			{
				return;
			}

			if (numHue.Value != 0)
			{
				_huePicker.SelectedHue = (int)numHue.Value;
				imgHue.Image = Pandora.Hues[(int)numHue.Value].GetSpectrum(imgHue.Size);
			}
			else
			{
				imgHue.Image.Dispose();
				imgHue.Image = null;
			}
		}
	}
}