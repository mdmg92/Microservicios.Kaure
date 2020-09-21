using System.ComponentModel.DataAnnotations;

namespace Microservicios.Kaure.Account.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        public string FullName { get; set; }
    }
}
