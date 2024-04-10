using MediatR;
using MoviesRating.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands
{
    public class SingInCommand : IRequest<JsonWebTokenDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
