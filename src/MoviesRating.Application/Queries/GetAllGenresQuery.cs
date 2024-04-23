using MediatR;
using MoviesRating.Application.DTO.Genres;
using MoviesRating.Application.Queries.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetAllGenresQuery:IRequest<PagedList<GenreDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
