using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MoviesRating.Application.Auth;
using MoviesRating.Application.Strategies;
using MoviesRating.Domain.Entities;
namespace MoviesRating.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {           
            var assembly = typeof(Extensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddScoped<IRateMovieStrategy, RateExistMovieStrategy>();
            services.AddScoped<IRateMovieStrategy, RateNotExistMovieStrategy>();

            return services;
        }
    }
}
