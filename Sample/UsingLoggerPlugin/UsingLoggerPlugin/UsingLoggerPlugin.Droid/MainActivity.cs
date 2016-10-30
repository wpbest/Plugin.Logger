using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Logger;
using Plugin.Logger.Abstractions;

namespace UsingLoggerPlugin.Droid
{
    [Activity(Label = "UsingLoggerPlugin", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CrossLogger.Current.Configure("UsingLoggerPlugin.log", 3, 100, LogLevel.Warn, true);
            CrossLogger.Current.Log(LogLevel.Info, "UsingLoggerPlugin", "Log Started");
            string log = CrossLogger.Current.Get();

            LoadApplication(new App());
        }
    }
}

