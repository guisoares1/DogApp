using Application.ViewMode;
using Domain.Entities;

namespace Application.Mappings
{
    public static class DogBreedMap
    {
        public static DogBreed ToDomain(DogBreedVM vm)
        {
            return new DogBreed
            {
                DogId = vm.DogId,
                Name = vm.Name,
                Description = vm.Description,
                Hypoallergenic = vm.Hypoallergenic,
                MaxLife = vm.MaxLife,
                MinLife = vm.MinLife
            };
        }

        public static DogBreedVM ToViewModel(DogBreed domain)
        {
            return new DogBreedVM
            {
                DogId = domain.DogId,
                Name = domain.Name,
                Description = domain.Description,
                Hypoallergenic = domain.Hypoallergenic,
                MaxLife = domain.MaxLife,
                MinLife = domain.MinLife
            };
        }
    }
}
