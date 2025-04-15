using Bokifa.Domain.DTOs.Banner;

namespace Bokifa.Application.Validators.Banner
{
    public class CreateBannerValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerValidator()
        {
            RuleFor(x => x.Discount)
                .InclusiveBetween(0, 100);
        }
    }
}
