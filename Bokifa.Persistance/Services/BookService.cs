using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.Extensions.Caching.Memory;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class BookService:IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IBookRepo _command;
        private readonly IQueryRepository<Book> _query;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "books";
        public BookService(IUnitOfWork unitOfWork, IQueryRepository<Book> query, IBookRepo command, IMapper mapper, IMemoryCache cache)
        {
            _work = unitOfWork;
            _query = query;
            _command = command;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<ICollection<BookDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Book>? cachedDict))
            {
                return _mapper.Map<ICollection<BookDto>>(cachedDict.Values);
            }

            var books = await _query.GetAllAsync();
            var bookDict = books.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bookDict);
            return _mapper.Map<ICollection<BookDto>>(books);
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var bookId = await _query.GetByIdAsync(id);
            if (bookId == null)
            {
                throw new Exception("Book not found");
            }
            return _mapper.Map<BookDto>(bookId);
        }
        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            var newBook = await _command.CreateAsync(book);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Book> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, Book>(cachedDict)
                {
                    [newBook.Id] = newBook
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, Book>
                {
                    [newBook.Id] = newBook
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<BookDto>(newBook);
        }
        public async Task UpdateAsync(UpdateBookDto dto)
        {
            var existingBook = await _query.GetByIdAsync(dto.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found");
            }

            _mapper.Map(dto, existingBook);
            await _command.UpdateAsync(existingBook);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Book> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, Book>(cachedDict)
                {
                    [dto.Id] = existingBook
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var bookId = await _query.GetByIdAsync(id);
            if (bookId == null)
            {
                throw new KeyNotFoundException("Book not found");
            }
            await _command.DeleteAsync(bookId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Book> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, Book>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
