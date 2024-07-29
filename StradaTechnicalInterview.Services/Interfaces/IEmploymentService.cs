using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.Services.Interfaces
{
    public interface IEmploymentService
    {
        Task<int> CreateEmploymentAsync(EmploymentRequestDto employmentDto);

        Task DeleteEmployment(int employmentId);

        Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId);

        Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentRequestDto employmentDto);
    }
}