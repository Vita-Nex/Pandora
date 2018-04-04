#region Header
// /*
//  *    2018 - Pandora - AccessLevel.cs
//  */
#endregion

namespace TheBox.Data
{
	public enum AccessLevel
	{
		Player = 0,
		Counselor = 1,
		GameMaster = 2,
		Seer = 3,
		Administrator = 4,

		//Update Skill - Issue 18 http://code.google.com/p/pandorasbox3/issues/detail?id=18 -Neo
		Developer = 5,

		Owner = 6
		//Update Access Level -End
	}
}