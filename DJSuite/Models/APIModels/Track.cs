using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DJSuite.Models.APIModels
{   
        public class Tracks
    {
            [JsonProperty("tracks")]
            public Content Content { get; set; }
        }

        public class Content
        {
            [JsonProperty("href")]
            public Uri Href { get; set; }

            [JsonProperty("items")]
            public TrackDTO[] Tracks { get; set; }

            [JsonProperty("limit")]
            public long Limit { get; set; }

            [JsonProperty("next")]
            public Uri Next { get; set; }

            [JsonProperty("offset")]
            public long Offset { get; set; }

            [JsonProperty("previous")]
            public object Previous { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public class TrackDTO
        {
            [JsonProperty("album")]
            public Album Album { get; set; }

            [JsonProperty("artists")]
            public Artist[] Artists { get; set; }

            [JsonProperty("disc_number")]
            public long DiscNumber { get; set; }

            [JsonProperty("duration_ms")]
            public long DurationMs { get; set; }

            [JsonProperty("explicit")]
            public bool Explicit { get; set; }

            [JsonProperty("external_ids")]
            public ExternalIds ExternalIds { get; set; }

            [JsonProperty("external_urls")]
            public ExternalUrls ExternalUrls { get; set; }

            [JsonProperty("href")]
            public Uri Href { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("is_local")]
            public bool IsLocal { get; set; }

            [JsonProperty("is_playable")]
            public bool IsPlayable { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("popularity")]
            public long Popularity { get; set; }

            [JsonProperty("preview_url")]
            public Uri PreviewUrl { get; set; }

            [JsonProperty("track_number")]
            public long TrackNumber { get; set; }

            [JsonProperty("type")]
            public ItemType Type { get; set; }

            [JsonProperty("uri")]
            public string Uri { get; set; }

            public string TextToDisplay { get => FormatText(); }

            private string FormatText()
            {
            var text = "";
                if(Artists.Length > 0) 
                {
                    text = Name + " By " + Artists[0].Name;
                }
                else
                {
                text = Name;
                }
                return text;
            }


       
        }

        public class Album
        {
            [JsonProperty("album_type")]
            public AlbumTypeEnum AlbumType { get; set; }

            [JsonProperty("artists")]
            public Artist[] Artists { get; set; }

            [JsonProperty("external_urls")]
            public ExternalUrls ExternalUrls { get; set; }

            [JsonProperty("href")]
            public Uri Href { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("images")]
            public Image[] Images { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("release_date")]
            public DateTimeOffset ReleaseDate { get; set; }

            [JsonProperty("release_date_precision")]
            public ReleaseDatePrecision ReleaseDatePrecision { get; set; }

            [JsonProperty("total_tracks")]
            public long TotalTracks { get; set; }

            [JsonProperty("type")]
            public AlbumTypeEnum Type { get; set; }

            [JsonProperty("uri")]
            public string Uri { get; set; }
        }

        public  class Artist
        {
            [JsonProperty("external_urls")]
            public ExternalUrls ExternalUrls { get; set; }

            [JsonProperty("href")]
            public Uri Href { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public ArtistType Type { get; set; }

            [JsonProperty("uri")]
            public string Uri { get; set; }
        }

        public class ExternalUrls
        {
            [JsonProperty("spotify")]
            public Uri Spotify { get; set; }
        }

        public class Image
        {
            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }
        }

        public class ExternalIds
        {
            [JsonProperty("isrc")]
            public string Isrc { get; set; }
        }

        public enum AlbumTypeEnum { Album, Compilation, Single };

        public enum ArtistType { Artist };

        public enum ReleaseDatePrecision { Day };

        public enum ItemType { Track };

        
   

       

        internal class AlbumTypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AlbumTypeEnum) || t == typeof(AlbumTypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "album":
                        return AlbumTypeEnum.Album;
                    case "compilation":
                        return AlbumTypeEnum.Compilation;
                    case "single":
                        return AlbumTypeEnum.Single;
                }
                throw new Exception("Cannot unmarshal type AlbumTypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (AlbumTypeEnum)untypedValue;
                switch (value)
                {
                    case AlbumTypeEnum.Album:
                        serializer.Serialize(writer, "album");
                        return;
                    case AlbumTypeEnum.Compilation:
                        serializer.Serialize(writer, "compilation");
                        return;
                    case AlbumTypeEnum.Single:
                        serializer.Serialize(writer, "single");
                        return;
                }
                throw new Exception("Cannot marshal type AlbumTypeEnum");
            }

            public static readonly AlbumTypeEnumConverter Singleton = new AlbumTypeEnumConverter();
        }

        internal class ArtistTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ArtistType) || t == typeof(ArtistType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "artist")
                {
                    return ArtistType.Artist;
                }
                throw new Exception("Cannot unmarshal type ArtistType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ArtistType)untypedValue;
                if (value == ArtistType.Artist)
                {
                    serializer.Serialize(writer, "artist");
                    return;
                }
                throw new Exception("Cannot marshal type ArtistType");
            }

            public static readonly ArtistTypeConverter Singleton = new ArtistTypeConverter();
        }

        internal class ReleaseDatePrecisionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ReleaseDatePrecision) || t == typeof(ReleaseDatePrecision?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "day")
                {
                    return ReleaseDatePrecision.Day;
                }
                throw new Exception("Cannot unmarshal type ReleaseDatePrecision");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ReleaseDatePrecision)untypedValue;
                if (value == ReleaseDatePrecision.Day)
                {
                    serializer.Serialize(writer, "day");
                    return;
                }
                throw new Exception("Cannot marshal type ReleaseDatePrecision");
            }

            public static readonly ReleaseDatePrecisionConverter Singleton = new ReleaseDatePrecisionConverter();
        }

        internal class ItemTypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ItemType) || t == typeof(ItemType?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "track")
                {
                    return ItemType.Track;
                }
                throw new Exception("Cannot unmarshal type ItemType");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ItemType)untypedValue;
                if (value == ItemType.Track)
                {
                    serializer.Serialize(writer, "track");
                    return;
                }
                throw new Exception("Cannot marshal type ItemType");
            }

            public static readonly ItemTypeConverter Singleton = new ItemTypeConverter();
        }
    }


