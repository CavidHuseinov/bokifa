namespace Bokifa.Domain.DTOs.HeadBanner
{
    public record CreateHeadBannerDto
    {
        public string Content { get; set; }
        public ICollection<Guid> THeadBannerIds { get; set; }
    }
}
