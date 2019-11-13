using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJSuite.Models.APIModels
{
    public class ArtistDTO
    {
        //A list of the genres the artist is associated with.
        public Array[] Genres { get; set; }
        //A link to the Web API endpoint providing full details of the artist.
        public string Href { get; set; }
        //Artist ID
        public string Id { get; set; }
        /*
         * Images of the artist in various sizes, widest first.
         * Array filler with Spotify 'ImageObject'
         */
        public Array[] Images { get; set; }
        //Artist Name
        public string Name { get; set; }
        /*
         * The popularity of the artist.
         * The value will be between 0 and 100, with 100 being the most popular.
         */
        public int Popularity { get; set; }
        //The Spotify URI for the artist.
        public string Uri { get; set; }

    }
}