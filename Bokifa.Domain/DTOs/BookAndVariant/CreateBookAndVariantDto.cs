namespace Bokifa.Domain.DTOs.BookAndVariant
{
    public record CreateBookAndVariantDto
    {
        public Guid BookId { get; set; }
        public Guid VariantId { get; set; }
    }
}
