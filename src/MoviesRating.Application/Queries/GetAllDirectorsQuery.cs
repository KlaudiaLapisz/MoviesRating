using MediatR;
using MoviesRating.Application.DTO.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetAllDirectorsQuery:IRequest<IEnumerable<DirectorDto>>
    {

    }
}
