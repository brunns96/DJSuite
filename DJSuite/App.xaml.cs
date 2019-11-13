using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DJSuite.Services;
using DJSuite.Views;

namespace DJSuite
{
    public partial class App : Application
    {
        public static bool HasLoggedIn { get; set; }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
