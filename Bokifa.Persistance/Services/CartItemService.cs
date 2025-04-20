using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.CartItem;
using Bokifa.Domain.DTOs.Promocode;
using Bokifa.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace Bokifa.Persistance.Services 
{ 
    public class CartItemService : ICartItemService 
    { 
        private readonly ICartItemRepo _command; 
        private readonly IQueryRepository<CartItem> _query; 
        private readonly IUnitOfWork _work; 
        private readonly IMapper _mapper; 
        private readonly SignInManager<AppUser> _sign; 
        private readonly IHttpContextAccessor _http;
        private readonly IQueryRepository<Promocode> _promoCodeQuery;
        public CartItemService(ICartItemRepo command, IQueryRepository<CartItem> query, IUnitOfWork work, IMapper mapper, SignInManager<AppUser> sign, IHttpContextAccessor http, IQueryRepository<Promocode> promoCodeQuery)
        {
            _command = command;
            _query = query;
            _work = work;
            _mapper = mapper;
            _sign = sign;
            _http = http;
            _promoCodeQuery = promoCodeQuery;
        }

        public async Task AddToCartAsync(CreateCartItemDto dto) 
        { 
            var userId = _sign.UserManager.GetUserId(_http.HttpContext.User); 
            foreach (var bookId in dto.BookIds) 
            { 
                var order = new CartItem 
                { 
                    BookId = bookId, 
                    AppUserId = userId 
                };
                dto.Quantity++;
                await _command.CreateAsync(order); 
            } 
            await _work.SaveChangeAsync(); 
        } 
 
        public async Task DeleteAsync(Guid id) 
        { 
            var cartItem = await _query.GetByIdAsync(id); 
            if (cartItem == null) 
                throw new Exception("Cart item not found"); 
            await _command.DeleteAsync(cartItem); 
            await _work.SaveChangeAsync(); 
        } 
 
        public async Task<ICollection<CartItemDto>> GetUserOrdersAsync() 
        { 
            var userId = _sign.UserManager.GetUserId(_http.HttpContext.User); 
            if (string.IsNullOrEmpty(userId)) 
                throw new Exception("User not found"); 
 
            var cartItems = await _sign.UserManager.Users
                .Where(x => x.Id == userId) 
                .SelectMany(x => x.CartItems) 
                .Select(ci => new CartItemDto 
                { 
                    Id = ci.Id,
                    BookId = ci.BookId, 
                    Book = new BookMiniDto 
                    { 
                        Id = ci.Book.Id,
                        Title = ci.Book.Title, 
                        Description = ci.Book.Description, 
                        ImgUrl = ci.Book.ImgUrl, 
                        Price = ci.Book.Price, 
                        Discount = ci.Book.Discount,
                    } 
                }).ToListAsync(); 
 
            return cartItems; 
        }
        public async Task<PromocodeDto> ApplyPromoCode(CartItemQueryDto dto)
        {
            var AppUserId = _sign.UserManager.GetUserId(_http.HttpContext.User);
            var promoCode = await _promoCodeQuery.GetByIdAsync(dto.PromocodeId);
            if (promoCode == null)
            {
                throw new Exception("Promocode not found");
            }

            var cartItem = await _query.GetAsync(c => c.AppUserId == AppUserId && c.BookId == dto.BookId);

            if (cartItem == null)
            {
                throw new Exception("Cart item not found");
            }

            cartItem.PromocodeId = promoCode.Id;
            await _command.UpdateAsync(cartItem);
            await _work.SaveChangeAsync();

            return _mapper.Map<PromocodeDto>(promoCode);
        }





    }
}