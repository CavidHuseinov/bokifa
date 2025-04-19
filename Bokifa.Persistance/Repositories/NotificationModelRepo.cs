
namespace Bokifa.Persistance.Repositories
{
    public class NotificationModelRepo:CommandRepository<NotificationModel>, INotificationModelRepo
    {
        public NotificationModelRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
