using Microservicios.Kaure.Notification.Models;
using Microservicios.Kaure.Notification.Repositories.Data;

namespace Microservicios.Kaure.Notification.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly INotificationContext _notificationContext;

        public MailRepository(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public bool Add(SendMail sendMail)
        {
            _notificationContext.SendMail.Add(sendMail);
            _notificationContext.SaveChanges();

            return true;
        }
    }
}
