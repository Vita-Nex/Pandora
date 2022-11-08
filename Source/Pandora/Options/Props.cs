#region Header
// /*
//  *    2018 - Pandora - Props.cs
//  */
#endregion

#region References
using System.Collections.Specialized;

using TheBox.Common;
using TheBox.Data;
#endregion

namespace TheBox.Options
{
	/// <summary>
	///     Provides options for properties
	/// </summary>
	public class PropsOptions
	{
		public PropsOptions()
		{
			ShowAllProps = false;
			ShowAllTypes = false;
			UseType = false;
			RecentProps = new RecentStringList();
			RecentValues = new RecentStringList();
			RecentTypes = new RecentStringList();
			RecentClasses = new RecentStringList();
			FBTypes = new RecentStringList();
			FBProps = new RecentStringList();
			FBValues = new RecentStringList();

			Filters = new StringCollection();
		}

		// TimeSpan

		// Point3D

		/// <summary>
		///     Gets or sets the list of recently used properties
		/// </summary>
		public RecentStringList RecentProps { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used values
		/// </summary>
		public RecentStringList RecentValues { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used types to limit a property setting
		/// </summary>
		public RecentStringList RecentTypes { get; set; }

		/// <summary>
		///     Gets or sets a value stating whether a gSet would use the type to limit its targets
		/// </summary>
		public bool UseType { get; set; }

		/// <summary>
		///     Specifies whether the classes tree should display types which have no declared properties
		/// </summary>
		public bool ShowAllTypes { get; set; }

		/// <summary>
		///     Specifies whether each class will display all properties, included the ones inherited
		/// </summary>
		public bool ShowAllProps { get; set; }

		/// <summary>
		///     States how to fileter the properties displayed on the properties tree
		/// </summary>
		public AccessLevel Filter { get; set; } = AccessLevel.Administrator;

		/// <summary>
		///     Gets or sets the recently searched classes
		/// </summary>
		public RecentStringList RecentClasses { get; set; }

		/// <summary>
		///     Gets or sets the number of days for the TimeSpan control
		/// </summary>
		public int Days { get; set; }

		/// <summary>
		///     Gets or sets the number of hours for the TimeSpan control
		/// </summary>
		public int Hours { get; set; }

		/// <summary>
		///     Gets or sets the number of minutes for the TimeSpan control
		/// </summary>
		public int Minutes { get; set; }

		/// <summary>
		///     Gets or sets the number of seconds for the TimeSpan control
		/// </summary>
		public int Seconds { get; set; }

		/// <summary>
		///     Gets or sets the value of the X coordinate on the Point3D control
		/// </summary>
		public int PointX { get; set; }

		/// <summary>
		///     Gets or sets the value of the Y coordinate on the Point3D control
		/// </summary>
		public int PointY { get; set; }

		/// <summary>
		///     Gets or sets the value of the Z coordinate on the Point3D control
		/// </summary>
		public int PointZ { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used types in the FB
		/// </summary>
		public RecentStringList FBTypes { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used props in the FB
		/// </summary>
		public RecentStringList FBProps { get; set; }

		/// <summary>
		///     Gets or sets the list of recently used values in the FB
		/// </summary>
		public RecentStringList FBValues { get; set; }

		/// <summary>
		///     Gets or sets the preset filters
		/// </summary>
		public StringCollection Filters { get; set; }
	}
}