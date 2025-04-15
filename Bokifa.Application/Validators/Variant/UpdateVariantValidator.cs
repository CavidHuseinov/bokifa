using Bokifa.Domain.DTOs.Variant;

namespace Bokifa.Application.Validators.Variant
{
    public class UpdateVariantValidator:AbstractValidator<UpdateVariantDto>
    {
        public UpdateVariantValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
