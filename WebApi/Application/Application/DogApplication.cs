using Application.Mappings;
using Application.ViewMode;
using Domain.Interfaces;

namespace Application.Application
{
    public class DogApplication 
    {
        private readonly IDogService _dogService;

        public DogApplication(IDogService dogService)
        {
            _dogService = dogService;
        }

        public DogBreedVM Add(DogBreedVM dogBreedVM)
        {
            var breed = DogBreedMap.ToDomain(dogBreedVM);
            _dogService.AddBreed(breed);
            return DogBreedMap.ToViewModel(breed);
        }

        public IEnumerable<DogBreedVM> GetAll()
        {
            var breeds = _dogService.GetAllBreeds();
            return breeds.Select(DogBreedMap.ToViewModel);
        }

        public DogBreedVM GetById(string id)
        {
            var breed = _dogService.GetBreedById(id);
            return DogBreedMap.ToViewModel(breed);
        }
        public void AddBreads()
        {
            _dogService.FetchAndStoreBreeds();
        }
    }
}
