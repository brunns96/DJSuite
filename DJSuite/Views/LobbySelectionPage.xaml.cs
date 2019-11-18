using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DJSuite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LobbySelectionPage : ContentPage
    {
        public ObservableCollection<Lobby> Lobbys { get; set; }
        public LobbySelectionPage()
        {
            InitializeComponent();
            Lobbys = new ObservableCollection<Lobby>();
            Lobbys.Add(new Lobby
            {
                Name = "Thanksgiving Lobby"
            });
            
            LobbyView.ItemsSource = Lobbys;
        }

        private async void LobbyView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
        }
    }


    public class Lobby
    {
        public string Name { get; set; }
    }

}