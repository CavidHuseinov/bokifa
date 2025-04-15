namespace Bokifa.Persistance.Repositories
{
    public class BookRepo:CommandRepository<Book>, IBookRepo
    {
        public BookRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
