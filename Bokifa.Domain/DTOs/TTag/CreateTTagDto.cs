using Bokifa.Domain.Enums;

namespace Bokifa.Domain.DTOs.TTag
{
    public record CreateTTagDto
    {
        public string Name { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid TagId { get; set; }
    }
}
