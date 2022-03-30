using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using SongsApp.Models;

namespace SongsApp.Services
{
    public static class KVDataService 
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task<List<Song>> GetSecretData()
        {
            var secretJson = await httpClient.GetStringAsync("https://songsfunction.azurewebsites.net/api/GetSongsFunction");

            return JsonConvert.DeserializeObject<List<Song>>(secretJson);
        }

    }
}
