using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Repositories
{
    public interface IFavouriteMovieRepository
    {
        Task AddAsync(FavouriteMovie favouriteMovie, CancellationToken cancellationToken = default);
        Task<FavouriteMovie> GetFavouriteMovie (Guid userId, Guid movieId, CancellationToken cancellationToken = default);
    }
}
