#region Header
// /*
//  *    2018 - Pandora - TileMask.cs
//  */
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Describes a single tile and its positioning
	/// </summary>
	public class TileMask
	{
		private readonly uint m_Flags;
		private readonly int m_Id;

		/// <summary>
		///     Gets the tile flags
		/// </summary>
		public uint Flags { get { return m_Flags; } }

		/// <summary>
		///     Gets the tile ID
		/// </summary>
		public int ID { get { return m_Id; } }

		/// <summary>
		///     Creates a new TileMask object
		/// </summary>
		/// <param name="flags">The flags for this tile mask</param>
		/// <param name="id">The item id for this tile</param>
		public TileMask(uint flags, int id)
		{
			m_Flags = flags;
			m_Id = id;
		}
	}
}