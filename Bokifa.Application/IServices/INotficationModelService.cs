
using Bokifa.Domain.DTOs.NotificationModel;

namespace Bokifa.Application.IServices
{
    public interface INotficationModelService
    {
        Task<ICollection<NotificationModelDto>> GetAllAsync();
        Task CreateAsync(CreateNotificationModelDto dto);
    }
}
