using Bokifa.Domain.DTOs.TCategory;
using FluentValidation;

namespace Bokifa.Application.Validators.TCategory
{
    public class UpdateTCategoryValidator : AbstractValidator<UpdateTCategoryDto>
    {
        public UpdateTCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}
