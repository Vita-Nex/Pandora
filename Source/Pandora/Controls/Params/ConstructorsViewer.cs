#region Header
// /*
//  *    2018 - Pandora - ConstructorsViewer.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Data;
using TheBox.Pages;
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Summary description for ConstructorsViewer.
	/// </summary>
	public class ConstructorsViewer : UserControl
	{
		private CheckBox chkUse;
		private LinkLabel lnk1;
		private LinkLabel lnk2;
		private LinkLabel lnk3;
		private LinkLabel lnk4;
		private Label labNoCtors;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private IParam m_Param1;
		private IParam m_Param2;
		private ConstructorDef m_CurrentCtor;

		public ConstructorsViewer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		private BoxItem m_Item;
		private bool m_SetUp;

		/// <summary>
		///     Sets the item currently selected
		/// </summary>
		public BoxItem Item
		{
			set
			{
				m_SetUp = true;

				m_Item = value;
				CleanUp();

				if (m_Item == null)
				{
					chkUse.Enabled = false;
					labNoCtors.Visible = false;

					lnk1.Visible = false;
					lnk2.Visible = false;
					lnk3.Visible = false;
					lnk4.Visible = false;

					m_SetUp = false;

					return;
				}

				if (m_Item.AdditionalCtors != null && m_Item.AdditionalCtors.Count > 0)
				{
					// We have other constructors
					chkUse.Enabled = true;
					chkUse.Checked = Pandora.Profile.Items.UseOptions;
					labNoCtors.Visible = false;

					if (m_Item.EmptyCtor)
					{
						chkUse.Checked = Pandora.Profile.Items.UseOptions;
					}
					else
					{
						chkUse.Checked = true;
						chkUse.Enabled = false;
					}

					lnk1.Visible = true;
					lnk2.Visible = m_Item.AdditionalCtors.Count > 1;
					lnk3.Visible = m_Item.AdditionalCtors.Count > 2;
					lnk4.Visible = m_Item.AdditionalCtors.Count > 3;

					ViewConstructor(0);
				}
				else
				{
					chkUse.Enabled = false;
					labNoCtors.Visible = true;

					lnk1.Visible = false;
					lnk2.Visible = false;
					lnk3.Visible = false;
					lnk4.Visible = false;
				}

				m_SetUp = false;
			}
		}

		/// <summary>
		///     Gets the parameters specified by the constructor
		/// </summary>
		public string Parameters
		{
			get
			{
				string pms = null;

				if (chkUse.Checked)
				{
					if (m_Param1 != null && m_Param2 != null)
					{
						pms = String.Format("{0} {1}", m_Param1.Value, m_Param2.Value);
					}
					else if (m_Param1 != null)
					{
						pms = m_Param1.Value;
					}
				}

				return pms;
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

		#region Component Designer generated code
		/// <summary>
		///     Required method for Designer support - do not modify
		///     the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chkUse = new System.Windows.Forms.CheckBox();
			this.lnk1 = new System.Windows.Forms.LinkLabel();
			this.lnk2 = new System.Windows.Forms.LinkLabel();
			this.lnk3 = new System.Windows.Forms.LinkLabel();
			this.lnk4 = new System.Windows.Forms.LinkLabel();
			this.labNoCtors = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkUse
			// 
			this.chkUse.Enabled = false;
			this.chkUse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkUse.Location = new System.Drawing.Point(4, 4);
			this.chkUse.Name = "chkUse";
			this.chkUse.Size = new System.Drawing.Size(104, 16);
			this.chkUse.TabIndex = 0;
			this.chkUse.Text = "Common.Options";
			this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
			// 
			// lnk1
			// 
			this.lnk1.Location = new System.Drawing.Point(108, 4);
			this.lnk1.Name = "lnk1";
			this.lnk1.Size = new System.Drawing.Size(24, 16);
			this.lnk1.TabIndex = 1;
			this.lnk1.TabStop = true;
			this.lnk1.Text = "1";
			this.lnk1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnk1.Visible = false;
			this.lnk1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk1_LinkClicked);
			// 
			// lnk2
			// 
			this.lnk2.Location = new System.Drawing.Point(132, 4);
			this.lnk2.Name = "lnk2";
			this.lnk2.Size = new System.Drawing.Size(24, 16);
			this.lnk2.TabIndex = 2;
			this.lnk2.TabStop = true;
			this.lnk2.Text = "2";
			this.lnk2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnk2.Visible = false;
			this.lnk2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk2_LinkClicked);
			// 
			// lnk3
			// 
			this.lnk3.Location = new System.Drawing.Point(156, 4);
			this.lnk3.Name = "lnk3";
			this.lnk3.Size = new System.Drawing.Size(24, 16);
			this.lnk3.TabIndex = 3;
			this.lnk3.TabStop = true;
			this.lnk3.Text = "3";
			this.lnk3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnk3.Visible = false;
			this.lnk3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk3_LinkClicked);
			// 
			// lnk4
			// 
			this.lnk4.Location = new System.Drawing.Point(180, 4);
			this.lnk4.Name = "lnk4";
			this.lnk4.Size = new System.Drawing.Size(24, 16);
			this.lnk4.TabIndex = 4;
			this.lnk4.TabStop = true;
			this.lnk4.Text = "4";
			this.lnk4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lnk4.Visible = false;
			this.lnk4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk4_LinkClicked);
			// 
			// labNoCtors
			// 
			this.labNoCtors.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labNoCtors.Location = new System.Drawing.Point(4, 28);
			this.labNoCtors.Name = "labNoCtors";
			this.labNoCtors.Size = new System.Drawing.Size(196, 23);
			this.labNoCtors.TabIndex = 5;
			this.labNoCtors.Text = "Items.NoCtor";
			this.labNoCtors.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.labNoCtors.Visible = false;
			// 
			// ConstructorsViewer
			// 
			this.Controls.Add(this.labNoCtors);
			this.Controls.Add(this.lnk4);
			this.Controls.Add(this.lnk3);
			this.Controls.Add(this.lnk2);
			this.Controls.Add(this.lnk1);
			this.Controls.Add(this.chkUse);
			this.Name = "ConstructorsViewer";
			this.Size = new System.Drawing.Size(204, 60);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConstructorsViewer_Paint);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Draw the border when the control is painting
		/// </summary>
		private void ConstructorsViewer_Paint(object sender, PaintEventArgs e)
		{
			// Paint the border
			var pen = new Pen(SystemColors.ControlDark);
			e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			pen.Dispose();
		}

		/// <summary>
		///     Removes the controls for the current parameters
		/// </summary>
		private void CleanUp()
		{
			if (m_Param1 != null)
			{
				(m_Param1 as Control).Visible = false;
				Controls.Remove(m_Param1 as UserControl);
				(m_Param1 as UserControl).Dispose();
				m_Param1 = null;
			}

			if (m_Param2 != null)
			{
				(m_Param2 as Control).Visible = false;
				Controls.Remove(m_Param2 as UserControl);
				(m_Param2 as UserControl).Dispose();
				m_Param2 = null;
			}
		}

		/// <summary>
		///     Creates a control for a parameter
		/// </summary>
		/// <param name="param">The type of the parameter that will be displayed</param>
		/// <param name="location">The location at which the control should be added</param>
		/// <returns>An IParam object that's been added to the control</returns>
		private IParam AddParam(ParamDef param, Point location)
		{
			UserControl c = null;

			switch (param.ParamType)
			{
				case BoxPropType.Boolean:

					c = new BoolParam();
					break;

				case BoxPropType.DateTime:

					c = new DateTimeParam();
					break;

				case BoxPropType.Enumeration:

					c = new EnumParam();
					(c as EnumParam).EnumValues = param.EnumValues;
					(c as EnumParam).EnumValueChanged += ConstructorsViewer_EnumValueChanged;
					break;

				case BoxPropType.Map:

					c = new MapParam();
					break;

				case BoxPropType.Numeric:

					c = new NumericParam();
					break;

				case BoxPropType.Other:

					c = new TextParam();
					(c as TextParam).IsOther = true;
					break;

				case BoxPropType.Point3D:

					c = new Point3DParam();
					break;

				case BoxPropType.Text:

					c = new TextParam();
					break;

				case BoxPropType.TimeSpan:

					c = new TimeSpanParam();
					break;
			}

			(c as IParam).ParamName = param.Name;
			c.Location = location;
			Controls.Add(c);

			return c as IParam;
		}

		/// <summary>
		///     Views one of the constructors defined on the item
		/// </summary>
		/// <param name="index"></param>
		private void ViewConstructor(int index)
		{
			m_CurrentCtor = m_Item.AdditionalCtors[index] as ConstructorDef;

			m_Param1 = AddParam(m_CurrentCtor.Param1, new Point(4, 20));

			if (m_CurrentCtor.Param2 != null)
			{
				m_Param2 = AddParam(m_CurrentCtor.Param2, new Point(104, 20));
			}
		}

		/// <summary>
		///     An enumeration value has changed
		/// </summary>
		private void ConstructorsViewer_EnumValueChanged(object sender, EventArgs e)
		{
			if ((sender as IParam) == m_Param1)
			{
				var index = m_CurrentCtor.Param1.EnumValues.IndexOf(m_Param1.Value);

				var def = m_CurrentCtor.List1[index] as ItemDef;

				Items.ArtHue = def.Hue;
				Items.ArtIndex = def.Art;
			}

			if ((sender as IParam) == m_Param2)
			{
				var index = m_CurrentCtor.Param2.EnumValues.IndexOf(m_Param2.Value);

				var def = m_CurrentCtor.List2[index] as ItemDef;

				Items.ArtHue = def.Hue;
				Items.ArtIndex = def.Art;
			}
		}

		private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CleanUp();
			ViewConstructor(0);
		}

		private void lnk2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CleanUp();
			ViewConstructor(1);
		}

		private void lnk3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CleanUp();
			ViewConstructor(2);
		}

		private void lnk4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CleanUp();
			ViewConstructor(3);
		}

		private void chkUse_CheckedChanged(object sender, EventArgs e)
		{
			if (!m_SetUp)
			{
				Pandora.Profile.Items.UseOptions = chkUse.Checked;
			}
		}

		/// <summary>
		///     Specifies if the control allows to change the displayed ItemID
		/// </summary>
		public bool AllowItemIDChange
		{
			get
			{
				if (m_CurrentCtor == null)
				{
					return false;
				}

				if (m_CurrentCtor.Param1 != null && m_CurrentCtor.Param1.Name.ToLower() == "itemid")
				{
					if (m_Param1 != null)
					{
						return true;
					}
				}

				if (m_CurrentCtor.Param2 != null && m_CurrentCtor.Param2.Name.ToLower() == "itemid")
				{
					if (m_Param2 != null)
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		///     States whether the control can change the hue of the displayed item
		/// </summary>
		public bool AllowHueChange
		{
			get
			{
				if (m_CurrentCtor.Param1 != null && m_CurrentCtor.Param1.Name.ToLower() == "hue")
				{
					if (m_Param1 != null && (m_Param1 as Control).Visible)
					{
						return true;
					}
				}

				if (m_CurrentCtor.Param2 != null && m_CurrentCtor.Param2.Name.ToLower() == "hue")
				{
					if (m_Param2 != null && (m_Param2 as Control).Visible)
					{
						return true;
					}
				}

				return false;
			}
		}
	}
}