using Newtonsoft.Json;


namespace BookWorm.DTO
{
    public class PersonDto
    {
        [JsonProperty("birth_year")]
        public int? BirthYear { get; set; }

        [JsonProperty("death_year")]
        public int? DeathYear { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
