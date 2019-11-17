using DJSuite.Models.APIModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DJSuite.Services
{
    class SongService
    {

        public async Task<ObservableCollection<TrackDTO>> GetSongsAsync(string searchText)
        {
            var url = $"https://djsuiteapi.azurewebsites.net/api/dj/gettracks?searchText={searchText}&tokenid={Token.TokenID}";
            ObservableCollection<TrackDTO> tracks = new ObservableCollection<TrackDTO>();
            var testTracks = new Tracks();

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
                        jsonResponse = await sr.ReadToEndAsync();
                        testTracks = JsonConvert.DeserializeObject<Tracks>(jsonResponse);
                    }
                }
                foreach(var trackDTO in testTracks.Content.Tracks)
                {
                    tracks.Add(trackDTO);
                }
                
                return tracks;
            }
            return new ObservableCollection<TrackDTO>();



        }
    }
}
