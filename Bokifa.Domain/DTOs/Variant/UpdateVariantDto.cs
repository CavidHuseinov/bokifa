namespace Bokifa.Domain.DTOs.Variant
{
    public record UpdateVariantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
