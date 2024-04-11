using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesRating.Application.DTO.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesRating.Application.Auth
{
    internal class Authenticator : IAuthenticator
    {
        private readonly string _issuer;
        private readonly TimeSpan _expiry;
        private readonly string _audience;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityToken = new JwtSecurityTokenHandler();

        public Authenticator(IConfiguration configuration)
        {
            _issuer = configuration["auth:issuer"];
            _audience = configuration["auth:audience"];
            _expiry = TimeSpan.Parse(configuration["auth:expiry"]);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["auth:signingKey"])),
                    SecurityAlgorithms.HmacSha256);
        }

        public JsonWebTokenDto CreateToken(Guid userId, string role)
        {
            var now = DateTime.Now;
            var expires = now.Add(_expiry);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new(ClaimTypes.Role, role)
            };
            var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
            var token = _jwtSecurityToken.WriteToken(jwt);

            return new JsonWebTokenDto
            {
                AccessToken = token
            };

        }
    }
}
