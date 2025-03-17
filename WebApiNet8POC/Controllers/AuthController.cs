using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApiNet8POC.Models.Application;
using WebApiNet8POC.Services.Interfaces;

namespace WebApiNet8POC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] LoginModel login)
        {
            // Validate user credentials (this is just an example)
            if (login.Username == "test" && login.Password == "password")
            {
                JwtSecurityToken token = _authService.GenerateToken(login);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }
    }
}