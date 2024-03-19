using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Exceptions
{
    public class DirectorDoesNotExistException : MovieRatingException
    {
        public DirectorDoesNotExistException() : base("Director does not exist.")
        {
        }
    }
}
