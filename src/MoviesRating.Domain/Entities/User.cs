using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            UserId = userId;
            UserName = userName;
            Email = email;
            Password = password;
            FullName = fullName;
            Role = role;
        }
    }
}
