using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class MovieExistException : MovieRatingException
    {
        public MovieExistException() : base("Movie is already exist.")
        {

        }
    }
}
