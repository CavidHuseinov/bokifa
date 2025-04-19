
namespace Bokifa.Persistance.Repositories
{
    public class PromocodeRepo:CommandRepository<Promocode> , IPromocodeRepo
    {
        public PromocodeRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
