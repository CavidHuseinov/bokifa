//using Bokifa.Application.IServices;
//using Bokifa.Domain.DTOs.EmailQueueDto;
//using Bookifa.Application.IServices;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;

//public class EmailBackgroundService : BackgroundService
//{
//    private readonly IEmailService _emailService;
//    private readonly IEmailQueueService _queue;
//    private readonly ILogger<EmailBackgroundService> _logger;

//    public EmailBackgroundService(IEmailService emailService, IEmailQueueService queue, ILogger<EmailBackgroundService> logger)
//    {
//        _emailService = emailService;
//        _queue = queue;
//        _logger = logger;
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            var emailQueue = await _queue.DequeueAsync(stoppingToken);

//            if (emailQueue != null)
//            {
//                try
//                {
//                    foreach (var toEmail in emailQueue.ToEmails)
//                    {
//                        var emailDto = new EmailQueueDto
//                        {
//                            ToEmails = new List<string> { toEmail }, 
//                            Subject = emailQueue.Subject,
//                            Body = emailQueue.Body,
//                            Attachments = emailQueue.Attachments
//                        };

//                        await _emailService.SendEmailsAsync(emailDto);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError(ex, "Error sending email notification.");
//                }
//            }

//            await Task.Delay(5000, stoppingToken);
//        }
//    }
//}
