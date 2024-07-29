using StradaTechnicalInterview.Infrastructure.Contexts;
using StradaTechnicalInterview.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace StradaTechnicalInterview.Repositories.Implementations
{
    public class EmploymentRepository : IEmploymentRepository
    {
        private readonly ApplicationDbContext _context;

        public EmploymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId)
        {
            return await _context.Employment
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == employmentId);
        }

        public async Task<int> CreateEmploymentAsync(EmploymentEntity employment)
        {
            if (employment == null)
                throw new ArgumentNullException(nameof(employment));

            _context.Employment.Add(employment);
            await _context.SaveChangesAsync();
            return employment.Id;
        }

        public async Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentEntity updatedEmployment)
        {
            var existingEmployment = await _context.Employment
                .FirstOrDefaultAsync(e => e.Id == employmentId && e.UserId == userId);

            if (existingEmployment == null)
                throw new InvalidOperationException("Employment not found or user mismatch.");

            existingEmployment.Company = updatedEmployment.Company;
            existingEmployment.MonthsOfExperience = updatedEmployment.MonthsOfExperience;
            existingEmployment.Salary = updatedEmployment.Salary;
            existingEmployment.StartDate = updatedEmployment.StartDate;
            existingEmployment.EndDate = updatedEmployment.EndDate;

            _context.Employment.Update(existingEmployment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmploymentAsync(int employmentId)
        {
            var employment = await _context.Employment.FindAsync(employmentId);

            if (employment == null)
                throw new InvalidOperationException("Employment not found.");

            _context.Employment.Remove(employment);
            await _context.SaveChangesAsync();
        }
    }
}