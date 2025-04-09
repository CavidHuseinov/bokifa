namespace Bokifa.Domain.DTOs.BookAndCategory
{
    public record CreateBookAndCategoryDto
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
