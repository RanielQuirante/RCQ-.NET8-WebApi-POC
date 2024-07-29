using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Models.Dtos.Response;

namespace StradaTechnicalInterview.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserRequestDto userDto);

        Task<UserResponseDto?> GetUserByIdAsync(int id);

        Task<List<UserResponseDto>> GetUsersAsync();

        Task UpdateUserAsync(int id, UserRequestDto userDto);
    }
}