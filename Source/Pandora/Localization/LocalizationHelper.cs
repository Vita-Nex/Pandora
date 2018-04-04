#region Header
// /*
//  *    2018 - Pandora - LocalizationHelper.cs
//  */
#endregion

#region References
using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

using TheBox.Buttons;
using TheBox.Common.Localization;
#endregion

namespace TheBox.Localization
{
	// Issue 28:  	 Refactoring Pandora.cs - Tarion
	public class LocalizationHelper
	{
		private const string DEFAULT_LANGUAGE = "English";
		private TextProvider m_TextProvider;

		/// <summary>
		///     Gets the TextProvider object used to retrieve localized text
		/// </summary>
		public TextProvider TextProvider
		{
			get
			{
				if (m_TextProvider == null)
				{
					// Issue 6:  	 Improve error management - Tarion
					try
					{
						m_TextProvider = Pandora.Localization.GetLanguage();
					}
					catch
					{
						return null;
					}
					// End Issue 6
				}

				return m_TextProvider;
			}
			set { m_TextProvider = value; }
		}

		/// <summary>
		///     Gets a StringCollection representing the languages available
		/// </summary>
		public StringCollection SupportedLanguages
		{
			get
			{
				var languages = new StringCollection();

				languages.Add(DEFAULT_LANGUAGE);

				// TODO : Add code to correctly detect supported languages

				return languages;
			}
		}

		/// <summary>
		///     Localizes the text of a control and all of its children controls
		/// </summary>
		/// <param name="control">The control that should be localized</param>
		public void LocalizeControl(Control control)
		{
			if (control is Form)
			{
				// Set options on controls
				var f = control as Form;

				f.TopMost = Pandora.Profile.General.TopMost;
				f.Opacity = Pandora.Profile.General.Opacity / 100.0;
			}

			if (control is BoxButton)
			{
				// Box button
				var b = control as BoxButton;

				ButtonDef def = null;

				if (b.ButtonID >= 0)
					def = Pandora.Buttons[b];

				Pandora.Profile.ButtonIndex.DoButton(b);
			}
			else
			{
				// Classic control
				var text = control.Text;

				var path = text.Split('.');

				if (path.Length == 2)
					control.Text = Pandora.Localization.TextProvider[text];

				if (control is LinkLabel)
				{
					(control as LinkLabel).LinkColor = Pandora.Profile.General.Links.Color;
					(control as LinkLabel).VisitedLinkColor = Pandora.Profile.General.Links.Color;
					(control as LinkLabel).LinkBehavior = LinkBehavior.HoverUnderline;
				}

				if (control.Controls.Count > 0)
				{
					foreach (Control c in control.Controls)
						LocalizeControl(c);
				}
			}
		}

		/// <summary>
		///     Localizes a menu and all of its submenus
		/// </summary>
		/// <param name="menu">The menu that must be localized</param>
		public void LocalizeMenu(Menu menu)
		{
			foreach (MenuItem mi in menu.MenuItems)
			{
				var text = mi.Text;

				var localizedText = Pandora.Localization.TextProvider[text];

				if (localizedText != null)
					mi.Text = localizedText;

				if (mi.MenuItems.Count > 0)
					LocalizeMenu(mi);
			}
		}

		/// <summary>
		///     Added support for ContextMenuStrip Tarion (19.07.2010)
		/// </summary>
		/// <param name="contextMenuStrip"></param>
		public void LocalizeMenu(ContextMenuStrip contextMenuStrip)
		{
			foreach (ToolStripItem tsi in contextMenuStrip.Items)
			{
				var text = tsi.Text;

				var localizedText = Pandora.Localization.TextProvider[text];

				if (localizedText != null)
					tsi.Text = localizedText;

				if (tsi is ToolStripMenuItem)
				{
					var tsmi = (ToolStripMenuItem)tsi;

					if (tsmi != null && tsmi.DropDownItems.Count > 0)
						LocalizeMenu(tsmi);
				}
			}
		}

		/// <summary>
		///     Added support for ToolStripMenuItem Tarion (19.07.2010)
		/// </summary>
		/// <param name="toolStripMenuItem"></param>
		public void LocalizeMenu(ToolStripMenuItem toolStripMenuItem)
		{
			foreach (ToolStripItem tsi in toolStripMenuItem.DropDownItems)
			{
				var text = tsi.Text;

				var localizedText = Pandora.Localization.TextProvider[text];

				if (localizedText != null)
					tsi.Text = localizedText;

				if (tsi is ToolStripMenuItem)
				{
					var tsmi = (ToolStripMenuItem)tsi;

					if (tsmi != null && tsmi.DropDownItems.Count > 0)
						LocalizeMenu(tsmi);
				}
			}
		}

		/// <summary>
		///     Gets the language corresponding to the language selected in the profile
		/// </summary>
		/// <returns>A Text Provider object</returns>
		public TextProvider GetLanguage()
		{
			// Return a default value: Tarion (19.07.2010)
			if (Pandora.Profile == null)
				return GetLanguage(DEFAULT_LANGUAGE);

			return GetLanguage(Pandora.Profile.Language);
		}

		/// <summary>
		///     Gets the language corresponding to the currently selected language
		/// </summary>
		/// <returns></returns>
		public TextProvider GetLanguage(string language)
		{
			var file = Path.Combine(Pandora.Folder, "Lang");
			string resource = null;

			file = Path.Combine(file, string.Format("{0}.dll", language));

			if (!File.Exists(file))
			{
				// Selected language doesn't exist. Revert to English
				MessageBox.Show(
					String.Format(
						"The langague selected for the current profile could not be located. {0} will be used instead.\n\nMissing language: {0}.",
						Pandora.Profile.Language,
						DEFAULT_LANGUAGE));

				Pandora.Profile.Language = DEFAULT_LANGUAGE;

				file = Path.Combine(Pandora.Folder, "Lang");
				file = Path.Combine(file, string.Format(DEFAULT_LANGUAGE + ".dll"));

				if (!File.Exists(file))
				{
					// English doesn't exist either. This is wrong.
					MessageBox.Show(
						String.Format(
							"Pandora's Box couldn't locate a required component ({0}.dll). Please reinstall the program to address this issue.",
							DEFAULT_LANGUAGE));
					Pandora.Log.WriteError(null, DEFAULT_LANGUAGE + ".dll not found. Closing.");
					Pandora.ClosePandora();
					// Is this executed?
					throw new Exception("Default language file not found");
				}
			}

			try
			{
				// Read the TextProvider object
				resource = string.Format("{0}.language.xml", language);

				// Load the assembly
				var asm = Assembly.LoadFile(file);
				var stream = asm.GetManifestResourceStream(resource);

				var dom = new XmlDocument();
				dom.Load(stream);

				stream.Close();

				var tp = TextProvider.Deserialize(dom);

				return tp;
			}
			catch (Exception err)
			{
				MessageBox.Show(
					"An unexpected error occurred when loading language files. Details about the error have been recorded in the log file. Pandora's Box will now close.");
				Pandora.Log.WriteError(err, "Loading resource {0} from assembly in file {1}", resource, file);
				throw new Exception("Language file corrupted");
			}
		}
	}
}