using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
using MoviesRating.Domain.Entities;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            var query = _dbContext.Rates.AsQueryable();
            if (!string.IsNullOrEmpty(request.GenreName))
            {
                query = query.Where(x => x.Movie.Genre.Name == request.GenreName);
            }

            var topMovies = await query
            .GroupBy(x => new
            {
                x.Movie.MovieId,
                x.Movie.Title,
                x.Movie.Description,
                x.Movie.YearOfProduction,
                x.Movie.Genre.Name,
                x.Movie.Director.FirstName,
                x.Movie.Director.LastName,

            })
            .Select(x => new MovieDto
            {
                MovieId = x.Key.MovieId,
                Title = x.Key.Title,
                Description = x.Key.Description,
                YearOfProduction = x.Key.YearOfProduction,
                Rate = x.Average(x => x.Value),
                Genre = new MovieGenreDto
                {
                    GenreName = x.Key.Name
                },
                Director = new MovieDirectorDto
                {
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName
                }
            })
            .OrderByDescending(x => x.Rate).Take(request.TopCount)
        .ToListAsync(cancellationToken);

            return topMovies;
        }
    }
}
