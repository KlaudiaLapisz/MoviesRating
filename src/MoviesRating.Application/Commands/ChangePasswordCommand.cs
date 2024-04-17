using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands
{
    public class ChangePasswordCommand: IRequest
    {
        public Guid UserId { get; set; } 
        public string Password { get; set; }
    }
}
