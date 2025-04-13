using Bookifa.Domain.Abstractions;
using Bookifa.Domain.Entities.Identity;

namespace Bokifa.Domain.Entities
{
    public class Favorite:BaseEntity
    {
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
