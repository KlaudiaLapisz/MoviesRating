using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetAsync(Guid id);
        Task UpdateAsync(Genre genre);
        Task AddAsync(Genre genre);
        Task DeleteAsync(Genre genre);
        Task<Genre> GetGenreByName(string name);
    }
}
