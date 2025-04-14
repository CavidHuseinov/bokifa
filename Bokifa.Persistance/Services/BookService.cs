using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.DTOs.ContactAdress;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
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
        private readonly IContactAddressService _contactAddress;
        public BookService(IUnitOfWork unitOfWork, IQueryRepository<Book> query, IBookRepo command, IMapper mapper, IContactAddressService contactAddress)
        {
            _work = unitOfWork;
            _query = query;
            _command = command;
            _mapper = mapper;
            _contactAddress = contactAddress;
        }
        public async Task<ICollection<BookDto>> GetAllAsync()
        {

            var books = await _query.GetAllAsync(
                include: x => x
                .Include(x => x.BookAndCategories).ThenInclude(x => x.Category)
                .Include(x=>x.BookAndTags).ThenInclude(x=>x.Tag)
                .Include(x=>x.Comments)
                .Include(x=>x.BookAndVariants).ThenInclude(x=>x.Variant));
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
            if (dto.VariantIds != null && dto.VariantIds.Any())
            {
                book.BookAndVariants = new List<BookAndVariant>();
                foreach (var variantId in dto.VariantIds)
                {
                    book.BookAndVariants.Add(new BookAndVariant
                    {
                        VariantId = variantId
                    });
                }
            }
            var newBook = await _command.CreateAsync(book);

            await _work.SaveChangeAsync();
            var createNewNotification = new CreateContactAddressDto
            {
                SendNotification = true
            };
            var sendNotification = await _contactAddress.SendNotification(createNewNotification);
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
        }
    }
}
