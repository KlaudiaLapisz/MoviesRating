using Microsoft.EntityFrameworkCore;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;

namespace MoviesRating.Infrastructure.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public MovieRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(movie, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(movie);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Movies
                .Include(x => x.Genre)
                .Include(x => x.Director).ToListAsync(cancellationToken);
        }

        public async Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Movies
                .Include(x => x.Genre)
                .Include(x => x.Director)
                .SingleOrDefaultAsync(x => x.MovieId == id, cancellationToken);
        }

        public async Task<Movie> GetMovieByTitleAndYearOfProductionAsync(string title, int yearOfProduction, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Movies.SingleOrDefaultAsync(x => x.Title == title && x.YearOfProduction == yearOfProduction, cancellationToken);

        }

        public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _dbContext.Update(movie);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
