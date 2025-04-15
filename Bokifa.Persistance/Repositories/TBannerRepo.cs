namespace Bokifa.Persistance.Repositories
{
    public class TBannerRepo:CommandRepository<TBanner>, ITBannerRepo
    {
        public TBannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
