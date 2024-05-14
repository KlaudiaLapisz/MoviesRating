using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Genre> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Genre genre, CancellationToken cancellationToken = default);
        Task AddAsync(Genre genre, CancellationToken cancellationToken = default);
        Task DeleteAsync(Genre genre, CancellationToken cancellationToken = default);
        Task<Genre> GetGenreByName(string name, CancellationToken cancellationToken = default);
    }
}
