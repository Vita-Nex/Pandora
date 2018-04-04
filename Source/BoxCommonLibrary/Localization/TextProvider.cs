#region Header
// /*
//  *    2018 - BoxCommonLibrary - TextProvider.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Xml;
#endregion

namespace TheBox.Common.Localization
{
	[Serializable]
	/// <summary>
	/// Provides localized text elements for the box
	/// </summary>
	public class TextProvider
	{
		private Dictionary<string, Dictionary<string, string>> m_Sections;
		private string m_Language;

		/// <summary>
		///     Gets the text associated with the specified resource
		/// </summary>
		public string this[string description]
		{
			get
			{
				var locate = description.Split('.');

				if (locate.Length != 2)
				{
					return null;
				}

				Dictionary<string, string> loc;
				m_Sections.TryGetValue(locate[0], out loc);

				if (loc == null)
					return null;

				string s;
				loc.TryGetValue(locate[1], out s);
				return s;
			}
			set
			{
				var locate = description.Split('.');

				if (locate.Length != 2)
				{
					throw new Exception("Bad descriptor when adding a new entry to text provider");
				}

				Add(value, locate[0], locate[1]);
			}
		}

		/// <summary>
		///     Gets or sets a string identifying the language represented by the text provider
		/// </summary>
		public string Language { get { return m_Language; } set { m_Language = value; } }

		/// <summary>
		///     Gets or sets the data collection (sections) for this text provider
		/// </summary>
		public Dictionary<string, Dictionary<string, string>> Data { get { return m_Sections; } set { m_Sections = value; } }

		/// <summary>
		///     Creates a new TextProvider object
		/// </summary>
		public TextProvider()
		{
			m_Sections = new Dictionary<string, Dictionary<string, string>>();
		}

		/// <summary>
		///     Deletes a section contained in the TextProvider
		/// </summary>
		/// <param name="name">The name of the section that will be deleted</param>
		public void DeleteSection(string name)
		{
			m_Sections.Remove(name);
		}

		/// <summary>
		///     Removes an item from the TextProvider
		/// </summary>
		/// <param name="section">The section the item belongs to</param>
		/// <param name="item">The item name</param>
		public void RemoveItem(string section, string item)
		{
			Dictionary<string, string> hash;
			m_Sections.TryGetValue(section, out hash);

			if (hash != null)
			{
				hash.Remove(item);
			}
		}

		/// <summary>
		///     Removes an item from the TextProvider
		/// </summary>
		/// <param name="definition">The full item definition</param>
		public void RemoveItem(string definition)
		{
			var loc = definition.Split('.');

			if (loc.Length != 2)
				return;

			RemoveItem(loc[0], loc[1]);
		}

		private void Add(string text, string category, string definition)
		{
			Dictionary<string, string> loc = null;

			if (m_Sections.ContainsKey(category))
			{
				loc = m_Sections[category];
			}
			else
			{
				loc = new Dictionary<string, string>();

				m_Sections.Add(category, loc);
			}
			loc[definition] = text;
		}

		#region serialization
		/// <summary>
		///     Saves the contents of the TextProvider to file
		/// </summary>
		/// <param name="filename"></param>
		public void Serialize(string filename)
		{
			var dom = new XmlDocument();

			XmlNode decl = dom.CreateXmlDeclaration("1.0", null, null);

			dom.AppendChild(decl);

			XmlNode lang = dom.CreateElement("Data");

			var langtype = dom.CreateAttribute("language");
			langtype.Value = m_Language;
			lang.Attributes.Append(langtype);

			foreach (var toplevel in m_Sections.Keys)
			{
				XmlNode topnode = dom.CreateElement("section");

				var topname = dom.CreateAttribute("name");
				topname.Value = toplevel;

				topnode.Attributes.Append(topname);

				Dictionary<string, string> hash;
				m_Sections.TryGetValue(toplevel, out hash);

				foreach (var lowlevel in hash.Keys)
				{
					XmlNode entrynode = dom.CreateElement("entry");

					var name = dom.CreateAttribute("name");
					name.Value = lowlevel;
					entrynode.Attributes.Append(name);

					var val = dom.CreateAttribute("text");
					string value;
					hash.TryGetValue(lowlevel, out value);
					val.Value = value;
					entrynode.Attributes.Append(val);

					topnode.AppendChild(entrynode);
				}

				lang.AppendChild(topnode);
			}

			dom.AppendChild(lang);

			dom.Save(filename);
		}

		/// <summary>
		///     Reads a TextProvider item from an Xml document
		/// </summary>
		/// <param name="dom">The XmlDocument containing the object</param>
		/// <returns>A TextProvider object</returns>
		public static TextProvider Deserialize(XmlDocument dom)
		{
			var data = dom.ChildNodes[1];

			var text = new TextProvider();

			text.m_Language = data.Attributes["language"].Value;

			foreach (XmlNode section in data.ChildNodes)
			{
				var topkey = section.Attributes["name"].Value;

				var hash = new Dictionary<string, string>();

				foreach (XmlNode entry in section.ChildNodes)
				{
					var lowkey = entry.Attributes["name"].Value;
					var t = entry.Attributes["text"].Value;

					hash.Add(lowkey, t);
				}

				text.m_Sections.Add(topkey, hash);
			}

			return text;
		}
		#endregion
	}
}