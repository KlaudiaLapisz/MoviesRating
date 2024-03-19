using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class GenreExistException : MovieRatingException
    {
        public GenreExistException() : base("Genre is already existing.")
        {

        }
    }
}
