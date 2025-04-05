using Bokifa.Domain.Enums;
using Oxu.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class THeadBanner:BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Content { get; set; }
        public Guid? HeadBannerId { get; set; }
        public HeadBanner? HeadBanner { get; set; }
    }
}
