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

		/// <summary>
		///     Gets the tile flags
		/// </summary>
		public uint Flags { get; }

		/// <summary>
		///     Gets the tile ID
		/// </summary>
		public int ID { get; }

		/// <summary>
		///     Creates a new TileMask object
		/// </summary>
		/// <param name="flags">The flags for this tile mask</param>
		/// <param name="id">The item id for this tile</param>
		public TileMask(uint flags, int id)
		{
			Flags = flags;
			ID = id;
		}
	}
}