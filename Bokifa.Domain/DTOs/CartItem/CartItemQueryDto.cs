
namespace Bokifa.Domain.DTOs.CartItem
{
    public record CartItemQueryDto
    {
        public Guid BookId { get; set; }
        public Guid PromocodeId { get; set; }
    }
}
