
namespace Bokifa.Domain.DTOs.Promocode
{
    public record CreatePromocodeForAllUserDto
    {
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
    }
}
