using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllAsync();
        Task<Director> GetAsync(Guid id);
        Task UpdateAsync(Director director);
        Task AddAsync(Director director);
        Task DeleteAsync(Director director);
        Task<Director> GetDirectorByFirstNameAndLastName(string firstName, string lastName);
    }
}
