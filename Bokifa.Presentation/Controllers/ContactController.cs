using Microsoft.AspNetCore.Mvc;
using Bookifa.Application.IServices;
using Bookifa.Domain.DTOs.Contact;
using Bookifa.Presentation.Abstraction;

namespace Bookifa.Presentation.Controllers
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
            var emailLists = new List<string>
            {
                model.Email
            };
            await _emailService.SendEmailsAsync(emailLists, model.Name, model.Comment);
            return Ok("The review has been successfully submitted.");
        }
    }
}
