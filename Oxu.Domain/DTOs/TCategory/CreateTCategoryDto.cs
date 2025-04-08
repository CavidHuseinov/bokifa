using Bokifa.Domain.Enums;

namespace Bokifa.Domain.DTOs.TCategory
{
    public record CreateTCategoryDto
    {
        public string Name { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid CategoryId { get; set; }
    }
}
