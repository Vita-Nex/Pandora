#region Header
// /*
//  *    2018 - Pandora - MapParam.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Windows.Forms;
#endregion

namespace TheBox.Controls.Params
{
	/// <summary>
	///     Summary description for MapParam.
	/// </summary>
	public class MapParam : UserControl, IParam
	{
		private Label labName;
		private ComboBox cmb;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public MapParam()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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

				Pandora.ToolTip.SetToolTip(labName, null);
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
			this.labName = new System.Windows.Forms.Label();
			this.cmb = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// labName
			// 
			this.labName.Font = new System.Drawing.Font(
				"Microsoft Sans Serif",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((System.Byte)(0)));
			this.labName.Location = new System.Drawing.Point(0, 0);
			this.labName.Name = "labName";
			this.labName.Size = new System.Drawing.Size(96, 16);
			this.labName.TabIndex = 0;
			// 
			// cmb
			// 
			this.cmb.Location = new System.Drawing.Point(0, 16);
			this.cmb.Name = "cmb";
			this.cmb.Size = new System.Drawing.Size(96, 21);
			this.cmb.TabIndex = 1;
			// 
			// MapParam
			// 
			this.Controls.Add(this.cmb);
			this.Controls.Add(this.labName);
			this.Name = "MapParam";
			this.Size = new System.Drawing.Size(96, 36);
			this.Load += new System.EventHandler(this.MapParam_Load);
			this.ResumeLayout(false);
		}
		#endregion

		private void MapParam_Load(object sender, EventArgs e)
		{
			try
			{
				for (var i = 0; i < 4; i++)
				{
					if (Pandora.Profile.Travel.EnabledMaps[i])
					{
						cmb.Items.Add(Pandora.Profile.Travel.MapNames[i]);
					}
				}

				cmb.SelectedIndex = 0;
			}
			catch
			{ }
		}

		private static readonly string[] m_MapNames = {"felucca", "trammel", "ilshenar", "malas"};

		#region IParam Members
		public string ParamName
		{
			set
			{
				labName.Text = value;
				Pandora.ToolTip.SetToolTip(labName, value);
			}
		}

		public string Value
		{
			get
			{
				var map = cmb.SelectedItem as string;

				for (var i = 0; i < 4; i++)
				{
					if (Pandora.Profile.Travel.EnabledMaps[i] && Pandora.Profile.Travel.MapNames[i] == map)
					{
						return m_MapNames[i];
					}
				}

				return "felucca";
			}
		}

		public bool IsDefined { get { return true; } }
		#endregion
	}
}