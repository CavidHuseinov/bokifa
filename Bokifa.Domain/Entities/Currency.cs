
namespace Bokifa.Domain.Entities
{
    public class Currency:BaseEntity
    {
        public string Code { get; set; }= default!;
        public string Symbol { get; set; } = default!;
        public decimal RateToBase { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
