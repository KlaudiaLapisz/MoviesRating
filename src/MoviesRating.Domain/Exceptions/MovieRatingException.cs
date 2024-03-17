using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Exceptions
{
    public abstract class MovieRatingException:Exception
    {
        protected MovieRatingException(string message):base(message)
        {
            
        }
    }
}
