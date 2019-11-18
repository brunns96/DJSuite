using System;
using DJSuite.Models;
using DJSuite.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DJSuite.Services;
namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();                     
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            Navigation.InsertPageBefore(new LoginWebView(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }



    }
}