using Microsoft.WindowsAzure.Storage.Table;

namespace SongsApp.Models
{
    public class Song : TableEntity
    {
        public string SongName { get; set; }
        public string SongAlbum { get; set; }
    }
}
