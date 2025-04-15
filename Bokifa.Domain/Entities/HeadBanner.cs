namespace Bokifa.Domain.Entities
{
    public class HeadBanner : BaseEntity
    {
        public string Content { get; set; }
        public PrimaryLanguageType LanguageType { get; set; } = PrimaryLanguageType.Eng;
        public ICollection<THeadBanner>? THeadBanners { get; set; }
    }
}
