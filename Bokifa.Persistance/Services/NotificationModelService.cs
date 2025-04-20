
using Bokifa.Domain.DTOs.NotificationModel;
using Bookifa.Application.IServices;

namespace Bokifa.Persistance.Services
{
    public class NotificationModelService : INotficationModelService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly INotificationModelRepo _command;
        private readonly IQueryRepository<NotificationModel> _query;
        private readonly IEmailService _emailService;

        public NotificationModelService(INotificationModelRepo command, IMapper mapper, IUnitOfWork work, IQueryRepository<NotificationModel> query, IEmailService emailService)
        {
            _command = command;
            _mapper = mapper;
            _work = work;
            _query = query;
            _emailService = emailService;
        }

        public async Task CreateAsync(CreateNotificationModelDto dto)
        {
            var notification = _mapper.Map<NotificationModel>(dto);
            var newNotification = await _command.CreateAsync(notification);
            if (newNotification == null)
            {
                throw new Exception("Failed to create notification");
            }
            await _work.SaveChangeAsync();
        }

        public async Task<ICollection<NotificationModelDto>> GetAllAsync()
        {
            var notifications = await _query.GetAllAsync().ToListAsync();
            if (notifications == null)
            {
                throw new Exception("No notifications found");
            }
            return _mapper.Map<ICollection<NotificationModelDto>>(notifications);
        }


    }
}
