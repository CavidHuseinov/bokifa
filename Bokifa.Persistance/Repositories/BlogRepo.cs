

namespace Bokifa.Persistance.Repositories
{
    public class BlogRepo : CommandRepository<Blog>, IBlogRepo
    {
        public BlogRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
