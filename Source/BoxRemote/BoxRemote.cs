#region Header
// /*
//  *    2018 - BoxServer - BoxRemote.cs
//  */
#endregion

#region References
using System;
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     Provides the interface that allows Pandora to communicate with the BoxServer
	/// </summary>
	public class BoxRemote : MarshalByRefObject
	{
		/// <summary>
		///     Represents the delegate for handling messages sent by Pandora
		/// </summary>
		public delegate byte[] Message(string typeName, byte[] data, out string answerType);

		/// <summary>
		///     Occurs when Pandora's Box sends a request to the server
		/// </summary>
		public static event Message OnMessage;

		/// <summary>
		///     Performs a request invoked by a remote application
		/// </summary>
		/// <param name="type">The name of the type corresponding to the message</param>
		/// <param name="data">The byte stream representing the BoxMessage object</param>
		/// <param name="answerType">Will hold the name of the answer type</param>
		/// <returns>The outcome BoxMessage resulting from the action</returns>
		public byte[] PerformRemoteRequest(string typeName, byte[] data, out string answerType)
		{
			answerType = null;

			if (OnMessage != null)
			{
				return OnMessage(typeName, data, out answerType);
			}
			return null;
		}
	}
}