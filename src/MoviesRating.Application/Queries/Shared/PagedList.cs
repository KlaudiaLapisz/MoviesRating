using MoviesRating.Application.DTO.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries.Shared
{
    public class PagedList<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPageNumber { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
