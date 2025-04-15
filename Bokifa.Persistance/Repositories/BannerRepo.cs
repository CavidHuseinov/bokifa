namespace Bokifa.Persistance.Repositories
{
    public class BannerRepo : CommandRepository<Banner>, IBannerRepo
    {
        public BannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
