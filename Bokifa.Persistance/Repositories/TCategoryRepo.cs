namespace Bokifa.Persistance.Repositories
{
    public class TCategoryRepo : CommandRepository<TCategory>, ITCategoryRepo
    {
        public TCategoryRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
