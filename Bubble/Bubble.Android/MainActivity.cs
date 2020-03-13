using System;
using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using SDR.Helpers;
using Xamarin.Forms;

namespace SDR.Droid
{
    [Activity(Label = "SDR", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize 
        | ConfigChanges.Orientation 
        | ConfigChanges.KeyboardHidden 
        | ConfigChanges.Keyboard, 
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Context context = this.ApplicationContext;
            var version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            SharedData.Version = version;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());
            RequestPermissionsForApp();
         
        }

    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        public void StartScanner()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                var e = ex.ToString();

            }



        }

        void RequestPermissionsForApp()
        {
            string[] PermissionsSMS = { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage, Manifest.Permission.Internet };
            const int RequestSMSId = 0;
            RequestPermissions(PermissionsSMS, RequestSMSId);
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            try
            {
                base.OnConfigurationChanged(newConfig);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();

            }
        }


    }
    
}
