
namespace Bokifa.Domain.Entities
{
    public class Promocode:BaseEntity
    {
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public bool IsUsed { get; set; }
        public ICollection<AppUserAndPromocode>? AppUserAndPromocodes { get; set; }
    }
}
