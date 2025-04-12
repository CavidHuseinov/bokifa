using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Variant:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TVariant> TVariants { get; set; }
        public PrimaryLanguageType PrimaryLanugageType { get; set; } = PrimaryLanguageType.English;
        public ICollection<BookAndVariant>? BookAndVariants { get; set; }
    }
}
