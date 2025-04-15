namespace Bokifa.Persistance.Repositories
{
    public class TBookRepo : CommandRepository<TBook>, ITBookRepo
    {
        public TBookRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
