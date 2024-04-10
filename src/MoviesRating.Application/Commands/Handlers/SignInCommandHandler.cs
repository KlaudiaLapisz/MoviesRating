using MediatR;
using Microsoft.AspNetCore.Identity;
using MoviesRating.Application.DTO.Users;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    internal class SignInCommandHandler : IRequestHandler<SingInCommand, JsonWebTokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public SignInCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<JsonWebTokenDto> Handle(SingInCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByUserNameAsync(request.UserName);
            if (existingUser == null)
            {
                throw new InvalidCredentialsException();
            }
            var verifyPasswordResult = _passwordHasher.VerifyHashedPassword(default, existingUser.Password, request.Password);

            if (verifyPasswordResult == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialsException();
            }

            return new JsonWebTokenDto
            {
                AccessToken = "Success"
            };
        }
    }
}
