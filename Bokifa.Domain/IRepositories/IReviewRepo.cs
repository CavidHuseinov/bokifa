namespace Bokifa.Domain.IRepositories
{
    public interface IReviewRepo : ICommandRepository<Review>
    {
        Task<decimal> AverageRating(Guid bookId);
    }
}
