#region Header
// /*
//  *    2018 - BoxCommonLibrary - FileIcon.cs
//  */
#endregion

#region References
using System;
using System.Drawing;
using System.Runtime.InteropServices;
#endregion

namespace TheBox.Common
{
	/// <summary>
	///     Enables extraction of icons for any file type from
	///     the Shell.
	/// </summary>
	public class FileIcon : IDisposable
	{
		/// <summary>
		///     Gets the small icon for a file
		/// </summary>
		/// <param name="file">The path to the file</param>
		/// <returns>An Icon object with the file icon</returns>
		public static Icon GetSmallIcon(string file)
		{
			var fi = new FileIcon(file);

			fi.Flags = fi.Flags | SHGetFileInfoConstants.SHGFI_SMALLICON &
					   ~(SHGetFileInfoConstants.SHGFI_DISPLAYNAME | SHGetFileInfoConstants.SHGFI_TYPENAME |
						 SHGetFileInfoConstants.SHGFI_ATTRIBUTES | SHGetFileInfoConstants.SHGFI_EXETYPE);

			fi.GetInfo();

			var icon = fi.ShellIcon;
			fi.Dispose();

			return icon;
		}

		#region UnmanagedCode
		private const int MAX_PATH = 260;

		[StructLayout(LayoutKind.Sequential)]
		private struct SHFILEINFO
		{
			public readonly IntPtr hIcon;
			public readonly int iIcon;
			public readonly int dwAttributes;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public readonly string szDisplayName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public readonly string szTypeName;
		}

		[DllImport("shell32")]
		private static extern int SHGetFileInfo(
			string pszPath,
			int dwFileAttributes,
			ref SHFILEINFO psfi,
			uint cbFileInfo,
			uint uFlags);

