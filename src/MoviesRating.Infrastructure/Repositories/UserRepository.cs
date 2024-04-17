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
    internal class UserRepository : IUserRepository
    {
        private readonly MoviesRatingDbContext _dbContext;

        public UserRepository(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x=>x.UserName == userName);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.UserId == id);
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
