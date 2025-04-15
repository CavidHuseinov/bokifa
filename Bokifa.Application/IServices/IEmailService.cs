using Microsoft.AspNetCore.Http;

namespace Bookifa.Application.IServices
{
    public interface IEmailService
    {
        Task SendEmailsAsync(List<string> toEmails, string subject, string body, List<IFormFile> attachments = null);
    }
}
