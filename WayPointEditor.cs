﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace airsoftnavi
{
	[Activity (Label = "WayPointEditor")]			
	public class WayPointEditor : Activity
	{
		public static WayPoint WayPoint{ get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView(Resource.Layout.WayPointEditor);
		}

		protected override void OnStart ()
		{
			base.OnStart ();

		}
	}
}

