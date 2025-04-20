using Bokifa.Domain.DTOs.Review;

namespace Bokifa.Persistance.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IQueryRepository<Review> _query;
        private readonly IReviewRepo _command;
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IReviewRepo command,
            IQueryRepository<Review> query,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _work = unitOfWork;
            _mapper = mapper;
            _command = command;
            _query = query;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetUserId()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
            if (userId == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }
            return userId;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByBookAsync(Guid bookId, int pageIndex, int pageSize)
        {
            var reviews = await _query.GetByPagedAsync(
                predicate: r => r.BookId == bookId,
                include: x => x.Include(x => x.AppUser),
                orderBy: q => q.OrderByDescending(r => r.CreatedAt.Date),
                enableTracking: false,
                pageIndex: pageIndex,
                pageSize: pageSize).ToListAsync();

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            review.AppUserId = GetUserId();
            var newReview = await _command.CreateAsync(review);
            await _work.SaveChangeAsync();
            return _mapper.Map<ReviewDto>(newReview);
        }

        public async Task DeleteAsync(Guid id)
        {
            var reviewId = await _query.GetByIdAsync(id);
            if (reviewId == null)
            {
                throw new DirectoryNotFoundException("Review Not Found");
            }
            await _command.DeleteAsync(reviewId);
            await _work.SaveChangeAsync();
        }
        public async Task<decimal> GetAverageRatingAsync(Guid bookId)
        {
            return await _command.AverageRating(bookId);
        }
    }
}