using System;
using System.Collections.Generic;
using Android.Locations;

namespace airsoftnavi
{
	public class WayPoint
	{
		public Guid Guid{ get; set;}
		public String Caption{ get; set;}
		public String Description{ get; set; }
		public String Location{ get; set; }
		public List<String> Images{ get; set; }

		public WayPoint ()
		{
			Images = new List<string> ();
		}

		public WayPoint (Location location):this()
		{
			Guid = Guid.NewGuid ();
			Location = location.ToString ();
		}
	}
}

