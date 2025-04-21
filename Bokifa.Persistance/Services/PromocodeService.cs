using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.CartItem;
using Bokifa.Domain.DTOs.Promocode;
using Bokifa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Bokifa.Persistance.Services
{
    public class PromocodeService : IPromocodeService
    {
        private readonly IQueryRepository<Promocode> _query;
        private readonly IPromocodeRepo _command;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly UserManager<AppUser> _user;
        private readonly IHttpContextAccessor _http;
        private readonly IAppUserAndPromocodeRepo _AppUserAndPromocodeCommand;
        private readonly IQueryRepository<AppUserAndPromocode> _appUserAndPromocodeQuery;

        public PromocodeService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPromocodeRepo command,
            IQueryRepository<Promocode> query,
            UserManager<AppUser> user,
            IHttpContextAccessor http,
            IAppUserAndPromocodeRepo appUserAndPromocodeCommand,
            IQueryRepository<AppUserAndPromocode> appUserAndPromocodeQuery)
        {
            _work = unitOfWork;
            _mapper = mapper;
            _command = command;
            _query = query;
            _user = user;
            _http = http;
            _AppUserAndPromocodeCommand = appUserAndPromocodeCommand;
            _appUserAndPromocodeQuery = appUserAndPromocodeQuery;
        }
        private string GetCurrentUserAsync()
        {
            var userId = _user.GetUserId(_http.HttpContext.User);
            if (userId == null) throw new Exception("User not found");
            return userId;
        }

        public async Task<PromocodeDto> CreateAsync(CreatePromocodeDto dto)
        {
            var promocode = _mapper.Map<Promocode>(dto);
            if(dto.AppUserIds != null && dto.AppUserIds.Any())
            {
                promocode.AppUserAndPromocodes = new List<AppUserAndPromocode>();
                foreach (var userId in dto.AppUserIds)
                {
                    promocode.AppUserAndPromocodes.Add(new AppUserAndPromocode
                    {
                        AppUserId = userId
                    });
                }
            }
            var newPromocode = await _command.CreateAsync(promocode);
            await _work.SaveChangeAsync();
            return _mapper.Map<PromocodeDto>(newPromocode);
        }
        public async Task<PromocodeDto> CreateAsyncForAllUser(CreatePromocodeForAllUserDto dto)
        {
            var promocode = _mapper.Map<Promocode>(dto);
            promocode.AppUserAndPromocodes = new List<AppUserAndPromocode>();
            var allUserIds = await _command.GetAllUserIdsAsync();
            

            foreach (var userId in allUserIds)
            {
                promocode.AppUserAndPromocodes.Add(new AppUserAndPromocode
                {
                    AppUserId = userId,
                    PromocodeId = promocode.Id

                });
            }

            var newPromocode = await _command.CreateAsync(promocode);
            await _work.SaveChangeAsync();
            return _mapper.Map<PromocodeDto>(newPromocode);
        }

        public async Task DeleteAsync(Guid id)
        {
            var promcoodeId = await _query.GetByIdAsync(id);
            if (promcoodeId == null)
            {
                throw new FileNotFoundException("Promocode not found");
            }
            await _command.DeleteAsync(promcoodeId);
            await _work.SaveChangeAsync();

        }

        public async Task<ICollection<PromocodeDto>> GetAllAsync()
        {
            var promocodes = await _query.GetAllAsync().ToListAsync();
            return _mapper.Map<ICollection<PromocodeDto>>(promocodes);
        }

        public async Task<PromocodeDto> GetByIdAsync(Guid id)
        {
            var promocodeId = await _query.GetByIdAsync(id);
            if (promocodeId == null)
            {
                throw new FileNotFoundException("Promocode not found");
            }
            return _mapper.Map<PromocodeDto>(promocodeId);
        }
        public async Task UpdateAsync(UpdatePromocodeDto dto)
        {
           var promocodeId = await _query.GetByIdAsync(dto.Id);
            if (promocodeId == null)
            {
                throw new FileNotFoundException("Promocode not found");
            }
            var promocode = _mapper.Map<Promocode>(dto);
            await _command.UpdateAsync(promocode);
            await _work.SaveChangeAsync();
        }
        public async Task<bool> IsPromocodeValid(string code)
        {
            var promocode = await _query.GetAsync(x => x.Code == code);
            if (promocode == null)
                return false;
            if (promocode.ExpirationDate < DateTime.UtcNow)
                return false;
            if (promocode.IsUsed)
                return false;
            return true;
        }
        public async Task<PromocodeDto> UsePromocodeAsync(string code)
        {
            var promocode = await _query.GetAsync(p => p.Code == code);
            var userId = GetCurrentUserAsync();

            if (promocode.AppUserAndPromocodes == null ||
                !promocode.AppUserAndPromocodes.Any(x => x.AppUserId == userId))
            {
                throw new Exception("This promocode has already been used");
            }

            var userPromocodeRecord = promocode.AppUserAndPromocodes
                .FirstOrDefault(x => x.AppUserId == userId);

            await _AppUserAndPromocodeCommand.DeleteAsync(userPromocodeRecord);

            await _work.SaveChangeAsync();

            return _mapper.Map<PromocodeDto>(promocode);
        }
        public async Task<bool> IsPromoCodeExistAsync(string promoCode)
        {
            return await _command.IsPromoCodeExistAsync(promoCode);
        }
    }
}
