
using Bokifa.Domain.DTOs.Promocode;
using Microsoft.Identity.Client;

namespace Bokifa.Domain.DTOs.AppUserAndPromocode
{
    public record AppUserAndPromocodeDto
    {
       public Guid PromocodeId { get; set; }
       public PromocodeDto Promocode { get; set; } 
    }
}
