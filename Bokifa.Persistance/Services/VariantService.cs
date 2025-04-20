using Bokifa.Domain.DTOs.Variant;

namespace Bokifa.Persistance.Services
{
    public class VariantService : IVariantService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IQueryRepository<Variant> _query;
        private readonly IVariantRepo _command;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "Variants";
        public VariantService(IMapper mapper, IUnitOfWork work, IQueryRepository<Variant> query, IVariantRepo command, IMemoryCache cache)
        {
            _mapper = mapper;
            _work = work;
            _query = query;
            _command = command;
            _cache = cache;
        }
        public async Task<ICollection<VariantDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out List<VariantDto> cachedList))
            {
                return cachedList;
            }

            var variants = await _query.GetAllAsync(
                include:q=>q.Include(x=>x.TVariants)
                ).ToListAsync();
            var variantDtos = _mapper.Map<List<VariantDto>>(variants);

            _cache.Set(cacheKey, variantDtos);
            return variantDtos;
        }

        public async Task<VariantDto> GetByIdAsync(Guid id)
        {
            var variantId = await _query.GetByIdAsync(id);
            if (variantId == null)
            {
                throw new Exception("Variant not found");
            }
            return _mapper.Map<VariantDto>(variantId);
        }
        public async Task<VariantDto> CreateAsync(CreateVariantDto dto)
        {
            var variant = _mapper.Map<Variant>(dto);
            var newVariant = await _command.CreateAsync(variant);
            await _work.SaveChangeAsync();

            _cache.TryGetValue(cacheKey, out Dictionary<Guid, Variant> cachedDict);

            cachedDict ??= new Dictionary<Guid, Variant>();
            cachedDict[newVariant.Id] = newVariant;

            _cache.Set(cacheKey, cachedDict);

            return _mapper.Map<VariantDto>(newVariant);
        }

        public async Task UpdateAsync(UpdateVariantDto dto)
        {
            var existingVariant = await _query.GetByIdAsync(dto.Id);
            if (existingVariant == null)
            {
                throw new KeyNotFoundException("Variant not found");
            }

            _mapper.Map(dto, existingVariant);
            await _command.UpdateAsync(existingVariant);
            await _work.SaveChangeAsync();

            _cache.Remove(cacheKey);
            _cache.Set(cacheKey, new Dictionary<Guid, Variant> { { dto.Id, existingVariant } });
        }

        public async Task DeleteAsync(Guid id)
        {
            var variant = await _query.GetByIdAsync(id);
            if (variant == null)
            {
                throw new KeyNotFoundException("Variant not found");
            }

            await _command.DeleteAsync(variant);
            await _work.SaveChangeAsync();

            _cache.Remove(cacheKey);
            _cache.Set(cacheKey, new Dictionary<Guid, Variant>());
        }
    }
}
