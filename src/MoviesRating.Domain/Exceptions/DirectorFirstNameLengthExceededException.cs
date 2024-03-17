using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class DirectorFirstNameLengthExceededException : MovieRatingException
    {
        public DirectorFirstNameLengthExceededException() : base("Director first name length exceeded.")
        {

        }
    }
}
