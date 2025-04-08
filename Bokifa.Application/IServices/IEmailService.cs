using Microsoft.AspNetCore.Http;

namespace Bookifa.Application.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile> attachments = null);
    }
}
