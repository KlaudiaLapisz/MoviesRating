using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyGenreNameException : MovieRatingException
    {
        public EmptyGenreNameException() : base("Genre name is empty.")
        {

        }
    }
}
