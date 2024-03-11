using Microsoft.Extensions.DependencyInjection;

namespace MoviesRating.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
