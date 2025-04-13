using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Favorite;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Domain.Entities.Identity;
using Bookifa.Persistance.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bokifa.Persistance.Services
{
    public class FavoriteService:IFavoriteService
    {
        private readonly IFavoriteRepo _command;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IHttpContextAccessor _http;
        private readonly SignInManager<AppUser> _sign;
        public FavoriteService(IFavoriteRepo command, IMapper mapper, IUnitOfWork work, SignInManager<AppUser> sign, IHttpContextAccessor http)
        {
            _command = command;
            _mapper = mapper;
            _work = work;
            _sign = sign;
            _http = http;
        }

        public async Task AddToFavoritesAsync(CreateFavoriteDto dto)
        {
            var userId = _sign.UserManager.GetUserId(_http.HttpContext.User);

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User not found");

            var favorite = new Favorite
            {
                BookId = dto.BookId,
                AppUserId = userId
            };
            
            await _command.CreateAsync(favorite);  
            await _work.SaveChangeAsync();  
        }

    }
}
