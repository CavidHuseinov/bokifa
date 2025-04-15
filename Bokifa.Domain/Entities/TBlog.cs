
namespace Bokifa.Domain.Entities
{
    public class TBlog:BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
