using Microsoft.Extensions.DependencyInjection;
using MoviesRating.Application.Services;

namespace MoviesRating.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
