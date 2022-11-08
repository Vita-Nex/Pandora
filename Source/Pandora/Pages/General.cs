#region Header
// /*
//  *    2018 - Pandora - General.cs
//  */
#endregion

#region References
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using TheBox.Buttons;
using TheBox.Data;
using TheBox.Forms;
#endregion

namespace TheBox.Pages
{
	/// <summary>
	///     Summary description for General.
	/// </summary>
	public class General : UserControl
	{
		private LinkLabel lnkSound;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private BoxButton boxButton1;
		private BoxButton boxButton2;
		private BoxButton boxButton3;
		private BoxButton boxButton4;
		private BoxButton boxButton5;
		private BoxButton boxButton6;
		private ComboBox cmbSpeech;
		private ComboBox cmbWeb;
		private Button bTell;
		private Button bSM;
		private Button bBCast;
		private Button bWeb;
		private Button bPriv;
		private Button bSound;
		private GroupBox groupBox4;
		private LinkLabel lnkSkill;
		private NumericUpDown numSkill;
		private Button bGetSkill;
		private Button bSetSkill;
		private GroupBox groupBox5;
		private CheckBox chkDupe;
		private NumericUpDown numDupe;
		private Button bDupe;
		private Button bInBag;
		private GroupBox groupBox6;
		private Button bLightGlobal;
		private Button bLightLocal;
		private NumericUpDown numLight;

		/// <summary>
		///     Required designer variable.
		/// </summary>
		private readonly Container components = null;

