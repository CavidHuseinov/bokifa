namespace Bokifa.Domain.DTOs.HeadBanner
{
    public record HeadBannerDto : BaseDto
    {
        public string Content { get; set; }
        public string PrimaryLanguageType { get; set; }

    }
}
