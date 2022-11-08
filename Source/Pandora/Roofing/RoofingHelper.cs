#region Header
// /*
//  *    2018 - Pandora - RoofingHelper.cs
//  */
#endregion

namespace TheBox.Roofing
{
	/// <summary>
	///     Provides methods used in roofing creation
	/// </summary>
	public class RoofingHelper
	{
		/// <summary>
		///     Compares two tiles according to their position
		/// </summary>
		/// <param name="middle">The height of the middle tile</param>
		/// <param name="relative">The height of the tile compared to the middle one</param>
		/// <returns>A uint flag describing the relationship between the tiles</returns>
		public static uint Compare(int middle, int relative)
		{
			if (relative == 0)
			{
				return 8; // Empty
			}

			if (relative < 0)
			{
				relative = (short)-relative;
			}

			if (relative == middle)
			{
				return 4; // Even
			}
			if (relative < middle)
			{
				return 1; // Lower
			}
			return 2; // Higher
		}

		/// <summary>
		///     Gets the flags for a given element
		/// </summary>
		/// <param name="prevLine">Previous line (3 items in the array)</param>
		/// <param name="line">Current line (3 items in the array, middle is being evaluated)</param>
		/// <param name="nextLine">Next line (3 items in the array)</param>
		/// <returns>The uint flags</returns>
		public static uint GetFlags(int[] prevLine, int[] line, int[] nextLine)
		{
			uint flags = 0;

			flags |= Compare(line[1], prevLine[0]);
			flags <<= 4;

			flags |= Compare(line[1], prevLine[1]);
			flags <<= 4;

			flags |= Compare(line[1], prevLine[2]);
			flags <<= 4;

			flags |= Compare(line[1], line[0]);
			flags <<= 4;

			flags |= Compare(line[1], line[2]);
			flags <<= 4;

			flags |= Compare(line[1], nextLine[0]);
			flags <<= 4;

			flags |= Compare(line[1], nextLine[1]);
			flags <<= 4;

			flags |= Compare(line[1], nextLine[2]);

			return flags;
		}
	}
}