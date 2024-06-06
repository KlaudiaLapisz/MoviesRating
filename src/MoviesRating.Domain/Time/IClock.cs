using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Time
{
    public interface IClock
    {
        DateTime GetCurrentDay();
        
    }
}
