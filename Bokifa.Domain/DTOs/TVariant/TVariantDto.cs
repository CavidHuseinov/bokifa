namespace Bokifa.Domain.DTOs.TVariant
{
    public record TVariantDto : BaseDto
    {
        public string Name { get; set; }
        public string LanguageType { get; set; }
    }
}
