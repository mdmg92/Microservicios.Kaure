using System.ComponentModel.DataAnnotations;

namespace Microservicios.Kaure.Notification.Models
{
    public class SendMail
    {
        [Key]
        public int SendMailId { get; set; }
        public string SendDate { get; set; }
        public int AccountId { get; set; }
    }
}
