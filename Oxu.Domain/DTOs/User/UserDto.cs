using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.User
{
    public record UserDto:BaseDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
