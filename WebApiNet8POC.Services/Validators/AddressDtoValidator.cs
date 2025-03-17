using FluentValidation;
using WebApiNet8POC.Models.Dtos.Request;

namespace WebApiNet8POC.Services.Validators
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