using Bokifa.Domain.DTOs.Category;

namespace Bokifa.Application.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}
