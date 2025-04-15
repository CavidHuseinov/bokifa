namespace Bokifa.Persistance.Repositories
{
    public class THeadBannerRepo : CommandRepository<THeadBanner>, ITHeadBannerRepo
    {
        public THeadBannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
