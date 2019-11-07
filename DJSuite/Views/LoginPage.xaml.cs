using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DJSuite.Helpers;
using DJSuite.Models;
using DJSuite.Services;
using DJSuite.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel viewModel;
        private static string clientId = "47a5c9cece574b54bd77ab03ddc871a8";
        private static string redirectUrl = "https://www.google.com/";
        private string url = "https://accounts.spotify.com/authorize?client_id=" + clientId + "&redirect_uri=" + redirectUrl + "&response_type=code&scope=user-read-private user-read-email user-library-read";
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
            
            webView.Source = url;
            webView.Navigated += WebView_Navigated;
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            //viewModel.user.Username = InputValue
            //viewModel.user.Password = InputValue
            //viewmode.user.Token == //service class method to get api token

            LoginService loginService = new LoginService(new User { Username = "", Password = "", Token = "" });
            loginService.DeserializeJson();

        }
        async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            //verify callback URL
            // Debug.WriteLine(e.Url);
            Uri url = new Uri(e.Url);

            if (url.Host.Contains("example.com"))
            {
                //parse the response
                var code = HttpUtility.ParseQueryString(url.Query).Get("code");
                var error = HttpUtility.ParseQueryString(url.Query).Get("error");
                //exchange this for a token
                // Debug.WriteLine("Got Code: " + code);

                if (error != null)
                {
                    //  Debug.WriteLine("Error with logging user in");
                    await DisplayAlert("Uh-oh", "Can't log you in", "Ok");
                    webView.Source = url;
                    await Navigation.PopAsync();
                }

                //To-do: Exchange the code for an access token if no error


                Device.BeginInvokeOnMainThread(async () =>
                {
                    //Save the RefreshToken and set App AccessToken and LastRefreshedTime
                    var postbackURL = "https://accounts.spotify.com/api/token";
                    var tokens = await OAuth2Helper.GetAccessTokenFromCode(postbackURL,
                           Credentials.RedirectURI,
                           Credentials.ClientID,
                           Credentials.ClientSecret,
                           Credentials.Scopes,
                           code);

                    //In App.cs, add these variables to maintain context
                    App.HasLoggedIn = true;
                    App.AuthModel = tokens;

                    await Navigation.PushModalAsync(new ItemDetailPage());

                });
            }
        }
    }
}