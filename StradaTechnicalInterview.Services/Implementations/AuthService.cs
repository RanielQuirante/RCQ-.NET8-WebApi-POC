using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StradaTechnicalInterview.Models.Application;
using StradaTechnicalInterview.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StradaTechnicalInterview.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GenerateToken(LoginModel login)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return token;
        }
    }
}