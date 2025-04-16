
using Bokifa.Domain.DTOs.ContactAdress;

namespace Bokifa.Application.Validators.ContactAddress
{
    public class CreateContactAddress : AbstractValidator<CreateContactAddressDto>
    {
        public CreateContactAddress()
        {
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Phone is required")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid number format");
        }
    }
}
