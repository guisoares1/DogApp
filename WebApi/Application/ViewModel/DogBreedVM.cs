﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewMode
{
    public class DogBreedVM
    {
        public required string DogId { get; set; } 
        public required string Name { get; set; } 
        public int MinLife { get; set; } 
        public int MaxLife { get; set; } 
        public required string Description { get; set; } 
        public bool Hypoallergenic { get; set; }
    }

}
