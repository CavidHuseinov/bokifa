using Bokifa.Domain.DTOs.BookAndCategory;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.Category
{
    public record CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public ICollection<BookAndCategoryDto>? Books { get; set; }
        public string PrimaryLanguageType { get; set; }

    }
}
