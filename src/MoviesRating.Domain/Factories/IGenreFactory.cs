using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Factories
{
    public interface IGenreFactory
    {
        Genre CreateGenre(Guid genreId, string genreName);
    }
}
