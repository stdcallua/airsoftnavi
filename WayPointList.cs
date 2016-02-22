
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
	[Activity (Label = "WayPointList")]			
	public class WayPointList : ListActivity
	{
		List<WayPoint> _wayPoints;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			//SetContentView (Resource.Layout.WayPointList);
			_wayPoints = new List<WayPoint>{new WayPoint()};
			//ArrayAdapter adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleExpandableListItem1, values);
			WayPointAdapter adapter = new WayPointAdapter(this, _wayPoints);
			ListAdapter = adapter;
			// Create your application here
		}


		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			base.OnListItemClick (l, v, position, id);
			WayPointEditor.WayPoint = _wayPoints[position];
			StartActivity(typeof(WayPointEditor));

			// запустить редактор
		}
	}
}

