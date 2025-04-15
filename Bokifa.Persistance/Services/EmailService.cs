namespace Bookifa.Persistance.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailsAsync(List<string> toEmails, string subject, string body, List<IFormFile> attachments = null)
        {
            var emailTasks = new List<Task>();

            foreach (var toEmail in toEmails)
            {
                emailTasks.Add(Task.Run(async () =>
                {
                    await SendEmailAsync(toEmail, subject, body, attachments);
                }));
            }

            await Task.WhenAll(emailTasks);
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile> attachments = null)
        {
            using (var smtpClient = new SmtpClient(_config["Email:SmtpServer"]))
            {
                smtpClient.Port = int.Parse(_config["Email:Port"]);
                smtpClient.Credentials = new NetworkCredential(_config["Email:Username"], _config["Email:Password"]);
                smtpClient.EnableSsl = true;

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_config["Email:From"]);
                    mailMessage.To.Add(toEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    if (attachments != null)
                    {
                        foreach (var file in attachments)
                        {
                            if (file.Length > 0)
                            {
                                using (var stream = new MemoryStream())
                                {
                                    await file.CopyToAsync(stream);
                                    var attachment = new Attachment(new MemoryStream(stream.ToArray()), file.FileName);
                                    mailMessage.Attachments.Add(attachment);
                                }
                            }
                        }
                    }

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
