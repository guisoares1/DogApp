using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDogRepository
    {
        IEnumerable<DogBreed> GetAll();
        DogBreed? GetById(string id);
        void Add(DogBreed breed);
    }
}
