using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DogBreedAttributes
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("life")]
        public LifeSpan Life { get; set; }  
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        public bool Hypoallergenic { get; set; }
        [JsonPropertyName("male_weight")]
        public Weight MaleWeight { get; set; }
        [JsonPropertyName("female_weight")]
        public Weight FemaleWeight { get; set; }
    }
}
