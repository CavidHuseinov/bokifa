using Bokifa.Domain.DTOs.TBook;

namespace Bokifa.Persistance.Services
{
    public class TBookService : ITBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly ITBookRepo _command;
        private readonly IQueryRepository<TBook> _query;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "TBooks";

        public TBookService(IMemoryCache cache, IQueryRepository<TBook> query, ITBookRepo command, IUnitOfWork work, IMapper mapper)
        {
            _cache = cache;
            _query = query;
            _command = command;
            _work = work;
            _mapper = mapper;
        }
        public async Task<ICollection<TBookDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBook>? cachedDict))
            {
                return _mapper.Map<ICollection<TBookDto>>(cachedDict.Values);
            }

            var tBooks = await _query.GetAllAsync(
                include: x => x
                .Include(x => x.Book));
            var tBookDict = tBooks.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, tBookDict);
            return _mapper.Map<ICollection<TBookDto>>(tBooks);
        }

        public async Task<TBookDto> GetByIdAsync(Guid id)
        {
            var tBookId = await _query.GetByIdAsync(id);
            if (tBookId == null)
            {
                throw new Exception("TBook not found");
            }
            return _mapper.Map<TBookDto>(tBookId);
        }
        public async Task<TBookDto> CreateAsync(CreateTBookDto dto)
        {
            var tBook = _mapper.Map<TBook>(dto);
            var newTBook = await _command.CreateAsync(tBook);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBook> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, TBook>(cachedDict)
                {
                    [newTBook.Id] = newTBook
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, TBook>
                {
                    [newTBook.Id] = newTBook
                };
                _cache.Set(cacheKey, newCache);
            }

            return _mapper.Map<TBookDto>(newTBook);
        }
        public async Task UpdateAsync(UpdateTBookDto dto)
        {
            var existingTBook = await _query.GetByIdAsync(dto.Id);
            if (existingTBook == null)
            {
                throw new KeyNotFoundException("TBook not found");
            }

            _mapper.Map(dto, existingTBook);
            await _command.UpdateAsync(existingTBook);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBook> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, TBook>(cachedDict)
                {
                    [dto.Id] = existingTBook
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var tBookId = await _query.GetByIdAsync(id);
            if (tBookId == null)
            {
                throw new KeyNotFoundException("TBook not found");
            }
            await _command.DeleteAsync(tBookId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBook> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, TBook>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
