using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyMovieDescriptionException : MovieRatingException
    {
        public EmptyMovieDescriptionException() : base("Movie description is empty.")
        {

        }
    }
}
