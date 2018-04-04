#region Header
// /*
//  *    2018 - Pandora - ExplorerMessage.cs
//  */
#endregion

#region References
using System;
using System.Collections;
#endregion

namespace TheBox.BoxServer
{
	[Serializable]
	/// <summary>
	/// This is the base message for all Script Explorer actions
	/// </summary>
	public class ExplorerMessage : BoxMessage
	{
		/// <summary>
		///     The list of folders allowed for this user
		/// </summary>
		protected ArrayList m_Folders;
	}
}