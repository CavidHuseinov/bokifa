using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookifa.Application.IServices
{
    public interface IEmailService
    {
        Task SendEmailsAsync(List<string> toEmails, string subject, string body, List<IFormFile> attachments = null);
    }
}
