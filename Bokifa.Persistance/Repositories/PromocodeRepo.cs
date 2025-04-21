
using Microsoft.EntityFrameworkCore;

namespace Bokifa.Persistance.Repositories
{
    public class PromocodeRepo : CommandRepository<Promocode>, IPromocodeRepo
    {
        private readonly BokifaDbContext _context;
        private readonly UserManager<AppUser> _user;
        public PromocodeRepo(BokifaDbContext context, UserManager<AppUser> user) : base(context)
        {
            _context = context;
            _user = user;
        }

        public async Task<ICollection<string>> GetAllUserIdsAsync()
        {
            return await _user.Users.Select(u => u.Id).ToListAsync();
        }

        public async Task<bool> IsPromoCodeExistAsync(string promoCode)
        {
            return await _context.Promocodes.AnyAsync(x => x.Code == promoCode);
        }
    }
}
