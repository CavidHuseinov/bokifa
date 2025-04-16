

namespace Bokifa.Persistance.Repositories
{
    public class BlogRepo : CommandRepository<Blog>, IBlogRepo
    {
        public BlogRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
