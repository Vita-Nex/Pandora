#region Header
// /*
//  *    2018 - Pandora - RandomBrushMessage.cs
//  */
#endregion

#region References
using System;
using System.Collections;
using System.Xml.Serialization;
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(BuildItem))]
	/// <summary>
	/// Summary description for RandomBrush.
	/// </summary>
	public class RandomBrushMessage : BoxMessage
	{
		private ArrayList m_Items;

		/// <summary>
		///     Gets or sets the list of items that will be created
		/// </summary>
		public ArrayList Items { get { return m_Items; } set { m_Items = value; } }

		public RandomBrushMessage()
		{
			m_Items = new ArrayList();
		}
	}
}