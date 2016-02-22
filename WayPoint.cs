using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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

	public class WayPointAdapter: BaseAdapter
	{
		List<WayPoint> _waypointList;
		Activity _activity;

		public WayPointAdapter(Activity activity, List<WayPoint> list)
		{
			_waypointList = list;
			_activity = activity;
		}

		public override int Count {
			get { return _waypointList.Count; }
		}

		public override Java.Lang.Object GetItem (int position) {
			// could wrap a Contact in a Java.Lang.Object
			// to return it here if needed
			return null;
		}

		public override long GetItemId (int position) {
			return position;//_waypointList [position].;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = View.Inflate(_activity, Resource.Layout.WayPointList, null);
			var caption = view.FindViewById<TextView> (Resource.Id.wpCaption);
			caption.Text = _waypointList [position].Caption;
			/*var view = convertView ?? _activity.LayoutInflater.Inflate (
				Resource.Layout.ContactListItem, parent, false);
			var contactName = view.FindViewById<TextView> (Resource.Id.ContactName);
			var contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
			contactName.Text = _contactList [position].DisplayName;

			if (_contactList [position].PhotoId == null) {
				contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
				contactImage.SetImageResource (Resource.Drawable.contactImage);
			}  else {
				var contactUri = ContentUris.WithAppendedId (
					ContactsContract.Contacts.ContentUri, _contactList [position].Id);
				var contactPhotoUri = Android.Net.Uri.WithAppendedPath (contactUri,
					Contacts.Photos.ContentDirectory);
				contactImage.SetImageURI (contactPhotoUri);
			}*/
			return view;
		}
	}
}

