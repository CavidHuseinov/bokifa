using Bokifa.Domain.DTOs.Variant;
using FluentValidation;

namespace Bokifa.Application.Validators.Variant
{
    public class CreateVariantValidator : AbstractValidator<CreateVariantDto>
    {
        public CreateVariantValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
