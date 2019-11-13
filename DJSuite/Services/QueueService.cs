using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DJSuite.Models.APIModels;

using System.Net.Http.Headers;
namespace DJSuite.Services
{
    public class QueueService
    {
        //TODO Look into this method
        public async Task GetSongsAsync()
        {
            JObject jsonObject;
            var url = "https://djsuiteapi.azurewebsites.net/api/dj/queue";
            HttpClient client = null;
            List<QueueDTO> queue = null;
            using(client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    queue = await response.Content.ReadAsAsync<List<QueueDTO>>();
                }
            }
            
           
        }

    }
}
