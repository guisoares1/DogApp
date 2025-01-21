using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly ApplicationDbContext _context;

        public DogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DogBreed> GetAll()
        {
            return _context.DogBreeds.ToList();
        }

        public DogBreed? GetById(string id)
        {
            return _context.DogBreeds.FirstOrDefault(d => d.Id == id);
        }

        public void Add(DogBreed breed)
        {
            _context.DogBreeds.Add(breed);
            _context.SaveChanges();
        }
    }
}
