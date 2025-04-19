
using Bokifa.Domain.DTOs.EmailQueueDto;
//using System.Threading.Channels;

//namespace Bokifa.Persistance.Services
//{
//    public class EmailQueueService : IEmailQueueService
//    {
//        private readonly Channel<EmailQueueDto> _queue;
//        public EmailQueueService(Channel<EmailQueueDto> queue)
//        {
//            _queue = queue;
//        }

//        public async ValueTask<EmailQueueDto> DequeueAsync(CancellationToken cancellationToken)
//        {
//            return await _queue.Reader.ReadAsync(cancellationToken);
//        }

//        public async ValueTask QueueEmailAsync(EmailQueueDto email)
//        {
//            if (email == null) throw new ArgumentNullException(nameof(email));
//            await _queue.Writer.WriteAsync(email);
//        }
//    }
//}
