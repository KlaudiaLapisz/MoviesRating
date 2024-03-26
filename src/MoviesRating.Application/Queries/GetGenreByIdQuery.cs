using MediatR;
using MoviesRating.Application.DTO.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetGenreByIdQuery:IRequest<GenreDto>
    {
        public Guid Id {  get; set; }
    }
}
