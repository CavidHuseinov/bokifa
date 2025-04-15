namespace Bokifa.Domain.DTOs.TCategory
{
    public record UpdateTCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid CategoryId { get; set; }
    }
}
