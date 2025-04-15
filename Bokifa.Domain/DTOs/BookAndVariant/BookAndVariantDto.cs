using Bokifa.Domain.DTOs.Variant;

namespace Bokifa.Domain.DTOs.BookAndVariant
{
    public record BookAndVariantDto : BaseDto
    {
        public Guid BookId { get; set; }
        public Guid VariantId { get; set; }
        public VariantDto Variant { get; set; }
    }
}
