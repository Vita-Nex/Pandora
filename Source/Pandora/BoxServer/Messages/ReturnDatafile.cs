#region Header
// /*
//  *    2018 - Pandora - ReturnDatafile.cs
//  */
#endregion

#region References
using System;
using System.Xml.Serialization;

using TheBox.Data;
#endregion

namespace TheBox.BoxServer
{
	[Serializable, XmlInclude(typeof(BoxData)), XmlInclude(typeof(SpawnData)), XmlInclude(typeof(PropsData))]
	/// <summary>
	/// This message brings the BoxData object from the server to Pandora's Box
	/// </summary>
	public class ReturnDatafile : BoxMessage
	{
		private object m_Data;

		/// <summary>
		///     Gets or sets the BoxData retrieved from the server
		/// </summary>
		public object Data { get => m_Data; set => m_Data = value; }

		/// <summary>
		///     Creates a new ReturnBoxData message
		/// </summary>
		/// <param name="data">The BoxData to send to the client</param>
		public ReturnDatafile(object data)
		{
			m_Data = data;
		}

		/// <summary>
		///     Creates a new ReturnBoxData message
		/// </summary>
		public ReturnDatafile()
		{ }
	}
}