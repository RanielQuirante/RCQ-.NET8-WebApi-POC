using StradaTechnicalInterview.Models.Application;
using System.IdentityModel.Tokens.Jwt;

namespace StradaTechnicalInterview.Services.Interfaces
{
    public interface IAuthService
    {
        JwtSecurityToken GenerateToken(LoginModel login);
    }
}