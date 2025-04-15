using Bokifa.Domain.DTOs.Category;

namespace Bokifa.Domain.DTOs.BookAndCategory
{
    public record BookAndCategoryDto
    {
        public CategoryDto? Category { get; set; }
    }
}
