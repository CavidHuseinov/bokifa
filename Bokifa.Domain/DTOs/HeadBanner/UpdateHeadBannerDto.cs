namespace Bokifa.Domain.DTOs.HeadBanner
{
    public record UpdateHeadBannerDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
