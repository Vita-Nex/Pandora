#region Header
// /*
//  *    2018 - Pandora - HuePicker.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.ArtViewer;
using TheBox.Common;
using TheBox.Controls;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for HuePicker.
	/// </summary>
	public class HuePicker : Form
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private HuesChart Chart;
		private NumericUpDown numIndex;
		private Label labName;
		private ArtViewer.ArtViewer Art;
		private PictureBox imgSpectrum;
		private TrackBar barDarkness;
		private ComboBox comboType;
		private NumericUpDown numID;
		private CheckBox chkScale;
		private CheckBox chkRoom;
		private CheckBox chkAnimate;
		private Button bCancel;
		private LinkLabel lnkZero;
		private Button bSelect;
		private Button bSet;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public HuePicker()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			try
			{
				Pandora.Localization.LocalizeControl(this);
			}
			catch (Exception)
			{
				// For designer
			}
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
			var resources = new System.Resources.ResourceManager(typeof(HuePicker));
			this.Chart = new TheBox.Controls.HuesChart();
			this.label1 = new System.Windows.Forms.Label();
			this.numIndex = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.labName = new System.Windows.Forms.Label();
			this.Art = new TheBox.ArtViewer.ArtViewer();
			this.imgSpectrum = new System.Windows.Forms.PictureBox();
			this.barDarkness = new System.Windows.Forms.TrackBar();
			this.comboType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.numID = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.chkScale = new System.Windows.Forms.CheckBox();
			this.chkRoom = new System.Windows.Forms.CheckBox();
			this.chkAnimate = new System.Windows.Forms.CheckBox();
			this.bCancel = new System.Windows.Forms.Button();
			this.lnkZero = new System.Windows.Forms.LinkLabel();
			this.bSelect = new System.Windows.Forms.Button();
			this.bSet = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.numIndex).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.barDarkness).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numID).BeginInit();
			this.SuspendLayout();
			// 
			// Chart
			// 
			this.Chart.ColorTableIndex = 28;
			this.Chart.Location = new System.Drawing.Point(8, 64);
			this.Chart.Name = "Chart";
			this.Chart.SelectedIndex = 1;
			this.Chart.Size = new System.Drawing.Size(452, 302);
			this.Chart.TabIndex = 0;
			this.Chart.Text = "huesChart1";
			this.Chart.Click += new System.EventHandler(this.Chart_Click);
			this.Chart.HueChanged += new System.EventHandler(this.Chart_HueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(376, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Common.Index";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// numIndex
			// 
			this.numIndex.Location = new System.Drawing.Point(408, 40);
			this.numIndex.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
			this.numIndex.Name = "numIndex";
			this.numIndex.Size = new System.Drawing.Size(56, 20);
			this.numIndex.TabIndex = 2;
			this.numIndex.ValueChanged += new System.EventHandler(this.numIndex_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Common.Name";
			// 
			// labName
			// 
			this.labName.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Underline,
				System.Drawing.GraphicsUnit.Point,
				0);
			this.labName.Location = new System.Drawing.Point(48, 8);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(176, 23);
			this.labName.TabIndex = 4;
			// 
			// Art
			// 
			this.Art.Animate = false;
			this.Art.Art = TheBox.ArtViewer.Art.Items;
			this.Art.ArtIndex = 0;
			this.Art.BackColor = System.Drawing.Color.White;
			this.Art.Hue = 0;
			this.Art.Location = new System.Drawing.Point(472, 40);
			this.Art.Name = "Art";
			this.Art.ResizeTallItems = false;
			this.Art.RoomView = true;
			this.Art.ShowHexID = true;
			this.Art.ShowID = false;
			this.Art.Size = new System.Drawing.Size(152, 168);
			this.Art.TabIndex = 5;
			this.Art.Text = "artViewer1";
			// 
			// imgSpectrum
			// 
			this.imgSpectrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgSpectrum.Location = new System.Drawing.Point(8, 40);
			this.imgSpectrum.Name = "imgSpectrum";
			this.imgSpectrum.Size = new System.Drawing.Size(344, 16);
			this.imgSpectrum.TabIndex = 6;
			this.imgSpectrum.TabStop = false;
			// 
			// barDarkness
			// 
			this.barDarkness.Location = new System.Drawing.Point(472, 320);
			this.barDarkness.Maximum = 31;
			this.barDarkness.Name = "barDarkness";
			this.barDarkness.Size = new System.Drawing.Size(152, 45);
			this.barDarkness.TabIndex = 7;
			this.barDarkness.TabStop = false;
			this.barDarkness.TickStyle = System.Windows.Forms.TickStyle.None;
			this.barDarkness.Value = 28;
			this.barDarkness.Scroll += new System.EventHandler(this.barDarkness_Scroll);
			// 
			// comboType
			// 
			this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboType.Items.AddRange(new object[] { "Items", "NPCs", "Gumps" });
			this.comboType.Location = new System.Drawing.Point(520, 216);
			this.comboType.Name = "comboType";
			this.comboType.Size = new System.Drawing.Size(104, 21);
			this.comboType.TabIndex = 8;
			this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(472, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "Common.Type";
			// 
			// numID
			// 
			this.numID.Location = new System.Drawing.Point(520, 240);
			this.numID.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
			this.numID.Name = "numID";
			this.numID.Size = new System.Drawing.Size(64, 20);
			this.numID.TabIndex = 10;
			this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(472, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Common.ID";
			// 
			// chkScale
			// 
			this.chkScale.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkScale.Location = new System.Drawing.Point(472, 264);
			this.chkScale.Name = "chkScale";
			this.chkScale.Size = new System.Drawing.Size(64, 24);
			this.chkScale.TabIndex = 12;
			this.chkScale.Text = "HuePicker.Scale";
			this.chkScale.CheckedChanged += new System.EventHandler(this.chkScale_CheckedChanged);
			// 
			// chkRoom
			// 
			this.chkRoom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRoom.Location = new System.Drawing.Point(544, 264);
			this.chkRoom.Name = "chkRoom";
			this.chkRoom.Size = new System.Drawing.Size(80, 24);
			this.chkRoom.TabIndex = 13;
			this.chkRoom.Text = "HuePicker.RoomView";
			this.chkRoom.CheckedChanged += new System.EventHandler(this.chkRoom_CheckedChanged);
			// 
			// chkAnimate
			// 
			this.chkAnimate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkAnimate.Location = new System.Drawing.Point(472, 288);
			this.chkAnimate.Name = "chkAnimate";
			this.chkAnimate.TabIndex = 14;
			this.chkAnimate.Text = "HuePicker.Animate";
			this.chkAnimate.CheckedChanged += new System.EventHandler(this.chkAnimate_CheckedChanged);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(560, 8);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(64, 23);
			this.bCancel.TabIndex = 16;
			this.bCancel.Text = "Common.Close";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// lnkZero
			// 
			this.lnkZero.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkZero.Location = new System.Drawing.Point(360, 40);
			this.lnkZero.Name = "lnkZero";
			this.lnkZero.Size = new System.Drawing.Size(8, 16);
			this.lnkZero.TabIndex = 18;
			this.lnkZero.TabStop = true;
			this.lnkZero.Text = "0";
			this.lnkZero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkZero.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkZero_LinkClicked);
			// 
			// bSelect
			// 
			this.bSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSelect.Location = new System.Drawing.Point(400, 8);
			this.bSelect.Name = "bSelect";
			this.bSelect.Size = new System.Drawing.Size(64, 23);
			this.bSelect.TabIndex = 17;
			this.bSelect.Text = "Common.Select";
			this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
			// 
			// bSet
			// 
			this.bSet.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSet.Location = new System.Drawing.Point(472, 8);
			this.bSet.Name = "bSet";
			this.bSet.Size = new System.Drawing.Size(64, 23);
			this.bSet.TabIndex = 19;
			this.bSet.Text = "Common.Set";
			this.bSet.Click += new System.EventHandler(this.bSet_Click);
			// 
			// HuePicker
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(630, 367);
			this.Controls.Add(this.bSet);
			this.Controls.Add(this.lnkZero);
			this.Controls.Add(this.bSelect);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.chkAnimate);
			this.Controls.Add(this.chkRoom);
			this.Controls.Add(this.chkScale);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboType);
			this.Controls.Add(this.barDarkness);
			this.Controls.Add(this.imgSpectrum);
			this.Controls.Add(this.Art);
			this.Controls.Add(this.labName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numIndex);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Chart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.Name = "HuePicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HuePicker.Title";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.HuePicker_Closing);
			this.Load += new System.EventHandler(this.HuePicker_Load);
			((System.ComponentModel.ISupportInitialize)this.numIndex).EndInit();
			((System.ComponentModel.ISupportInitialize)this.barDarkness).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numID).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		private int m_SelectedHue;

		public int SelectedHue
		{
			get => m_SelectedHue;
			set
			{
				m_SelectedHue = value;

				if (m_SelectedHue < 0)
				{
					m_SelectedHue = 0;
				}

				if (m_SelectedHue > 3000)
				{
					m_SelectedHue = 3000;
				}

				Chart.SelectedIndex = m_SelectedHue;

				if (value == 0)
				{
					Art.Hue = 0;
				}
			}
		}

		private void HuePicker_Load(object sender, EventArgs e)
		{
			// Preview
			comboType.SelectedIndex = (int)Pandora.Profile.Hues.Art;
			chkRoom.Checked = Pandora.Profile.Hues.RoomView;
			chkScale.Checked = Pandora.Profile.Hues.Scale;
			chkAnimate.Checked = Pandora.Profile.Hues.Animate;
			numID.Value = Pandora.Profile.Hues.PreviewIndex;

			barDarkness.Value = Pandora.Profile.Hues.Darkness;
			Chart.ColorTableIndex = barDarkness.Value;

			SelectedHue = Pandora.Profile.Hues.SelectedIndex;

			if (SelectedHue == 0)
			{
				labName.Text = Pandora.Localization.TextProvider["Common.None"];
			}
		}

		private void Chart_HueChanged(object sender, EventArgs e)
		{
			// Spectrum
			imgSpectrum.Image = Chart.SelectedHue.GetSpectrum(imgSpectrum.Size);

			// Preview
			Art.Hue = Chart.SelectedIndex;

			numIndex.Value = Chart.SelectedIndex;
			labName.Text = Chart.SelectedHue.Name;
		}

		private void comboType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Art.Art = (Art)comboType.SelectedIndex;
			Pandora.Profile.Hues.Art = Art.Art;
		}

		private void numID_ValueChanged(object sender, EventArgs e)
		{
			Art.ArtIndex = (int)numID.Value;
			Pandora.Profile.Hues.PreviewIndex = Art.ArtIndex;
		}

		private void chkScale_CheckedChanged(object sender, EventArgs e)
		{
			Art.ResizeTallItems = chkScale.Checked;
			Pandora.Profile.Hues.Scale = chkScale.Checked;
		}

		private void chkRoom_CheckedChanged(object sender, EventArgs e)
		{
			Art.RoomView = chkRoom.Checked;
			Pandora.Profile.Hues.RoomView = chkRoom.Checked;
		}

		private void chkAnimate_CheckedChanged(object sender, EventArgs e)
		{
			Art.Animate = chkAnimate.Checked;
			Pandora.Profile.Hues.Animate = chkAnimate.Checked;
		}

		private void numIndex_ValueChanged(object sender, EventArgs e)
		{
			if (SelectedHue != (int)numIndex.Value)
			{
				SelectedHue = (int)numIndex.Value;
			}

			if (SelectedHue == 0)
			{
				imgSpectrum.Image = null;
				labName.Text = Pandora.Localization.TextProvider["Common.None"];
			}
		}

		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
					return false;
			}
			return base.IsInputKey(keyData);
		}

		private void barDarkness_Scroll(object sender, EventArgs e)
		{
			Chart.ColorTableIndex = barDarkness.Value;
			Pandora.Profile.Hues.Darkness = barDarkness.Value;
		}

		private void Chart_Click(object sender, EventArgs e)
		{
			_ = Chart.Focus();
		}

		private void bSelect_Click(object sender, EventArgs e)
		{
			Pandora.BoxForm.SelectedHue = m_SelectedHue;
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			Visible = false;
		}

		private void lnkZero_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			numIndex.Value = 0;
			// SelectedHue = 0;
		}

		private void HuePicker_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			Visible = false;
		}

		private void bSet_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoSet("hue", m_SelectedHue.ToString(), null);
		}
	}
}
