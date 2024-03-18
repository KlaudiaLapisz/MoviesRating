using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyMovieIdException : MovieRatingException
    {
        public EmptyMovieIdException() : base("Movie ID is empty.")
        {

        }
    }
}
