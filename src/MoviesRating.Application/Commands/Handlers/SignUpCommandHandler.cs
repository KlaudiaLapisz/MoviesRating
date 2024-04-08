using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
    {
        private readonly IUserRepository _userRepository;

        public SignUpCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
           var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                throw new EmailAlreadyExistException();
            }
            var existingUserName= await _userRepository.GetByUserNameAsync(request.UserName);
            if (existingUserName != null)
            {
                throw new UserNameAlreadyExistException();
            }
            var user=new User(request.UserId, request.UserName, request.Email, request.Password, request.FullName, request.Role);
            await _userRepository.AddAsync(user);
        }
    }
}
