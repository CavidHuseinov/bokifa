
using Bokifa.Domain.DTOs.ContactAdress;

namespace Bokifa.Application.Validators.ContactAddress
{
    public class UpdateContactAddressValidator : AbstractValidator<UpdateContactAddressDto>
    {
        public UpdateContactAddressValidator()
        {
            RuleFor(x => x.NewPhoneNumber).NotEmpty().WithMessage("Phone is required")
          .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid number format");
        }
    }
}
