using Bokifa.Domain.DTOs.HeadBanner;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.THeadBanner
{
    public record THeadBannerDto:BaseDto
    {
        public string Content { get; set; }
        public string LanguageType { get; set; }
        public HeadBannerDto HeadBanner { get; set; }
    }
}
