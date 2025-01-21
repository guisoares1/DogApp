using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DogBreedResponse
    {
        public required string Id { get; set; }
        public required string Type { get; set; }
        public DogBreedAttributes? Attributes { get; set; }
    }
}
