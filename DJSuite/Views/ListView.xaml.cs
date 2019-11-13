using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DJSuite.Models;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage
    {
        public ObservableCollection<Song> Songs { get; set; }
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public ListView()
        {
            InitializeComponent();

            //populate songs from database
            Songs = new ObservableCollection<Song>
            {
                new Song{ Title="Don't Stop Believing"},
                new Song{ Title="One More Time"},
                new Song{ Title="The Less I Know The Better"},
                new Song{ Title="Come Down"}
            };


            SongView.ItemsSource = Songs;
            SongView.RefreshCommand = new Command(() =>
            {
                SongView.IsRefreshing = true;

                Songs.Add(new Song { Title = "Able to refresh data" });
                SongView.ItemsSource = Songs;
                SongView.IsRefreshing = false;
            });
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var content = e.Item as Song;

            
            await DisplayAlert("Item Tapped", content.Title, "OK");

            //Deselect Item
            SongView.SelectedItem = null;
        }
        

       
    }
}
