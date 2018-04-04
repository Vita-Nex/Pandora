#region Header
// /*
//  *    2018 - Pandora - SearchForm.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.Forms
{
	/// <summary>
	///     Summary description for SearchForm.
	/// </summary>
	public class SearchForm : Form
	{
		private RadioButton rName;
		private RadioButton rID;
		private Button bOk;
		private Button bCancel;
		private TextBox txSearchString;
		private Label label1;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		/// <summary>
		///     The types of searches available
		/// </summary>
		public enum SearchType
		{
			/// <summary>
			///     Search for a decorative item
			/// </summary>
			Deco,

			/// <summary>
			///     Search for a scripted item
			/// </summary>
			Item,

			/// <summary>
			///     Search for a scripted mobile
			/// </summary>
			Mobile,

			/// <summary>
			///     Search for a location
			/// </summary>
			Location
		}

		/// <summary>
		///     Creates a new form used to get input for a search
		/// </summary>
		/// <param name="type">The type of search</param>
		public SearchForm(SearchType type)
		{
			InitializeComponent();

			Pandora.Localization.LocalizeControl(this);

			if (type != SearchType.Deco)
			{
				rID.Visible = false;
				rName.Visible = false;
			}

			switch (type)
			{
				case SearchType.Deco:
				case SearchType.Item:

					Text = "Find Item";
					break;

				case SearchType.Location:

					Text = Pandora.Localization.TextProvider["Misc.FindLoc"];
					break;

				case SearchType.Mobile:

					Text = Pandora.Localization.TextProvider["Misc.FindMob"];
					break;
			}
		}

		/// <summary>
		///     Gets the search string. Returns null if it's empty
		/// </summary>
		public string SearchString
		{
			get
			{
				if (txSearchString.Text == "")
					return null;
				return txSearchString.Text;
			}
		}

		public int SearchID
		{
			get
			{
				if (txSearchString.Text == "")
					return -1;
				var i = -1;

				try
				{
					i = Convert.ToInt32(txSearchString.Text);
				}
				catch
				{ }

				return i;
			}
		}

		/// <summary>
		///     Gets a value stating whether to search for IDs. Valid only for deco items.
		/// </summary>
		public bool SearchForIDs { get { return rID.Checked; } }

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
			var resources = new System.Resources.ResourceManager(typeof(SearchForm));
			this.txSearchString = new System.Windows.Forms.TextBox();
			this.rName = new System.Windows.Forms.RadioButton();
			this.rID = new System.Windows.Forms.RadioButton();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txSearchString
			// 
			this.txSearchString.Location = new System.Drawing.Point(8, 8);
			this.txSearchString.Name = "txSearchString";
			this.txSearchString.Size = new System.Drawing.Size(248, 20);
			this.txSearchString.TabIndex = 0;
			this.txSearchString.Text = "";
			this.txSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txSearchString_KeyDown);
			// 
			// rName
			// 
			this.rName.Checked = true;
			this.rName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rName.Location = new System.Drawing.Point(8, 128);
			this.rName.Name = "rName";
			this.rName.TabIndex = 1;
			this.rName.TabStop = true;
			this.rName.Text = "Common.Name";
			// 
			// rID
			// 
			this.rID.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rID.Location = new System.Drawing.Point(152, 128);
			this.rID.Name = "rID";
			this.rID.TabIndex = 2;
			this.rID.Text = "Common.ID";
			// 
			// bOk
			// 
			this.bOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bOk.Location = new System.Drawing.Point(184, 152);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(72, 23);
			this.bOk.TabIndex = 3;
			this.bOk.Text = "Common.Ok";
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCancel.Location = new System.Drawing.Point(8, 152);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(72, 23);
			this.bCancel.TabIndex = 4;
			this.bCancel.Text = "Common.Cancel";
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 96);
			this.label1.TabIndex = 5;
			this.label1.Text = "Misc.Search";
			// 
			// SearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 181);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.rID);
			this.Controls.Add(this.rName);
			this.Controls.Add(this.txSearchString);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SearchForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SearchForm";
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void bOk_Click(object sender, EventArgs e)
		{
			if (txSearchString.Text == "")
			{
				DialogResult = DialogResult.Cancel;
			}
			else
			{
				DialogResult = DialogResult.OK;
			}

			Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void SearchForm_Load(object sender, EventArgs e)
		{
			txSearchString.Focus();
		}

		private void txSearchString_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}