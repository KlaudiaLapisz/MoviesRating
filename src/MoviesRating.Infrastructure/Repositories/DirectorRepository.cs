using Microsoft.EntityFrameworkCore;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;

namespace MoviesRating.Infrastructure.Repositories
{
    internal class DirectorRepository : IDirectorRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public DirectorRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Director director, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(director, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Director director, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(director);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Director>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Directors.Include(x => x.Movies).ToListAsync(cancellationToken);
        }

        public async Task<Director> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Directors.Include(x => x.Movies).SingleOrDefaultAsync(x => x.DirectorId == id, cancellationToken);
        }

        public async Task<Director> GetDirectorByFirstNameAndLastName(string firstName, string lastName, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Directors.SingleOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName, cancellationToken);
        }

        public async Task UpdateAsync(Director director, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(director);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
