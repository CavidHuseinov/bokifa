namespace Bokifa.Domain.DTOs.THeadBanner
{
    public record UpdateTHeadBannerDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid HeadBannerId { get; set; }
    }
}
