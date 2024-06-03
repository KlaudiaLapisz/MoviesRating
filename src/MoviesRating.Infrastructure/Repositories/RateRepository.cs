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
    internal class RateRepository : IRateRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public RateRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Rate rate, CancellationToken cancellationToken = default)
        {
            await _dbContext.Rates.AddAsync(rate, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Rates.AnyAsync(x => x.UserId == userId && x.MovieId == movieId, cancellationToken);
        }

        public async Task<Rate> GetAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Rates.SingleOrDefaultAsync(x => x.MovieId == movieId && x.UserId == userId, cancellationToken);
        }

        public async Task UpdateAsync(Rate rate, CancellationToken cancellationToken = default)
        {
            _dbContext.Rates.Update(rate);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
