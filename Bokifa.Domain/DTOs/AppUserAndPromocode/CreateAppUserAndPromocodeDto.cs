
namespace Bokifa.Domain.DTOs.AppUserAndPromocode
{
    public record CreateAppUserAndPromocodeDto
    {
        public Guid PromocodeId { get; set; }
        public string AppUserId { get; set; }
    }
}
