using WebApiNet8POC.Models.Dtos.Request;
using WebApiNet8POC.Models.Entities;

namespace WebApiNet8POC.Services.Interfaces
{
    public interface IEmploymentService
    {
        Task<int> CreateEmploymentAsync(EmploymentRequestDto employmentDto);

        Task DeleteEmployment(int employmentId);

        Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId);

        Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentRequestDto employmentDto);
    }
}