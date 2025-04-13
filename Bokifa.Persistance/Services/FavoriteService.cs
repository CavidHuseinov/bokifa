using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Favorite;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Domain.Entities.Identity;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bokifa.Persistance.Services
{
    public class FavoriteService:IFavoriteService
    {
        private readonly IFavoriteRepo _command;
        private readonly IQueryRepository<Favorite> _query;
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

            foreach (var bookId in dto.BookIds)
            {
                var favorite = new Favorite
                {
                    BookId = bookId,
                    AppUserId = userId
                };
                await _command.CreateAsync(favorite);
            }
            await _work.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var favorite = await _query.GetByIdAsync(id);
            if (favorite == null)
                throw new Exception("Favorite not found");
            await _command.DeleteAsync(favorite);
            await _work.SaveChangeAsync();
        }
    }
}
