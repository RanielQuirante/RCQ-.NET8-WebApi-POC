using WebApiNet8POC.Models.Dtos.Request;
using WebApiNet8POC.Models.Dtos.Response;

namespace WebApiNet8POC.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserRequestDto userDto);

        Task<UserResponseDto?> GetUserByIdAsync(int id);

        Task<List<UserResponseDto>> GetUsersAsync();

        Task UpdateUserAsync(int id, UserRequestDto userDto);
    }
}