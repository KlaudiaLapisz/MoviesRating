using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class MovieDoesNotExistException : MovieRatingException
    {
        public MovieDoesNotExistException() : base("Movie does not exist.")
        {
        }
    }
}
