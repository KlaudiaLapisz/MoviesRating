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
    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllMoviesQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Movies.Select(x => new MovieDto
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                Genre = new MovieGenreDto
                {
                    GenreName=x.Genre.Name,
                },
                YearOfProduction = x.YearOfProduction,
                Director = new MovieDirectorDto
                {
                    FirstName=x.Director.FirstName,
                    LastName=x.Director.LastName
                }
            }).ToListAsync();
        }
    }
}
