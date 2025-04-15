using Bokifa.Domain.DTOs.THeadBanner;

namespace Bokifa.Application.Validators.THeadBanner
{
    public class CreateTHeadBannerValidator : AbstractValidator<CreateTHeadBannerDto>
    {
        public CreateTHeadBannerValidator()
        {
            RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
