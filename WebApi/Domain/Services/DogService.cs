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
            try
            {
                return _dogRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting all races.", ex);
            }
        }

        public DogBreed GetBreedById(string id)
        {
            try
            {
                return _dogRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error getting the race with ID {id}.", ex);
            }
        }

        public void AddBreed(DogBreed breed)
        {
            try
            {
                _dogRepository.Add(breed);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error to adding the races {breed.Name}.", ex);
            }
        }

        public void FetchAndStoreBreeds()
        {
            var page = 1;

            try
            {
                while (page < 29)
                {
                    var breeds = _dogApiService.GetBreedsByPage(page).ToList();
                    bool pageProcessed = false;

                    foreach (var breed in breeds)
                    {
                        if (PageVisited(breed.DogId))
                            continue; 

                        _dogRepository.Add(breed);
                        pageProcessed = true; 
                    }

                    
                    if (pageProcessed)
                        break;

                    page++; 
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error when searching and storing breeds.", ex);
            }
        }

        private bool PageVisited(string dogId)
        {
            return _dogRepository.GetById(dogId) != null;
        }
    }
}
