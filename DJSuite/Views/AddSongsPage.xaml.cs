using DJSuite.Models.APIModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DJSuite.Services;
namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSongsPage : ContentPage
    {

        public ObservableCollection<TrackDTO> Songs = new ObservableCollection<TrackDTO>();
        QueuePage _page;
        SongService songService = new SongService();
        public AddSongsPage(QueuePage page)
        {            

            InitializeComponent();
            Title = "Add Songs To Queue";
            _page = page;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedSong = e.Item as TrackDTO;
            if(_page.Songs != null)
            {
                if (_page.Songs.Contains(selectedSong))
                {
                    await DisplayAlert("Song already in Queue", "The selected song is already in the queue", "Go Back");
                }
            }
            
            var resp = await DisplayActionSheet("Add Song to Queue?", "Cancel", null, "Yes","No");
            
            if(resp == "Yes")
            {
                _page.Songs.Add(selectedSong);
                Songs.Remove(selectedSong);
            }

            //Deselect Item
            SongView.SelectedItem = null;
            


        }

        public async void SongsSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = SongsSearchBar.Text;

            
            Songs = await songService.GetSongsAsync(searchText);

           // var suggestions = Songs.Where(track => track.Name.ToLower().Contains(searchText)).ToList();
            
            SongView.ItemsSource = Songs; 
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(_page, this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }
}
