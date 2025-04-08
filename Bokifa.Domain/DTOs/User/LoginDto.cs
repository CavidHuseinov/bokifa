namespace Bookifa.Domain.DTOs.User
{
    public record LoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
