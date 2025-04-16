namespace Bokifa.Persistance.Repositories
{
    public class CategoryRepo : CommandRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
