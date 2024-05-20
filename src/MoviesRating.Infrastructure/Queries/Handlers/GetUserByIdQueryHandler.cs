using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Users;
using MoviesRating.Application.Queries;
using MoviesRating.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.Queries.Handlers
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetUserByIdQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);
            if (user == null)
            {
                return null;
            }

            return new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
            };
        }
    }
}
