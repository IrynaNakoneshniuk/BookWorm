using Newtonsoft.Json;
using System.Collections.Generic;


namespace BookWorm.DTO
{
    public class BookDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("authors")]
        public List<PersonDto>? Authors { get; set; }

        [JsonProperty("translators")]
        public List<PersonDto>? Translators { get; set; }

        [JsonProperty("subjects")]
        public List<string>? Subjects { get; set; }

        [JsonProperty("bookshelves")]
        public List<string>? Bookshelves { get; set; }

        [JsonProperty("languages")]
        public List<string>? Languages { get; set; }

        [JsonProperty("copyright")]
        public bool? Copyright { get; set; }

        [JsonProperty("media_type")]
        public string? MediaType { get; set; }

        [JsonProperty("formats")]
        public Dictionary<string, string>? Formats { get; set; }

        [JsonProperty("download_count")]
        public int? DownloadCount { get; set; }
    }
}
