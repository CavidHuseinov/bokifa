
namespace Bokifa.Domain.DTOs.Promocode
{
    public record UpdatePromocodeDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public ICollection<string> AppUserIds { get; set; }
    }
}