		[DllImport("user32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);

		private const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100;
		private const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000;
		private const int FORMAT_MESSAGE_FROM_HMODULE = 0x800;
		private const int FORMAT_MESSAGE_FROM_STRING = 0x400;
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
		private const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x200;
		private const int FORMAT_MESSAGE_MAX_WIDTH_MASK = 0xFF;

		[DllImport("kernel32")]
		private extern static int FormatMessage(
			int dwFlags,
			IntPtr lpSource,
			int dwMessageId,
			int dwLanguageId,
			string lpBuffer,
			uint nSize,
			int argumentsLong);

		[DllImport("kernel32")]
		private extern static int GetLastError();
		#endregion

		#region Member Variables
		private string displayName;
		private string typeName;
		private Icon fileIcon;
		#endregion

		#region Enumerations
		/// <summary>
		///     Flags which control FileIcon behaviour
		/// </summary>
		[Flags]
		public enum SHGetFileInfoConstants
		{
			/// <summary>
			///     Get icon.  Combine with SHGFI_LARGEICON, SHGFI_SMALLICON,
			///     SHGFI_OPENICON, SHGFI_SHELLICONSIZE, SHGFI_LINKOVERLAY,
			///     SHGFI_SELECTED, SHGFI_ADDOVERLAYS to specify icon
			///     size.
			/// </summary>
			SHGFI_ICON = 0x100,

			/// <summary>
			///     Get the Display name of the file.
			/// </summary>
			SHGFI_DISPLAYNAME = 0x200,

			/// <summary>
			///     Get the TypeName of the file.
			/// </summary>
			SHGFI_TYPENAME = 0x400,

			/// <summary>
			///     Get the attributes of the file.
			/// </summary>
			SHGFI_ATTRIBUTES = 0x800,

			/// <summary>
			///     Get the icon location (not used in this class)
			/// </summary>
			SHGFI_ICONLOCATION = 0x1000,

			/// <summary>
			///     Get the exe type (not used in this class)
			/// </summary>
			SHGFI_EXETYPE = 0x2000,

			/// <summary>
			///     Get the index of the icon in the System Image List (use
			///     vbAccelerator SystemImageList class instead)
			/// </summary>
			SHGFI_SYSICONINDEX = 0x4000,

			/// <summary>
			///     Put a link overlay on icon
			/// </summary>
			SHGFI_LINKOVERLAY = 0x8000,

			/// <summary>
			///     Show icon in selected state
			/// </summary>
			SHGFI_SELECTED = 0x10000,

			/// <summary>
			///     Get only specified attributes (not supported in this class)
			/// </summary>
			SHGFI_ATTR_SPECIFIED = 0x20000,

			/// <summary>
			///     get large icon
			/// </summary>
			SHGFI_LARGEICON = 0x0,

			/// <summary>
			///     get small icon
			/// </summary>
			SHGFI_SMALLICON = 0x1,

			/// <summary>
			///     get open icon
			/// </summary>
			SHGFI_OPENICON = 0x2,

			/// <summary>
			///     get shell size icon
			/// </summary>
			SHGFI_SHELLICONSIZE = 0x4,

			//SHGFI_PIDL = 0x8,                  // pszPath is a pidl 
			/// <summary>
			///     Use passed dwFileAttribute
			/// </summary>
			SHGFI_USEFILEATTRIBUTES = 0x10,

			/// <summary>
			///     Apply the appropriate overlays
			/// </summary>
			SHGFI_ADDOVERLAYS = 0x000000020,

			/// <summary>
			///     Get the index of the overlay (not used in this class)
			/// </summary>
			SHGFI_OVERLAYINDEX = 0x000000040
		}
		#endregion

		#region Implementation
		/// <summary>
		///     Clears up any resources associated with the class
		/// </summary>
		public void Dispose()
		{
			if (fileIcon != null)
			{
				fileIcon.Dispose();
			}
		}

		/// <summary>
		///     Gets/sets the flags used to extract the icon
		/// </summary>
		public SHGetFileInfoConstants Flags { get; set; }

		/// <summary>
		///     Gets/sets the filename to get the icon for
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		///     Gets the icon for the chosen file
		/// </summary>
		public Icon ShellIcon { get { return fileIcon; } }

		/// <summary>
		///     Gets the display name for the selected file
		///     if the SHGFI_DISPLAYNAME flag was set.
		/// </summary>
		public string DisplayName { get { return displayName; } }

		/// <summary>
		///     Gets the type name for the selected file
		///     if the SHGFI_TYPENAME flag was set.
		/// </summary>
		public string TypeName { get { return typeName; } }

		/// <summary>
		///     Gets the information for the specified
		///     file name and flags.
		/// </summary>
		public void GetInfo()
		{
			if (fileIcon != null)
			{
				fileIcon.Dispose();
			}
			fileIcon = null;
			typeName = "";
			displayName = "";

			var shfi = new SHFILEINFO();
			var shfiSize = (uint)Marshal.SizeOf(shfi.GetType());

			var ret = SHGetFileInfo(FileName, 0, ref shfi, shfiSize, (uint)(Flags));
			if (ret != 0)
			{
				if (shfi.hIcon != IntPtr.Zero)
				{
					fileIcon = Icon.FromHandle(shfi.hIcon);
					// Now owned by the GDI+ object
					//DestroyIcon(shfi.hIcon);
				}
				typeName = shfi.szTypeName;
				displayName = shfi.szDisplayName;
			}
			else
			{
				var err = GetLastError();
				Console.WriteLine("Error {0}", err);
				var txtS = new string('\0', 256);
				var len = FormatMessage(
					FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
					IntPtr.Zero,
					err,
					0,
					txtS,
					256,
					0);
				Console.WriteLine("Len {0} text {1}", len, txtS);

				// throw exception
			}
		}

		/// <summary>
		///     Constructs a new, default instance of the FileIcon
		///     class.  Specify the filename and call GetInfo()
		///     to retrieve an icon.
		/// </summary>
		public FileIcon()
		{
			Flags = SHGetFileInfoConstants.SHGFI_ICON | SHGetFileInfoConstants.SHGFI_DISPLAYNAME |
					SHGetFileInfoConstants.SHGFI_TYPENAME | SHGetFileInfoConstants.SHGFI_ATTRIBUTES |
					SHGetFileInfoConstants.SHGFI_EXETYPE;
		}

		/// <summary>
		///     Constructs a new instance of the FileIcon class
		///     and retrieves the icon, display name and type name
		///     for the specified file.
		/// </summary>
		/// <param name="fileName">
		///     The filename to get the icon,
		///     display name and type name for
		/// </param>
		public FileIcon(string fileName)
			: this()
		{
			FileName = fileName;
			GetInfo();
		}

		/// <summary>
		///     Constructs a new instance of the FileIcon class
		///     and retrieves the information specified in the
		///     flags.
		/// </summary>
		/// <param name="fileName">
		///     The filename to get information
		///     for
		/// </param>
		/// <param name="flags">
		///     The flags to use when extracting the
		///     icon and other shell information.
		/// </param>
		public FileIcon(string fileName, SHGetFileInfoConstants flags)
		{
			FileName = fileName;
			Flags = flags;
			GetInfo();
		}
		#endregion
	}
}