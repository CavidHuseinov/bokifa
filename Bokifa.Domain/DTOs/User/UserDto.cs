﻿using Bokifa.Domain.DTOs.AppUserAndPromocode;
using Bokifa.Domain.DTOs.Favorite;

namespace Bookifa.Domain.DTOs.User
{
    public record UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<FavoriteDto>? Favorites { get; set; }
        public ICollection<AppUserAndPromocodeDto>? AppUserAndPromocodes { get; set; }
    }
}
