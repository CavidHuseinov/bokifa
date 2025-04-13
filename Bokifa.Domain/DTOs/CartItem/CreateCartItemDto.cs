namespace Bokifa.Domain.DTOs.CartItem
{
    public record CreateCartItemDto
    {
        public ICollection<Guid>? BookIds { get; set; }
        public int Quantity { get; set; }
    }
}
