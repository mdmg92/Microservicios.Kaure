using Microservicios.Kaure.Notification.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Kaure.Notification.Repositories.Data
{
    public class NotificationContext : DbContext, INotificationContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
        {
        }

        public DbSet<SendMail> SendMail { get; set; }
        public DbContext Instance => this;
    }
}
