
namespace Bokifa.Domain.IRepositories
{
    public interface IPromocodeRepo:ICommandRepository<Promocode>
    {
        Task<bool> IsPromoCodeExistAsync(string promoCode);
        Task<ICollection<string>> GetAllUserIdsAsync();
    }
}
