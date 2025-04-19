
using Bokifa.Domain.DTOs.AppUserAndPromocode;

namespace Bokifa.Domain.DTOs.Promocode
{
    public record PromocodeDto:BaseDto
    {
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
