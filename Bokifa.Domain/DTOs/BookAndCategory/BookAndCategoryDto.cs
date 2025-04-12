using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.Category;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.BookAndCategory
{
    public record BookAndCategoryDto
    {
        public CategoryDto? Category { get; set; }
    }
}
