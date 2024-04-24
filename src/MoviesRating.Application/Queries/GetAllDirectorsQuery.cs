using MediatR;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Queries.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetAllDirectorsQuery:IRequest<PagedList<DirectorDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
