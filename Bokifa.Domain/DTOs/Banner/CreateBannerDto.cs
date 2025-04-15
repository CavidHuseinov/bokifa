namespace Bokifa.Domain.DTOs.Banner
{
    public record CreateBannerDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BtnName { get; set; }
        public string ImgUrl { get; set; }
        public decimal? Discount { get; set; }
    }
}
