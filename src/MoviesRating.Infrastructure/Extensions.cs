using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;
using MoviesRating.Infrastructure.Repositories;

namespace MoviesRating.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["sqlServer:connectionString"];
            services.AddDbContext<MoviesRatingDbContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
