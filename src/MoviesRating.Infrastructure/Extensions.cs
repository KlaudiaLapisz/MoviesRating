using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;
using MoviesRating.Infrastructure.Exceptions;
using MoviesRating.Infrastructure.Repositories;
using System.Text;

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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<ErrorHandlingMiddleware>();
            var assembly = typeof(Extensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            var issuer = configuration["auth:issuer"];
            var audience = configuration["auth:audience"];
            var signingKey = configuration["auth:signingKey"];
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Audience = audience;
                o.IncludeErrorDetails = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                };
            });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
