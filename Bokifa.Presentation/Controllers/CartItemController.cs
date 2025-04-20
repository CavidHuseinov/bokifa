using Bokifa.Domain.DTOs.CartItem;


namespace Bokifa.Presentation.Controllers
{
    [Authorize]
    public class CartItemController:ApiController
    {
        private readonly ICartItemService _services;

        public CartItemController(ICartItemService services)
        {
            _services = services;
        }
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] CreateCartItemDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _services.AddToCartAsync(dto);
            return Ok("Added to cart");
        }
        [HttpGet("GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            var cartItems = await _services.GetUserOrdersAsync();
            return Ok(cartItems);
        }
        [HttpDelete("DeleteCartItem/{id}")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            await _services.DeleteAsync(id);
            return Ok("Deleted from cart");
        }
        [HttpPost("apply-promocode")]
        public async Task<IActionResult> ApplyPromoCode(CartItemQueryDto dto)
        {
            var result = await _services.ApplyPromoCode(dto);
            return Ok(result); 
        }
    }
}
