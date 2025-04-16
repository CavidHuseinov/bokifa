namespace Bokifa.Application.Seeds
{
    public class CurrencySeeder
    {
        private readonly BokifaDbContext _context;

        public CurrencySeeder(BokifaDbContext context)
        {
            _context = context;
        }
        public async Task SeedCurrenciesAsync()
        {
            if (!_context.Currencies.Any())
            {
                var currencies = new List<Currency>
            {
                new() { Id = Guid.NewGuid(), Code = "USD", Symbol = "$", RateToBase = 1 },
                new() { Id = Guid.NewGuid(), Code = "EUR", Symbol = "€", RateToBase = 0.92m },
                new() { Id = Guid.NewGuid(), Code = "AZN", Symbol = "₼", RateToBase = 1.7m }
            };
                await _context.Currencies.AddRangeAsync(currencies);
                await _context.SaveChangesAsync();
            }
        }
    }
}
