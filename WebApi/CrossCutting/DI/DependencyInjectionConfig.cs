using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IDogRepository, DogRepository>();

            services.AddHttpClient<IDogApiService, DogApiService>(client =>
            {
                client.BaseAddress = new Uri("https://api.thedogapi.com/v2/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
