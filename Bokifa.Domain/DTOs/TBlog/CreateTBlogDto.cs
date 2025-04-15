
namespace Bokifa.Domain.DTOs.TBlog
{
    public record CreateTBlogDto
    {
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BlogId { get; set; }
    }
}
