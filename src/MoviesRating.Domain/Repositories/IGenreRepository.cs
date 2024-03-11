using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
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
