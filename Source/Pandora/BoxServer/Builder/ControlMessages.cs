#region Header
// /*
//  *    2018 - Pandora - ControlMessages.cs
//  */
#endregion

#region References
using System;
using System.Xml.Serialization;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// Deletes all the items in the build structure
	/// </summary>
	public class BuilderDeleteMessage : BoxMessage
	{ }

	[Serializable]
	/// <summary>
	/// Hues all the items in the build structure
	/// </summary>
	public class HueMessage : BoxMessage
	{
		private int m_Hue;

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the new hue for the items
		/// </summary>
		public int Hue { get => m_Hue; set => m_Hue = value; }

		public HueMessage()
		{ }

		public HueMessage(int hue)
		{
			m_Hue = hue;
		}
	}

	[Serializable]
	/// <summary>
	/// Moves the items in the structure
	/// </summary>
	public class OffsetMessage : BoxMessage
	{
		private int m_X;
		private int m_Y;
		private int m_Z;

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the X offset
		/// </summary>
		public int XOffset { get => m_X; set => m_X = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Y offset
		/// </summary>
		public int YOffset { get => m_Y; set => m_Y = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Z offset
		/// </summary>
		public int ZOffset { get => m_Z; set => m_Z = value; }

		public OffsetMessage()
		{ }

		public OffsetMessage(int xOffset, int yOffset, int zOffset)
		{
			m_X = xOffset;
			m_Y = yOffset;
			m_Z = zOffset;
		}
	}
}