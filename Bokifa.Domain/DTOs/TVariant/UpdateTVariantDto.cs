namespace Bokifa.Domain.DTOs.TVariant
{
    public record UpdateTVariantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid VariantId { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
