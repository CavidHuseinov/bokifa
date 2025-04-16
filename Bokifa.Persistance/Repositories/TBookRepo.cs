namespace Bokifa.Persistance.Repositories
{
    public class TBookRepo : CommandRepository<TBook>, ITBookRepo
    {
        public TBookRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
