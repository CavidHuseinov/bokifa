
namespace Bokifa.Presentation.Controllers
{
    public class CurrencyController:ApiController
    {
        private readonly ICurrencyService _service;
        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }
        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _service.GetByCodeAsync(code);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return result != null ? Ok(result) : NotFound();
        }
    }
}
