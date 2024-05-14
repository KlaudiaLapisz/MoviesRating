using Microsoft.EntityFrameworkCore;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;

namespace MoviesRating.Infrastructure.Repositories
{
    internal class GenreRepository : IGenreRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GenreRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Genre genre, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(genre, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Genre genre, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(genre);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Genres.Include(x => x.Movies).ToListAsync(cancellationToken);
        }

        public async Task<Genre> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Genres.Include(x => x.Movies).SingleOrDefaultAsync(x => x.GenreId == id, cancellationToken);
        }

        public async Task<Genre> GetGenreByName(string name, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Genres.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
        }

        public async Task UpdateAsync(Genre genre, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(genre);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
