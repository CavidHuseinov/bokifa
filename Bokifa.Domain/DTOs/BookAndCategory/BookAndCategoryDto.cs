using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.Category;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.BookAndCategory
{
    public record BookAndCategoryDto
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
