#region Header
// /*
//  *    2018 - Pandora - ProcessExtension.cs
//  */
#endregion

#region References
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
#endregion

namespace TheBox.Common
{
	//  Issue 33:  	 Bring to front if already started - Tarion
	public static class ProcessExtension
	{
		[DllImport("User32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

		[DllImport("User32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		private const int WS_SHOWNORMAL = 1;

		/// <summary>
		///     Brings an application to front
		/// </summary>
		/// <param name="procToFront"></param>
		public static void BringToFront(Process procToFront)
		{
			if (procToFront != null)
			{
				_ = ShowWindowAsync(procToFront.MainWindowHandle, WS_SHOWNORMAL);
				_ = SetForegroundWindow(procToFront.MainWindowHandle);
			}
		}
	}
}