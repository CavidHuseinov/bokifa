using Bokifa.Domain.Entities;
using Bookifa.Domain.IRepositories.Generics;

namespace Bokifa.Domain.IRepositories
{
    public interface IReviewRepo:ICommandRepository<Review>
    {
        Task<decimal> AverageRating(Guid bookId);
    }
}
