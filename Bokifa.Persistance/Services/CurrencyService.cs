
using Bokifa.Domain.DTOs.Currency;

namespace Bokifa.Persistance.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepo _command;
        private readonly IQueryRepository<Currency> _query;
        private readonly IMapper _mapper;

        public CurrencyService(IQueryRepository<Currency> repo, IMapper mapper)
        {
            _query = repo;
            _mapper = mapper;
        }

        public async Task<CurrencyDto> GetByCodeAsync(string code)
        {
            var currency = await _query.GetAllAsync(x => x.Code == code.ToUpper())
                                       .FirstOrDefaultAsync();

            if (currency is null)
                throw new KeyNotFoundException("Currency not found");

            return _mapper.Map<CurrencyDto>(currency);
        }


        public async Task<List<CurrencyDto>> GetAllAsync()
        {
            var currencies = await _query.GetAllAsync().ToListAsync();
            return _mapper.Map<List<CurrencyDto>>(currencies);
        }
    }

}
