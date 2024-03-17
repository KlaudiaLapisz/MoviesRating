using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyGenreIdException : MovieRatingException
    {
        public EmptyGenreIdException() : base("Genre ID is empty.")
        {

        }
    }
}
