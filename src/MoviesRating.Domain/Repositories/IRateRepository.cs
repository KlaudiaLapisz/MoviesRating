using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Repositories
{
    public interface IRateRepository
    {
        Task<Rate> GetAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default);
        Task AddAsync(Rate rate, CancellationToken cancellationToken = default);
        Task UpdateAsync(Rate rate, CancellationToken cancellationToken = default);
    }
}
