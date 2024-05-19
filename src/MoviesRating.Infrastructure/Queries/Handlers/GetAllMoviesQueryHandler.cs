using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
using MoviesRating.Application.Queries.Shared;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Queries.Handlers
{
    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, PagedList<MovieDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllMoviesQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request.PageNumber - 1) * request.PageSize;
            var count = await _dbContext.Directors.CountAsync(cancellationToken);
            var totalPageNumber = (int)Math.Ceiling(count / (double)request.PageSize);
            var items = await _dbContext.Movies
                .OrderBy(x => x.Title)
                .Skip(skipCount)
                .Take(request.PageSize)
                .Select(x => new MovieDto
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
                }).ToListAsync(cancellationToken);

            return new PagedList<MovieDto>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPageNumber = totalPageNumber,
                Items = items
            };
        }
    }
}
