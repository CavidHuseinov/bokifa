
using Bokifa.Domain.DTOs.Currency;

namespace Bokifa.Application.IServices
{
    public interface ICurrencyService
    {
        Task<CurrencyDto> GetByCodeAsync(string code);
        Task<List<CurrencyDto>> GetAllAsync();
    }

}
