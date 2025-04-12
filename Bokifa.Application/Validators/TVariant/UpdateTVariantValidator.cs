using Bokifa.Domain.DTOs.TVariant;
using FluentValidation;

namespace Bokifa.Application.Validators.TVariant
{
    public class UpdateTVariantValidator : AbstractValidator<UpdateTVariantDto>
    {
        public UpdateTVariantValidator()
        {
             RuleFor(x => x.Name)
           .NotEmpty()
           .WithMessage("Name is required.");
        }        
    }
}
