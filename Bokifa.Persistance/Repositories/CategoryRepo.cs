namespace Bokifa.Persistance.Repositories
{
    public class CategoryRepo : CommandRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
