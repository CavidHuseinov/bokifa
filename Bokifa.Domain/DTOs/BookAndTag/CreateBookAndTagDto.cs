namespace Bokifa.Domain.DTOs.BookAndTag
{
    public record CreateBookAndTagDto
    {
        public Guid TagId {  get; set; }
        public Guid BookId { get; set; }
    }
}
