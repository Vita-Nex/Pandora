#region Header
// /*
//  *    2018 - Pandora - PropManager.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;

using TheBox.Forms;
using TheBox.Options;
#endregion

namespace TheBox.Controls
{
	/// <summary>
	///     Summary description for PropManager.
	/// </summary>
	public class PropManager : UserControl
	{
		private Label label1;
		private Label label2;
		private ComboBox cbProps;
		private ComboBox cbValue;
		private ComboBox cbType;
		private Button bGet;
		private Button bSet;
		private CheckBox chkType;
		private Button button1;
		private PictureBox imgFilter;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		private ContextMenu cmFilters;

		private FilterBuilder m_FilterForm;

		public PropManager()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			Pandora.Localization.LocalizeMenu(cmFilters);

			bSet.Tag = new CommandCallback(DoSet);
			bSet.ContextMenu = Pandora.cmModifiers;
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
			var resources = new System.Resources.ResourceManager(typeof(PropManager));
			this.label1 = new System.Windows.Forms.Label();
			this.cbProps = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbValue = new System.Windows.Forms.ComboBox();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.bGet = new System.Windows.Forms.Button();
			this.bSet = new System.Windows.Forms.Button();
			this.chkType = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.imgFilter = new System.Windows.Forms.PictureBox();
			this.cmFilters = new System.Windows.Forms.ContextMenu();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Props.Property";
			// 
			// cbProps
			// 
			this.cbProps.Location = new System.Drawing.Point(4, 20);
			this.cbProps.Name = "cbProps";
			this.cbProps.Size = new System.Drawing.Size(168, 21);
			this.cbProps.TabIndex = 1;
			this.cbProps.Enter += new System.EventHandler(this.cbProps_Enter);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Props.Value";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// cbValue
			// 
			this.cbValue.Location = new System.Drawing.Point(48, 44);
			this.cbValue.Name = "cbValue";
			this.cbValue.Size = new System.Drawing.Size(124, 21);
			this.cbValue.TabIndex = 3;
			this.cbValue.Enter += new System.EventHandler(this.cbValue_Enter);
			// 
			// cbType
			// 
			this.cbType.Location = new System.Drawing.Point(4, 88);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(168, 21);
			this.cbType.TabIndex = 5;
			this.cbType.Enter += new System.EventHandler(this.cbType_Enter);
			// 
			// bGet
			// 
			this.bGet.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bGet.Location = new System.Drawing.Point(52, 116);
			this.bGet.Name = "bGet";
			this.bGet.Size = new System.Drawing.Size(44, 24);
			this.bGet.TabIndex = 6;
			this.bGet.Text = "Props.Get";
			this.bGet.Click += new System.EventHandler(this.bGet_Click);
			// 
			// bSet
			// 
			this.bSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSet.Location = new System.Drawing.Point(104, 116);
			this.bSet.Name = "bSet";
			this.bSet.Size = new System.Drawing.Size(64, 24);
			this.bSet.TabIndex = 8;
			this.bSet.Text = "Props.Set";
			this.bSet.Click += new System.EventHandler(this.bSet_Click);
			// 
			// chkType
			// 
			this.chkType.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkType.Location = new System.Drawing.Point(4, 68);
			this.chkType.Name = "chkType";
			this.chkType.Size = new System.Drawing.Size(84, 20);
			this.chkType.TabIndex = 10;
			this.chkType.Text = "Props.Type";
			this.chkType.CheckedChanged += new System.EventHandler(this.chkType_CheckedChanged);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(4, 116);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(44, 24);
			this.button1.TabIndex = 11;
			this.button1.Text = "Common.Clear";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// imgFilter
			// 
			this.imgFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgFilter.Image = (System.Drawing.Image)resources.GetObject("imgFilter.Image");
			this.imgFilter.Location = new System.Drawing.Point(152, 68);
			this.imgFilter.Name = "imgFilter";
			this.imgFilter.Size = new System.Drawing.Size(20, 16);
			this.imgFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgFilter.TabIndex = 12;
			this.imgFilter.TabStop = false;
			this.imgFilter.Click += new System.EventHandler(this.imgFilter_Click);
			// 
			// PropManager
			// 
			this.Controls.Add(this.imgFilter);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chkType);
			this.Controls.Add(this.bSet);
			this.Controls.Add(this.bGet);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.cbValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbProps);
			this.Controls.Add(this.label1);
			this.Name = "PropManager";
			this.Size = new System.Drawing.Size(176, 144);
			this.Load += new System.EventHandler(this.PropManager_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private PropsOptions Options => Pandora.Profile.Props;

		#region Access Methods
		public void SetProperty(string prop, string value, string type)
		{
			if (prop == null)
			{
				return;
			}

			if (prop == "")
			{
				return;
			}

			// Set property first
			cbProps.Text = prop;
			UpdateProps(false);

			// Value
			if (value != null && value.Length > 0)
			{
				cbValue.Text = value;
				UpdateValues(false);
			}

			// Type
			if (type != null && type.Length > 0)
			{
				cbType.Text = type;
				UpdateValues(false);
			}
		}
		#endregion

		private void UpdateProps(bool clear)
		{
			if (cbProps.Text != "")
			{
				Options.RecentProps.AddString(cbProps.Text);
			}

			cbProps.BeginUpdate();

			cbProps.Items.Clear();

			cbProps.Items.AddRange(Options.RecentProps.GetArray());

			cbProps.EndUpdate();

			cbProps.SelectedIndex = -1;

			if (!clear && cbProps.Items.Count > 0)
			{
				cbProps.SelectedIndex = 0;
			}
		}

		private void UpdateValues(bool clear)
		{
			if (cbValue.Text != "")
			{
				Options.RecentValues.AddString(cbValue.Text);
			}

			cbValue.BeginUpdate();

			cbValue.Items.Clear();
			cbValue.Items.AddRange(Options.RecentValues.GetArray());
			cbValue.EndUpdate();

			cbValue.SelectedIndex = -1;

			if (!clear && cbValue.Items.Count > 0)
			{
				cbValue.SelectedIndex = 0;
			}
		}

		private void UpdateTypes(bool clear)
		{
			if (cbType.Text != "")
			{
				Options.RecentTypes.AddString(cbType.Text);
			}

			cbType.BeginUpdate();
			cbType.Items.Clear();
			cbType.Items.AddRange(Options.RecentTypes.GetArray());
			cbType.EndUpdate();

			cbType.SelectedIndex = -1;

			if (!clear && cbType.Items.Count > 0)
			{
				cbType.SelectedIndex = 0;
			}
		}

		private void bGet_Click(object sender, EventArgs e)
		{
			if (cbProps.Text.Length > 0)
			{
				// Valid prop
				Pandora.Profile.Commands.DoGet(cbProps.Text);
				UpdateProps(false);
			}
		}

		private void bSet_Click(object sender, EventArgs e)
		{
			DoSet(null);
		}

		private void DoSet(string modifier)
		{
			if (cbProps.Text.Length > 0 && cbValue.Text.Length > 0)
			{
				if (chkType.Checked && cbType.Text.Length > 0)
				{
					Pandora.Profile.Commands.DoSet(cbProps.Text, cbValue.Text, cbType.Text, modifier);
					UpdateTypes(false);
				}
				else
				{
					Pandora.Profile.Commands.DoSet(cbProps.Text, cbValue.Text, modifier);
				}

				UpdateProps(false);
				UpdateValues(false);
			}
		}

		private void cbProps_Enter(object sender, EventArgs e)
		{
			if (cbProps.Text.Length > 0)
			{
				cbProps.SelectAll();
			}
		}

		private void cbValue_Enter(object sender, EventArgs e)
		{
			if (cbValue.Text.Length > 0)
			{
				cbValue.SelectAll();
			}
		}

		private void cbType_Enter(object sender, EventArgs e)
		{
			if (cbType.Text.Length > 0)
			{
				cbType.SelectAll();
			}
		}

		private void PropManager_Load(object sender, EventArgs e)
		{
			try
			{
				//  Issue 27: Designer warnings - Tarion
				chkType.Checked = Options.UseType;
				// End Issue 27
				UpdateValues(false);
				UpdateProps(false);
				UpdateTypes(true);

				BuildPresets();
			}
			catch
			{ } // VS
		}

		private void chkType_CheckedChanged(object sender, EventArgs e)
		{
			Options.UseType = chkType.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			cbProps.Text = "";
			cbValue.Text = "";
			cbType.Text = "";
		}

		private void imgFilter_Click(object sender, EventArgs e)
		{
			if (m_FilterForm == null)
			{
				m_FilterForm = new FilterBuilder();
				m_FilterForm.Closed += m_FilterForm_Closed;
				m_FilterForm.Show();
			}
			else
			{
				m_FilterForm.BringToFront();
			}
		}

		/// <summary>
		///     Sets the value displayed by the value field
		/// </summary>
		public string DisplayedValue
		{
			set
			{
				cbValue.Text = value;
				Pandora.BoxForm.SelectSmallTab(SmallTabs.Props);
			}
		}

		/// <summary>
		///     Sets the value displayed the property field
		/// </summary>
		public string DisplayedProp
		{
			set
			{
				cbProps.Text = value;
				Pandora.BoxForm.SelectSmallTab(SmallTabs.Props);
			}
		}

		private void m_FilterForm_Closed(object sender, EventArgs e)
		{
			if (m_FilterForm.DialogResult == DialogResult.OK)
			{
				cbType.Text = m_FilterForm.Filter;

				if (m_FilterForm.AddToPresets && !Pandora.Profile.Props.Filters.Contains(m_FilterForm.Filter))
				{
					_ = Pandora.Profile.Props.Filters.Add(m_FilterForm.Filter);
					BuildPresets();
				}
			}

			m_FilterForm.Dispose();
			m_FilterForm = null;
		}

		private void BuildPresets()
		{
			if (cmFilters != null)
			{
				cmFilters.Dispose();
			}

			cmFilters = new ContextMenu();

			var add = new MenuItem(Pandora.Localization.TextProvider["Props.AddPreset"]);
			add.Click += add_Click;
			_ = cmFilters.MenuItems.Add(add);

			var del = new MenuItem(Pandora.Localization.TextProvider["Props.DelPreset"]);

			foreach (var s in Pandora.Profile.Props.Filters)
			{
				var presDel = new MenuItem(s);
				_ = del.MenuItems.Add(presDel);
				presDel.Click += presDel_Click;
			}

			_ = cmFilters.MenuItems.Add(del);

			_ = cmFilters.MenuItems.Add("-");

			foreach (var s in Pandora.Profile.Props.Filters)
			{
				var doPres = new MenuItem(s);
				doPres.Click += doPres_Click;
				_ = cmFilters.MenuItems.Add(doPres);
			}

			cmFilters.Popup += cmFilters_Popup;

			cbType.ContextMenu = cmFilters;
		}

		private void add_Click(object sender, EventArgs e)
		{
			// Add current text to presets
			_ = Pandora.Profile.Props.Filters.Add(cbType.Text);
			BuildPresets();
		}

		private void presDel_Click(object sender, EventArgs e)
		{
			// Delete the preset
			Pandora.Profile.Props.Filters.Remove((sender as MenuItem).Text);
			BuildPresets();
		}

		private void doPres_Click(object sender, EventArgs e)
		{
			// Select a preset
			cbType.Text = (sender as MenuItem).Text;
		}

		private void cmFilters_Popup(object sender, EventArgs e)
		{
			cmFilters.MenuItems[0].Enabled = cbType.Text.Length > 0 && !Pandora.Profile.Props.Filters.Contains(cbType.Text);

			cmFilters.MenuItems[1].Enabled = Pandora.Profile.Props.Filters.Count > 0;
		}
	}
}