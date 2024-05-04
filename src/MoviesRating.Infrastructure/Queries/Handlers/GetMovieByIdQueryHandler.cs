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
    internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetMovieByIdQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var rates = _dbContext.Rates.Where(x => x.MovieId == request.Id).ToList();
            var sum = rates.Sum(x => x.Value);
            var count = rates.Count();
            var avg = count == 0 ? 0 : Math.Round((double)sum / count, 2);

            var movie = await _dbContext.Movies.Select(x => new MovieDto
            {
                MovieId = x.MovieId,
                Title = x.Title,
                Description = x.Description,
                Genre = new MovieGenreDto
                {
                    GenreName = x.Genre.Name,
                },
                YearOfProduction = x.YearOfProduction,
                Director = new MovieDirectorDto
                {
                    FirstName = x.Director.FirstName,
                    LastName = x.Director.LastName
                }
            }).SingleOrDefaultAsync(x => x.MovieId == request.Id);
            movie.Rate = avg;
            return movie;
        }
    }
}

