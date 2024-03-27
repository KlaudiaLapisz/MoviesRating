using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Queries;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Queries.Handlers
{
    internal class GetAllDirectorsQueryHandler : IRequestHandler<GetAllDirectorsQuery, IEnumerable<DirectorDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllDirectorsQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DirectorDto>> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Directors.Select(x => new DirectorDto
            {
                DirectorId = x.DirectorId,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToListAsync();
        }
    }
}
