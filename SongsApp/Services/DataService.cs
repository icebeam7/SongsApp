using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

using SongsApp.Models;

namespace SongsApp.Services
{
    public class DataService
    {
        public static async Task<List<Song>> GetData()
        {
            var apiKey = "QCRgmjSzD6zHhAHWzpjQcCsER2Ch3LlNUU1HOUxcTLAq3R1eLI6HT9PZMA1wCRy9QdJo177zMw6wuVlmjNiwRQ==";

            var creds = new StorageCredentials("songsstoragecb", apiKey);
            var cloudStorageAcct = new CloudStorageAccount(creds, "core.windows.net", true);

            var tableClient = cloudStorageAcct.CreateCloudTableClient();

            var table = tableClient.GetTableReference("SongsTable");

            var tableQuery = new TableQuery<Song>();

            var tableContents = await table.ExecuteQuerySegmentedAsync(tableQuery, null);

            return tableContents.Results;
        }
    }
}
