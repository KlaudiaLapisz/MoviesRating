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
        public ICollection<Rate> Rates { get; set; }
        public ICollection<FavouriteMovie> FavouriteMovies { get; set; }
        public ICollection<MovieToWatch> MoviesToWatch { get; set; }

        private User()
        {

        }

        public User(Guid userId, string userName, string email, string password, string fullName, string role)
        {
            if (userId == Guid.Empty)
            {
                throw new EmptyUserIdException();
            }
            UserId = userId;

            ChangeUserName(userName);

            ChangeEmail(email);

            ChangePassword(password);

            ChangeRole(role);
            ChangeFullName(fullName);
        }

        public void ChangePassword(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new EmptyPasswordException();
            }
            Password = newPassword;
        }

        public void ChangeRole(string newRole)
        {
            if (string.IsNullOrEmpty(newRole))
            {
                throw new EmptyRoleException();
            }
            Role = newRole;
        }

        public void ChangeUserName(string newUserName)
        {
            if (string.IsNullOrEmpty(newUserName))
            {
                throw new EmptyUserNameException();
            }
            if (newUserName.Length > 50)
            {
                throw new UserNameLengthExceededException();
            }
            UserName = newUserName;
        }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail))
            {
                throw new EmptyEmailException();
            }
            if (newEmail.Length > 50)
            {
                throw new EmailLengthExceededException();
            }
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(newEmail);
            if (!match.Success)
            {
                throw new InvalidEmailFormatException();
            }
            Email = newEmail;
        }

        public void ChangeFullName(string newFullName)
        {
            if (string.IsNullOrEmpty(newFullName))
            {
                throw new EmptyFullNameException();
            }
            if (newFullName.Length > 100)
            {
                throw new FullNameLengthExceededException();
            }
            FullName = newFullName;

        }
    }
}
