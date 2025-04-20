using Bokifa.Domain.DTOs.Author;

namespace Bokifa.Persistance.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IQueryRepository<Author> _query;
        private readonly IAuthorRepo _command;
        private readonly MemoryCache _cache;
        private readonly string cacheKey= "authors";
        public AuthorService(IMapper mapper, IUnitOfWork work, IQueryRepository<Author> query, IAuthorRepo command, IMemoryCache cache)
        {
            _mapper = mapper;
            _work = work;
            _query = query;
            _command = command;
            _cache = (MemoryCache)cache;
        }
        public async Task<ICollection<AuthorDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Author>? cachedDict))
            {
                return _mapper.Map<ICollection<AuthorDto>>(cachedDict.Values);
            }

            var authors = await _query.GetAllAsync().ToListAsync();
            var authorDict = authors.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, authorDict);
            return _mapper.Map<ICollection<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetByIdAsync(Guid id)
        {
            var authorId = await _query.GetByIdAsync(id);
            if (authorId == null)
            {
                throw new Exception("Author not found");
            }
            return _mapper.Map<AuthorDto>(authorId);
        }
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            var newAuthor = await _command.CreateAsync(author);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Author> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, Author>(cachedDict)
                {
                    [newAuthor.Id] = newAuthor
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, Author>
                {
                    [newAuthor.Id] = newAuthor
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<AuthorDto>(newAuthor);
        }
        public async Task UpdateAsync(UpdateAuthorDto dto)
        {
            var existingAuthor = await _query.GetByIdAsync(dto.Id);
            if (existingAuthor == null)
            {
                throw new KeyNotFoundException("Author not found");
            }

            _mapper.Map(dto, existingAuthor);
            await _command.UpdateAsync(existingAuthor);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Author> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, Author>(cachedDict)
                {
                    [dto.Id] = existingAuthor
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var authorId = await _query.GetByIdAsync(id);
            if (authorId == null)
            {
                throw new KeyNotFoundException("Author not found");
            }
            await _command.DeleteAsync(authorId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Author> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, Author>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
