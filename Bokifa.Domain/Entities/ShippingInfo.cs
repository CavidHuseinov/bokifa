﻿namespace Bokifa.Domain.Entities
{
    public class ShippingInfo : BaseEntity
    {
        public string? Country { get; set; }
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
        public string Address { get; set; }
        public string Apartment { get; set; }
        public string? State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool SaveInformation { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
