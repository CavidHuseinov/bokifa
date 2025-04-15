namespace Bokifa.Persistance.Repositories
{
    public class HeadBannerRepo : CommandRepository<HeadBanner>, IHeadBannerRepo
    {
        public HeadBannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
