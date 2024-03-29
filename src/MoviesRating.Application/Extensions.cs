using Microsoft.Extensions.DependencyInjection;
namespace MoviesRating.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {           
            var assembly = typeof(Extensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            return services;
        }
    }
}
