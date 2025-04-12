using Bookifa.Domain.Abstractions;
using Bookifa.Domain.DTOs.User;

namespace Bokifa.Domain.DTOs.Review
{
    public record ReviewDto:BaseDto
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public UserDto AppUser { get; set; }
    }  
}
