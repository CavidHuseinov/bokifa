using Bokifa.Domain.DTOs.Tag;

namespace Bokifa.Domain.DTOs.TTag
{
    public record TTagDto : BaseDto
    {
        public string Name { get; set; }
        public string LanguageType { get; set; }
        public TagDto Tag { get; set; }
    }
}
