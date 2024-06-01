﻿using MediatR;
using Microsoft.EntityFrameworkCore;
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
    internal class GetAllMoviesToWatchQueryHandler : IRequestHandler<GetAllMoviesToWatchQuery, PagedList<MovieDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllMoviesToWatchQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<MovieDto>> Handle(GetAllMoviesToWatchQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request.PageNumber - 1) * request.PageSize;
            var count = await _dbContext.MoviesToWatch.Where(x => x.UserId == request.UserId).CountAsync(cancellationToken);
            var totalPageNumber = (int)Math.Ceiling(count / (double)request.PageSize);
            var items = await _dbContext.MoviesToWatch
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Movie.Title)
                .Skip(skipCount)
                .Take(request.PageSize)
                .Select(x => new MovieDto
                {
                    MovieId = x.MovieId,
                    Title = x.Movie.Title,
                    Description = x.Movie.Description,
                    Genre = new MovieGenreDto
                    {
                        GenreName = x.Movie.Genre.Name,
                    },
                    YearOfProduction = x.Movie.YearOfProduction,
                    Director = new MovieDirectorDto
                    {
                        FirstName = x.Movie.Director.FirstName,
                        LastName = x.Movie.Director.LastName
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
