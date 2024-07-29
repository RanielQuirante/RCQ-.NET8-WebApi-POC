using FluentValidation;
using StradaTechnicalInterview.Models.Dtos.Request;

namespace StradaTechnicalInterview.Services.Validators
{
    public class EmploymentDtoValidator : AbstractValidator<EmploymentRequestDto>
    {
        public EmploymentDtoValidator()
        {
            RuleFor(x => x.Company).NotEmpty().WithMessage("Company is mandatory");
            RuleFor(x => x.MonthsOfExperience)
                .NotNull().WithMessage("Months of Experience is mandatory")
                .Must(monthOfExperience => monthOfExperience.HasValue && monthOfExperience.Value > 0)
                .WithMessage("Months of Experience must be greater than 0");

            RuleFor(x => x.Salary)
                .NotNull().WithMessage("Salary is mandatory")
                .Must(salary => salary.HasValue && salary.Value > 0)
                .WithMessage("Salary must be greater than 0");

            RuleFor(x => x.StartDate).NotNull().WithMessage("Start Date is mandatory");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("End Date is mandatory")
                .GreaterThan(x => x.StartDate).WithMessage("End Date must be greater than Start Date");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("User Id is mandatory")
                .GreaterThan(0).WithMessage("User Id must be greater than 0");
        }
    }
}