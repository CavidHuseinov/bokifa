
namespace Bokifa.Domain.DTOs.Promocode
{
    public record CreatePromocodeDto
    {
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public ICollection<string> AppUserIds { get; set; }
    }
}
