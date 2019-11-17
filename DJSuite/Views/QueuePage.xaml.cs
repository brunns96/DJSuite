using DJSuite.Models;
using DJSuite.Models.APIModels;
using DJSuite.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QueuePage : ContentPage
    {

        public ObservableCollection<TrackDTO> Songs { get; set; }
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
        public QueuePage()
        {
            InitializeComponent();

            //populate songs from database
            Songs = new ObservableCollection<TrackDTO>();

            SongView.ItemsSource = Songs;
            SongView.RefreshCommand = new Command(() =>
            {
                SongView.IsRefreshing = true;

                SongView.ItemsSource = Songs;
                SongView.IsRefreshing = false;
            });

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var content = e.Item as Queue;

            //var ex = await DisplayActionSheet("Add Song to Queue", "Cancel", null,"Add Song?");

            



            //Deselect Item
            SongView.SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddSongsPage(this)));
        }
        
    }
}
