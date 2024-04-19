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
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
           var existingUser = await _userRepository.GetUserByIdAsync(request.UserId);
            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            existingUser.ChangeUserName(request.UserName);
            existingUser.ChangeEmail(request.Email);
            existingUser.ChangeFullName(request.FullName);

            await _userRepository.UpdateAsync(existingUser);
        }
    }
}
