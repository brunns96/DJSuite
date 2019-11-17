using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJSuite.Models.APIModels
{
    public class TrackDTOTOREMOVE
    {
        public AlbumDTO Album { get; set; }
        public ArtistDTO[] Artists { get; set; }
        public Array[] AvailableMarkets { get; set; }
        public int durationMs { get; set; }
        public bool Explicit { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool Is_Playable { get; set; }
        public int Popularity { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
    }
}