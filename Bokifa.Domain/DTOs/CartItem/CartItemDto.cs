using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Domain.DTOs.CartItem
{
    public record CartItemDto : BaseDto
    {
        public Guid BookId { get; set; }
        public BookMiniDto Book { get; set; }
        public int Quantity { get; set; }
    }
}
