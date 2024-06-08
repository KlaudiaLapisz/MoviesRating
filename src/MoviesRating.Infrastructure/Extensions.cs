using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoviesRating.Application.Commands;
using MoviesRating.Domain.Repositories;
using MoviesRating.Domain.Time;
using MoviesRating.Infrastructure.DAL;
using MoviesRating.Infrastructure.Exceptions;
using MoviesRating.Infrastructure.HostedServices;
using MoviesRating.Infrastructure.Logging;
using MoviesRating.Infrastructure.Logging.Decorators;
using MoviesRating.Infrastructure.Repositories;
using MoviesRating.Infrastructure.Time;
using MoviesRating.Infrastructure.UnitOfWorks;
using MoviesRating.Infrastructure.UnitOfWorks.Decorators;
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
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IFavouriteMovieRepository, FavouriteMovieRepository>();
            services.AddScoped<IMovieToWatchRepository, MovieToWatchRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClock, Clock>();
            services.AddSingleton<ErrorHandlingMiddleware>();
            services.AddSingleton<LoggingMiddleware> ();
            services.AddHostedService<DatabaseInitializer>();
            services.Decorate<IRequestHandler<RateMovieCommand>, LoggingRateMovieCommandHandlerDecorator>();
            services.TryDecorate(typeof(IRequestHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
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
            services.AddSwaggerGen(swagger =>
            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MoviesRating API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesRating API");
                c.RoutePrefix = "docs";
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<LoggingMiddleware>();

            return app;
        }
    }
}
