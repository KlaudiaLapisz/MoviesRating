using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

        public User(Guid userId, string userName, string email, string password, string fullName, string role)
        {
            if (userId == Guid.Empty)
            {
                throw new EmptyUserIdException();
            }
            UserId = userId;

            if (string.IsNullOrEmpty(userName))
            {
                throw new EmptyUserNameException();
            }
            if (userName.Length > 50)
            {
                throw new UserNameLengthExceededException();
            }
            UserName = userName;

            if (string.IsNullOrEmpty(email))
            {
                throw new EmptyEmailException();
            }
            if (email.Length > 50)
            {
                throw new EmailLengthExceededException();
            }

            var emailPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            if (Regex.IsMatch(email, emailPattern))
            {
                throw new InvalidEmailFormatException();
            }
            Email = email;

            if (string.IsNullOrEmpty(password))
            {
                throw new EmptyPasswordException();
            }
            Password = password;

            if (string.IsNullOrEmpty(fullName))
            {
                throw new EmptyFullNameException();
            }
            if (fullName.Length > 100)
            {
                throw new FullNameLengthExceededException();
            }
            FullName = fullName;

            if (string.IsNullOrEmpty(role))
            {
                throw new EmptyRoleException();
            }
            Role = role;
        }
    }
}
