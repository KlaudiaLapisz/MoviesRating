using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Genres;
using MoviesRating.Application.Queries;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Queries.Handlers
{
    internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllGenresQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Genres.Select(x => new GenreDto
            {
                GenreId = x.GenreId,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}
