namespace Bokifa.Persistance.Repositories
{
    public class ReviewRepo : CommandRepository<Review>, IReviewRepo
    {
        private readonly BokifaDbContext _context;
        public ReviewRepo(BokifaDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<decimal> AverageRating(Guid bookId)
        {
            return await _context.Reviews
                .Where(r => r.BookId == bookId)
                .AverageAsync(r => (decimal?)r.Rating) ?? 0;
        }
    }
}
