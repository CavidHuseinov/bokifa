using Bokifa.Domain.DTOs.CartItem;

namespace Bokifa.Application.IServices
{
    public interface ICartItemService
    {
        Task AddToCartAsync(CreateCartItemDto dto);
        Task DeleteAsync(Guid id);
        Task<ICollection<CartItemDto>> GetUserOrdersAsync();
    }
}
