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

        public async Task AddAsync(Rate rate)
        {
            await _dbContext.Rates.AddAsync(rate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Rate> GetAsync(Guid userId, Guid movieId)
        {
            return await _dbContext.Rates.SingleOrDefaultAsync(x => x.MovieId == movieId && x.UserId == userId);
        }

        public async Task UpdateAsync(Rate rate)
        {
            _dbContext.Rates.Update(rate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
