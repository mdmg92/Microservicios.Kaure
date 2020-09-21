using Microservicios.Kaure.Notification.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Notification.Repositories.Data
{
    public interface INotificationContext
    {
        DbSet<SendMail> SendMail { get; set; }
        int SaveChanges();
    }
}
