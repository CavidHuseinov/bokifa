namespace Bokifa.Persistance.Repositories
{
    public class TBannerRepo:CommandRepository<TBanner>, ITBannerRepo
    {
        public TBannerRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
