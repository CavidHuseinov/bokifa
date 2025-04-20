using Bokifa.Domain.DTOs.HeadBanner;

namespace Bokifa.Persistance.Services
{
    public class HeadBannerService : IHeadBannerService
    {
        private readonly IHeadBannerRepo _command;
        private readonly IQueryRepository<HeadBanner> _query;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "HeadBanners";
        public HeadBannerService(IHeadBannerRepo command,
                                 IQueryRepository<HeadBanner> query,
                                 IMapper mapper,
                                 IMemoryCache cache,
                                 IUnitOfWork work)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _cache = cache;
            _work = work;
        }

        public async Task<ICollection<HeadBannerDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner>? cachedDict))
            {
                return _mapper.Map<ICollection<HeadBannerDto>>(cachedDict.Values);
            }

            var banners = await _query.GetAllAsync().ToListAsync();
            var bannerDict = banners.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bannerDict);
            return _mapper.Map<ICollection<HeadBannerDto>>(banners);
        }

        public async Task<HeadBannerDto> GetByIdAsync(Guid id)
        {
            var bannerId =await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<HeadBannerDto>(bannerId);
        }
        public async Task<HeadBannerDto> CreateAsync(CreateHeadBannerDto dto)
        {
            var banner = _mapper.Map<HeadBanner>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();

            if(_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, HeadBanner>(cachedDict)
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, HeadBanner>
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<HeadBannerDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateHeadBannerDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, HeadBanner>(cachedDict)
                {
                    [dto.Id] = existingBanner
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }
            await _command.DeleteAsync(bannerId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, HeadBanner>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
