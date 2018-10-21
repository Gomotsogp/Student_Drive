using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FragmentActivity = Android.Support.V4.App.FragmentActivity;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Android.Content.PM;

namespace Student_Drive
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class Map_Activity : FragmentActivity ,IOnMapReadyCallback
    {
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
        
        public async void AddMarker(Location Location)
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

        public async Task<Location> GetLocation()
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

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                Platform.Init(this, savedInstanceState);

                SetContentView(Resource.Layout.Map_layout);
                mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
                if (mapFragment == null)
                {
                    GoogleMapOptions Options = new GoogleMapOptions()
                        .InvokeRotateGesturesEnabled(true);
                    mapFragment = MapFragment.NewInstance(Options);
                    FragmentManager.BeginTransaction().Add(Resource.Id.map, mapFragment).Commit();
                }

                mapFragment.GetMapAsync(this);


                // Create your application here

                AddMarker(await GetLocation());
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