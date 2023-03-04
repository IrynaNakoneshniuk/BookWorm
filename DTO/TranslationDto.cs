using Newtonsoft.Json;

namespace BookWorm.DTO
{
    public class TranslationDto
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
    }
}
