
namespace Bokifa.Domain.DTOs.BlogAndTag
{
    public record CreateBlogAndTagDto
    {
        public Guid BlogId { get; set; }
        public Guid TagId { get; set; }
    }
}
