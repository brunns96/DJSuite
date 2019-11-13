using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJSuite.Models.APIModels
{
    // https://developer.spotify.com/documentation/web-api/reference-beta/#objects-index
    public class AudioFeaturesDTO
    {
        public float Acousticness { get; set; }
        public float Danceability { get; set; }
        public float Energy { get; set; }
        public string Id { get; set; }
        public float Instrumentalness { get; set; }
        public int Key { get; set; }
        public float Liveness { get; set; }
        public float Loadness { get; set; }
        public int Mode { get; set; }
        public float Speechiness { get; set; }
        public float Tempo { get; set; }
        public int TimeSignature { get; set; }
        public string Uri { get; set; }
        public float Valence { get; set; }
    }
}