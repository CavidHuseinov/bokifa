
namespace Bokifa.Domain.Entities
{
    public class ContactAddress:BaseEntity
    {
        public string PhoneNumber { get; set; } = default!;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime? ConfirmedAt { get; set; }
            
    }
}
