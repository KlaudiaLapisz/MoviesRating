using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
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
