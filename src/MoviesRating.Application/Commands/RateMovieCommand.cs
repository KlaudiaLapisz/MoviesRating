using MediatR;
using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands
{
    public class RateMovieCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public int Value { get; set; }

    }
}
