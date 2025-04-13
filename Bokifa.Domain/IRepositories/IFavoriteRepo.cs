using Bokifa.Domain.Entities;
using Bookifa.Domain.IRepositories.Generics;

namespace Bokifa.Domain.IRepositories
{
    public interface IFavoriteRepo : ICommandRepository<Favorite>
    {
        Task<bool> ExistsAsync(string userId, Guid bookId);
    }

}