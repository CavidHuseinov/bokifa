namespace Bokifa.Persistance.Repositories
{
    public class BookRepo:CommandRepository<Book>, IBookRepo
    {
        public BookRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
