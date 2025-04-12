using Bokifa.Domain.DTOs.Tag;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.TTag
{
    public record TTagDto:BaseDto
    {
        public string Name { get; set; }
        public string LanguageType { get; set; }
        public TagDto Tag { get; set; }
    }
}
