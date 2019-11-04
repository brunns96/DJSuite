using DJSuite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DJSuite.Models;
namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        SongViewModel viewModel;
        public TestPage(SongViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        //OVERRIDE Constructor
        public TestPage()
        {
            InitializeComponent();
            var song = new Song
            {
                Name = "Stayin' Alive",
                Artist = "Bee Gees",
                Album = "TEST ALBUM"
            
            };

            viewModel = new SongViewModel(song);
            BindingContext = viewModel;

        }

        private void InitializeData()
        {

        }
    }
}