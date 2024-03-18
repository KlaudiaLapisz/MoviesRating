using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class MovieTitleLengthExceededException : MovieRatingException
    {
        public MovieTitleLengthExceededException() : base("Movie title length exceeded.")
        {

        }
    }
}
