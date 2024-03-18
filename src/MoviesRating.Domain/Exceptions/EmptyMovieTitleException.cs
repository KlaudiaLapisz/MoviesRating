using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyMovieTitleException : MovieRatingException
    {
        public EmptyMovieTitleException() : base("Movie title is empty.")
        {
        }
    }
}
