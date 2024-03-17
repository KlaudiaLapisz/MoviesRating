using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class EmptyDirectorLastNameException : MovieRatingException
    {
        public EmptyDirectorLastNameException() : base("Empty director last name.")
        {

        }
    }
}
