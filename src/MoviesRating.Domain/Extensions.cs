using Microsoft.Extensions.DependencyInjection;
using MoviesRating.Domain.Factories;

namespace MoviesRating.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IGenreFactory, GenreFactory>();
            services.AddScoped<IDirectorFactory, DirectorFactory>();
            
            return services;
        }
    }
}
