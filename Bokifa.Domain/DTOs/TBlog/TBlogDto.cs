
using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Domain.DTOs.TBlog
{
    public record TBlogDto:BaseDto
    {
        public string LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
