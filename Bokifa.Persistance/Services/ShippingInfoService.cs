
using Bokifa.Domain.DTOs.ShippingInfo;
using Bookifa.Domain.ValueObjects;

namespace Bokifa.Persistance.Services
{
    public class ShippingInfoService : IShippingInfoService
    {
        private readonly IMapper _mapper;
        private readonly IShippingInfoRepo _command;
        private readonly IQueryRepository<ShippingInfo> _query;
        private readonly IUnitOfWork _work;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _user;

        public ShippingInfoService(
            IMapper mapper,
            IShippingInfoRepo command,
            IQueryRepository<ShippingInfo> query,
            IUnitOfWork work,
            IHttpContextAccessor http,
            UserManager<AppUser> user)
        {
            _mapper = mapper;
            _command = command;
            _query = query;
            _work = work;
            _http = http;
            _user = user;
        }
        private async Task<AppUser> GetCurrentUserAsync()
        {
            var userId = _user.GetUserId(_http.HttpContext.User);
            if (userId == null) throw new Exception("User not found");
            return await _user.FindByIdAsync(userId);
        }
        public async Task<ShippingInfoDto> CreateAsync(CreateShippingInfoDto dto)
        {
            var user = await GetCurrentUserAsync();
            var existing = await _query.GetAsync(x => x.AppUserId == user.Id);
            if (existing != null) throw new Exception("Shipping info already exists");
            var shippingInfo = _mapper.Map<ShippingInfo>(dto);
            shippingInfo.AppUserId = user.Id;
            await _command.CreateAsync(shippingInfo);
            await _work.SaveChangeAsync();
            var data = _mapper.Map<ShippingInfoDto>(shippingInfo);
            return data;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetCurrentUserAsync();
            var shippingInfo = await _query.GetAsync(x => x.AppUserId == user.Id && x.Id == id);
            if (shippingInfo == null) throw new Exception("Shipping info not found");
            await _command.DeleteAsync(shippingInfo);
            await _work.SaveChangeAsync();
        }

        public async Task<ShippingInfoDto> GetAsync()
        {
           var user = await GetCurrentUserAsync();
            var shippingInfo = await _query.GetAsync(x => x.AppUserId == user.Id);

            if (shippingInfo == null)
            {
                throw new Exception("Shipping info not found");
            }
            var data = _mapper.Map<ShippingInfoDto>(shippingInfo);
            data.Surname = user.Surname;
            data.Name = user.Name;
            return data;
        }
    }
}
