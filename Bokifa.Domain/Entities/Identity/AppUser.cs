using Bokifa.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace Bookifa.Domain.Entities.Identity
{
    public sealed class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname { get; set; } 
        public string? RefreshToken { get; set; }
        public DateTime ExpirationRefreshTokenDate { get; set; } = DateTime.Now;
        public ICollection<Review>? Comments { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
