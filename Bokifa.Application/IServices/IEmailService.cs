using Bokifa.Domain.DTOs.EmailQueueDto;

namespace Bookifa.Application.IServices
{
    public interface IEmailService
    {
        Task SendEmailsAsync(EmailQueueDto dto);
    }
}
