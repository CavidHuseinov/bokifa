using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Variant:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TVariant> TVariants { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.Eng;
        public ICollection<BookAndVariant>? BookAndVariants { get; set; }
    }
}
