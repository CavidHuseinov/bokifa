namespace Bokifa.Domain.Entities
{
    public class BookAndVariant
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
