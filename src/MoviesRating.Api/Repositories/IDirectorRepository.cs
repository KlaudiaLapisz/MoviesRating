using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Movie> GetAsync(Guid id);
        Task UpdateAsync(Director director);
        Task AddAsync(Director director);
        Task DeleteAsync(Director director);
    }
}
