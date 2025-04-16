namespace Bokifa.Persistance.Repositories
{
    public class AuthorRepo : CommandRepository<Author>, IAuthorRepo
    {
        public AuthorRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
