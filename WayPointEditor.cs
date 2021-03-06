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
	public class WayPointEditor : TabActivity
	{
		public static WayPoint WayPoint{ get; set; }

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            
			SetContentView(View.Inflate(Application.Context, Resource.Layout.WayPointEditor, null));
            CreateTab(typeof(WPEditorGPS), "wpeeditor_gsp", "GPS", Resource.Drawable.Icon);
			CreateTab(typeof(WPEditorInformation), "wpeeditor_information", "Info", Resource.Drawable.Icon);
			CreateTab(typeof(WPEditorImages), "wpeeditor_images", "Images", Resource.Drawable.Icon);
        }

		public override Boolean OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.WPEMenu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            var drawableIcon = Resources.GetDrawable(drawableId);
            spec.SetIndicator(label/*, drawableIcon*/);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }

        protected override void OnStart ()
		{
			base.OnStart ();

		}
	}

    [Activity]
    public class WPEditorGPS : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WayPointEditorGPS);
        }
    }

	[Activity]
	public class WPEditorInformation : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.WayPointEditorInfo);
		}
	}

	[Activity]
	public class WPEditorImages : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.WayPointEditorImages);
		}
	}
}

