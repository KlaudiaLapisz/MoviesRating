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
        Task<Rate> GetAsync(Guid userId, Guid movieId);
        Task AddAsync(Rate rate);
        Task UpdateAsync(Rate rate);
    }
}
