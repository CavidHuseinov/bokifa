﻿using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.Extensions.Caching.Memory;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Bokifa.Persistance.Services
{
    public class BookService : IBookService
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

            var books = await _query.GetAllAsync(
                include: x => x
                .Include(x => x.BookAndCategories).ThenInclude(x => x.Category)
                .Include(x=>x.BookAndTags).ThenInclude(x=>x.Tag)
                .Include(x=>x.Comments));
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

            if (dto.CategoryIds != null && dto.CategoryIds.Any())
            {
                book.BookAndCategories = new List<BookAndCategory>();
                foreach (var categoryId in dto.CategoryIds)
                {
                    book.BookAndCategories.Add(new BookAndCategory
                    {
                        CategoryId = categoryId
                    });
                }
            }
            if(dto.TagIds != null && dto.TagIds.Any())
            {
                book.BookAndTags = new List<BookAndTag>();
                foreach (var tagId in dto.TagIds)
                {
                    book.BookAndTags.Add(new BookAndTag
                    {
                        TagId = tagId
                    });
                }
            }
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
