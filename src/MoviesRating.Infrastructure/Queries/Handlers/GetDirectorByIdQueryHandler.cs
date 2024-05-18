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
    internal class GetDirectorByIdQueryHandler : IRequestHandler<GetDirectorByIdQuery, DirectorDto>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetDirectorByIdQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DirectorDto> Handle(GetDirectorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Directors.Select(x => new DirectorDto
            {
                DirectorId = x.DirectorId,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).SingleOrDefaultAsync(x=>x.DirectorId==request.Id, cancellationToken);
        }
    }
}
