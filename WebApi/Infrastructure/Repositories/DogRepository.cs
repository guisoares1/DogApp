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
            return _context.DogBreed.ToList();
        }

        public DogBreed? GetById(string id)
        {
            return _context.DogBreed.FirstOrDefault(d => d.DogId == id);
        }

        public void Add(DogBreed breed)
        {
            _context.DogBreed.Add(breed);
            _context.SaveChanges();
        }
    }
}
