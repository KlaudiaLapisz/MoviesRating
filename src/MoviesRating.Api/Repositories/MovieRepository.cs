using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.DAL;
using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public MovieRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Movie movie)
        {
            await _dbContext.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            _dbContext.Remove(movie);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies
                .Include(x => x.Genre)
                .Include(x => x.Director).ToListAsync();
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            return await _dbContext.Movies
                .Include(x => x.Genre)
                .Include(x => x.Director)
                .SingleOrDefaultAsync(x => x.MovieId == id);
        }

        public async Task<Movie> GetMovieByTitleAndYearOfProductionAsync(string title, int yearOfProduction)
        {
            return await _dbContext.Movies.SingleOrDefaultAsync(x => x.Title == title && x.YearOfProduction == yearOfProduction);

        }

        public async Task UpdateAsync(Movie movie)
        {
            _dbContext.Update(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
