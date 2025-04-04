using Microsoft.AspNetCore.Mvc;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Contact;
using Oxu.Presentation.Abstraction;

namespace Oxu.Presentation.Controllers
{
    public sealed class ContactController : ApiController
    {
        private readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SubmitComment([FromForm] ContactFormDto model)
        {

            if (!ModelState.IsValid) return BadRequest("Your review was not submitted.");

            string body = $"User: {model.Name} ({model.Email})\n\nComment: {model.Comment}";
            await _emailService.SendEmailAsync(model.Email, model.Name, model.Comment);
            return Ok("The review has been successfully submitted.");
        }
    }
}
