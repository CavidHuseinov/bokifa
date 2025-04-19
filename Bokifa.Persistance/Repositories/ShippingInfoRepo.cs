
namespace Bokifa.Persistance.Repositories
{
    public class ShippingInfoRepo:CommandRepository<ShippingInfo>, IShippingInfoRepo
    {
        public ShippingInfoRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
