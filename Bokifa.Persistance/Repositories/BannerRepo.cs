namespace Bokifa.Persistance.Repositories
{
    public class BannerRepo : CommandRepository<Banner>, IBannerRepo
    {
        public BannerRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
