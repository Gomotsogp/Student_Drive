﻿using System;
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

namespace Student_Drive
{
    [Activity(Label = "Register Page")]
    public class RegisterPage : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterLayout);

            // Create your application here
            FindViewById<Button>(Resource.Id.buttonRegisterPage).Click += (s, e) =>
            {
                var intent = new Intent(this, typeof(MainPage));
                StartActivity(intent);
            };
        }
    }
}