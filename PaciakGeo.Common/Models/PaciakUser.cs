using System.Text.Json.Serialization;

namespace PaciakGeo.Common.Models
{
    public class PaciakUser
    {
        [JsonPropertyName("uid")]
        public int Uid { get; set; }
        [JsonPropertyName("username")]
        public string Name { get; set; }
        [JsonPropertyName("userslug")]
        public string Slug { get; set; }
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}