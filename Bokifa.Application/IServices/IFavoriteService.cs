using Bokifa.Domain.DTOs.Favorite;

namespace Bokifa.Application.IServices
{
    public interface IFavoriteService
    {
        Task AddToFavoritesAsync(CreateFavoriteDto dto);
    }
}
