using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJSuite.Models;
using DJSuite.ViewModels;
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
            //viewModel.user.Username = InputValue
            //viewModel.user.Password = InputValue
            //viewmode.user.Token == //service class method to get api token



        }
    }
}