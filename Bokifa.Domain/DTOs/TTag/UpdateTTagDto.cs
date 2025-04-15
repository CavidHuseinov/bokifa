namespace Bokifa.Domain.DTOs.TTag
{
    public record UpdateTTagDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid TagId { get; set; }
    }
}
