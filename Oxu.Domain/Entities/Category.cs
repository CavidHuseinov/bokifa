using Bokifa.Domain.Enums;
using Oxu.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TCategory>? TCategories { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.Azerbaijan;
    }
}
