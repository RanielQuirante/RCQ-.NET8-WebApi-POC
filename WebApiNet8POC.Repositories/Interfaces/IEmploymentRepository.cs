using WebApiNet8POC.Models.Entities;

namespace WebApiNet8POC.Repositories.Interfaces
{
    public interface IEmploymentRepository
    {
        Task<int> CreateEmploymentAsync(EmploymentEntity employment);

        Task DeleteEmploymentAsync(int employmentId);

        Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId);

        Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentEntity updatedEmployment);
    }
}