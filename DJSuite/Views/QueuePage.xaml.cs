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
            Title = "Lobby Queue Page";
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
            var track = e.Item as TrackDTO;

            

            if (track.Votes == null)
            {
                track.Votes = 0;
            }           

            var vote = await DisplayActionSheet("Upvote/Downvote", "Cancel", null, "Upvote", "Downvote");
            if(vote == "Upvote")
            {
                track.Votes++;
            }

            Songs.Where(song => song.Name == track.Name).Select(song => { song.Votes = track.Votes; return true; });

            var tempList = Songs.OrderByDescending(song => song.Votes).ToList();
            Songs = new ObservableCollection<TrackDTO>();
            foreach(var song in tempList)
            {
                Songs.Add(song);
            }
            SongView.ItemsSource = Songs;

            //Deselect Item
            SongView.SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new AddSongsPage(this), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
        
    }
}
