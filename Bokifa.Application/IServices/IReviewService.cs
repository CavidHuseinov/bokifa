using Bokifa.Domain.DTOs.Review;

namespace Bokifa.Application.IServices
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByBookAsync(Guid bookId, int pageIndex, int pageSize);
        Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto);
        Task<decimal> GetAverageRatingAsync(Guid bookId);
        Task DeleteAsync(Guid id);
    }
}
