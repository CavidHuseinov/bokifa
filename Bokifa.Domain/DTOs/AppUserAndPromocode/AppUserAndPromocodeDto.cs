
using Bokifa.Domain.DTOs.Promocode;
using Microsoft.Identity.Client;

namespace Bokifa.Domain.DTOs.AppUserAndPromocode
{
    public record AppUserAndPromocodeDto
    {
       public PromocodeDto Promocode { get; set; } 
       public Guid PromocodeId { get; set; }
    }
}
