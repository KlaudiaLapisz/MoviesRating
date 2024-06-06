using MoviesRating.Domain.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Time
{
    internal class Clock : IClock
    {
        public DateTime GetCurrentDay()
        {
            return DateTime.Now;
        }
    }
}
