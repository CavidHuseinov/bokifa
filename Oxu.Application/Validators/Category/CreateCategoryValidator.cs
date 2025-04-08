using Bokifa.Domain.DTOs.Category;
using FluentValidation;

namespace Bokifa.Application.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
