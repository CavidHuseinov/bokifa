using Bokifa.Domain.DTOs.TVariant;

namespace Bokifa.Domain.DTOs.Variant
{
    public record VariantDto : BaseDto
    {
        public string Name { get; set; }
        public string PrimaryLanguageType { get; set; }
        public ICollection<TVariantDto> TVariants { get; set; }
    }
}
