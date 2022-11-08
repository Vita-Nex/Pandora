#region Header
// /*
//  *    2018 - Pandora - BoxLog.cs
//  */
#endregion

#region References
using System;
using System.IO;
using System.Runtime.InteropServices;
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     Provides logging functionality for Pandora's Box
	/// </summary>
	public class BoxLog
	{
		// Issue 6:  	 Improve error management - Tarion
		// Intergration of log4net

		#region Imports
		//struct to retrive memory status
		[StructLayout(LayoutKind.Sequential)]
		private struct MEMORYSTATUS
		{
			public readonly uint dwLength;
			public readonly uint dwMemoryLoad;
			public readonly uint dwTotalPhys;
			public readonly uint dwAvailPhys;
			public readonly uint dwTotalPageFile;
			public readonly uint dwAvailPageFile;
			public readonly uint dwTotalVirtual;
			public readonly uint dwAvailVirtual;
		}

		// Constants used for processor types
		private const int PROCESSOR_INTEL_386 = 386;

		private const int PROCESSOR_INTEL_486 = 486;
		private const int PROCESSOR_INTEL_PENTIUM = 586;
		private const int PROCESSOR_MIPS_R4000 = 4000;
		private const int PROCESSOR_ALPHA_21064 = 21064;

		//To get Memory status
		[DllImport("kernel32")]
		private static extern void GlobalMemoryStatus(ref MEMORYSTATUS buf);
		#endregion

		private readonly string filename;
		private StreamWriter m_Stream;

		public BoxLog(string filename)
		{
			this.filename = filename;

			var folder = Path.GetDirectoryName(filename);

			// Ensure directory
			if (!Directory.Exists(folder))
			{
				_ = Directory.CreateDirectory(folder);
			}

			try
			{
				m_Stream = new StreamWriter(filename, false);
			}
			catch
			{
				m_Stream = null;
				return;
			}

			LogHeader();
		}

		/// <summary>
		///     Log the systeminformation at the beginning of the logile
		/// </summary>
		private void LogHeader()
		{
			var memSt = new MEMORYSTATUS();
			GlobalMemoryStatus(ref memSt);

			m_Stream.WriteLine("Pandora's Box - Log");
			m_Stream.WriteLine("Pandora version {0}", Pandora.Version);
			m_Stream.WriteLine("");
			m_Stream.WriteLine(DateTime.Now.ToString());
			m_Stream.WriteLine("Windows version: " + Environment.OSVersion.Version);
			m_Stream.WriteLine("Physical memory: " + (memSt.dwTotalPhys / 1024));
			m_Stream.WriteLine();
		}

		private string CurrentTime => String.Format("[{0}:{1}:{2}]", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

		public void WriteEntry(string text)
		{
			if (m_Stream != null)
			{
				m_Stream.WriteLine("{0} {1}", CurrentTime, text);
				m_Stream.Flush();
			}
		}

		public void WriteEntry(string format, params object[] args)
		{
			WriteEntry(String.Format(format, args));
		}

		public void WriteError(Exception error, string additionalInfo)
		{
			if (m_Stream != null)
			{
				WriteEntry("**** ERROR ****");

				if (error != null)
				{
					m_Stream.WriteLine(error.ToString());
				}

				if (additionalInfo != null)
				{
					m_Stream.WriteLine("Additional information: {0}", additionalInfo);
				}

				m_Stream.Flush();
			}
		}

		public void WriteError(Exception error, string format, params object[] args)
		{
			WriteError(error, String.Format(format, args));
		}

		/// <summary>
		///     Unsused! Remove it?
		///     - by Tarion
		/// </summary>
		public void Close()
		{
			if (m_Stream != null)
			{
				WriteEntry("Session closed");
				m_Stream.Close();
				m_Stream = null;
			}
		}
	}
}
