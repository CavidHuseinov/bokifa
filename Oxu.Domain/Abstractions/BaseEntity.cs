using Oxu.Domain.ValueObjects;

namespace Oxu.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public CreatedAtVO CreatedAt { get; set; } = new CreatedAtVO(DateTime.Now);


    }
}
