namespace Bokifa.Persistance.Repositories
{
    public class TCategoryRepo : CommandRepository<TCategory>, ITCategoryRepo
    {
        public TCategoryRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
