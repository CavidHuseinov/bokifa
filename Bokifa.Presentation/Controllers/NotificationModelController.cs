
using Bokifa.Domain.DTOs.NotificationModel;

namespace Bokifa.Presentation.Controllers
{
    public class NotificationModelController:ApiController
    {
        private readonly INotficationModelService _service;

        public NotificationModelController(INotficationModelService service)
        {
            _service = service;
        }
        [HttpGet("get-all-subscribe")]
        public async Task<IActionResult> GetAllSubscribe()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
        [HttpPost("create-subscribe")]
        public async Task<IActionResult> CreateSubscribe([FromBody] CreateNotificationModelDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created successfully");
        }
    }
}
