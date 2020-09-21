using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservicios.Kaure.Account.Models
{
    public class Account
    {
        [Key]
        public int IdAccount { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
    }
}
