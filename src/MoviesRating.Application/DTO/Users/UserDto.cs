using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.DTO.Users
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }

    }
}
