using Microsoft.EntityFrameworkCore;
using StradaTechnicalInterview.Infrastructure.Contexts;
using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Employments)
                .ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Employments)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<int> CreateAddUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}