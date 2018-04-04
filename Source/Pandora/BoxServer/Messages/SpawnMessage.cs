#region Header
// /*
//  *    2018 - Pandora - SpawnMessage.cs
//  */
#endregion

#region References
using System;

using TheBox.Data;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// This message creates a spawn group in Pandora's Box
	/// </summary>
	public class SpawnMessage : BoxMessage
	{
		private BoxSpawn m_Spawn;

		/// <summary>
		///     Gets or sets the spawn requested by Pandora's Box
		/// </summary>
		public BoxSpawn Spawn { get { return m_Spawn; } set { m_Spawn = value; } }

		/// <summary>
		///     Creates a new SpawnMessage
		/// </summary>
		public SpawnMessage()
		{ }

		/// <summary>
		///     Creates a new SpawnMessage
		/// </summary>
		/// <param name="spawn">The spawn that will be created on the server</param>
		public SpawnMessage(BoxSpawn spawn)
		{
			m_Spawn = spawn;
		}
	}
}