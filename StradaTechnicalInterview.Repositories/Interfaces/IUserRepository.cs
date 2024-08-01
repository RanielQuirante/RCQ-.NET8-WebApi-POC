using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAddUserAsync(UserEntity user);

        Task<bool> EmailExistsAsync(string email);

        Task<UserEntity?> GetUserByIdAsync(int id);

        Task<List<UserEntity>> GetUsersAsync();

        Task UpdateUserAsync(UserEntity user);
    }
}