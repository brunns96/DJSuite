using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using DJSuite.Helpers;
using DJSuite.Models;
using DJSuite.Services;
using DJSuite.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginService loginService;
        UserViewModel viewModel;
        private static string clientId = "47a5c9cece574b54bd77ab03ddc871a8";
        private static string redirectUrl = "https://djsuiteapi.azurewebsites.net/api/dj/callback";
        private string url = "https://accounts.spotify.com/authorize?client_id=" + clientId + "&redirect_uri=" + redirectUrl + "&response_type=code&scope=user-read-private user-read-email user-library-read&deviceId=testPhone";
        public LoginPage()
        {
            InitializeComponent();

            User user = new User
            {
                Username = "",
                Password = ""
            };
            viewModel = new UserViewModel(user);
            BindingContext = viewModel;
            //TODO REMOVE 
            loginService = new LoginService();
            webView.Source = url;

            webView.Navigated += WebView_Navigated;
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            //viewModel.user.Username = InputValue
            //viewModel.user.Password = InputValue
            //viewmode.user.Token == //service class method to get api token

            //LoginService loginService = new LoginService(new User { Username = "", Password = "", Token = "" });
            //loginService.DeserializeJson();
            var response = await DependencyService.Get<INativeBrowser>().LaunchBrowserAsync(url);
        }
        async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var json = await webView.EvaluateJavaScriptAsync("document.body.innerHTML");

            //TODO:set page to a loading icon
            await Navigation.PushModalAsync(new ItemDetailPage());


            if (json.Contains("access_token"))
            {

                var arg = @".*""access_token"":""(.?)"".*";
                var m = Regex.Match(json, arg);
                var x = m.Groups[0].Value;

                //TODO Call API to send device Id and token
                //Store device id and token 

                loginService.PostDataToAPI(GetDeviceId(), "TESTTOKEN");
            }

            //code to go to new xamarin form page
            await Navigation.PushModalAsync(new ItemDetailPage());
        }

        private string GetDeviceId()
        {
            var deviceId = Preferences.Get("my_deviceId", string.Empty);
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                deviceId = System.Guid.NewGuid().ToString();
                Preferences.Set("my_deviceId", deviceId);
            }

            return deviceId;
        }
    }
}