#region Header
// /*
//  *    2018 - Pandora - AddActorsMessage.cs
//  */
#endregion

#region References
using System;
using System.Collections;
using System.Xml.Serialization;
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(BoxActor))]
	/// <summary>
	/// Allows the Theatre module to create NPC around the user
	/// </summary>
	public class AddActorsMessage : BoxMessage
	{
		private ArrayList m_Actors;

		/// <summary>
		///     Gets or sets the list of the BoxActor objects
		/// </summary>
		public ArrayList Actors { get => m_Actors; set => m_Actors = value; }

		public AddActorsMessage()
		{
			m_Actors = new ArrayList();
		}

		public AddActorsMessage(ArrayList actors)
		{
			m_Actors = actors;
		}
	}

	[Serializable]
	public class BoxActor
	{
		private string m_Ctor;
		private int m_XOffset;
		private int m_YOffset;

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the constructor for the actor, including addionally set properties
		/// </summary>
		public string Ctor { get => m_Ctor; set => m_Ctor = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the X offset from the invoker
		/// </summary>
		public int XOffset { get => m_XOffset; set => m_XOffset = value; }

		[XmlAttribute]
		/// <summary>
		/// Gets or sets the Y offset from the invoker
		/// </summary>
		public int YOffset { get => m_YOffset; set => m_YOffset = value; }

		public override string ToString()
		{
			return String.Format("({0},{1}) {2}", m_XOffset, m_YOffset, m_Ctor);
		}
	}
}