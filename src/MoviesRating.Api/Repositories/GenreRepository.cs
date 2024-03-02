using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GenreRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Genre genre)
        {
            await _dbContext.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre genre)
        {
            _dbContext.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.Include(x => x.Movies).ToListAsync();
        }

        public async Task<Genre> GetAsync(Guid id)
        {
            return await _dbContext.Genres.Include(x => x.Movies).SingleOrDefaultAsync(x => x.GenreId == id);
        }

        public async Task UpdateAsync(Genre genre)
        {
            _dbContext.Update(genre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
