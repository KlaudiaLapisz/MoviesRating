using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Genres;
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
    internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, PagedList<GenreDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllGenresQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request.PageNumber - 1) * request.PageSize;
            var count = await _dbContext.Genres.CountAsync(cancellationToken);
            var totalPageNumber = (int)Math.Ceiling(count / (double)request.PageSize);
            var items = await _dbContext.Genres
                .OrderBy(x => x.Name)
                .Skip(skipCount)
                .Take(request.PageSize)
                .Select(x => new GenreDto
                {
                    GenreId = x.GenreId,
                    Name = x.Name,
                }).ToListAsync(cancellationToken);
            
            return new PagedList<GenreDto>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPageNumber = totalPageNumber,
                Items = items
            };
        }
    }
}
