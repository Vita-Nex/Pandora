#region Header
// /*
//  *    2018 - TravelAgent - PB1Import.cs
//  */
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;

using TheBox.Common;
using TheBox.Data;

// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
// Issue 10 - End
#endregion

namespace Box.Misc
{
	public class PB1Import
	{
		public static Facet Convert(string filename)
		{
			var single = Utility.LoadXml(typeof(LocationsList), filename) as LocationsList;
			var cust = Utility.LoadXml(typeof(CustomLocations), filename) as CustomLocations;

			if (single == null)
			{
				cust = Utility.LoadXml(typeof(CustomLocations), filename) as CustomLocations;

				if (cust == null)
				{
					return null;
				}
			}

			if (single != null)
			{
				return Convert(single);
			}
			var form = new PB1ImportForm();
			form.ShowDialog();

			switch (form.Map)
			{
				case 0:
					return Convert(cust.Felucca);
				case 1:
					return Convert(cust.Felucca);
				case 2:
					return Convert(cust.Ilshenar);
				case 3:
					return Convert(cust.Malas);
			}

			return null;
		}

		private static Facet Convert(LocationsList list)
		{
			var f = new Facet();

			var categories = new StringCollection();

			foreach (var loc in list.Places)
			{
				if (!categories.Contains(loc.Category))
				{
					categories.Add(loc.Category);
				}
			}

			foreach (var cat in categories)
			{
				var g = new GenericNode(cat);
				f.Nodes.Add(g);
			}

			foreach (var g in f.Nodes)
			{
				var sub = new StringCollection();

				foreach (var loc in list.Places)
				{
					if (loc.Category == g.Name && !sub.Contains(loc.Subsection))
					{
						sub.Add(loc.Subsection);
					}
				}

				foreach (var s in sub)
				{
					var gSub = new GenericNode(s);
					g.Elements.Add(gSub);
				}
			}

			foreach (var gCat in f.Nodes)
			{
				foreach (GenericNode gSub in gCat.Elements)
				{
					foreach (var loc in list.Places)
					{
						if (loc.Category == gCat.Name && loc.Subsection == gSub.Name)
						{
							gSub.Elements.Add(Convert(loc));
						}
					}
				}
			}

			return f;
		}

		private static TheBox.Data.Location Convert(Location loc)
		{
			var newLoc = new TheBox.Data.Location();

			newLoc.Name = loc.Name;
			newLoc.Map = loc.Map;
			newLoc.X = loc.x;
			newLoc.Y = loc.y;
			newLoc.Z = (sbyte)loc.z;

			return newLoc;
		}
	}

	[XmlInclude(typeof(LocationsList))]
	[XmlInclude(typeof(Location))]
	public class CustomLocations
	{
		public LocationsList Felucca;
		public LocationsList Ilshenar;
		public LocationsList Malas;

		public CustomLocations()
		{
			Felucca = new LocationsList();
			Ilshenar = new LocationsList();
			Malas = new LocationsList();
		}
	}

	/// <summary>
	///     Summary description for LocationsList.
	/// </summary>
	[XmlInclude(typeof(Location))]
	public class LocationsList
	{
		// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
		public List<Location> Places;

		// Issue 10 - End
		public LocationsList()
		{
			// Issue 10 - Update the code to Net Framework 3.5 - http://code.google.com/p/pandorasbox3/issues/detail?id=10 - Smjert
			Places = new List<Location>();
			// Issue 10 - End
		}
	}

	/// <summary>
	///     Summary description for Location.
	/// </summary>
	public class Location : IComparable
	{
		public short ID;
		public string Name;
		public string Category;
		public string Subsection;
		public short Map;
		public short x;
		public short y;
		public short z;
		public bool Custom;

		public int CompareTo(object obj)
		{
			if (obj is Location)
			{
				var loc = (Location)obj;

				if (loc.Map != Map)
					return Map.CompareTo(loc.Map);
				if (Category != loc.Category)
					return Category.CompareTo(loc.Category);
				if (Subsection != loc.Subsection)
					return Subsection.CompareTo(loc.Subsection);
				return Name.CompareTo(loc.Name);
			}
			throw new Exception("Not a Location: " + obj);
		}

		public void MakePoint(string point)
		{
			var X = "";
			var Y = "";
			var Z = "";

			while (point[0] != ',')
			{
				X += point[0];
				point = point.Substring(1, point.Length - 1);
			}

			point = point.Substring(1, point.Length - 1);

			while (point[0] != ',')
			{
				Y += point[0];
				point = point.Substring(1, point.Length - 1);
			}

			point = point.Substring(1, point.Length - 1);
			Z = point;

			x = Convert.ToInt16(X);
			y = Convert.ToInt16(Y);
			z = Convert.ToInt16(Z);
		}
	}
}