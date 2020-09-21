using Microservicios.Kaure.Notification.Models;

namespace Microservicios.Kaure.Notification.Repositories
{
    public interface IMailRepository
    {
        bool Add(SendMail sendMail);
    }
}
