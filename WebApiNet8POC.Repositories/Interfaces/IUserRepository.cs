using WebApiNet8POC.Models.Entities;

namespace WebApiNet8POC.Repositories.Interfaces
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