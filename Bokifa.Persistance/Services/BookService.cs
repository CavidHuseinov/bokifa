using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Persistance.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepo _bookCommandRepo;
        private readonly IQueryRepository<Book> _bookQueryRepo;
        private readonly IQueryRepository<Variant> _variantQueryRepo;
        private readonly IQueryRepository<Category> _categoryQueryRepo;
        private readonly IContactAddressService _contactAddressService;

        public BookService(
            IUnitOfWork unitOfWork,
            IQueryRepository<Book> bookQueryRepo,
            IBookRepo bookCommandRepo,
            IMapper mapper,
            IContactAddressService contactAddressService,
            IQueryRepository<Variant> variantQueryRepo,
            IQueryRepository<Category> categoryQueryRepo)
        {
            _unitOfWork = unitOfWork;
            _bookQueryRepo = bookQueryRepo;
            _bookCommandRepo = bookCommandRepo;
            _mapper = mapper;
            _contactAddressService = contactAddressService;
            _variantQueryRepo = variantQueryRepo;
            _categoryQueryRepo = categoryQueryRepo;
        }

        public async Task<ICollection<BookDto>> GetAllAsync()
        {
            var books = await _bookQueryRepo.GetAllAsync(
                include: q => q
                    .Include(b => b.BookAndCategories).ThenInclude(bc => bc.Category)
                    .Include(b => b.BookAndTags).ThenInclude(bt => bt.Tag)
                    .Include(b => b.Comments)
                    .Include(b => b.BookAndVariants).ThenInclude(bv => bv.Variant),
                enableTracking: false)
                .ToListAsync();

            return _mapper.Map<ICollection<BookDto>>(books);
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var book = await _bookQueryRepo.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var book = _mapper.Map<Book>(dto);

            book.BookAndCategories = new List<BookAndCategory>();
            book.BookAndTags = new List<BookAndTag>();
            book.BookAndVariants = new List<BookAndVariant>();

            if (dto.CategoryIds?.Any() == true)
            {
                foreach (var categoryId in dto.CategoryIds)
                {
                    book.BookAndCategories.Add(new BookAndCategory { CategoryId = categoryId });
                }
            }

            if (dto.TagIds?.Any() == true)
            {
                foreach (var tagId in dto.TagIds)
                {
                    book.BookAndTags.Add(new BookAndTag { TagId = tagId });
                }
            }

            if (dto.VariantIds?.Any() == true)
            {
                foreach (var variantId in dto.VariantIds)
                {
                    book.BookAndVariants.Add(new BookAndVariant { VariantId = variantId });
                }
            }

            var createdBook = await _bookCommandRepo.CreateAsync(book);
            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<BookDto>(createdBook);
        }

        public async Task UpdateAsync(UpdateBookDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var existingBook = await _bookQueryRepo.GetByIdAsync(dto.Id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with ID {dto.Id} not found.");
            }

            _mapper.Map(dto, existingBook);
            await _bookCommandRepo.UpdateAsync(existingBook);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _bookQueryRepo.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            await _bookCommandRepo.DeleteAsync(book);
            await _unitOfWork.SaveChangeAsync();
        }


        public async Task<Dictionary<string, int>> GetBookCountsByFormatAsync()
        {
            var counts = new Dictionary<string, int>();

            var books = await _bookQueryRepo.GetAllAsync(
                include: q => q.Include(b => b.BookAndVariants).ThenInclude(bv => bv.Variant),
                enableTracking: false)
                .ToListAsync();

            var formatBooks = books
                .SelectMany(b => b.BookAndVariants.Select(bv => new { bv.Variant.Name, b.Id }))
                .GroupBy(item => item.Name)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Id).Distinct().Count());

            foreach (var format in formatBooks)
            {
                counts.Add(format.Key, format.Value);
            }

            return counts;
        }

        public async Task<Dictionary<string, int>> GetSpecialCategoriesCountAsync()
        {
            var counts = new Dictionary<string, int>();

            var books = await _bookQueryRepo.GetAllAsync(
                include: q => q
                    .Include(b => b.BookAndVariants).ThenInclude(bv => bv.Variant)
                    .Include(b => b.BookAndCategories).ThenInclude(bc => bc.Category),
                enableTracking: false)
                .ToListAsync();

            var variants = await _variantQueryRepo.GetAllAsync(
                enableTracking: false)
                .ToListAsync();
            foreach (var variant in variants)
            {
                var variantCount = books.Count(b => b.BookAndVariants.Any(bv => bv.VariantId == variant.Id));
                counts.Add(variant.Name, variantCount);
            }

            var categories = await _categoryQueryRepo.GetAllAsync(
                enableTracking: false)
                .ToListAsync();
            foreach (var category in categories)
            {
                var categoryCount = books.Count(b => b.BookAndCategories.Any(bc => bc.CategoryId == category.Id));
                counts.Add(category.Name, categoryCount);
            }

            return counts;
        }

        public async Task<Dictionary<string, int>> GetBookCountsByRatingAsync()
        {
            var counts = new Dictionary<string, int>();

            var books = await _bookQueryRepo.GetAllAsync(
                include: q => q.Include(b => b.Comments),
                enableTracking: false)
                .ToListAsync();

            for (int rating = 1; rating <= 5; rating++)
            {
                var ratingCount = books.Count(b => b.Comments.Any() &&
                    Math.Round(b.Comments.Average(c => c.Rating)) == rating);
                counts.Add(rating.ToString(), ratingCount);
            }

            return counts;
        }

        public async Task<Dictionary<string, int>> GetBookCountsByAvailabilityAsync()
        {
            var counts = new Dictionary<string, int>();

            var books = await _bookQueryRepo.GetAllAsync(enableTracking: false).ToListAsync();

            counts.Add("Available", books.Count(b => b.InStock));
            counts.Add("Unavailable", books.Count(b => !b.InStock));

            return counts;
        }

        public async Task<Dictionary<string, Dictionary<string, int>>> GetAllFilterCountsAsync()
        {
            return new Dictionary<string, Dictionary<string, int>>
            {
                { "categories", await GetBookCountsByCategoryAsync() },
                { "availability", await GetBookCountsByAvailabilityAsync() },
                { "format", await GetBookCountsByFormatAsync() },
                { "category", await GetSpecialCategoriesCountAsync() },
                { "rating", await GetBookCountsByRatingAsync() }
            };
        }
    }
}