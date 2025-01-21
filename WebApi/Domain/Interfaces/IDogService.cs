using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDogService
    {
        IEnumerable<DogBreed> GetAllBreeds();
        DogBreed GetBreedById(string id);
        void AddBreed(DogBreed breed);
        void FetchAndStoreBreeds();
    }
}
