using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public DirectorRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Director director)
        {
            await _dbContext.AddAsync(director);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Director director)
        {
            _dbContext.Remove(director);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            return await _dbContext.Directors.Include(x => x.Movies).ToListAsync();
        }

        public async Task<Director> GetAsync(Guid id)
        {
            return await _dbContext.Directors.Include(x => x.Movies).SingleOrDefaultAsync(x => x.DirectorId == id);
        }

        public async Task UpdateAsync(Director director)
        {
            _dbContext.Update(director);
            await _dbContext.SaveChangesAsync();
        }
    }
}
