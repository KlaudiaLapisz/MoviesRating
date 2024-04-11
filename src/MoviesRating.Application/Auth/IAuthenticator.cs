using MoviesRating.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Auth
{
    public interface IAuthenticator
    {
        JsonWebTokenDto CreateToken(Guid userId, string role);
    }
}
