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
	[Activity(Label = "airsoftnavi", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, ILocationListener
    {
		private LocationManager _locationManager;
		private Location _currentLocation;
		private String _locationProvider;

		public static String GetWPFolder()
		{
			
			return Path.Combine ("AirsoftNavi", "WayPoints");
		}

		public Location CurrentLocation
		{
			get{ return _currentLocation;}
			set
			{
				_currentLocation = value; 
			}
		}

		protected void ShowInputCodeDialog() {

			// get prompts.xml view
			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (Resource.String.inputcode);

			View dialog = View.Inflate (this, Resource.Layout.InputCodeDialog, null);
			alert.SetView(dialog);

			alert.SetPositiveButton ("OK", (senderAlert, args) => {
				AutoCompleteTextView textView = dialog.FindViewById<AutoCompleteTextView>(Resource.Id.inputCode);
				//textView.Text;
				//test input code
			} );
			alert.SetNegativeButton ("CANCEL", (senderAlert, args) => {
				//perform your own task for this conditional button click
			} );
			//run the alert in UI thread to display in the screen
			RunOnUiThread (() => {
				alert.Show();
			} );
		}

		public override Boolean OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.Main, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.new_waypoint:
                    WayPointEditor.WayPoint = new WayPoint();
                    StartActivity(typeof(WayPointEditor));
                    //ShowInputCodeDialog ();
                    //do something
                    return true;
			case Resource.Id.waypoints:
				StartActivity (typeof(WayPointList));
				//WayPointEditor editor = new WayPointEditor ();

				//do something
				return true;
			}
			return base.OnOptionsItemSelected(item);
		}

		public void OnLocationChanged (Location location)
		{
			CurrentLocation = location;
		}

		public void OnProviderDisabled (string provider)
		{
			//throw new NotImplementedException ();
		}

		public void OnProviderEnabled (string provider)
		{
			//throw new NotImplementedException ();
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
            _gpsStatus.Text = status == Availability.Available? GetString(Resource.String.gps_status_connected): GetString(Resource.String.gps_status_disconected);
            //throw new NotImplementedException ();
        }

        TextView _gpsStatus;
        Button _checkCode;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _gpsStatus = FindViewById<TextView>(Resource.Id.textGPSstatus);
            _checkCode = FindViewById<Button>(Resource.Id.buttonCheckCode);
            _checkCode.Click += _checkCode_Click;
            // Get our button from the layout resource,
            // and attach an event to it
            //            Button button = FindViewById<Button>(Resource.Id.MyButton);

            //            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        private void _checkCode_Click(object sender, EventArgs e)
        {
            ShowInputCodeDialog();
        }

        void InitializeLocationManager()
		{
			_locationManager = (LocationManager) GetSystemService(LocationService);
			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};

			IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				_locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				_locationProvider = string.Empty;
			}
			//Log.Debug(TAG, "Using " + _locationProvider + ".");
		}
    }
}

