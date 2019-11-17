using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DJSuite.Models.APIModels;

using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DJSuite.Services
{
    public class QueueService
    {
        public ObservableCollection<Queue> GetSongsAsync()
        {
            var url = "https://djsuiteapi.azurewebsites.net/api/dj/queue";
            ObservableCollection<Queue> queue = null;
            var webRequest = WebRequest.Create(url);
            string jsonResponse = string.Empty;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/json";

                HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        jsonResponse = sr.ReadToEnd();
                        queue = JsonConvert.DeserializeObject<ObservableCollection<Queue>>(jsonResponse);
                    }
                }
                return queue;
            }
            return new ObservableCollection<Queue>();
      
            
           
        }

    }
}
