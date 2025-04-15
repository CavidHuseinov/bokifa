
namespace Bokifa.Persistance.Repositories
{
    public class TBlogRepo:CommandRepository<TBlog>, ITBlogRepo
    {
        public TBlogRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
