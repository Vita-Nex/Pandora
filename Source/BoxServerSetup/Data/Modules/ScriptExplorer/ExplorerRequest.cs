using System;

namespace TheBox.BoxServer
{
	[ Serializable ]
	/// <summary>
	/// Requests BoxServer to provide information about the folders and files available for remote manipulation
	/// </summary>
	public class ExplorerRequest : ExplorerMessage
	{
		/// <summary>
		/// Creates a new ExplorerRequest message
		/// </summary>
		public ExplorerRequest()
		{
		}

		public override BoxMessage Perform()
		{
			// Authentication ensures there are valid folders
			return new FolderInfo( Username );
		}
	}
}
