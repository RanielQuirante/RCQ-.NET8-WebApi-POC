using AutoMapper;
using FluentValidation;
using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Models.Entities;
using StradaTechnicalInterview.Repositories.Implementations;
using StradaTechnicalInterview.Repositories.Interfaces;
using StradaTechnicalInterview.Services.Interfaces;

namespace StradaTechnicalInterview.Services.Implementations
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IEmploymentRepository _employmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EmploymentRequestDto> _employmentRequestValidator;

        public EmploymentService(IEmploymentRepository employmentRepository, IMapper mapper, IValidator<EmploymentRequestDto> employmentRequestValidator, IUserRepository userRepository)
        {
            _employmentRepository = employmentRepository;
            _mapper = mapper;
            _employmentRequestValidator = employmentRequestValidator;
            _userRepository = userRepository;
        }

        public async Task<int> CreateEmploymentAsync(EmploymentRequestDto employmentDto)
        {
            var validationResult = await _employmentRequestValidator.ValidateAsync(employmentDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetUserByIdAsync(employmentDto.UserId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {employmentDto.UserId} not found.");
            }

            var employment = _mapper.Map<EmploymentEntity>(employmentDto);
            return await _employmentRepository.CreateEmploymentAsync(employment);
        }

        public async Task UpdateEmploymentAsync(int employmentId, int userId, EmploymentRequestDto employmentDto)
        {
            var validationResult = await _employmentRequestValidator.ValidateAsync(employmentDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetUserByIdAsync(userId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            var existingEmployment = await _employmentRepository.GetEmploymentByIdAsync(employmentId);
            if (existingEmployment == null)
            {
                throw new KeyNotFoundException($"Employment with ID {employmentId} not found.");
            }

            _mapper.Map(employmentDto, existingEmployment);

            await _employmentRepository.UpdateEmploymentAsync(employmentId, userId, existingEmployment);
        }

        public async Task<EmploymentEntity> GetEmploymentByIdAsync(int employmentId)
        {
            var employment = await _employmentRepository.GetEmploymentByIdAsync(employmentId);
            if (employment == null)
            {
                throw new KeyNotFoundException($"Employment with ID {employmentId} not found.");
            }
            return employment;
        }

        public async Task DeleteEmployment(int employmentId)
        {
            await _employmentRepository.DeleteEmploymentAsync(employmentId);
        }
    }
}