#region Header
// /*
//  *    2018 - Pandora - GetDatafile.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     Defines the datafiles that can be retrieved from the server
	/// </summary>
	public enum BoxDatafile
	{
		BoxData,
		PropsData,
		SpawnData
	}

	[Serializable]
	/// <summary>
	/// This message is used to retrieve a datafile from the server
	/// </summary>
	public class GetDatafile : BoxMessage
	{
		private BoxDatafile m_DataType;

		/// <summary>
		///     Gets or sets the datafile type to retrieve
		/// </summary>
		public BoxDatafile DataType { get => m_DataType; set => m_DataType = value; }
	}
}