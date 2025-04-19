namespace Bookifa.Domain.Entities.Identity
{
    public sealed class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime ExpirationRefreshTokenDate { get; set; } = DateTime.UtcNow;
        public ICollection<Review>? Comments { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
        public ContactAddress ContactAddress { get; set; }
        public ICollection<ShippingInfo>? ShippingInfos { get; set; }
        public ICollection<AppUserAndPromocode>? AppUserAndPromocodes { get; set; }
	}
}
