using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChangeRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            user.ChangeRole(request.NewRole);
            await _userRepository.UpdateAsync(user);
        }
    }
}
