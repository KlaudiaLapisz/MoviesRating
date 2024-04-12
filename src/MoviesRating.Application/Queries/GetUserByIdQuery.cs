using MediatR;
using MoviesRating.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
