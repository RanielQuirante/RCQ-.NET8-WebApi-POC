using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StradaTechnicalInterview.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("secure-data")]
        public IActionResult GetSecureData()
        {
            return Ok("This is a secure endpoint");
        }
    }
}