		public General()
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
			var resources = new System.Resources.ResourceManager(typeof(General));
			this.lnkSound = new System.Windows.Forms.LinkLabel();
			this.cmbSpeech = new System.Windows.Forms.ComboBox();
			this.cmbWeb = new System.Windows.Forms.ComboBox();
			this.bTell = new System.Windows.Forms.Button();
			this.bSM = new System.Windows.Forms.Button();
			this.bBCast = new System.Windows.Forms.Button();
			this.bWeb = new System.Windows.Forms.Button();
			this.bPriv = new System.Windows.Forms.Button();
			this.bSound = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.boxButton4 = new TheBox.Buttons.BoxButton();
			this.boxButton3 = new TheBox.Buttons.BoxButton();
			this.boxButton2 = new TheBox.Buttons.BoxButton();
			this.boxButton1 = new TheBox.Buttons.BoxButton();
			this.boxButton5 = new TheBox.Buttons.BoxButton();
			this.boxButton6 = new TheBox.Buttons.BoxButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.numSkill = new System.Windows.Forms.NumericUpDown();
			this.lnkSkill = new System.Windows.Forms.LinkLabel();
			this.bGetSkill = new System.Windows.Forms.Button();
			this.bSetSkill = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.bInBag = new System.Windows.Forms.Button();
			this.numDupe = new System.Windows.Forms.NumericUpDown();
			this.chkDupe = new System.Windows.Forms.CheckBox();
			this.bDupe = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.bLightGlobal = new System.Windows.Forms.Button();
			this.bLightLocal = new System.Windows.Forms.Button();
			this.numLight = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numSkill).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numDupe).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numLight).BeginInit();
			this.SuspendLayout();
			// 
			// lnkSound
			// 
			this.lnkSound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lnkSound.Location = new System.Drawing.Point(4, 40);
			this.lnkSound.Name = "lnkSound";
			this.lnkSound.Size = new System.Drawing.Size(116, 20);
			this.lnkSound.TabIndex = 0;
			this.lnkSound.TabStop = true;
			this.lnkSound.Text = "General.ChooseSnd";
			this.lnkSound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkSound_MouseDown);
			// 
			// cmbSpeech
			// 
			this.cmbSpeech.Location = new System.Drawing.Point(4, 16);
			this.cmbSpeech.Name = "cmbSpeech";
			this.cmbSpeech.Size = new System.Drawing.Size(228, 21);
			this.cmbSpeech.TabIndex = 1;
			// 
			// cmbWeb
			// 
			this.cmbWeb.Location = new System.Drawing.Point(4, 16);
			this.cmbWeb.Name = "cmbWeb";
			this.cmbWeb.Size = new System.Drawing.Size(184, 21);
			this.cmbWeb.TabIndex = 2;
			// 
			// bTell
			// 
			this.bTell.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTell.Location = new System.Drawing.Point(4, 40);
			this.bTell.Name = "bTell";
			this.bTell.Size = new System.Drawing.Size(72, 21);
			this.bTell.TabIndex = 3;
			this.bTell.Text = "General.Tell";
			this.bTell.Click += new System.EventHandler(this.bTell_Click);
			// 
			// bSM
			// 
			this.bSM.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSM.Location = new System.Drawing.Point(80, 40);
			this.bSM.Name = "bSM";
			this.bSM.Size = new System.Drawing.Size(72, 21);
			this.bSM.TabIndex = 4;
			this.bSM.Text = "General.SM";
			this.bSM.Click += new System.EventHandler(this.bSM_Click);
			// 
			// bBCast
			// 
			this.bBCast.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bBCast.Location = new System.Drawing.Point(156, 40);
			this.bBCast.Name = "bBCast";
			this.bBCast.Size = new System.Drawing.Size(76, 21);
			this.bBCast.TabIndex = 5;
			this.bBCast.Text = "General.BCast";
			this.bBCast.Click += new System.EventHandler(this.bBCast_Click);
			// 
			// bWeb
			// 
			this.bWeb.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bWeb.Location = new System.Drawing.Point(192, 16);
			this.bWeb.Name = "bWeb";
			this.bWeb.Size = new System.Drawing.Size(56, 21);
			this.bWeb.TabIndex = 6;
			this.bWeb.Text = "General.www";
			this.bWeb.Click += new System.EventHandler(this.bWeb_Click);
			// 
			// bPriv
			// 
			this.bPriv.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bPriv.Location = new System.Drawing.Point(124, 40);
			this.bPriv.Name = "bPriv";
			this.bPriv.Size = new System.Drawing.Size(64, 21);
			this.bPriv.TabIndex = 7;
			this.bPriv.Text = "General.priv";
			this.bPriv.Click += new System.EventHandler(this.bPriv_Click);
			// 
			// bSound
			// 
			this.bSound.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSound.Location = new System.Drawing.Point(192, 40);
			this.bSound.Name = "bSound";
			this.bSound.Size = new System.Drawing.Size(56, 21);
			this.bSound.TabIndex = 8;
			this.bSound.Text = "General.Snd";
			this.bSound.Click += new System.EventHandler(this.bSound_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bSM);
			this.groupBox1.Controls.Add(this.cmbSpeech);
			this.groupBox1.Controls.Add(this.bBCast);
			this.groupBox1.Controls.Add(this.bTell);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(4, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(236, 64);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Misc.Speech";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbWeb);
			this.groupBox2.Controls.Add(this.bWeb);
			this.groupBox2.Controls.Add(this.bPriv);
			this.groupBox2.Controls.Add(this.bSound);
			this.groupBox2.Controls.Add(this.lnkSound);
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox2.Location = new System.Drawing.Point(240, 76);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(252, 64);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Misc.WebSnd";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.boxButton4);
			this.groupBox3.Controls.Add(this.boxButton3);
			this.groupBox3.Controls.Add(this.boxButton2);
			this.groupBox3.Controls.Add(this.boxButton1);
			this.groupBox3.Controls.Add(this.boxButton5);
			this.groupBox3.Controls.Add(this.boxButton6);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(4, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(196, 72);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "General.Cmd";
			// 
			// boxButton4
			// 
			this.boxButton4.AllowEdit = true;
			this.boxButton4.ButtonID = 73;
			this.boxButton4.Def = null;
			this.boxButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton4.IsActive = true;
			this.boxButton4.Location = new System.Drawing.Point(68, 44);
			this.boxButton4.Name = "boxButton4";
			this.boxButton4.Size = new System.Drawing.Size(60, 23);
			this.boxButton4.TabIndex = 3;
			this.boxButton4.Text = "Restock";
			// 
			// boxButton3
			// 
			this.boxButton3.AllowEdit = true;
			this.boxButton3.ButtonID = 72;
			this.boxButton3.Def = null;
			this.boxButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton3.IsActive = true;
			this.boxButton3.Location = new System.Drawing.Point(68, 16);
			this.boxButton3.Name = "boxButton3";
			this.boxButton3.Size = new System.Drawing.Size(60, 23);
			this.boxButton3.TabIndex = 2;
			this.boxButton3.Text = "Players";
			// 
			// boxButton2
			// 
			this.boxButton2.AllowEdit = true;
			this.boxButton2.ButtonID = 71;
			this.boxButton2.Def = null;
			this.boxButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton2.IsActive = true;
			this.boxButton2.Location = new System.Drawing.Point(4, 44);
			this.boxButton2.Name = "boxButton2";
			this.boxButton2.Size = new System.Drawing.Size(60, 23);
			this.boxButton2.TabIndex = 1;
			this.boxButton2.Text = "Misc";
			// 
			// boxButton1
			// 
			this.boxButton1.AllowEdit = true;
			this.boxButton1.ButtonID = 70;
			this.boxButton1.Def = null;
			this.boxButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton1.IsActive = true;
			this.boxButton1.Location = new System.Drawing.Point(4, 16);
			this.boxButton1.Name = "boxButton1";
			this.boxButton1.Size = new System.Drawing.Size(60, 23);
			this.boxButton1.TabIndex = 0;
			this.boxButton1.Text = "Bank";
			// 
			// boxButton5
			// 
			this.boxButton5.AllowEdit = true;
			this.boxButton5.ButtonID = 74;
			this.boxButton5.Def = null;
			this.boxButton5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton5.IsActive = true;
			this.boxButton5.Location = new System.Drawing.Point(132, 16);
			this.boxButton5.Name = "boxButton5";
			this.boxButton5.Size = new System.Drawing.Size(60, 23);
			this.boxButton5.TabIndex = 4;
			this.boxButton5.Text = "Items";
			// 
			// boxButton6
			// 
			this.boxButton6.AllowEdit = true;
			this.boxButton6.ButtonID = 75;
			this.boxButton6.Def = null;
			this.boxButton6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxButton6.IsActive = true;
			this.boxButton6.Location = new System.Drawing.Point(132, 44);
			this.boxButton6.Name = "boxButton6";
			this.boxButton6.Size = new System.Drawing.Size(60, 23);
			this.boxButton6.TabIndex = 5;
			this.boxButton6.Text = "Cast";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.numSkill);
			this.groupBox4.Controls.Add(this.lnkSkill);
			this.groupBox4.Controls.Add(this.bGetSkill);
			this.groupBox4.Controls.Add(this.bSetSkill);
			this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox4.Location = new System.Drawing.Point(200, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(120, 72);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Misc.Skills";
			// 
			// numSkill
			// 
			this.numSkill.DecimalPlaces = 1;
			this.numSkill.Location = new System.Drawing.Point(32, 44);
			this.numSkill.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numSkill.Name = "numSkill";
			this.numSkill.Size = new System.Drawing.Size(48, 20);
			this.numSkill.TabIndex = 1;
			this.numSkill.Value = new decimal(new int[] { 1099, 0, 0, 65536 });
			this.numSkill.ValueChanged += new System.EventHandler(this.numSkill_ValueChanged);
			// 
			// lnkSkill
			// 
			this.lnkSkill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lnkSkill.Location = new System.Drawing.Point(4, 16);
			this.lnkSkill.Name = "lnkSkill";
			this.lnkSkill.Size = new System.Drawing.Size(112, 23);
			this.lnkSkill.TabIndex = 0;
			this.lnkSkill.TabStop = true;
			this.lnkSkill.Text = "Common.Choose";
			this.lnkSkill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnkSkill.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lnkSkill_MouseDown);
			// 
			// bGetSkill
			// 
			this.bGetSkill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bGetSkill.Image = (System.Drawing.Image)resources.GetObject("bGetSkill.Image");
			this.bGetSkill.Location = new System.Drawing.Point(4, 44);
			this.bGetSkill.Name = "bGetSkill";
			this.bGetSkill.Size = new System.Drawing.Size(24, 23);
			this.bGetSkill.TabIndex = 13;
			this.bGetSkill.Click += new System.EventHandler(this.bGetSkill_Click);
			// 
			// bSetSkill
			// 
			this.bSetSkill.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bSetSkill.Location = new System.Drawing.Point(80, 44);
			this.bSetSkill.Name = "bSetSkill";
			this.bSetSkill.Size = new System.Drawing.Size(36, 23);
			this.bSetSkill.TabIndex = 13;
			this.bSetSkill.Text = "Common.Set";
			this.bSetSkill.Click += new System.EventHandler(this.bSetSkill_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.bInBag);
			this.groupBox5.Controls.Add(this.numDupe);
			this.groupBox5.Controls.Add(this.chkDupe);
			this.groupBox5.Controls.Add(this.bDupe);
			this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox5.Location = new System.Drawing.Point(320, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(96, 72);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "General.Dupe";
			// 
			// bInBag
			// 
			this.bInBag.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bInBag.Location = new System.Drawing.Point(4, 44);
			this.bInBag.Name = "bInBag";
			this.bInBag.Size = new System.Drawing.Size(44, 23);
			this.bInBag.TabIndex = 17;
			this.bInBag.Text = "General.Bag";
			this.bInBag.Click += new System.EventHandler(this.bInBag_Click);
			// 
			// numDupe
			// 
			this.numDupe.Location = new System.Drawing.Point(24, 16);
			this.numDupe.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			this.numDupe.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this.numDupe.Name = "numDupe";
			this.numDupe.Size = new System.Drawing.Size(60, 20);
			this.numDupe.TabIndex = 15;
			this.numDupe.Value = new decimal(new int[] { 1, 0, 0, 0 });
			this.numDupe.ValueChanged += new System.EventHandler(this.numDupe_ValueChanged);
			// 
			// chkDupe
			// 
			this.chkDupe.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkDupe.Location = new System.Drawing.Point(8, 16);
			this.chkDupe.Name = "chkDupe";
			this.chkDupe.Size = new System.Drawing.Size(16, 20);
			this.chkDupe.TabIndex = 14;
			this.chkDupe.CheckedChanged += new System.EventHandler(this.chkDupe_CheckedChanged);
			// 
			// bDupe
			// 
			this.bDupe.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bDupe.Location = new System.Drawing.Point(48, 44);
			this.bDupe.Name = "bDupe";
			this.bDupe.Size = new System.Drawing.Size(44, 23);
			this.bDupe.TabIndex = 16;
			this.bDupe.Text = "General.Dupe";
			this.bDupe.Click += new System.EventHandler(this.bDupe_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.bLightGlobal);
			this.groupBox6.Controls.Add(this.bLightLocal);
			this.groupBox6.Controls.Add(this.numLight);
			this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox6.Location = new System.Drawing.Point(416, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(76, 72);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "General.Light";
			// 
			// bLightGlobal
			// 
			this.bLightGlobal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bLightGlobal.Location = new System.Drawing.Point(40, 44);
			this.bLightGlobal.Name = "bLightGlobal";
			this.bLightGlobal.Size = new System.Drawing.Size(32, 23);
			this.bLightGlobal.TabIndex = 2;
			this.bLightGlobal.Text = "General.All";
			this.bLightGlobal.Click += new System.EventHandler(this.bLightGlobal_Click);
			// 
			// bLightLocal
			// 
			this.bLightLocal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bLightLocal.Location = new System.Drawing.Point(8, 44);
			this.bLightLocal.Name = "bLightLocal";
			this.bLightLocal.Size = new System.Drawing.Size(32, 23);
			this.bLightLocal.TabIndex = 1;
			this.bLightLocal.Text = "General.You";
			this.bLightLocal.Click += new System.EventHandler(this.bLightLocal_Click);
			// 
			// numLight
			// 
			this.numLight.Location = new System.Drawing.Point(16, 16);
			this.numLight.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
			this.numLight.Name = "numLight";
			this.numLight.Size = new System.Drawing.Size(48, 20);
			this.numLight.TabIndex = 0;
			this.numLight.ValueChanged += new System.EventHandler(this.numLight_ValueChanged);
			// 
			// General
			// 
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "General";
			this.Size = new System.Drawing.Size(496, 142);
			this.Load += new System.EventHandler(this.General_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.numSkill).EndInit();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.numDupe).EndInit();
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.numLight).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		///     Loading: read and set options
		/// </summary>
		private void General_Load(object sender, EventArgs e)
		{
			try
			{
				// Sounds
				Pandora.SoundData.SoundChanged += SoundData_SoundChanged;
				UpdateSound();
				bPriv.Tag = new CommandCallback(PerformPrivSound);
				bPriv.ContextMenu = Pandora.cmModifiers;

				// Skills
				Pandora.Skills.AllSkillsSelected += Skills_AllSkillsSelected;
				Pandora.Skills.SkillSelected += Skills_SkillSelected;
				numSkill.Value = Pandora.Profile.General.SkillValue;

				if (Pandora.Profile.General.AllSkills)
				{
					// Display all skills text
					lnkSkill.Text = Pandora.Localization.TextProvider["Misc.AllSkills"];
				}
				else
				{
					if (Pandora.Profile.General.SkillName != null)
					{
						// Display selected skill
						lnkSkill.Text = Pandora.Profile.General.SkillName;
					}
				}

				// Duping
				numDupe.Value = Pandora.Profile.General.DupeAmount;
				chkDupe.Checked = Pandora.Profile.General.DupeCheck;

				// Light
				numLight.Value = Pandora.Profile.General.LightLevel;

				// Speech
				UpdateSpeech();
				bTell.Tag = new CommandCallback(PerformTell);
				bTell.ContextMenu = Pandora.cmModifiers;

				// Web
				UpdateWeb();
				bWeb.Tag = new CommandCallback(PerformOpenBrowser);
				bWeb.ContextMenu = Pandora.cmModifiers;

				// Menus
				RefreshSpeechMenu();
				RefreshWebMenu();
			}
			catch
			{ }
		}

		#region Sound
		/// <summary>
		///     The user chose a new sound
		/// </summary>
		private void SoundData_SoundChanged(object sender, EventArgs e)
		{
			Pandora.Profile.General.Sound = Pandora.SoundData.SelectedSound;
			UpdateSound();
		}

		/// <summary>
		///     Updates the sound name displayed in the sound preview
		/// </summary>
		private void UpdateSound()
		{
			if (Pandora.Profile.General.Sound != null)
			{
				lnkSound.Text = Pandora.Profile.General.Sound.Name;
			}
			else
			{
				lnkSound.Text = Pandora.Localization.TextProvider["General.ChooseSnd"];
			}
		}

		/// <summary>
		///     User clicks the sound
		/// </summary>
		private void lnkSound_MouseDown(object sender, MouseEventArgs e)
		{
			Pandora.SoundData.Menu.Show(lnkSound, new Point(e.X, e.Y));
		}

		/// <summary>
		///     PrivSound callback
		/// </summary>
		/// <param name="modifier">The command modifier</param>
		private void PerformPrivSound(string modifier)
		{
			if (Pandora.Profile.General.Sound != null)
			{
				Pandora.Profile.Commands.DoPrivSound(Pandora.Profile.General.Sound.Index, modifier);
			}
		}

		/// <summary>
		///     PrivSound button
		/// </summary>
		private void bPriv_Click(object sender, EventArgs e)
		{
			PerformPrivSound(null);
		}

		/// <summary>
		///     Sound button
		/// </summary>
		private void bSound_Click(object sender, EventArgs e)
		{
			if (Pandora.Profile.General.Sound != null)
			{
				Pandora.Profile.Commands.DoSound(Pandora.Profile.General.Sound.Index);
			}
		}
		#endregion

		#region Skills
		/// <summary>
		///     Skils link clicked: show skills menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lnkSkill_MouseDown(object sender, MouseEventArgs e)
		{
			Pandora.Skills.Menu.Show(lnkSkill, new Point(e.X, e.Y));
		}

		/// <summary>
		///     User selected the all skills value
		/// </summary>
		private void Skills_AllSkillsSelected(object sender, EventArgs e)
		{
			Pandora.Profile.General.AllSkills = true;
			lnkSkill.Text = Pandora.Localization.TextProvider["Misc.AllSkills"];
		}

		/// <summary>
		///     User selected a specific skill
		/// </summary>
		private void Skills_SkillSelected(object sender, SkillEventArgs e)
		{
			Pandora.Profile.General.AllSkills = false;
			Pandora.Profile.General.SkillName = e.Text;
			Pandora.Profile.General.Skill = e.Skill;
			lnkSkill.Text = e.Text;
		}

		/// <summary>
		///     Updates the value of the skill set section in the options
		/// </summary>
		private void UpdateSkillValue()
		{
			Pandora.Profile.General.SkillValue = numSkill.Value;
		}

		/// <summary>
		///     Set skill clicked
		/// </summary>
		private void bSetSkill_Click(object sender, EventArgs e)
		{
			UpdateSkillValue();

			if (Pandora.Profile.General.AllSkills)
			{
				// Set all skills
				Pandora.Profile.Commands.DoSetAllSkills(Pandora.Profile.General.SkillValue);
			}
			else if (Pandora.Profile.General.Skill != null)
			{
				Pandora.Profile.Commands.DoSetSkill(Pandora.Profile.General.Skill, Pandora.Profile.General.SkillValue);
			}
		}

		/// <summary>
		///     Get skill clicked
		/// </summary>
		private void bGetSkill_Click(object sender, EventArgs e)
		{
			UpdateSkillValue();

			if (Pandora.Profile.General.AllSkills)
			{
				// Get all skills
				Pandora.Profile.Commands.DoGetAllSkills();
			}
			else if (Pandora.Profile.General.Skill != null)
			{
				Pandora.Profile.Commands.DoGetSkill(Pandora.Profile.General.Skill);
			}
		}

		/// <summary>
		///     Changing the value in the numeric up and down
		/// </summary>
		private void numSkill_ValueChanged(object sender, EventArgs e)
		{
			UpdateSkillValue();
		}
		#endregion

		#region Duping
		/// <summary>
		///     Updates the value of the dupe amount
		/// </summary>
		private void UpdateDupeAmount()
		{
			Pandora.Profile.General.DupeAmount = (int)numDupe.Value;
		}

		/// <summary>
		///     Value of the dupe numeric up and down changed
		/// </summary>
		private void numDupe_ValueChanged(object sender, EventArgs e)
		{
			UpdateDupeAmount();
		}

		/// <summary>
		///     Dupe Check changed
		/// </summary>
		private void chkDupe_CheckedChanged(object sender, EventArgs e)
		{
			Pandora.Profile.General.DupeCheck = chkDupe.Checked;
		}

		/// <summary>
		///     Dupe button
		/// </summary>
		private void bDupe_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoDupe(Pandora.Profile.General.DupeCheck, Pandora.Profile.General.DupeAmount);
		}

		/// <summary>
		///     Dupe in bag button
		/// </summary>
		private void bInBag_Click(object sender, EventArgs e)
		{
			Pandora.Profile.Commands.DoDupeInBag(Pandora.Profile.General.DupeCheck, Pandora.Profile.General.DupeAmount);
		}
		#endregion

		#region Light
		/// <summary>
		///     Updates the value of the light level option
		/// </summary>
		private void UpdateLightLevel()
		{
			Pandora.Profile.General.LightLevel = (int)numLight.Value;
		}

		/// <summary>
		///     Numeric up and down light changed
		/// </summary>
		private void numLight_ValueChanged(object sender, EventArgs e)
		{
			UpdateLightLevel();
		}

		/// <summary>
		///     Global Light button
		/// </summary>
		private void bLightGlobal_Click(object sender, EventArgs e)
		{
			UpdateLightLevel();
			Pandora.Profile.Commands.DoGlobalLight(Pandora.Profile.General.LightLevel);
		}

		/// <summary>
		///     Local light button
		/// </summary>
		private void bLightLocal_Click(object sender, EventArgs e)
		{
			UpdateLightLevel();
			Pandora.Profile.Commands.DoLocalLight(Pandora.Profile.General.LightLevel);
		}
		#endregion

		#region Speech
		/// <summary>
		///     Updates the speech list
		/// </summary>
		private void UpdateSpeech()
		{
			if (cmbSpeech.Text != null && cmbSpeech.Text.Length > 0)
			{
				Pandora.Profile.General.SpeechList.AddString(cmbSpeech.Text);
			}

			cmbSpeech.Items.Clear();
			cmbSpeech.Items.AddRange(Pandora.Profile.General.SpeechList.GetArray());
		}

		/// <summary>
		///     Performs the tell command
		/// </summary>
		/// <param name="modifier">The modifier for this command</param>
		private void PerformTell(string modifier)
		{
			if (cmbSpeech.Text != null && cmbSpeech.Text.Length > 0)
			{
				Pandora.Profile.Commands.DoTell(cmbSpeech.Text, modifier);
				UpdateSpeech();
			}
		}

		/// <summary>
		///     Tell button
		/// </summary>
		private void bTell_Click(object sender, EventArgs e)
		{
			PerformTell(null);
		}

		/// <summary>
		///     Staff message button
		/// </summary>
		private void bSM_Click(object sender, EventArgs e)
		{
			if (cmbSpeech.Text != null && cmbSpeech.Text.Length > 0)
			{
				Pandora.Profile.Commands.DoStaffMessage(cmbSpeech.Text);
				UpdateSpeech();
			}
		}

		/// <summary>
		///     Broadcast button
		/// </summary>
		private void bBCast_Click(object sender, EventArgs e)
		{
			if (cmbSpeech.Text != null && cmbSpeech.Text.Length > 0)
			{
				Pandora.Profile.Commands.DoBroadcast(cmbSpeech.Text);
				UpdateSpeech();
			}
		}
		#endregion

		#region Web
		/// <summary>
		///     Updates the recently used urls
		/// </summary>
		private void UpdateWeb()
		{
			if (cmbWeb.Text != null && cmbWeb.Text.Length > 0)
			{
				Pandora.Profile.General.WebList.AddString(cmbWeb.Text);
			}

			cmbWeb.Items.Clear();
			cmbWeb.Items.AddRange(Pandora.Profile.General.WebList.GetArray());
		}

		/// <summary>
		///     Performs the Open Browser command
		/// </summary>
		/// <param name="modifier">The command modifier</param>
		private void PerformOpenBrowser(string modifier)
		{
			if (cmbWeb.Text != null && cmbWeb.Text.Length > 0)
			{
				Pandora.Profile.Commands.DoOpenBrowser(cmbWeb.Text, modifier);
				UpdateWeb();
			}
		}

		/// <summary>
		///     WWW button
		/// </summary>
		private void bWeb_Click(object sender, EventArgs e)
		{
			PerformOpenBrowser(null);
		}
		#endregion

		#region Context Menus
		private ContextMenu m_SpeechMenu;
		private ContextMenu m_WebMenu;

		/// <summary>
		///     Refreshes the web menu
		/// </summary>
		private void RefreshWebMenu()
		{
			if (m_WebMenu != null)
			{
				m_WebMenu.Dispose();
			}

			m_WebMenu = new ContextMenu();

			var add = new MenuItem(Pandora.Localization.TextProvider["General.AddCurrPreset"]);
			add.Click += add_Click;
			_ = m_WebMenu.MenuItems.Add(add);

			var edit = new MenuItem(Pandora.Localization.TextProvider["General.EditPresets"]);
			edit.Click += EditWebPresets;
			_ = m_WebMenu.MenuItems.Add(edit);

			if (Pandora.Profile.General.WebPresets.Count > 0)
			{
				_ = m_WebMenu.MenuItems.Add("-");

				foreach (var url in Pandora.Profile.General.WebPresets)
				{
					var mi = new MenuItem(url);
					mi.Click += SelectWebPreset;
					_ = m_WebMenu.MenuItems.Add(mi);
				}
			}

			m_WebMenu.Popup += m_WebMenu_Popup;
			cmbWeb.ContextMenu = m_WebMenu;
		}

		/// <summary>
		///     Rebuilds the speech menu
		/// </summary>
		private void RefreshSpeechMenu()
		{
			if (m_SpeechMenu != null)
			{
				m_SpeechMenu.Dispose();
			}

			m_SpeechMenu = new ContextMenu();

			var add = new MenuItem(Pandora.Localization.TextProvider["General.AddCurrPreset"]);
			add.Click += add_Click2;
			_ = m_SpeechMenu.MenuItems.Add(add);

			var edit = new MenuItem(Pandora.Localization.TextProvider["General.EditPresets"]);
			edit.Click += EditSpeechPresets;
			_ = m_SpeechMenu.MenuItems.Add(edit);

			if (Pandora.Profile.General.SpeechPresets.Count > 0)
			{
				_ = m_SpeechMenu.MenuItems.Add("-");

				foreach (var speech in Pandora.Profile.General.SpeechPresets)
				{
					var mi = new MenuItem(speech);
					mi.Click += SelectSpeechPreset;
					_ = m_SpeechMenu.MenuItems.Add(mi);
				}
			}

			m_SpeechMenu.Popup += m_SpeechMenu_Popup;
			cmbSpeech.ContextMenu = m_SpeechMenu;
		}

		/// <summary>
		///     Edit the speech presets
		/// </summary>
		private void EditSpeechPresets(object sender, EventArgs e)
		{
			var form = new StringListForm
			{
				Strings = Pandora.Profile.General.SpeechPresets
			};

			_ = form.ShowDialog();

			Pandora.Profile.General.SpeechPresets = form.Strings;

			RefreshSpeechMenu();
		}

		/// <summary>
		///     Edit the speech presets
		/// </summary>
		private void EditWebPresets(object sender, EventArgs e)
		{
			var form = new StringListForm
			{
				Strings = Pandora.Profile.General.WebPresets
			};

			_ = form.ShowDialog();

			Pandora.Profile.General.WebPresets = form.Strings;

			RefreshWebMenu();
		}

		/// <summary>
		///     Speech preset menu item selected
		/// </summary>
		private void SelectSpeechPreset(object sender, EventArgs e)
		{
			if (sender is MenuItem mi)
			{
				cmbSpeech.Text = mi.Text;
			}
		}

		/// <summary>
		///     Speech preset menu item selected
		/// </summary>
		private void SelectWebPreset(object sender, EventArgs e)
		{
			if (sender is MenuItem mi)
			{
				cmbWeb.Text = mi.Text;
			}
		}

		/// <summary>
		///     Add current web to presets
		/// </summary>
		private void add_Click(object sender, EventArgs e)
		{
			foreach (var s in Pandora.Profile.General.WebPresets)
			{
				if (s.ToLower() == cmbWeb.Text.ToLower())
				{
					return;
				}
			}

			Pandora.Profile.General.WebPresets.Add(cmbWeb.Text);
			RefreshWebMenu();
		}

		/// <summary>
		///     Add current web to presets
		/// </summary>
		private void add_Click2(object sender, EventArgs e)
		{
			foreach (var s in Pandora.Profile.General.SpeechPresets)
			{
				if (s.ToLower() == cmbSpeech.Text.ToLower())
				{
					return;
				}
			}

			Pandora.Profile.General.SpeechPresets.Add(cmbSpeech.Text);
			RefreshSpeechMenu();
		}

		private void m_WebMenu_Popup(object sender, EventArgs e)
		{
			m_WebMenu.MenuItems[0].Enabled = cmbWeb.Text.Length > 0;
		}

		private void m_SpeechMenu_Popup(object sender, EventArgs e)
		{
			m_SpeechMenu.MenuItems[0].Enabled = cmbSpeech.Text.Length > 0;
		}
		#endregion
	}
}