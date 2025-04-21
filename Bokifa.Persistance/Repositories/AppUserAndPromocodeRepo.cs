
namespace Bokifa.Persistance.Repositories
{
    public class AppUserAndPromocodeRepo:CommandRepository<AppUserAndPromocode>, IAppUserAndPromocodeRepo
    {
        public AppUserAndPromocodeRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
