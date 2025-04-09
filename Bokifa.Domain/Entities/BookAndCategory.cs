namespace Bokifa.Domain.Entities
{
    public class BookAndCategory
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        public Book? Book { get; set; }
        public Category? Category { get; set; }
    }
}
