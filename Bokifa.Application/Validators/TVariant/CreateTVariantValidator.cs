using Bokifa.Domain.DTOs.TVariant;
using FluentValidation;

namespace Bokifa.Application.Validators.TVariant
{
    public class CreateTVariantValidator:AbstractValidator<CreateTVariantDto>
    {
        public CreateTVariantValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
