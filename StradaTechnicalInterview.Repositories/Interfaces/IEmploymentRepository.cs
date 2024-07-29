using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.Repositories.Implementations
{
    public interface IEmploymentRepository
    {
        Task<int> CreateEmploymentAsync(EmploymentEntity employment);

        Task DeleteEmploymentAsync(int employmentId);

        Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId);

        Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentEntity updatedEmployment);
    }
}