using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Director> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(Director director, CancellationToken cancellationToken = default);
        Task AddAsync(Director director, CancellationToken cancellationToken = default);
        Task DeleteAsync(Director director, CancellationToken cancellationToken = default);
        Task<Director> GetDirectorByFirstNameAndLastName(string firstName, string lastName, CancellationToken cancellationToken = default);
    }
}
