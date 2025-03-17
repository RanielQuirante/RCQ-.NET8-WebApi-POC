using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiNet8POC.Models.Dtos.Request;
using WebApiNet8POC.Services.Interfaces;

namespace WebApiNet8POC.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userDto)
        {
            var userId = await _userService.CreateUserAsync(userDto);

            var createdUserDto = await _userService.GetUserByIdAsync(userId);

            if (createdUserDto == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User created but not found.");

            return CreatedAtAction(nameof(GetUserById), new { id = userId }, createdUserDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
                return NotFound();

            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return NoContent();
        }
    }
}