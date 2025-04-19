
using Bokifa.Domain.DTOs.Promocode;
using Bokifa.Domain.Entities;

namespace Bokifa.Persistance.Services
{
    public class PromocodeService : IPromocodeService
    {
        private readonly IQueryRepository<Promocode> _query;
        private readonly IPromocodeRepo _command;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;

        public PromocodeService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPromocodeRepo command,
            IQueryRepository<Promocode> query)
        {
            _work = unitOfWork;
            _mapper = mapper;
            _command = command;
            _query = query;
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
            var promocodes = await _query.GetAllAsync();
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

        public async Task<bool> IsPromocodeValid(string code)
        {
           throw new NotImplementedException();
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
    }
}
