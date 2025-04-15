using Bokifa.Domain.DTOs.HeadBanner;

namespace Bokifa.Application.Validators.HeadBanner
{
    public class UpdateHeadBannerValidator:AbstractValidator<UpdateHeadBannerDto>
    {
        public UpdateHeadBannerValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
