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
    internal class FavouriteMovieRepository : IFavouriteMovieRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public FavouriteMovieRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(FavouriteMovie favouriteMovie, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(favouriteMovie, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(FavouriteMovie favouriteMovie, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(favouriteMovie);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<FavouriteMovie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Favourites
                .Include(x => x.Movie)
                .Include(x => x.User).ToListAsync(cancellationToken);
        }

        public async Task<FavouriteMovie> GetFavouriteMovieAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Favourites.SingleOrDefaultAsync(x => x.MovieId == movieId && x.UserId == userId, cancellationToken);
        }
    }
}
