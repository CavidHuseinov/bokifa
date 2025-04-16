namespace Bokifa.Persistance.Repositories
{
    public class CartItemRepo:CommandRepository<CartItem>, ICartItemRepo
    {
        public CartItemRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
