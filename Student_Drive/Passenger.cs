using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using Xamarin.Essentials;
using Android.Content.PM;

namespace Student_Drive
{
    [Activity(Label = "Passenger")]
    public class Passenger : Activity, IOnMapReadyCallback
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Create your application here
        //}
        private GoogleMap map;
        private MapFragment mapFragment;

        public void OnMapReady(GoogleMap googleMap)
        {
            try
            {
                map = googleMap;
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            try
            {
                Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            }
        }

        public async Task<Xamarin.Essentials.Location> GetLocation()
        {
            try
            {
                return await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            }
            return null;
        }
        public async void AddMarker(Android.Locations.Location Location)
        {
            try
            {
                //var Location = await GetLocation();
                MarkerOptions markerOpt1 = new MarkerOptions().SetPosition(new LatLng(Location.Latitude, Location.Longitude)).SetTitle("You");
                map.AddMarker(markerOpt1);
                map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(Location.Latitude, Location.Longitude), 13));
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.Passenger);
                Platform.Init(this, savedInstanceState);

                SetContentView(Resource.Layout.Map_layout);
                mapFragment = FragmentManager.FindFragmentByTag("passengermap") as MapFragment;
                if (mapFragment == null)
                {
                    GoogleMapOptions Options = new GoogleMapOptions()
                        .InvokeRotateGesturesEnabled(true);
                    mapFragment = MapFragment.NewInstance(Options);
                    FragmentManager.BeginTransaction().Add(Resource.Id.map, mapFragment).Commit();
                }

                mapFragment.GetMapAsync(this);


                // Create your application here

                //AddMarker(await GetLocation());
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            }
        }
    }
}