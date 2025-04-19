using Bokifa.Domain.DTOs.EmailQueueDto;
using Bookifa.Domain.DTOs.Contact;

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
            if (!ModelState.IsValid)
                return BadRequest("Your review was not submitted.");

            string body = $"User: {model.Name} ({model.Email})\n\nComment: {model.Comment}";

            var emailDto = new EmailQueueDto
            {
                ToEmails = new List<string> { model.Email }, 
                Subject = "New Comment Submitted",
                Body = body, 
                Attachments = null 
            };

            await _emailService.SendEmailsAsync(emailDto);

            return Ok("The review has been successfully submitted.");
        }

    }
}
