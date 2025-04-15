using Bokifa.Domain.DTOs.Category;

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
