using Bokifa.Domain.DTOs.EmailQueueDto;

namespace Bookifa.Persistance.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailsAsync(EmailQueueDto dto)
        {
            var emailTasks = dto.ToEmails.Select(toEmail => Task.Run(async () =>
            {
                await SendEmailAsync(toEmail, dto.Subject, dto.Body, dto.Attachments);
            }));

            await Task.WhenAll(emailTasks);
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile>? attachments)
        {
            using var smtpClient = new SmtpClient(_config["Email:SmtpServer"])
            {
                Port = int.Parse(_config["Email:Port"]),
                Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]),
                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["Email:From"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            if (attachments != null && attachments.Any())
            {
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        memoryStream.Position = 0;

                        var attachment = new Attachment(memoryStream, file.FileName);
                        mailMessage.Attachments.Add(attachment);
                    }
                }
            }

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
