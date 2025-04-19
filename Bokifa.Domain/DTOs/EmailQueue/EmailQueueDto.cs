
using Microsoft.AspNetCore.Http;

namespace Bokifa.Domain.DTOs.EmailQueueDto
{
    public class EmailQueueDto
    {
        public List<string>? ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile>? Attachments { get; set; }
    }

}
