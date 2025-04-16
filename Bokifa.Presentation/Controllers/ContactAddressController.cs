using Bokifa.Domain.DTOs.ContactAdress;

namespace Bokifa.Presentation.Controllers
{
    public class ContactAddressController:ApiController
    {
        private readonly IContactAddressService _service;

        public ContactAddressController(IContactAddressService service)
        {
            _service = service;
        }
        [HttpGet("get-contact-adress")]
        public async Task<IActionResult> GetContactAddress()
        {
            var result = await _service.GetAsync();
            return Ok(result);
        }
        [HttpPost("create-contact-adress")]
        public async Task<IActionResult> CreateContactAddress([FromBody] CreateContactAddressDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }
        [HttpPut("update-contact-adress")]
        public async Task<IActionResult> UpdateContactAddress([FromBody] UpdateContactAddressDto dto)
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("delete-contact-adress")]
        public async Task<IActionResult> DeleteContactAddress([FromQuery] Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
