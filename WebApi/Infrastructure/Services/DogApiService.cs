using Domain.Entities;
using Domain.Interfaces;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class DogApiService : IDogApiService
    {
        private readonly HttpClient _httpClient;

        public DogApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<DogBreed> GetBreedsByPage(int pageNumber)
        {
            var response = _httpClient.GetAsync($"https://dogapi.dog/api/v2/breeds?page[number]={pageNumber}").Result;
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var breeds = JsonSerializer.Deserialize<DogBreedResponseWrapper>(content, options);

            var dogBreeds = new List<DogBreed>();
            foreach (var breed in breeds.Data)
            {
                dogBreeds.Add(new DogBreed
                {
                    DogId = breed.Id,                               
                    Name = breed.Attributes.Name,                    
                    MinLife = breed.Attributes.Life.MinLife,        
                    MaxLife = breed.Attributes.Life.MaxLife,         
                    Description = breed.Attributes.Description,     
                    Hypoallergenic = breed.Attributes.Hypoallergenic 
                });
            }

            return dogBreeds;
        }
    }
}
