namespace Bokifa.Persistance.Repositories
{
    public class CartItemRepo:CommandRepository<CartItem>, ICartItemRepo
    {
        public CartItemRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
