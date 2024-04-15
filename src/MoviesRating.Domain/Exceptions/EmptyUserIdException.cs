using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyUserIdException : MovieRatingException
    {
        public EmptyUserIdException() : base("User ID is empty")
        {
        }
    }
}
