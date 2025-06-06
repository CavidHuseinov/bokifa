﻿namespace Bokifa.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public Guid? PromocodeId { get; set; }
        public Promocode? Promocode { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
