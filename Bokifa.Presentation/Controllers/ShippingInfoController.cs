
using Bokifa.Domain.DTOs.ShippingInfo;

namespace Bokifa.Presentation.Controllers
{
    public class ShippingInfoController:ApiController
    {
        private readonly IShippingInfoService _shippingInfoService;
        public ShippingInfoController(IShippingInfoService shippingInfoService)
        {
            _shippingInfoService = shippingInfoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _shippingInfoService.GetAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShippingInfoDto dto)
        {
            var data = await _shippingInfoService.CreateAsync(dto);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _shippingInfoService.DeleteAsync(id);
            return NoContent();
        }
    }
}
