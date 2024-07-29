using FluentValidation;
using StradaTechnicalInterview.Models.Dtos.Request;

namespace StradaTechnicalInterview.Services.Validators
{
    public class AddressDtoValidator : AbstractValidator<AddressRequestDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is mandatory");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is mandatory");
        }
    }
}