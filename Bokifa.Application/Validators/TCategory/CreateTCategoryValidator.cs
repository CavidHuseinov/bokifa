using Bokifa.Domain.DTOs.TCategory;

namespace Bokifa.Application.Validators.TCategory
{
    public class CreateTCategoryValidator : AbstractValidator<CreateTCategoryDto>
    {
        public CreateTCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
