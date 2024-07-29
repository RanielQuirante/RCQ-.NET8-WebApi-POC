using FluentValidation;
using StradaTechnicalInterview.Models.Dtos.Request;
using StradaTechnicalInterview.Repositories.Interfaces;

namespace StradaTechnicalInterview.Services.Validators
{
    public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
    {
        private readonly IUserRepository _userRepository;

        public UserRequestDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is mandatory");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is mandatory");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Valid Email is mandatory")
                .EmailAddress().WithMessage("Invalid email format")
                .MustAsync(EmailNotExists).WithMessage("Email already exists");

            RuleFor(x => x.Address).SetValidator(new AddressDtoValidator());
            RuleForEach(x => x.Employments).SetValidator(new EmploymentDtoValidator());
        }

        private async Task<bool> EmailNotExists(string email, CancellationToken cancellationToken)
        {
            return !await _userRepository.EmailExistsAsync(email);
        }
    }
}