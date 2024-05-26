using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class FavouriteMovieAlreadyAddedException : MovieRatingException
    {
        public FavouriteMovieAlreadyAddedException() : base("Movie is already added to favourite")
        {
        }
    }
}
