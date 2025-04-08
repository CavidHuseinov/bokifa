using Bokifa.Domain.DTOs.Banner;
using FluentValidation;

namespace Bokifa.Application.Validators.Banner
{
    public class UpdateBannerValidator : AbstractValidator<UpdateBannerDto>
    {
        public UpdateBannerValidator()
        {
            RuleFor(x => x.Discount)
            .InclusiveBetween(0, 100);
        }
    }
}
