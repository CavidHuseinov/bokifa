using Bokifa.Domain.DTOs.TVariant;

namespace Bokifa.Persistance.Services
{
    public class TVariantService:ITVariantService
    {
        private readonly ITVariantRepo _command;
        private readonly IQueryRepository<TVariant> _query;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "Variants";

        public TVariantService(IUnitOfWork work, IMapper mapper, ITVariantRepo command, IQueryRepository<TVariant> query, IMemoryCache cache)
        {
            _work = work;
            _mapper = mapper;
            _command = command;
            _query = query;
            _cache = cache;
        }
        public async Task<ICollection<TVariantDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TVariant>? cachedDict))
            {
                return _mapper.Map<ICollection<TVariantDto>>(cachedDict.Values);
            }

            var tVariants = await _query.GetAllAsync();
            var tVariantDict = tVariants.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, tVariantDict);
            return _mapper.Map<ICollection<TVariantDto>>(tVariants);
        }

        public async Task<TVariantDto> GetByIdAsync(Guid id)
        {
            var tVariantId = await _query.GetByIdAsync(id);
            if (tVariantId == null)
            {
                throw new Exception("TVariant not found");
            }
            return _mapper.Map<TVariantDto>(tVariantId);
        }
        public async Task<TVariantDto> CreateAsync(CreateTVariantDto dto)
        {
            var tVariant = _mapper.Map<TVariant>(dto);
            var newTVariant = await _command.CreateAsync(tVariant);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TVariant> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, TVariant>(cachedDict)
                {
                    [newTVariant.Id] = newTVariant
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, TVariant>
                {
                    [newTVariant.Id] = newTVariant
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<TVariantDto>(newTVariant);
        }
        public async Task UpdateAsync(UpdateTVariantDto dto)
        {
            var existingTVariant = await _query.GetByIdAsync(dto.Id);
            if (existingTVariant == null)
            {
                throw new KeyNotFoundException("TVariant not found");
            }

            _mapper.Map(dto, existingTVariant);
            await _command.UpdateAsync(existingTVariant);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TVariant> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, TVariant>(cachedDict)
                {
                    [dto.Id] = existingTVariant
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var tVariantId = await _query.GetByIdAsync(id);
            if (tVariantId == null)
            {
                throw new KeyNotFoundException("TVariant not found");
            }
            await _command.DeleteAsync(tVariantId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TVariant> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, TVariant>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
