using MoviesRating.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
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

            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (!match.Success)
            {
                throw new InvalidEmailFormatException();
            }
            Email = email;

            ChangePassword(password);

            if (string.IsNullOrEmpty(fullName))
            {
                throw new EmptyFullNameException();
            }
            if (fullName.Length > 100)
            {
                throw new FullNameLengthExceededException();
            }
            FullName = fullName;

            ChangeRole(role);
        }

        public void ChangePassword (string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new EmptyPasswordException();
            }
            Password = newPassword;
        }

        public void ChangeRole (string newRole)
        {
            if (string.IsNullOrEmpty(newRole))
            {
                throw new EmptyRoleException();
            }
            Role = newRole;
        }
    }
}
