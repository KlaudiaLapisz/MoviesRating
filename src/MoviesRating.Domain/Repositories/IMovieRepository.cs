using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetAsync(Guid id);
        Task UpdateAsync(Movie movie);
        Task AddAsync(Movie movie);
        Task DeleteAsync(Movie movie);
        Task<Movie> GetMovieByTitleAndYearOfProductionAsync(string title, int yearOfProduction);
    }
}
