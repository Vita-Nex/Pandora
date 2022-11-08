#region Header
// /*
//  *    2018 - Pandora - BuildMessage.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(BuildItem))]
	/// <summary>
	/// Requests the server to build a structure
	/// </summary>
	public class BuildMessage : BoxMessage
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		private List<BuildItem> m_Items;
		// Issue 10 - End

		/// <summary>
		///     Gets or sets the items composing this structure
		/// </summary>
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<BuildItem> Items
		// Issue 10 - End 
		{
			get => m_Items;
			set => m_Items = value;
		}

		/// <summary>
		///     Creates a new build request
		/// </summary>
		public BuildMessage()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			m_Items = new List<BuildItem>();
			// Issue 10 - End
		}
	}

	/// <summary>
	///     Defines an item part of a structure created in Pandora's Box
	/// </summary>
	[Serializable]
	public class BuildItem
	{
		private int m_ID;
		private int m_Hue;
		private int m_X;
		private int m_Y;
		private int m_Z;

		/// <summary>
		///     Gets or sets the item ID
		/// </summary>
		[XmlAttribute]
		public int ID { get => m_ID; set => m_ID = value; }

		/// <summary>
		///     Gets or sets the item hue
		/// </summary>
		[XmlAttribute]
		public int Hue { get => m_Hue; set => m_Hue = value; }

		/// <summary>
		///     Gets or sets the X coordinate
		/// </summary>
		[XmlAttribute]
		public int X { get => m_X; set => m_X = value; }

		/// <summary>
		///     Gets or sets the Y coordinate
		/// </summary>
		[XmlAttribute]
		public int Y { get => m_Y; set => m_Y = value; }

		/// <summary>
		///     Gets or sets the Z coordinate
		/// </summary>
		[XmlAttribute]
		public int Z { get => m_Z; set => m_Z = value; }
	}
}