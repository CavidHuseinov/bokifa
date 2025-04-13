using Bokifa.Domain.DTOs.Book;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.Favorite
{
    public record FavoriteDto:BaseDto
    {
        public Guid BookId { get; set; }
        public BookMiniDto Book { get; set; }
    }
}
