using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TTag>? TTags { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; }
        public ICollection<BookAndTag>? BookAndTags { get; set; }
    }
}
