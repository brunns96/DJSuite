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
            await TestMethodAsync();
          //  await Navigation.PushModalAsync(new LoginWebView());
        }

        private async System.Threading.Tasks.Task TestMethodAsync()
        {
            var queueService = new QueueService();
            await queueService.GetSongsAsync();
        }


    }
}