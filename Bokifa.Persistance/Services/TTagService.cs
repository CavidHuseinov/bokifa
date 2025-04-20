using Bokifa.Domain.DTOs.TTag;

namespace Bokifa.Persistance.Services
{
    public class TTagService: ITTagService
    {
        private readonly ITTagRepo _command;
        private readonly IQueryRepository<TTag> _query;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "Tags";
        public TTagService(IUnitOfWork work, IMemoryCache cache, IMapper mapper, ITTagRepo command, IQueryRepository<TTag> query)
        {
            _work = work;
            _cache = cache;
            _mapper = mapper;
            _command = command;
            _query = query;
        }
        public async Task<ICollection<TTagDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TTag>? cachedDict))
            {
                return _mapper.Map<ICollection<TTagDto>>(cachedDict.Values);
            }

            var tTags = await _query.GetAllAsync().ToListAsync();
            var tTagDict = tTags.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, tTagDict);
            return _mapper.Map<ICollection<TTagDto>>(tTags);
        }

        public async Task<TTagDto> GetByIdAsync(Guid id)
        {
            var tTagId = await _query.GetByIdAsync(id);
            if (tTagId == null)
            {
                throw new Exception("Tag not found");
            }
            return _mapper.Map<TTagDto>(tTagId);
        }
        public async Task<TTagDto> CreateAsync(CreateTTagDto dto)
        {
            var tTag = _mapper.Map<TTag>(dto);
            var newTag = await _command.CreateAsync(tTag);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TTag> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, TTag>(cachedDict)
                {
                    [newTag.Id] = newTag
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, TTag>
                {
                    [newTag.Id] = newTag
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<TTagDto>(newTag);
        }
        public async Task UpdateAsync(UpdateTTagDto dto)
        {
            var existingTag = await _query.GetByIdAsync(dto.Id);
            if (existingTag == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            _mapper.Map(dto, existingTag);
            await _command.UpdateAsync(existingTag);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TTag> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, TTag>(cachedDict)
                {
                    [dto.Id] = existingTag
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var tTagId = await _query.GetByIdAsync(id);
            if (tTagId == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }
            await _command.DeleteAsync(tTagId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TTag> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, TTag>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
