using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class MovieToWatchAlreadyAddedException : MovieRatingException
    {
        public MovieToWatchAlreadyAddedException() : base("Movie is already added to movie to watch")
        {
        }
    }
}
