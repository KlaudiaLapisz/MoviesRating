using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class GenreNameLengthExceededException : MovieRatingException
    {
        public GenreNameLengthExceededException() : base("Genre name length exceeded.")
        {

        }
    }
}
