using System.IdentityModel.Tokens.Jwt;
using WebApiNet8POC.Models.Application;

namespace WebApiNet8POC.Services.Interfaces
{
    public interface IAuthService
    {
        JwtSecurityToken GenerateToken(LoginModel login);
    }
}