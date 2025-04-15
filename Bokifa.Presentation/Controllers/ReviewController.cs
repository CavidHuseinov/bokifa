using Bokifa.Domain.DTOs.Review;

namespace Bokifa.Presentation.Controllers
{
    public sealed class ReviewController:ApiController
    {
        private readonly IReviewService _services;
        public ReviewController(IReviewService services)
        {
            _services = services;
        }
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetReviewsByBookAsync(Guid bookId, int pageIndex = 1, int pageSize = 10)
        {
            var reviews = await _services.GetReviewsByBookAsync(bookId,pageIndex,pageSize);
            return Ok(reviews);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync([FromBody] CreateReviewDto dto)
        {
            var review = await _services.CreateReviewAsync(dto);
            return Ok(review);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync(Guid id)
        {
            await _services.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("{productId}/average")]
        public async Task<IActionResult> GetAverageRating(Guid bookId)
        {
            var rating = await _services.GetAverageRatingAsync(bookId);
            return Ok(new { AverageRating = rating });
        }

    }
}
