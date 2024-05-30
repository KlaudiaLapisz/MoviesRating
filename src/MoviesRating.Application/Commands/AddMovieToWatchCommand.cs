using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands
{
    public class AddMovieToWatchCommand:IRequest
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}
