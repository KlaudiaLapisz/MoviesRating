using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public class IncorrectYearOfProductionException : MovieRatingException
    {
        public IncorrectYearOfProductionException() : base("Incorrect year of production.")
        {

        }
    }
}
