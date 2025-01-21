using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;
        private readonly IDogApiService _dogApiService;

        public DogService(IDogApiService dogApiService, IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
            _dogApiService = dogApiService;
        }

        public IEnumerable<DogBreed> GetAllBreeds()
        {
            return _dogRepository.GetAll();
        }

        public DogBreed GetBreedById(string id)
        {
            return _dogRepository.GetById(id);
        }

        public void AddBreed(DogBreed breed)
        {
            _dogRepository.Add(breed);
        }

        public void FetchAndStoreBreeds()
        {
            var page = 1;
            do
            {
                var breeds = _dogApiService.GetBreedsByPage(page).ToList();
                if (PageVisited(breeds[0].Id))
                {
                    page++;
                    continue;
                }

                foreach (var breed in breeds)
                    _dogRepository.Add(breed);
                
                page++;
            } while (page < 29);
        }
        private bool PageVisited(string dogId)
        {
            return _dogRepository.GetById(dogId) != null;
        }
    }
}
