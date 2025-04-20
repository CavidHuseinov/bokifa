using Bokifa.Domain.DTOs.CartItem;
using Bokifa.Domain.DTOs.Promocode;

namespace Bokifa.Application.IServices
{
    public interface ICartItemService
    {
        Task AddToCartAsync(CreateCartItemDto dto);
        Task DeleteAsync(Guid id);
        Task<ICollection<CartItemDto>> GetUserOrdersAsync();
        Task<PromocodeDto> ApplyPromoCode(CartItemQueryDto dto);
    }
}
