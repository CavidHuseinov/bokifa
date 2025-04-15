
namespace Bokifa.Domain.Entities
{
    public class BlogAndTag
    {
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
