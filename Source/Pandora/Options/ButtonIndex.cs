#region Header
// /*
//  *    2018 - Pandora - ButtonIndex.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using TheBox.Buttons;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Provides the default indexes on the multi command buttons
	/// </summary>
	public class ButtonIndex
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private readonly Dictionary<int, int> m_Table;

		/// <summary>
		///     Creates a new Button Index provider for multi command buttons
		/// </summary>
		public ButtonIndex()
		{
			m_Table = new Dictionary<int, int>();
			// Issue 10 - end
		}

		/// <summary>
		///     Gets or sets the index for a given button id
		/// </summary>
		public int this[int ButtonID]
		{
			get
			{
				if (m_Table.ContainsKey(ButtonID))
				{
					// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
					return m_Table[ButtonID];
				}
				// Issue 10 - End
				return -1;
			}
			set
			{
				m_Table[ButtonID] = value;
				Save();
			}
		}

		public static ButtonIndex Load()
		{
			var filename = String.Format(Path.Combine(Pandora.Profile.BaseFolder, "bdi.xml"));

			if (File.Exists(filename))
			{
				var dom = new XmlDocument();

				dom.Load(filename);

				if (dom.ChildNodes.Count != 2)
				{
					Pandora.Log.WriteError(null, String.Format("Bad format for file {0}", filename));
					return null;
				}

				var main = (XmlElement)dom.ChildNodes[1];

				if (main.Name != "table")
				{
					Pandora.Log.WriteError(null, String.Format("Bad format for file {0}", filename));
					return null;
				}

				var index = new ButtonIndex();

				foreach (XmlElement data in main.ChildNodes)
				{
					try
					{
						var key = Convert.ToInt32(data.Attributes["id"].Value);
						var val = Convert.ToInt32(data.Attributes["index"].Value);

						index.m_Table[key] = val;
					}
					catch (Exception err)
					{
						Pandora.Log.WriteError(err, String.Format("An error occurred when reading entries from {0}", filename));
						return null;
					}
				}

				return index;
			}
			return null;
		}

		private void Save()
		{
			try
			{
				var filename = String.Format(Path.Combine(Pandora.Profile.BaseFolder, "bdi.xml"));

				var dom = new XmlDocument();

				var decl = dom.CreateXmlDeclaration("1.0", null, null);
				_ = dom.AppendChild(decl);

				var main = dom.CreateElement("table");

				foreach (var key in m_Table.Keys)
				{
					var data = dom.CreateElement("data");

					var id = dom.CreateAttribute("id");
					id.Value = key.ToString();
					_ = data.Attributes.Append(id);

					var val = dom.CreateAttribute("index");
					val.Value = m_Table[key].ToString();
					_ = data.Attributes.Append(val);

					_ = main.AppendChild(data);
				}

				_ = dom.AppendChild(main);

				dom.Save(filename);
			}
			catch (Exception err)
			{
				Pandora.Log.WriteError(err, "Couldn\'t save the bdi.xml file");
			}
		}

		/// <summary>
		///     Processes a button fixing its default index if appliable
		/// </summary>
		/// <param name="button"></param>
		public void DoButton(BoxButton button)
		{
			if (button.Def != null && button.Def.MultiDef != null && button.ButtonID >= 0)
			{
				// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
				_ = m_Table.TryGetValue(button.ButtonID, out var i);

				button.Def.MultiDef.DefaultIndex = i;

				// Issue 10 - End
			}
		}
	}
}