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
        UserViewModel viewModel;
        
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
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new LoginWebView());
        }


    }
}