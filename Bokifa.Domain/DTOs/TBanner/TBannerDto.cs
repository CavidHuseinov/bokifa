using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.TBanner
{
    public record TBannerDto:BaseDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public LanguageType LanguageType { get; set; }
        public BannerDto Banner { get; set; }

    }
}
