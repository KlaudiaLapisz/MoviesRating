using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);
        Task AddAsync(Movie movie, CancellationToken cancellationToken = default);
        Task DeleteAsync(Movie movie, CancellationToken cancellationToken = default);
        Task<Movie> GetMovieByTitleAndYearOfProductionAsync(string title, int yearOfProduction, CancellationToken cancellationToken = default);
    }
}
