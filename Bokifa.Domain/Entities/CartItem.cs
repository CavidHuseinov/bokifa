using Bookifa.Domain.Abstractions;
using Bookifa.Domain.Entities.Identity;

namespace Bokifa.Domain.Entities
{
    public class CartItem:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
