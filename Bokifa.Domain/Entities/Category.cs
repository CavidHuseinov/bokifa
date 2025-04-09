using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.English;
        public ICollection<TCategory>? TCategories { get; set; }
        public ICollection<BookAndCategory>? BookAndCategories { get; set; }

    }
}
