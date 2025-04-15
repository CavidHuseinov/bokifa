namespace Bokifa.Domain.Entities
{
    public class TTag : BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Name { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
