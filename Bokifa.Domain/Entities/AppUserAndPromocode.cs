﻿
namespace Bokifa.Domain.Entities
{
    public class AppUserAndPromocode
    {
        public Guid PromocodeId { get; set; }
        public Promocode Promocode { get; set; } 
        public string AppUserId { get; set; } 
        public AppUser AppUser { get; set; } 
    }
}
