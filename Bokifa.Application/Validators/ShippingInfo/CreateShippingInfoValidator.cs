
using Bokifa.Domain.DTOs.ShippingInfo;

namespace Bokifa.Application.Validators.ShippingInfo
{
    public class CreateShippingInfoValidator : AbstractValidator<CreateShippingInfoDto>
    {
        public CreateShippingInfoValidator()
        {
            RuleFor(x=>x.Address)
                .NotEmpty().WithMessage("Address is required");
            RuleFor(x => x.Apartment)
                .NotEmpty().WithMessage("Apartment is required");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required");
        }
    }
}
