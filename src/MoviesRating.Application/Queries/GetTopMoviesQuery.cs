﻿using MediatR;
using MoviesRating.Application.DTO.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Queries
{
    public class GetTopMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
        public string GenreName { get; set; }
        public int TopCount { get; set; } = 10;
    }
}
