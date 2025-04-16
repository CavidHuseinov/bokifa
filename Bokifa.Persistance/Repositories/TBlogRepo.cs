
namespace Bokifa.Persistance.Repositories
{
    public class TBlogRepo:CommandRepository<TBlog>, ITBlogRepo
    {
        public TBlogRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
