#region Header
// /*
//  *    2018 - BoxEdit - Starter.cs
//  */
#endregion

#region References
using System;
using System.Windows.Forms;
#endregion

namespace TheBox.Editors
{
	/// <summary>
	///     Summary description for Form1.
	/// </summary>
	public class Starter
	{
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new TravelEditor());
		}
	}
}