using Bokifa.Domain.Enums;

namespace Bokifa.Domain.DTOs.TVariant
{
    public record CreateTVariantDto
    {
        public string Name { get; set; }
        public Guid VariantId { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
