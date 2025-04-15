
using Bokifa.Domain.DTOs.Author;
using Bokifa.Domain.DTOs.BlogAndTag;
using Bokifa.Domain.DTOs.TBlog;

namespace Bokifa.Domain.DTOs.Blog
{
    public record BlogDto:BaseDto
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }
        public ICollection<TBlogDto>? TBlogs { get; set; }
        public ICollection<BlogAndTagDto>? BlogAndTags { get; set; }
        public string PrimaryLanguageType { get; set; } 
    }
}
