using System.Text.Json.Serialization;

namespace YoutubeToSpotify.Models
{
    public class Artist
    {
        [JsonPropertyName("external_urls")]
        public string? ExternalUrls { get; set; }

        [JsonPropertyName("genres")]
        public string[]? Genres { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("popularity")]
        public int? Popularity { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }


}
