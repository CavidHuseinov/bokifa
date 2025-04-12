namespace Bokifa.Domain.Entities
{
    public class BookAndTag
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; } 
    }
}
