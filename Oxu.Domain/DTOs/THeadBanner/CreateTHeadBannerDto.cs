using Bokifa.Domain.Enums;

namespace Bokifa.Domain.DTOs.THeadBanner
{
    public record CreateTHeadBannerDto
    {
        public string Content { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
