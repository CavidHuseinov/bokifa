
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Promocode;

namespace Bokifa.Application.Validators.Promocode
{
    public class CreatePromocodeValidator : AbstractValidator<CreatePromocodeDto>
    {
        private readonly IPromocodeService _service;
        public CreatePromocodeValidator(IPromocodeService service)
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty")
                .MustAsync(BeUniquePromoCodeAsync).WithMessage("Cannot create a promocode with the same name");
            RuleFor(x => x.Discount).NotEmpty().WithMessage("Discount cannot be empty");
            _service = service;
        }
        private async Task<bool> BeUniquePromoCodeAsync(string promoCode, CancellationToken cancellationToken)
        {
            return !await _service.IsPromoCodeExistAsync(promoCode);
        }
    }
}
