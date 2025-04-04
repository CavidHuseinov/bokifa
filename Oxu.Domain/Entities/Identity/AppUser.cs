using Microsoft.AspNetCore.Identity;


namespace Oxu.Domain.Entities.Identity
{
    public sealed class AppUser:IdentityUser
    {
        public string Name {  get; set; }
        public string Surname { get; set; } 
        public string RefreshToken { get; set; }
        public DateTime ExpirationRefreshTokenDate { get; set; } = DateTime.Now;

    }
}
