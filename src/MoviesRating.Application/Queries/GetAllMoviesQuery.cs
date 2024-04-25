using MediatR;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetAllMoviesQuery:IRequest<PagedList<MovieDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
