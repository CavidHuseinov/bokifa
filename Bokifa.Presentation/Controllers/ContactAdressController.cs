namespace Bokifa.Presentation.Controllers
{
    public class ContactAdressController:ApiController
    {
        private readonly IContactAddressService _service;

        public ContactAdressController(IContactAddressService service)
        {
            _service = service;
        }
        [HttpGet("get-contact-adress")]
        public async Task<IActionResult> GetContactAddress()
        {
            var result = await _service.GetContactAddressAsync();
            return Ok(result);
        }
    }
}
