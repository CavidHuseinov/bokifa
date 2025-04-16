namespace Bokifa.Persistance.Repositories
{
    public class HeadBannerRepo : CommandRepository<HeadBanner>, IHeadBannerRepo
    {
        public HeadBannerRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
