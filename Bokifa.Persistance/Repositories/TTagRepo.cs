namespace Bokifa.Persistance.Repositories
{
    public class TTagRepo:CommandRepository<TTag>, ITTagRepo
    {
        public TTagRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
