#region Header
// /*
//  *    2018 - BoxCommonLibrary - NetUtility.cs
//  */
#endregion

#region References
using System.IO;
using System.Net;
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     Provides utilities for online stuff managment
	/// </summary>
	public class NetUtility
	{
		/// <summary>
		///     Retrieves the content of a web url (uses http protocol)
		///     [NOT SUPPORTED]
		/// </summary>
		/// <param name="url">The url to retrieve</param>
		/// <returns>A MemoryStream object containing the contents read. Returns null if an error occurs or the stream is empty.</returns>
		public static string GetDataFromHttp(string url)
		{
			WebResponse response = null;
			Stream stream = null;
			TextReader reader = null;
			string output = null;

			try
			{
				var request = WebRequest.Create(url);
				request.Timeout = 5000;

				response = request.GetResponse();
				stream = response.GetResponseStream();

				reader = new StreamReader(stream);
				output = reader.ReadToEnd();
			}
			catch
			{ }
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (stream != null)
				{
					stream.Close();
				}

				if (response != null)
				{
					response.Close();
				}
			}

			return output;
		}

		/// <summary>
		///     Retrieves a file using the http protocol and saves it to disk
		///     [NOT SUPPORTED]
		/// </summary>
		/// <param name="url">The url to retrieve from</param>
		/// <param name="destination">The destination filename</param>
		/// <returns>True if the operation was succesful</returns>
		public static bool GetFileFromHttp(string url, string destination)
		{
			WebResponse response = null;
			Stream stream = null;
			FileStream fs = null;
			var success = false;

			try
			{
				var request = WebRequest.Create(url);
				request.Timeout = 5000;

				response = request.GetResponse();
				stream = response.GetResponseStream();

				fs = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.Read);

				var buffer = new byte[12800];
				var count = 0;

				while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
				{
					fs.Write(buffer, 0, count);
				}

				success = true;
			}
			catch
			{
				success = false;
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}

				if (fs != null)
				{
					fs.Close();
				}

				if (response != null)
				{
					response.Close();
				}
			}

			return success;
		}
	}
}