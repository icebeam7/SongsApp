using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SongsApp.Models;
using SongsApp.Services;
using Xamarin.Forms;

namespace SongsApp.ViewModels
{
    public class SongViewModel : BaseViewModel
    {
        private ObservableCollection<Song> songs;

        public ObservableCollection<Song> Songs
        {
            get { return songs; }
            set { songs = value; OnPropertyChanged(); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public Command GetSongsCommand { get; set; }

        public SongViewModel()
        {
            GetSongsCommand = new Command(async () => await GetSongs());
        }

        private async Task GetSongs()
        {
            IsBusy = true;

            //var results = await DataService.GetData();
            var results = await KVDataService.GetSecretData();
            Songs = new ObservableCollection<Song>(results);

            IsBusy = false;
        }
    }
}
