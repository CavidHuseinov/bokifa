namespace Bokifa.Domain.Entities
{
    public class TBook : BaseEntity
    {
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
