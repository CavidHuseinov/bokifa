
namespace Bokifa.Persistance.Repositories
{
    public class CurrencyRepo:CommandRepository<Currency>, ICurrencyRepo
    {
        public CurrencyRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
