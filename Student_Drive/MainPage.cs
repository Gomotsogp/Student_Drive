using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace Student_Drive
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainPage : AppCompatActivity,NavigationView.IOnNavigationItemSelectedListener
    {

        //private SupportToolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            SetSupportActionBar(FindViewById<SupportToolbar>(Resource.Id.toolBar));
            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            ab.SetDisplayHomeAsUpEnabled(true);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, FindViewById<DrawerLayout>(Resource.Id.drawer_layout), FindViewById<SupportToolbar>(Resource.Id.toolBar), Resource.String.drawer_open, Resource.String.drawer_close);
            FindViewById<DrawerLayout>(Resource.Id.drawer_layout).AddDrawerListener(toggle);
            toggle.SyncState();
            FindViewById<NavigationView>(Resource.Id.nav_view).SetNavigationItemSelectedListener(this);

        }
        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            switch (menuItem.ItemId)
            {
                case Resource.Id.navigation_maps:
                    var intent = new Intent(this, typeof(Map_Activity));
                    StartActivity(intent);
                    break;
                case Resource.Id.navigation_settings:
                    Toast.MakeText(this, "worked", ToastLength.Long).Show();
                    break;
                case Resource.Id.navigation_exit:
                    var activity = (Activity)this;
                    activity.FinishAffinity();
                    break;
                default:
                    break;
            }
            //FindViewById<DrawerLayout>(Resource.Id.nav_view).CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}