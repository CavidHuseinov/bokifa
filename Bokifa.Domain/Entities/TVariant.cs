namespace Bokifa.Domain.Entities
{
    public class TVariant : BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Name { get; set; }
        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
