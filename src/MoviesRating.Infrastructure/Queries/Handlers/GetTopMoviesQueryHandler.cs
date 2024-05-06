using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Queries.Handlers
{
    internal class GetTopMoviesQueryHandler : IRequestHandler<GetTopMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetTopMoviesQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetTopMoviesQuery request, CancellationToken cancellationToken)
        { 
            // TODO: Add genre and director!
            var topMovies = await _dbContext.Rates
                .GroupBy(x => x.Movie).Select(g => new
            {
                Movie = g.Key,
                Rate = g.Average(x => x.Value)
            }).OrderByDescending(x => x.Rate).Take(10)
            .Select(x=>new MovieDto
            {
                MovieId = x.Movie.MovieId,
                Title = x.Movie.Title,
                Description = x.Movie.Description,                
                YearOfProduction = x.Movie.YearOfProduction,
                Rate=x.Rate
            })
            .ToListAsync();
            return topMovies;
        }
    }
}
