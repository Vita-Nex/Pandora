#region Header
// /*
//  *    2018 - BoxServer - ZLib.cs
//  */
#endregion

#region References
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
#endregion

namespace TheBox.BoxServer
{
	/// <summary>
	///     Provides access to compression and decompression
	/// </summary>
	public class BoxZLib
	{
		private enum ZLibError
		{
			Z_OK = 0,
			Z_STREAM_END = 1,
			Z_NEED_DICT = 2,
			Z_ERRNO = (-1),
			Z_STREAM_ERROR = (-2),
			Z_DATA_ERROR = (-3),
			Z_MEM_ERROR = (-4),
			Z_BUF_ERROR = (-5),
			Z_VERSION_ERROR = (-6)
		}

		private enum ZLibCompressionLevel
		{
			Z_NO_COMPRESSION = 0,
			Z_BEST_SPEED = 1,
			Z_BEST_COMPRESSION = 9,
			Z_DEFAULT_COMPRESSION = (-1)
		}

		[DllImport("zlib")]
		private static extern string zlibVersion();

		[DllImport("zlib")]
		private static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

		[DllImport("zlib")]
		private static extern ZLibError compress2(
			byte[] dest,
			ref int destLength,
			byte[] source,
			int sourceLength,
			ZLibCompressionLevel level);

		[DllImport("zlib")]
		private static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);

		/// <summary>
		///     Checks the zlib version for compatibility
		/// </summary>
		/// <returns>True if the liberary version matches, false otherwise or if the library can't be found</returns>
		public static bool CheckVersion()
		{
			string[] ver = null;

			try
			{
				ver = zlibVersion().Split('.');
			}
			catch (DllNotFoundException)
			{
				return false;
			}

			return ver[0] == "1";
		}

		/// <summary>
		///     Compresses a Serializable object
		/// </summary>
		/// <param name="source">The Serializable object that should be compressed</param>
		/// <returns>An array of bytes</returns>
		public static byte[] Compress(object source)
		{
			try
			{
				// Xml serialization to a stream
				var serializer = new XmlSerializer(source.GetType());
				var stream = new MemoryStream();
				serializer.Serialize(stream, source);

				// Convert stream to bytes
				var SourceBytes = stream.ToArray();

				stream.Close();

				var length = SourceBytes.Length;

				// Create output array
				var DestLength = SourceBytes.Length + 1;
				var Dest = new byte[DestLength];

				// Compression
				var result = compress2(
					Dest,
					ref DestLength,
					SourceBytes,
					SourceBytes.Length,
					ZLibCompressionLevel.Z_BEST_COMPRESSION);

				if (result != ZLibError.Z_OK)
				{
					return new byte[0];
				}
				// Trim the results according to the useful length
				var compressed = new byte[DestLength + 4];

				Array.Copy(Dest, 0, compressed, 4, DestLength);

				// Copy length to the start of the array
				compressed[0] = (byte)length;
				compressed[1] = (byte)(length >> 8);
				compressed[2] = (byte)(length >> 16);
				compressed[3] = (byte)(length >> 24);

				return compressed;
			}
			catch (Exception err)
			{
				var g = err.ToString();
				return new byte[0];
			}
		}

		/// <summary>
		///     Decompresses data corresponding to a Serializable object
		/// </summary>
		/// <param name="data">The array of bytes representing the compressed stream</param>
		/// <param name="type">The type of the object being deserialized</param>
		/// <returns>A Serializable object</returns>
		public static object Decompress(byte[] data, Type type)
		{
			try
			{
				// Get length
				var length = data[0] | (data[1] << 8) | (data[2] << 16) | (data[3] << 24);

				var actualData = new byte[data.Length - 4];
				Array.Copy(data, 4, actualData, 0, data.Length - 4);

				// Uncompress
				var output = new byte[length];

				var result = uncompress(output, ref length, actualData, actualData.Length);

				if (result != ZLibError.Z_OK)
				{
					return null;
				}

				var stream = new MemoryStream(output);

				var serializer = new XmlSerializer(type);

				var o = serializer.Deserialize(stream);

				stream.Close();

				return o;
			}
			catch
			{
				return null;
			}
		}
	}
}