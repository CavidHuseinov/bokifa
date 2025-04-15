using Bokifa.Domain.DTOs.HeadBanner;

namespace Bokifa.Application.Validators.HeadBanner
{
    public class CreateHeadBannerValidator:AbstractValidator<CreateHeadBannerDto>
    {
        public CreateHeadBannerValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
