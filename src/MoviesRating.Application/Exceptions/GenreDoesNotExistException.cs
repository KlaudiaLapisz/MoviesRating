using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class GenreDoesNotExistException : MovieRatingException
    {
        public GenreDoesNotExistException() : base("Genre does not exist.")
        {
        }
    }
}
