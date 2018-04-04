#region Header
// /*
//  *    2018 - Pandora - SkillsData.cs
//  */
#endregion

#region References
using System;
using System.IO;
using System.Windows.Forms;
#endregion

namespace TheBox.Data
{
	/// <summary>
	///     Provides information about the skills
	/// </summary>
	public class SkillsData
	{
		public delegate void SkillEventHandler(object sender, SkillEventArgs e);

		public event SkillEventHandler SkillSelected;
		public event EventHandler AllSkillsSelected;

		private readonly ContextMenu m_Menu;

		/// <summary>
		///     Gets the skills context menu
		/// </summary>
		public ContextMenu Menu { get { return m_Menu; } }

		public SkillsData()
		{
			m_Menu = new ContextMenu();
			var allskills = new MenuItem(Pandora.Localization.TextProvider["Misc.AllSkills"]);
			allskills.Click += allskills_Click;
			m_Menu.MenuItems.Add(allskills);
			m_Menu.MenuItems.Add(new MenuItem("-"));
			Load();
		}

		/// <summary>
		///     Loads the skills from the Skills.ini file
		/// </summary>
		private void Load()
		{
			var file = Path.Combine(Pandora.Profile.BaseFolder, "Skills.ini");

			if (!File.Exists(file))
			{
				Pandora.Log.WriteError(null, "Skills.ini file missing");
				m_Menu.MenuItems.Add(new MenuItem("Skills.ini not found"));
				return;
			}

			try
			{
				var reader = new StreamReader(file);

				string line = null;
				MenuItem parent = null;

				while ((line = reader.ReadLine()) != null)
				{
					line = line.Trim();

					if (line.Length == 0)
						continue;

					if (line.StartsWith("#"))
						continue;

					if (line.StartsWith(":"))
					{
						// New category
						var cat = new MenuItem(line.Substring(1));
						m_Menu.MenuItems.Add(cat);
						parent = cat;
					}
					else
					{
						// Skill
						var defs = line.Split(':');

						if (defs.Length != 2)
							continue;

						defs[0] = defs[0].Trim();
						defs[1] = defs[1].Trim();

						var mi = new InternalMenuItem(defs[0], defs[1]);
						mi.Click += mi_Click;
						parent.MenuItems.Add(mi);
					}
				}
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Can't read Skills.ini");
				m_Menu.MenuItems.Clear();
				m_Menu.MenuItems.Add(new MenuItem("You really had to mess up with Skills.ini...."));
			}
		}

		private void mi_Click(object sender, EventArgs e)
		{
			if (SkillSelected != null)
			{
				var mi = sender as InternalMenuItem;

				SkillSelected(this, new SkillEventArgs(mi.Text, mi.Skill));
			}
		}

		private class InternalMenuItem : MenuItem
		{
			/// <summary>
			///     Gets or sets the skill currently selected
			/// </summary>
			public string Skill { get; set; }

			public InternalMenuItem(string text, string skill)
				: base(text)
			{
				Skill = skill;
			}
		}

		private void allskills_Click(object sender, EventArgs e)
		{
			if (AllSkillsSelected != null)
			{
				AllSkillsSelected(this, new EventArgs());
			}
		}
	}

	public class SkillEventArgs : EventArgs
	{
		public string Text { get; set; }

		public string Skill { get; set; }

		public SkillEventArgs(string text, string skill)
		{
			Text = text;
			Skill = skill;
		}
	}
}