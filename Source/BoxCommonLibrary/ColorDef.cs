#region Header
// /*
//  *    2018 - BoxCommonLibrary - ColorDef.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Xml.Serialization;
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     Provides XML serializable information about a color
	/// </summary>
	[Serializable]
	public class ColorDef
	{
		private int m_Red;
		private int m_Green;
		private int m_Blue;
		private int m_Alpha = 255;

		/// <summary>
		///     Gets or sets the red component of the color
		/// </summary>
		[XmlAttribute]
		public int Red { get => m_Red; set => m_Red = value; }

		/// <summary>
		///     Gets or sets the green component of the color
		/// </summary>
		[XmlAttribute]
		public int Green { get => m_Green; set => m_Green = value; }

		/// <summary>
		///     Gets or sets the blue component of the color
		/// </summary>
		[XmlAttribute]
		public int Blue { get => m_Blue; set => m_Blue = value; }

		/// <summary>
		///     Gets or sets the alpha component of the color
		/// </summary>
		[XmlAttribute]
		public int Alpha { get => m_Alpha; set => m_Alpha = value; }

		/// <summary>
		///     Gets or sets the color specified
		/// </summary>
		[XmlIgnore]
		public Color Color
		{
			get => Color.FromArgb(m_Alpha, m_Red, m_Green, m_Blue);
			set
			{
				m_Red = value.R;
				m_Green = value.G;
				m_Blue = value.B;
				m_Alpha = value.A;
			}
		}

		/// <summary>
		///     Creates a new ColorDef object
		/// </summary>
		public ColorDef()
		{ }

		/// <summary>
		///     Creates a new ColorDef object
		/// </summary>
		/// <param name="color">The color this ColorDef will represent</param>
		public ColorDef(Color color)
		{
			Color = color;
		}
	}
}