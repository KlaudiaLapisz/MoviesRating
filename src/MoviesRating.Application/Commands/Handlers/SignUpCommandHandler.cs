using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public SignUpCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
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

            var hashedPassword = _passwordHasher.HashPassword(default, request.Password);
            var user=new User(request.UserId, request.UserName, request.Email, hashedPassword, request.FullName, request.Role);
            await _userRepository.AddAsync(user);
        }
    }
}
