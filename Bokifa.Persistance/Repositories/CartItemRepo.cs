using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class CartItemRepo:CommandRepository<CartItem>, ICartItemRepo
    {
        public CartItemRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
