namespace Bokifa.Persistance.Repositories
{
    public class THeadBannerRepo : CommandRepository<THeadBanner>, ITHeadBannerRepo
    {
        public THeadBannerRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
