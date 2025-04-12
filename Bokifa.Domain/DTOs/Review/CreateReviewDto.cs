namespace Bokifa.Domain.DTOs.Review
{
    public record CreateReviewDto
    {
        public string? Comment { get; set; }
        public Guid BookId { get; set; }
        public int Rating { get; set; }
    }
}
