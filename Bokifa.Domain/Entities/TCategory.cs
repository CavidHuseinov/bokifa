using Bokifa.Domain.Enums;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class TCategory:BaseEntity
    {
        public string Name { get; set; }
        public LanguageType LanguageType { get; set; }
        public Guid CategoryId {  get; set; }
        public Category Category { get; set; }
    }
}
