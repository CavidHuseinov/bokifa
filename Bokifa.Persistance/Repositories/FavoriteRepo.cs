using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Bokifa.Persistance.Repositories
{
    public class FavoriteRepo:CommandRepository<Favorite>, IFavoriteRepo
    {
        private readonly BookifaDbContext _context;
        public FavoriteRepo(BookifaDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ExistsAsync(string userId, Guid bookId)
        {
            return await _context.Favorites
                .AnyAsync(f => f.AppUserId == userId && f.BookId == bookId);
        }
    }

}
