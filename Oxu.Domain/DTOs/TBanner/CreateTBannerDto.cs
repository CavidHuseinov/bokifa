using Bokifa.Domain.Enums;

namespace Bokifa.Domain.DTOs.TBanner
{
    public record CreateTBannerDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public LanguageType LanguageType { get; set; }
    }
}
