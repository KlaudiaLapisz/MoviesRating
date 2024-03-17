using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class DirectorLastNameLengthExceededException : MovieRatingException
    {
        public DirectorLastNameLengthExceededException() : base("Director last name length exceeded.")
        {

        }
    }
}
