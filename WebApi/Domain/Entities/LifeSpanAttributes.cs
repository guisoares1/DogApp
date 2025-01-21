using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LifeSpan
    {
        [JsonPropertyName("min")]
        public int MinLife { get; set; }

        [JsonPropertyName("max")]
        public int MaxLife { get; set; }
    }

}
