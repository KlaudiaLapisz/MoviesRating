using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Repositories
{
    public interface IMovieToWatchRepository
    {
        Task AddAsync(MovieToWatch movieToWatch, CancellationToken cancellationToken = default);
        Task<MovieToWatch> GetAsync(Guid userId, Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieToWatch>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
