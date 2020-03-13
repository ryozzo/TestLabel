using Java.IO;
using SDR.Helpers;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SDR.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SDR
{
    public partial class App : Application
    {
        public string ContextUser
        {
            get { return Settings.UserSettings; }
            set
            {
                if (Settings.UserSettings == value)
                    return;
                Settings.UserSettings = value;
                OnPropertyChanged();
            }
        }

        public App()
        {
            InitializeComponent();

       
                MainPage = new NavigationPage(new Login(ContextUser));
          
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }
        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }
        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
