using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Directors;
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
    internal class GetAllDirectorsQueryHandler : IRequestHandler<GetAllDirectorsQuery, PagedList<DirectorDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllDirectorsQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<DirectorDto>> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request.PageNumber - 1) * request.PageSize;
            var count = await _dbContext.Directors.CountAsync();
            var totalPageNumber = (int)Math.Ceiling(count / (double)request.PageSize);
            var items = await _dbContext.Directors
                .OrderBy(x => x.LastName)
                .Skip(skipCount)
                .Take(request.PageSize)
                .Select(x => new DirectorDto
                {
                    DirectorId = x.DirectorId,
                    FirstName = x.FirstName,
                    LastName = x.LastName                   
                }).ToListAsync();

            return new PagedList<DirectorDto>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPageNumber = totalPageNumber,
                Items = items
            };
        }

    }
}
