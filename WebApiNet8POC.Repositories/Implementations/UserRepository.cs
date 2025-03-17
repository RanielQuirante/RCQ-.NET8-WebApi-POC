using Microsoft.EntityFrameworkCore;
using WebApiNet8POC.Infrastructure.Contexts;
using WebApiNet8POC.Models.Entities;
using WebApiNet8POC.Repositories.Interfaces;

namespace WebApiNet8POC.Repositories.Implementations
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Address)
                .Include(u => u.Employments)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
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
            return await _context.Users.AsNoTracking().AnyAsync(u => u.Email == email);
        }
    }
}