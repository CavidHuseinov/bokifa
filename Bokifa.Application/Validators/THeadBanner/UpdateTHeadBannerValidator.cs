using Bokifa.Domain.DTOs.THeadBanner;

namespace Bokifa.Application.Validators.THeadBanner
{
    public class UpdateTHeadBannerValidator : AbstractValidator<UpdateTHeadBannerDto>
    {
        public UpdateTHeadBannerValidator()
        {
            RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
