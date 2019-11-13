using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJSuite.Models.APIModels
{
    public class AlbumDTO
    {
        public ArtistDTO[] Artists{ get; set; }
        public Array[] AvailableMarkets { get; set; }
        public Array[] Genres { get; set; } 
        public string Href { get; set; }
        public string Id { get; set; }
        /*
         * Images of the album in various sizes, widest first.
         * Array filler with Spotify 'ImageObject'
         */
        public Array[] Images { get; set; }
        public string Name { get; set; }
        /*
         * The popularity of the album.
         * The value will be between 0 and 100, with 100 being the most popular.
         */
        public int Popularity { get; set; }
        public string ReleaseDate { get; set; }
        /*
         * Tracks on album
         * Uses Spotify 'SimplifiedTrackObject'
         * May be able to just use TrackDTO for this *
         */
        public Array[] Tracks { get; set; }
        public string uri { get; set; }
    }
}