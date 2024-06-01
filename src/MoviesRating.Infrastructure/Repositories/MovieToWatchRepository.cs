using Microsoft.EntityFrameworkCore;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Repositories
{
    internal class MovieToWatchRepository : IMovieToWatchRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public MovieToWatchRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MovieToWatch movieToWatch, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(movieToWatch, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieToWatch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.MoviesToWatch
                .Include(x => x.Movie)
                .Include(x => x.User).ToListAsync(cancellationToken);
        }

        public async Task<MovieToWatch> GetAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.MoviesToWatch.SingleOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId, cancellationToken);
        }
    }
}
