#region Header
// /*
//  *    2018 - Pandora - HueSelector.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using TheBox.Data;
using TheBox.Mul;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for HueChart.
	/// </summary>
	public class HueSelector : Form
	{
		[DllImport("User32")]
		private static extern short GetKeyState(int nVirtKey);

		private static readonly int VK_SHIFT = 0x10;
		private static readonly int VK_CONTROL = 0x11;
		private static readonly int VK_MENU = 0x12;

		private HueGroups m_Groups;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the hues selected on the chart
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<int> SelectedHues
		// Issue 10 - End
		{
			get;
			set;
		}

		private HuesCollection m_SelectedGroup;

		private HuesCollection SelectedGroup
		{
			set
			{
				m_SelectedGroup = value;

				bUpdate.Enabled = m_SelectedGroup != null;
				bDelete.Enabled = m_SelectedGroup != null;

				SelectedHues.Clear();
				SelectedHues.AddRange(m_SelectedGroup.Hues);

				DrawSelectionChart();
			}
		}

		private Bitmap SelectionChart;
		private Bitmap Chart;
		private Bitmap TempBmp;

		private byte GCSteps;
		private int PreviousSelectedColor;
		private int SelectedColor;
		private readonly Hues m_Hues;
		private PictureBox TheImage;
		private ComboBox cmbGroups;
		private Button bUpdate;
		private TextBox txNew;
		private Button bNew;
		private Button bDelete;
		private GroupBox groupBox1;
		private PictureBox imgHue;
		private Label labName;
		private TextBox textBox1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public HueSelector()
		{
			InitializeComponent();

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			SelectedHues = new List<int>();
			// Issue 10 - End

			TempBmp = new Bitmap(450, 300);

			m_Hues = Hues.Load(Pandora.Profile.MulManager["hues.mul"]);

			DrawHues();

			SelectedHues.Add(1);
			DrawSelectionChart();
			SelectedHues.Clear();
			TheImage.Image = Chart;
			SelectionChart = (Bitmap)Chart.Clone();

			Pandora.Localization.LocalizeControl(this);
			//Pandora.Localization.LocalizeControl( this );
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
			var resources = new System.Resources.ResourceManager(typeof(HueSelector));
			this.TheImage = new System.Windows.Forms.PictureBox();
			this.cmbGroups = new System.Windows.Forms.ComboBox();
			this.bUpdate = new System.Windows.Forms.Button();
			this.txNew = new System.Windows.Forms.TextBox();
			this.bNew = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labName = new System.Windows.Forms.Label();
			this.imgHue = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TheImage
			// 
			this.TheImage.Location = new System.Drawing.Point(16, 88);
			this.TheImage.Name = "TheImage";
			this.TheImage.Size = new System.Drawing.Size(450, 300);
			this.TheImage.TabIndex = 0;
			this.TheImage.TabStop = false;
			this.TheImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TheImage_MouseMove);
			this.TheImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TheImage_MouseDown);
			// 
			// cmbGroups
			// 
			this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGroups.Location = new System.Drawing.Point(8, 8);
			this.cmbGroups.Name = "cmbGroups";
			this.cmbGroups.Size = new System.Drawing.Size(128, 21);
			this.cmbGroups.TabIndex = 1;
			this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
			// 
			// bUpdate
			// 
			this.bUpdate.Enabled = false;
			this.bUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bUpdate.Location = new System.Drawing.Point(144, 8);
			this.bUpdate.Name = "bUpdate";
			this.bUpdate.Size = new System.Drawing.Size(64, 23);
			this.bUpdate.TabIndex = 2;
			this.bUpdate.Text = "Common.Update";
			this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
			// 
			// txNew
			// 
			this.txNew.Location = new System.Drawing.Point(296, 8);
			this.txNew.Name = "txNew";
			this.txNew.Size = new System.Drawing.Size(104, 20);
			this.txNew.TabIndex = 3;
			this.txNew.Text = "";
			this.txNew.TextChanged += new System.EventHandler(this.txNew_TextChanged);
			// 
			// bNew
			// 
			this.bNew.Enabled = false;
			this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNew.Location = new System.Drawing.Point(408, 8);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(64, 23);
			this.bNew.TabIndex = 4;
			this.bNew.Text = "Common.New";
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bDelete
			// 
			this.bDelete.Enabled = false;
			this.bDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDelete.Location = new System.Drawing.Point(216, 8);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(64, 23);
			this.bDelete.TabIndex = 5;
			this.bDelete.Text = "Common.Delete";
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labName);
			this.groupBox1.Controls.Add(this.imgHue);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 48);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// labName
			// 
			this.labName.Location = new System.Drawing.Point(8, 16);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(152, 23);
			this.labName.TabIndex = 1;
			this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imgHue
			// 
			this.imgHue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgHue.Location = new System.Drawing.Point(168, 16);
			this.imgHue.Name = "imgHue";
			this.imgHue.Size = new System.Drawing.Size(288, 24);
			this.imgHue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgHue.TabIndex = 0;
			this.imgHue.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.textBox1.Location = new System.Drawing.Point(8, 400);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(464, 72);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "HuePicker.Instructions";
			// 
			// HueSelector
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(482, 480);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bNew);
			this.Controls.Add(this.txNew);
			this.Controls.Add(this.bUpdate);
			this.Controls.Add(this.cmbGroups);
			this.Controls.Add(this.TheImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "HueSelector";
			this.Text = "HuePicker.Groups";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.HueSelector_Closing);
			this.Load += new System.EventHandler(this.HueSelector_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void DrawHues()
		{
			Chart = new Bitmap(450, 300);

			var Brightness = 28;
			var Index = 0;

			foreach (var group in m_Hues.Groups)
			{
				foreach (var entry in group.HueList)
				{
					// Draw the box for the hue
					DrawBox(Chart, entry.ColorTable[Brightness], Index);
					Index++;
				}
			}

			// Display the chart
			TheImage.Image = Chart;
		}

		private void DrawBox(Bitmap bmp, short Color16, int Index)
		{
			// Calculate the row and column (zero based)
			var column = Index / 60;
			var row = Index % 60;

			// Get the color
			var color = Hue.ToColor(Color16);

			// Find the top left corner of the box
			var x = column * 9;
			var y = row * 5;

			// Color
			for (var iX = 0; iX < 9; iX++)
			{
				for (var iY = 0; iY < 5; iY++)
				{
					bmp.SetPixel(x + iX, y + iY, color);
				}
			}
		}

		private int GetHueIndex(int x, int y)
		{
			var column = x / 9;
			var row = y / 5;
			return (column * 60) + row + 1;
		}

		private void DrawSelectionChart()
		{
			if (SelectedHues.Count == 0)
			{
				TheImage.Image = Chart;
				return;
			}

			SelectedHues.Sort();
			SelectionChart = DrawSelection(Chart, SelectedHues, Color.White);
			TheImage.Image = SelectionChart;
		}

		private void TheImage_MouseDown(object sender, MouseEventArgs e)
		{
			// Get the hue index ( zero based )
			SelectedColor = GetHueIndex(e.X, e.Y);

			// Handle selection of hues

			if (!(ShiftPressed() || ControlPressed()))
			{
				if ((SelectedHues.Count == 1) && SelectedHues.Contains(SelectedColor))
				{
					SelectedHues.Clear();
					DrawSelectionChart();
					return;
				}
				// No modifier keys pressed. Clear selection and add current item
				SelectedHues.Clear();
				SelectedHues.Add(SelectedColor);
				PreviousSelectedColor = SelectedColor;
				DrawSelectionChart();
				return;
			}

			if (SelectedHues.Contains(SelectedColor))
			{
				// Clicking the same just deselects it
				_ = SelectedHues.Remove(SelectedColor);

				if (ShiftPressed())
				{
					// Go down
					if (SelectedHues.Contains(SelectedColor + 1))
					{
						for (var i = SelectedColor + 1; i <= PreviousSelectedColor; i++)
						{
							if (SelectedHues.Contains(i))
							{
								_ = SelectedHues.Remove(i);
							}
							else
							{
								break;
							}
						}
					}
				}
				PreviousSelectedColor = SelectedColor - 1;
				DrawSelectionChart();
				return;
			}

			if (ControlPressed())
			{
				// Add a single item to the list
				SelectedHues.Add(SelectedColor);
				PreviousSelectedColor = SelectedColor;
				DrawSelectionChart();
				return;
			}

			if (ShiftPressed())
			{
				// Add a selection of items
				if (PreviousSelectedColor < SelectedColor)
				{
					// Moving backwards
					for (var i = SelectedColor; i > PreviousSelectedColor; i--)
					{
						if (!SelectedHues.Contains(i))
						{
							SelectedHues.Add(i);
						}
					}
				}
				if (PreviousSelectedColor > SelectedColor)
				{
					// Moving forward
					for (var i = SelectedColor; i < PreviousSelectedColor; i++)
					{
						if (!SelectedHues.Contains(i)) // Avoid duplicates
						{
							SelectedHues.Add(i);
						}
					}
				}

				PreviousSelectedColor = SelectedColor;
				DrawSelectionChart();
			}
		}

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private Bitmap DrawSelection(Bitmap oldImg, List<int> list, Color color)
		// Issue 10 - End
		{
			TempBmp = (Bitmap)oldImg.Clone();

			// Performe garbage collection once every 5 steps
			if (GCSteps == 5)
			{
				GC.Collect();
				GCSteps = 0;
			}
			else
			{
				GCSteps++;
			}

			// Sort the selected hues
			list.Sort();

			var Range = false;
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			var First = list[0];
			// Issue 10 - End
			var Last = First;

			foreach (var s in list)
			{
				if (First == s)
				{
					continue;
				}

				if (s == (Last + 1))
				{
					Range = true;
					Last = s;
					continue;
				}

				if (Range)
				{
					DrawSelectionBox(TempBmp, First - 1, Last - 1, color);
				}
				else
				{
					DrawSelectionBox(TempBmp, First - 1, color);
				}

				Range = false;
				First = s;
				Last = s;
			}

			if (Range)
			{
				DrawSelectionBox(TempBmp, First - 1, (short)(Last - 1), color);
			}
			else
			{
				DrawSelectionBox(TempBmp, First - 1, color);
			}

			return TempBmp;
		}

		private void DrawSelectionBox(Bitmap img, int first, int last, Color color)
		{
			var c1 = first / 60;
			var c2 = last / 60;
			var r1 = first % 60;
			var r2 = last % 60;

			if (c2 == c1)
			{
				// Draw a long box
				var x = c1 * 9;
				var y1 = r1 * 5;
				var y2 = (r2 * 5) + 4;

				for (var i = 0; i < 8; i++)
				{
					img.SetPixel(x + i, y1, color);
					img.SetPixel(x + i, y2, color);
				}

				for (var i = y1; i <= y2; i++)
				{
					img.SetPixel(x, i, color);
					img.SetPixel(x + 8, i, color);
				}
			}

			if (c2 > c1)
			{
				// Get the two points first
				var x1 = c1 * 9;
				var x2 = c2 * 9;
				var y1 = r1 * 5;
				var y2 = r2 * 5;

				var TopX1 = x1 + 9; // Can't be invalid
				var TopX2 = x2 + 8;

				// Draw the top segment
				for (var i = TopX1; i <= TopX2; i++)
				{
					img.SetPixel(i, 0, color);
				}

				var BottomX1 = x1;
				var BottomX2 = x2 - 1; // Can't be invalid

				// Draw the bottom segment
				for (var i = BottomX1; i <= BottomX2; i++)
				{
					img.SetPixel(i, 299, color);
				}

				// Draw left horizontal segment, height: y1
				for (var i = BottomX1; i <= TopX1; i++)
				{
					if ((c2 == (c1 + 1)) && (i == TopX1))
					{
						break;
					}

					img.SetPixel(i, y1, color);
				}

				// Draw right horizontal segment, height: y2 + 5;
				y2 += 4;
				for (var i = BottomX2; i <= TopX2; i++)
				{
					if ((c2 == (c1 + 1)) && (i == BottomX2))
					{
						continue;
					}

					img.SetPixel(i, y2, color);
				}

				// Draw left segment
				for (var i = y1; i <= 299; i++)
				{
					img.SetPixel(BottomX1, i, color);
				}

				int my;
				if (c2 == (c1 + 1))
				{
					my = Math.Min(y1, y2);
				}
				else
				{
					my = y1;
				}

				// Draw top left segment
				for (var i = 0; i <= my; i++)
				{
					img.SetPixel(TopX1, i, color);
				}

				// Draw right segment
				for (var i = 0; i <= y2; i++)
				{
					img.SetPixel(TopX2, i, color);
				}

				if (c2 == (c1 + 1))
				{
					my = Math.Max(y1, y2);
				}
				else
				{
					my = y2;
				}

				// Draw bottom right segment
				for (var i = my; i <= 299; i++)
				{
					img.SetPixel(BottomX2, i, color);
				}
			}
		}

		private void DrawSelectionBox(Bitmap img, int index, Color color)
		{
			// Draw a single box around a single hue
			// Calculate the row and column (zero based)
			var column = index / 60;
			var row = index % 60;

			// Find the top left corner of the box
			var x = column * 9;
			var y = row * 5;

			// Draw the box
			for (var iX = 0; iX < 9; iX++)
			{
				img.SetPixel(x + iX, y, color);
				img.SetPixel(x + iX, y + 5 - 1, color);
			}
			for (var iY = 0; iY < 5; iY++)
			{
				img.SetPixel(x, y + iY, color);
				img.SetPixel(x + 9 - 1, y + iY, color);
			}
		}

		private int GetGroupNumber(int index)
		{
			return (index - 1) / 8;
		}

		private int GetEntryNumber(int index)
		{
			return (index - 1) % 8;
		}

		private Hue GetHue(int index)
		{
			return m_Hues[index];
		}

		private bool ShiftPressed()
		{
			var shift = GetKeyState(VK_SHIFT);
			if (shift < -100)
			{
				return true;
			}

			return false;
		}

		private bool ControlPressed()
		{
			var control = GetKeyState(VK_CONTROL);
			if (control < -100)
			{
				return true;
			}

			return false;
		}

		private bool AltPressed()
		{
			var alt = GetKeyState(VK_MENU);
			if (alt < -100)
			{
				return true;
			}

			return false;
		}

		private Hue m_Hue;

		private void PreviewHue(int x, int y)
		{
			var hue = m_Hues[GetHueIndex(x, y)];

			if (hue != m_Hue)
			{
				m_Hue = hue;

				labName.Text = hue.Name;

				imgHue.Image = hue.GetSpectrum(imgHue.Size);

				GCSteps++;

				if (GCSteps == 10)
				{
					GCSteps = 0;
					GC.Collect();
				}
			}
		}

		private void TheImage_MouseMove(object sender, MouseEventArgs e)
		{
			PreviewHue(e.X, e.Y);

			if (e.Button == MouseButtons.Left)
			{
				// If Alt is pressed, don't select
				if (AltPressed())
				{
					return;
				}

				// Get the hue index ( zero based )
				var column = e.X / 9;
				var row = e.Y / 5;
				var selHue = (column * 60) + row + 1;

				if ((column >= 0) && (column <= 49) && (row >= 0) && (row <= 59))
				{
					if (!SelectedHues.Contains(selHue))
					{
						SelectedHues.Add(selHue);
						PreviousSelectedColor = selHue;
						DrawSelectionChart();
					}
				}
			}
		}

		public void ClearSelection()
		{
			SelectedHues.Clear();
			SelectionChart = (Bitmap)Chart.Clone();
			TheImage.Image = Chart;
		}

		private void UpdateDisplay()
		{
			DrawHues();
			SelectionChart = (Bitmap)Chart.Clone();
			DrawSelectionChart();
		}

		private void txNew_TextChanged(object sender, EventArgs e)
		{
			bNew.Enabled = txNew.Text.Length > 0;
		}

		private void bNew_Click(object sender, EventArgs e)
		{
			var c = new HuesCollection
			{
				Name = txNew.Text
			};
			txNew.Text = "";

			c.Hues.Add(1);

			m_Groups.Groups.Add(c);

			_ = cmbGroups.Items.Add(c);
			cmbGroups.SelectedItem = c;
		}

		private void bUpdate_Click(object sender, EventArgs e)
		{
			m_SelectedGroup.Hues.Clear();
			m_SelectedGroup.Hues.AddRange(SelectedHues);
		}

		private void cmbGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedGroup = cmbGroups.SelectedItem as HuesCollection;
		}

		private void HueSelector_Closing(object sender, CancelEventArgs e)
		{
			m_Groups.Save();
		}

		private void HueSelector_Load(object sender, EventArgs e)
		{
			m_Groups = HueGroups.Load();

			foreach (var c in m_Groups.Groups)
			{
				_ = cmbGroups.Items.Add(c);
			}

			if (cmbGroups.Items.Count > 0)
			{
				cmbGroups.SelectedIndex = 0;
			}
		}

		private void bDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "", Pandora.Localization.TextProvider["HuePicker.DeleteGroup"], MessageBoxButtons.YesNo) ==
				DialogResult.Yes)
			{
				_ = m_Groups.Groups.Remove(m_SelectedGroup);

				var index = cmbGroups.Items.IndexOf(m_SelectedGroup);

				cmbGroups.Items.Remove(m_SelectedGroup);

				if (index < cmbGroups.Items.Count)
				{
					cmbGroups.SelectedIndex = index;
				}
				else if (--index >= 0 && cmbGroups.Items.Count > 0)
				{
					cmbGroups.SelectedIndex = index;
				}
			}
		}
	}
}