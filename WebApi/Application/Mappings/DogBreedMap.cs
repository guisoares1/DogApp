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
                Id = vm.Id,
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
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                Hypoallergenic = domain.Hypoallergenic,
                MaxLife = domain.MaxLife,
                MinLife = domain.MinLife
            };
        }
    }
}
