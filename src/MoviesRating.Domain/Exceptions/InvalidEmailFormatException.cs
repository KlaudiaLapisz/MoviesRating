using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class InvalidEmailFormatException : MovieRatingException
    {
        public InvalidEmailFormatException() : base("Email format is not valid")
        {
        }
    }
}
