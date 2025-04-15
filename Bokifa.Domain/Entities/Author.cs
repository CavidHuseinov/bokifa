namespace Bokifa.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
