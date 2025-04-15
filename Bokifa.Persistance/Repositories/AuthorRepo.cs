namespace Bokifa.Persistance.Repositories
{
    public class AuthorRepo : CommandRepository<Author>, IAuthorRepo
    {
        public AuthorRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
