namespace Bokifa.Persistance.Repositories
{
    public class TTagRepo:CommandRepository<TTag>, ITTagRepo
    {
        public TTagRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
