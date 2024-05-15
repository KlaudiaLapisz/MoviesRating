using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<User> GetByUserNameAsync (string userName, CancellationToken cancellationToken = default);
        Task AddAsync (User user, CancellationToken cancellationToken = default);
        Task<User> GetUserByIdAsync (Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync (User user, CancellationToken cancellationToken = default);
        Task DeleteAsync (User user, CancellationToken cancellationToken = default);
    }
}
