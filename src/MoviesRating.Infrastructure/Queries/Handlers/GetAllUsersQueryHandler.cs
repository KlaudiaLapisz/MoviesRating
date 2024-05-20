using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesRating.Application.DTO.Users;
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
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedList<UserDto>>
    {
        private readonly MoviesRatingDbContext _dbContext;

        public GetAllUsersQueryHandler(MoviesRatingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var skipCount = (request.PageNumber - 1) * (request.PageSize);
            var count = await _dbContext.Users.CountAsync(cancellationToken);
            var totalPageNumber = (int)Math.Ceiling(count / (double)request.PageSize);
            var items = await _dbContext.Users
                .OrderBy(x => x.UserName)
                .Skip(skipCount)
                .Take(request.PageSize)
                .Select(x => new UserDto
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    FullName = x.FullName,
                    Email = x.Email,
                    Role = x.Role,
                }).ToListAsync(cancellationToken);
            return new PagedList<UserDto>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPageNumber = totalPageNumber,
                Items = items
            };
        }
    }
}
