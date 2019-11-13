using DJSuite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginWebView : ContentPage
    {

        LoginService loginService;
        private static string clientId = "47a5c9cece574b54bd77ab03ddc871a8";
        private static string redirectUrl = "https://djsuiteapi.azurewebsites.net/api/dj/callback";
        private string url = "https://accounts.spotify.com/authorize?client_id=" + clientId + 
            "&redirect_uri=" + redirectUrl + 
            "&response_type=code&scope=user-read-private user-read-email user-library-read&deviceId=testPhone";
        public LoginWebView()
        {
            InitializeComponent();

            webView.Source = url;

            webView.Navigated += WebView_Navigated;
        }

       
        async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            //TODO:set page to a loading icon
            webView.IsVisible = false;

            activityIndicator.Color = Color.Black;
            activityIndicator.IsRunning = true;

            var json = await webView.EvaluateJavaScriptAsync("document.body.innerHTML");

            if (json.Contains("access_token"))
            {
                //TODO Fix to get access token
                var arg = @".*""access_token"":""(.?)"".*";
                var m = Regex.Match(json, arg);
                var x = m.Groups[0].Value;

                //TODO Call API to send device Id and token
                //Store device id and token 
                loginService = new LoginService();
                loginService.PostDataToAPI(GetDeviceId(), "6");
            }
            else
            {
                //error handling
                
            }

            //code to go to new xamarin form page
            await Navigation.PushAsync(new ListView());
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