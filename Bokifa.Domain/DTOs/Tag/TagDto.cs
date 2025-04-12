using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.Tag
{
    public record TagDto:BaseDto
    {
        public string Name { get; set; }
    }
}
