﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Forms.Platform;

namespace App1.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = false, NoHistory = true)]
    public class AndroidSplashScreen : Activity
    {
        static readonly string TAG = "X:" + typeof(AndroidSplashScreen).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            CachedImageRenderer.Init(true); //NUGET PACKAGE 

            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

            //await Task.Delay(1000);

            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}