using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Builders
{
    public class UserBuilder
    {
        private Guid _userId;
        private string _userName;
        private string _password;
        private string _email;
        private string _fullName;
        private string _role;

        public UserBuilder AddUserId(Guid userId)
        {
            _userId = userId;

            return this;
        }

        public UserBuilder AddUserName(string userName)
        {
            _userName = userName;

            return this;
        }

        public UserBuilder AddPassword(string password) 
        {
            _password = password; 
            
            return this;
        }

        public UserBuilder AddEmail(string email)
        {
            _email = email;

            return this;
        }

        public UserBuilder AddFullName(string fullName)
        {
            _fullName = fullName;

            return this;
        }

        public UserBuilder AddRole(string role)
        {
            _role = role;

            return this;
        }

        public User Create()
        {
            return new User(_userId, _userName, _email, _password, _fullName, _role);
        }
    }
}
