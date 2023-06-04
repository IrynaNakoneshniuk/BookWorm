using Newtonsoft.Json;
using System.Collections.Generic;


namespace BookWorm.DTO
{
    public class TranslationResultDto
    {
        [JsonProperty("translations")]
        public List<TranslationDto> ?Translations { get; set; }
    }
}
