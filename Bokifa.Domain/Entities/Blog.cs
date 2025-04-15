
namespace Bokifa.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<TBlog>? TBlogs { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.Eng;
        public ICollection<BlogAndTag>? BlogAndTags { get; set; }
    }
}
