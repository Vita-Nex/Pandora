#region Header
// /*
//  *    2018 - Pandora - FilterBuilder.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Common;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for FilterBuilder.
	/// </summary>
	public class FilterBuilder : Form
	{
		private Label label1;
		private ComboBox cmbType;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private CheckBox chkNot;
		private ComboBox cmbProp;
		private ComboBox cmbOp;
		private ComboBox cmbValue;
		private Button bAdd;
		private CheckBox chkPresets;
		private Button bOk;
		private Button bCancel;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private Label label6;
		private ListBox lst;
		private Button bDel;
		private Label labOutput;

		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private readonly List<string> m_Conditions;

		// Issue 10 - End
		private Button bCheck;

		public FilterBuilder()
		{
			InitializeComponent();

			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Conditions = new List<string>();
			// Issue 10 - End

			Pandora.Localization.LocalizeControl(this);
			Pandora.ToolTip.SetToolTip(cmbOp, Pandora.Localization.TextProvider["Tips.Operators"]);
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
			var resources = new System.Resources.ResourceManager(typeof(FilterBuilder));
			this.label1 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.chkNot = new System.Windows.Forms.CheckBox();
			this.cmbProp = new System.Windows.Forms.ComboBox();
			this.cmbOp = new System.Windows.Forms.ComboBox();
			this.cmbValue = new System.Windows.Forms.ComboBox();
			this.bAdd = new System.Windows.Forms.Button();
			this.chkPresets = new System.Windows.Forms.CheckBox();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.lst = new System.Windows.Forms.ListBox();
			this.bDel = new System.Windows.Forms.Button();
			this.labOutput = new System.Windows.Forms.Label();
			this.bCheck = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0);
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Common.Type";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// cmbType
			// 
			this.cmbType.AllowDrop = true;
			this.cmbType.Location = new System.Drawing.Point(76, 16);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(176, 21);
			this.cmbType.TabIndex = 1;
			this.cmbType.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbType_DragDrop);
			this.cmbType.TextChanged += new System.EventHandler(this.cmbType_TextChanged);
			this.cmbType.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbType_DragEnter);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Underline,
				System.Drawing.GraphicsUnit.Point,
				0);
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(248, 128);
			this.label2.TabIndex = 3;
			this.label2.Text = ".";
			this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Props.Property";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Props.Op";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Common.Value";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkNot
			// 
			this.chkNot.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkNot.Location = new System.Drawing.Point(76, 88);
			this.chkNot.Name = "chkNot";
			this.chkNot.Size = new System.Drawing.Size(48, 24);
			this.chkNot.TabIndex = 7;
			this.chkNot.Text = "Common.Not";
			// 
			// cmbProp
			// 
			this.cmbProp.AllowDrop = true;
			this.cmbProp.Location = new System.Drawing.Point(120, 64);
			this.cmbProp.Name = "cmbProp";
			this.cmbProp.Size = new System.Drawing.Size(132, 21);
			this.cmbProp.TabIndex = 8;
			this.cmbProp.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbType_DragDrop);
			this.cmbProp.TextChanged += new System.EventHandler(this.cmbProp_TextChanged);
			this.cmbProp.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbType_DragEnter);
			// 
			// cmbOp
			// 
			this.cmbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOp.Items.AddRange(
				new object[]
					{"==", "!=", ">", "<", ">=", "<=", "==~", "starts", "starts~", "ends", "ends~", "contains", "contains~"});
			this.cmbOp.Location = new System.Drawing.Point(120, 88);
			this.cmbOp.Name = "cmbOp";
			this.cmbOp.Size = new System.Drawing.Size(132, 21);
			this.cmbOp.TabIndex = 9;
			// 
			// cmbValue
			// 
			this.cmbValue.AllowDrop = true;
			this.cmbValue.Location = new System.Drawing.Point(120, 112);
			this.cmbValue.Name = "cmbValue";
			this.cmbValue.Size = new System.Drawing.Size(132, 21);
			this.cmbValue.TabIndex = 10;
			this.cmbValue.DragDrop += new System.Windows.Forms.DragEventHandler(this.cmbType_DragDrop);
			this.cmbValue.TextChanged += new System.EventHandler(this.cmbValue_TextChanged);
			this.cmbValue.DragEnter += new System.Windows.Forms.DragEventHandler(this.cmbType_DragEnter);
			// 
			// bAdd
			// 
			this.bAdd.Enabled = false;
			this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAdd.Location = new System.Drawing.Point(96, 140);
			this.bAdd.Name = "bAdd";
			this.bAdd.TabIndex = 11;
			this.bAdd.Text = "Common.Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// chkPresets
			// 
			this.chkPresets.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkPresets.Location = new System.Drawing.Point(12, 272);
			this.chkPresets.Name = "chkPresets";
			this.chkPresets.Size = new System.Drawing.Size(248, 20);
			this.chkPresets.TabIndex = 12;
			this.chkPresets.Text = "Props.AddPreset";
			// 
			// bOk
			// 
			this.bOk.Enabled = false;
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(184, 296);
			this.bOk.Name = "bOk";
			this.bOk.TabIndex = 13;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(104, 296);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 14;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(264, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(184, 284);
			this.label6.TabIndex = 15;
			this.label6.Text = "Props.Cond";
			this.label6.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// lst
			// 
			this.lst.Location = new System.Drawing.Point(268, 24);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(176, 225);
			this.lst.TabIndex = 16;
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			// 
			// bDel
			// 
			this.bDel.Enabled = false;
			this.bDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDel.Location = new System.Drawing.Point(320, 260);
			this.bDel.Name = "bDel";
			this.bDel.TabIndex = 17;
			this.bDel.Text = "Common.Delete";
			this.bDel.Click += new System.EventHandler(this.bDel_Click);
			// 
			// labOutput
			// 
			this.labOutput.Location = new System.Drawing.Point(12, 176);
			this.labOutput.Name = "labOutput";
			this.labOutput.Size = new System.Drawing.Size(248, 92);
			this.labOutput.TabIndex = 18;
			this.labOutput.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
			// 
			// bCheck
			// 
			this.bCheck.Enabled = false;
			this.bCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCheck.Location = new System.Drawing.Point(272, 296);
			this.bCheck.Name = "bCheck";
			this.bCheck.Size = new System.Drawing.Size(172, 23);
			this.bCheck.TabIndex = 19;
			this.bCheck.Text = "Props.Check";
			this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
			// 
			// FilterBuilder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(450, 325);
			this.ControlBox = false;
			this.Controls.Add(this.bCheck);
			this.Controls.Add(this.labOutput);
			this.Controls.Add(this.bDel);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.chkPresets);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.cmbValue);
			this.Controls.Add(this.cmbOp);
			this.Controls.Add(this.cmbProp);
			this.Controls.Add(this.chkNot);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.Name = "FilterBuilder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Props.FB";
			this.Load += new System.EventHandler(this.FilterBuilder_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void label1_Paint(object sender, PaintEventArgs e)
		{
			Utility.DrawBorder(sender as Control, e.Graphics);
		}

		private void FilterBuilder_Load(object sender, EventArgs e)
		{
			cmbOp.SelectedIndex = 0;
			UpdateTypes();
			UpdateProps();
		}

		private void UpdateTypes()
		{
			string type = null;

			if (cmbType.Text.Length > 0)
			{
				type = cmbType.Text;
			}

			if (type != null)
			{
				Pandora.Profile.Props.FBTypes.AddString(type);
			}

			cmbType.BeginUpdate();
			cmbType.Items.Clear();
			cmbType.Items.AddRange(Pandora.Profile.Props.FBTypes.GetArray());
			cmbType.EndUpdate();
		}

		private void UpdateProps()
		{
			if (cmbProp.Text.Length > 0)
			{
				Pandora.Profile.Props.FBProps.AddString(cmbProp.Text);
			}

			if (cmbValue.Text.Length > 0)
			{
				Pandora.Profile.Props.FBValues.AddString(cmbValue.Text);
			}

			cmbProp.BeginUpdate();
			cmbValue.BeginUpdate();

			cmbProp.Items.Clear();
			cmbValue.Items.Clear();

			cmbProp.Items.AddRange(Pandora.Profile.Props.FBProps.GetArray());
			cmbValue.Items.AddRange(Pandora.Profile.Props.FBValues.GetArray());

			cmbProp.EndUpdate();
			cmbValue.EndUpdate();

			cmbProp.Text = "";
			cmbValue.Text = "";
		}

		private void UpdateOutput()
		{
			bOk.Enabled = cmbType.Text.Length > 0;
			bCheck.Enabled = cmbType.Text.Length > 0;

			if (cmbType.Text.Length == 0)
			{
				labOutput.Text = Pandora.Localization.TextProvider["Props.NoType"];
				return;
			}

			Filter = "where " + cmbType.Text;

			foreach (var s in m_Conditions)
			{
				Filter += " " + s;
			}

			labOutput.Text = Filter;
		}

		private void cmbType_TextChanged(object sender, EventArgs e)
		{
			UpdateOutput();
		}

		private void EnableProps()
		{
			bAdd.Enabled = cmbProp.Text.Length > 0 && cmbValue.Text.Length > 0;
		}

		private void bAdd_Click(object sender, EventArgs e)
		{
			var cond = String.Format("{0}{1}{2}", cmbProp.Text, cmbOp.Text, cmbValue.Text);

			_ = MessageBox.Show(cond);

			if (chkNot.Checked)
			{
				cond = "Not " + cond;
			}

			m_Conditions.Add(cond);

			UpdateProps();
			UpdateConditions();
		}

		private void UpdateConditions()
		{
			lst.Items.Clear();

			foreach (var s in m_Conditions)
			{
				_ = lst.Items.Add(s);
			}

			UpdateOutput();
		}

		private void cmbProp_TextChanged(object sender, EventArgs e)
		{
			EnableProps();
		}

		private void cmbValue_TextChanged(object sender, EventArgs e)
		{
			EnableProps();
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			bDel.Enabled = lst.SelectedIndex > -1;
		}

		private void bDel_Click(object sender, EventArgs e)
		{
			var index = lst.SelectedIndex;

			if (index > -1)
			{
				m_Conditions.RemoveAt(index);
				UpdateConditions();
			}
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			UpdateTypes();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cmbType_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetData(DataFormats.Text) != null)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void cmbType_DragDrop(object sender, DragEventArgs e)
		{
			var text = (string)e.Data.GetData(DataFormats.Text);

			if (text != null && text.Length > 0)
			{
				(sender as Control).Text = text;
			}
		}

		private void bCheck_Click(object sender, EventArgs e)
		{
			Pandora.SendToUO("Condition " + Filter, true);
		}

		/// <summary>
		///     Gets the filter string
		/// </summary>
		public string Filter { get; private set; }

		/// <summary>
		///     States whether the edited filter should be added to the presets
		/// </summary>
		public bool AddToPresets => chkPresets.Checked;
	}
}